using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using word = System.UInt32;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;


namespace EncryptionApp.Algorithms
{
    public class A52
    {
        private static A52 instance;

        private static word R1, R2, R3, R4;

        private const int IVLength = 8;

        // Maske Shift registara R1-R4

        private static readonly word R1MASK = 0x07FFFF; // 19 bita, 0-18
        private static readonly word R2MASK = 0x3FFFFF; // 22 bita, 0-21
        private static readonly word R3MASK = 0x7FFFFF; // 23 bita, 0-22
        private static readonly word R4MASK = 0x01FFFF; // 17 bita, 0-16

        // Kontrolni bitovi R4 registara

        private static readonly word R4TAP1 = 0x000400; // 10 bit
        private static readonly word R4TAP2 = 0x000008; // 3 bit
        private static readonly word R4TAP3 = 0x000080; // 7 bit

        // Bitovi za clock-ovanje Shift registara R1-R4

        private static readonly word R1TAPS = 0x072000; // bitovi 18,17,16,13 
        private static readonly word R2TAPS = 0x300000; // bitovi 21,20
        private static readonly word R3TAPS = 0x700080; // bitovi 22,21,20,7 
        private static readonly word R4TAPS = 0x010800; // bits 16,11 


        private A52() { }

        public static A52 GetInstance()
        {
            if (instance != null)
                return instance;
            else
            {
                instance = new A52();
                return instance;
            }
        }

        // F-ja Parity vraca 0 - broj jedinica u reg. paran, odnosno 1 - broj jedinica u reg. neparan

        private static word Parity(word x)
        {
            x ^= x >> 16;
            x ^= x >> 8;
            x ^= x >> 4;
            x ^= x >> 2;
            x ^= x >> 1;
            return x & 1;
        }

        private static word ClockOne(word register, word mask, word taps, word loadedBit)
        {
            word t = register & taps; // izdvajamo samo onoliko bitova koliko ima registar (19/22/23/19)
            register = (register << 1) & mask; // clock -> pomeranje svih bitova za 1 poziciju ulevo (& mask osigurava da zadrzimo samo relevantne bitove)
            register |= Parity(t); // dodaje bit registru na praznoj poziciji nakon pomaka
            register |= loadedBit; // dodaje vrednost učitanog bita (spoljnog ulaza) u registar
            return register;
        }

        // vecinsko glasanje - 1 ako su bar 2 parametra jednaka 1, u suprotnom 0

        private static word Majority(word reg1, word reg2, word reg3)
        {
            int sum = (reg1 != 0 ? 1 : 0) + (reg2 != 0 ? 1 : 0) + (reg3 != 0 ? 1 : 0);
            return (word)(sum >= 2 ? 1 : 0);
        }

        // loaded == 1, znači da se taj bit odnosi na poslednji bit broja okvira (frame number)
        // i u kontekstu A5/2 šifrovanja, taj bit mora biti postavljen u svakom od četiri registra (R1, R2, R3, R4).

        private static word Clock(int allP, int loaded)
        {
            word maj = Majority(R4 & R4TAP1, R4 & R4TAP2, R4 & R4TAP3);
            if ((allP != 0) || (((R4 & R4TAP1) != 0 ? 1u : 0u) == maj))
                R1 = ClockOne(R1, R1MASK, R1TAPS, (word)loaded << 15);
            if ((allP != 0) || (((R4 & R4TAP2) != 0 ? 1u : 0u) == maj))
                R2 = ClockOne(R2, R2MASK, R2TAPS, (word)loaded << 16);
            if ((allP != 0) || (((R4 & R4TAP3) != 0 ? 1u : 0u) == maj))
                R3 = ClockOne(R3, R3MASK, R3TAPS, (word)loaded << 18);
            R4 = ClockOne(R4, R4MASK, R4TAPS, (word)loaded << 10);
            return maj;
        }

        private static word delayBit = 0;
        private static word GetBit()
        {
            // izvlacimo poslednje bitove iz R1,R2 i R3, XOR-ujemo ih uzimamo samo poslednji bit sa &0x01
            word topBits = (((R1 >> 18) ^ (R2 >> 21) ^ (R3 >> 22)) & 0x01);
            word nowBit = delayBit;

            // XOR-ujemo sada topBits i Majority znacajnih bitova
            delayBit = (
                topBits
                ^ Majority(R1 & 0x8000, (~R1) & 0x4000, R1 & 0x1000)
                ^ Majority((~R2) & 0x10000, R2 & 0x2000, R2 & 0x200)
                ^ Majority(R3 & 0x40000, R3 & 0x10000, (~R3) & 0x2000)
                );
            return nowBit;
        }

