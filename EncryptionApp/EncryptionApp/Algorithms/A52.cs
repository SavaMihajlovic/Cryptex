//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using System.Runtime.Remoting.Messaging;
//using word = System.UInt32;


//namespace EncryptionApp.Algorithms
//{
//    public class A52
//    {
//        private static A52 instance;

//        private static word R1, R2, R3, R4;

//        // Maske Shift registara R1-R4

//        private static readonly word R1MASK = 0x07FFFF; // 19 bita, 0-18
//        private static readonly word R2MASK = 0x3FFFFF; // 22 bita, 0-21
//        private static readonly word R3MASK = 0x7FFFFF; // 23 bita, 0-22
//        private static readonly word R4MASK = 0x01FFFF; // 17 bita, 0-16

//        // Kontrolni bitovi R4 registara

//        private static readonly word R4TAP1 = 0x000400; // 10 bit
//        private static readonly word R4TAP2 = 0x000008; // 3 bit
//        private static readonly word R4TAP3 = 0x000080; // 7 bit

//        // Bitovi za clock-ovanje Shift registara R1-R4

//        private static readonly word R1TAPS = 0x072000; // bitovi 18,17,16,13 
//        private static readonly word R2TAPS = 0x300000; // bitovi 21,20
//        private static readonly word R3TAPS = 0x700080; // bitovi 22,21,20,7 
//        private static readonly word R4TAPS = 0x010800; // bits 16,11 


//        private A52() { }

//        public static A52 GetInstance()
//        {
//            if (instance != null)
//                return instance;
//            else
//            {
//                instance = new A52();
//                return instance;
//            }
//        }

//        // F-ja Parity vraca 0 - broj jedinica u reg. paran, odnosno 1 - broj jedinica u reg. neparan

//        private static word Parity(word x)
//        {
//            x ^= x >> 16;
//            x ^= x >> 8;
//            x ^= x >> 4;
//            x ^= x >> 2;
//            x ^= x >> 1;
//            return x & 1;
//        }

//        private static word ClockOne(word register, word mask, word taps, word loadedBit)
//        {
//            word t = register & mask; // izdvajamo samo onoliko bitova koliko ima registar (19/22/23/19)
//            register = (register << 1) & mask; // clock -> pomeranje svih bitova za 1 poziciju ulevo (& mask osigurava da zadrzimo samo relevantne bitove)
//            register |= Parity(t); // dodaje bit registru na praznoj poziciji nakon pomaka
//            register |= loadedBit; // dodaje vrednost učitanog bita (spoljnog ulaza) u registar
//            return register;
//        }

//        // vecinsko glasanje - 1 ako su bar 2 parametra jednaka 1, u suprotnom 0

//        private static word Majority(word reg1, word reg2, word reg3)
//        {
//            int sum = (reg1 != 0 ? 1 : 0) + (reg2 != 0 ? 1 : 0) + (reg3 != 0 ? 1 : 0);
//            return sum >= 2;
//        }

//        // allP = 1 - clock sva tri registra R1,R2,R3 ignorisuci srednje bitove
//        // loaded == 1, znači da se taj bit odnosi na poslednji bit broja okvira (frame number)
//        // i u kontekstu A5/2 šifrovanja, taj bit mora biti postavljen u svakom od četiri registra (R1, R2, R3, R4).

//        private static void Clock(int allP, int loaded)
//        {
//            word maj = Majority(R4 & R4TAP1, R4 & R4TAP2, R4 & R4TAP3);
//            if (allP || (((R4 & R4TAP1) != 0) == maj))
//                R1 = ClockOne(R1, R1MASK, R1TAPS, (word)loaded << 15);
//            if (allP || (((R4 & R4TAP2) != 0) == maj))
//                R2 = ClockOne(R2, R2MASK, R2TAPS, (word)loaded << 16);
//            if (allP || (((R4 & R4TAP3) != 0) == maj))
//                R3 = ClockOne(R3, R3MASK, R3TAPS, (word)loaded << 18);
//            R4 = ClockOne(R4, R4MASK, R4TAPS, (word)loaded << 10);
//        }

//        private static word GetBit()
//        {
//            // izvlacimo poslednje bitove iz R1,R2 i R3, XOR-ujemo ih uzimamo samo poslednji bit sa &0x01
//            word topBits = (((R1 >> 18) ^ (R2 >> 21) ^ (R3 >> 22)) & 0x01);
//            static word delaybit = 0;
//            word nowBit = delayBit;

//            // XOR-ujemo sada topBits i Majority znacajnih bitova
//            delayBit = (
//                topBits
//                ^ Majority(R1 & 0x8000, (~R1) & 0x4000, R1 & 0x1000)
//                ^ Majority((~R2) & 0x10000, R2 & 0x2000, R2 & 0x200)
//                ^ Majority(R3 & 0x40000, R3 & 0x10000, (~R3) & 0x2000)
//                );
//            return nowBit;
//        }

//        public static void KeySetup(byte[] key, uint frame)
//        {
//            int i;
//            uint keybit, framebit;

//            // 1. Isprazniti sve registre
//            R1 = R2 = R3 = R4 = 0;

//            // 2. Ucitati Key u Shift registre
//            for (i = 0; i < 64; i++)
//            {
//                Clock(1, 0);
//                keybit = (byte)((key[i / 8] >> (i & 7)) & 1);
//                R1 ^= keybit;
//                R2 ^= keybit;
//                R3 ^= keybit;
//                R4 ^= keybit;
//            }

//            // 3. Ucitaj broj okvira (frame)
//            for (i = 0; i < 22; i++)
//            {
//                Clock(1, i == 21 ? 1 : 0);
//                framebit = (frame >> i) & 1;
//                R1 ^= framebit;
//                R2 ^= framebit;
//                R3 ^= framebit;
//                R4 ^= framebit;
//            }

//            // Run for 100 cycles to mix key and frame number
//            for (i = 0; i < 100; i++)
//            {
//                Clock(0, 0);
//            }

//            GetBit();
//        }

//        public string Encrypt(string key, string frame, string data)
//        {
//            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
//            uint frameNum = Convert.ToUInt32(frame, 16);
//            byte[] dataBytes = Encoding.ASCII.GetBytes(data);

//            // Postavljamo ključ i okvir
//            KeySetup(keyBytes, frameNum);

//            // Generišemo keystream i šifrujemo
//            for (int i = 0; i < dataBytes.Length; i++)
//            {
//                byte keystreamBit = (byte)GetBit();  // Dobijamo jedan bit iz keystream-a
//                dataBytes[i] ^= keystreamBit;  // XOR sa podacima
//            }

//            return BitConverter.ToString(dataBytes).Replace("-", "");
//        }

//        // Dešifrovanje je isto jer je XOR simetričan
//        public string Decrypt(string key, string frame, string data)
//        {
//            return Encrypt(key, frame, data);  // XOR je simetričan
//        }
//    }
//}