        public static void KeySetup(byte[] key, uint frame)
        {
            int i;
            uint keybit, framebit;

            // 1. Isprazniti sve registre
            R1 = R2 = R3 = R4 = 0;

            // 2. Ucitati Key u Shift registre
            for (i = 0; i < 64; i++)
            {
                Clock(1, 0);
                keybit = (byte)((key[i / 8] >> (i & 7)) & 1);
                R1 ^= keybit;
                R2 ^= keybit;
                R3 ^= keybit;
                R4 ^= keybit;
            }

            // 3. Ucitaj broj okvira (frame)
            for (i = 0; i < 22; i++)
            {
                Clock(1, i == 21 ? 1 : 0);
                framebit = (frame >> i) & 1;
                R1 ^= framebit;
                R2 ^= framebit;
                R3 ^= framebit;
                R4 ^= framebit;
            }

            // Run for 100 cycles to mix key and frame number
            for (i = 0; i < 100; i++)
            {
                Clock(0, 0);
            }

            GetBit();
        }

        public static byte[] Encrypt(byte[] privateKey, word publicKey, byte[] data)
        {
            KeySetup(privateKey, publicKey);

            byte[] output = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                byte keystreamByte = 0;
                // A52 je bitna enkripcija, treba generisati 8 bita po bajtu
                for (int bit = 0; bit < 8; bit++)
                {
                    keystreamByte |= (byte)(GetBit() << bit);
                }
                output[i] = (byte)(data[i] ^ keystreamByte);
            }
            return output;
        }
        private static void ShiftRegisterLeftByOneByte(byte[] register, byte newByte)
        {
            Buffer.BlockCopy(register, 1, register, 0, register.Length - 1);
            register[register.Length - 1] = newByte;
        }

        public static byte[] EncryptCFB(byte[] privateKey, word publicKey, byte[] plaintext)
        {
            // 1. Generiši random IV
            byte[] iv = new byte[IVLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv);
            }

            // 2. Inicijalizuj shiftRegister sa IV
            byte[] shiftRegister = new byte[IVLength];
            Buffer.BlockCopy(iv, 0, shiftRegister, 0, IVLength);

            byte[] ciphertext = new byte[IVLength + plaintext.Length];

            // IV na početak ciphertexta
            Buffer.BlockCopy(iv, 0, ciphertext, 0, IVLength);

            // Sve do N - duzina plaintexta
            for (int i = 0; i < plaintext.Length; i++)
            {
                // Dobij keystream bajt od shiftRegistera (koristeći A52)
                byte[] encrypted = Encrypt(privateKey, publicKey, shiftRegister);
                byte keystreamByte = encrypted[0]; // samo prvi bajt iz outputa

                byte cipherByte = (byte)(plaintext[i] ^ keystreamByte);
                ciphertext[IVLength + i] = cipherByte;

                // Pomeri shiftRegister ulevo za 1 bajt i dodaj cipherByte na kraj
                ShiftRegisterLeftByOneByte(shiftRegister, cipherByte);
            }

            return ciphertext;
        }

        public static byte[] DecryptCFB(byte[] privateKey, word publicKey, byte[] ciphertext)
        {
            if (ciphertext.Length < IVLength)
                throw new ArgumentException("Ciphertext too short to contain IV");

            // 1. Izvuci IV iz ciphertexta
            byte[] iv = new byte[IVLength];
            Buffer.BlockCopy(ciphertext, 0, iv, 0, IVLength);

            byte[] shiftRegister = new byte[IVLength];
            Buffer.BlockCopy(iv, 0, shiftRegister, 0, IVLength);

            int plaintextLength = ciphertext.Length - IVLength;
            byte[] plaintext = new byte[plaintextLength];

            for (int i = 0; i < plaintextLength; i++)
            {
                // Dobij keystream bajt iz shiftRegistera
                byte[] encrypted = Encrypt(privateKey, publicKey, shiftRegister);
                byte keystreamByte = encrypted[0];

                byte cipherByte = ciphertext[IVLength + i];
                byte plainByte = (byte)(cipherByte ^ keystreamByte);
                plaintext[i] = plainByte;

                // Pomeri shiftRegister ulevo i dodaj ciphertext bajt na kraj
                ShiftRegisterLeftByOneByte(shiftRegister, cipherByte);
            }

            return plaintext;
        }
    }
}
