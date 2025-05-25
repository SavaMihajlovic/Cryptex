using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using word = System.UInt32;

namespace EncryptionApp.Algorithms
{
    public class A52FileEncryptor
    {
        public static void EncryptFile(string inputFile, string outputFile, string privateKeyHex, string publicKeyHex)
        {
            try
            {
                if (!TryParseKeys(privateKeyHex, publicKeyHex, out byte[] privateKey, out word publicKey))
                    return;

                byte[] inputData = File.ReadAllBytes(inputFile);
                byte[] encryptedBytes = A52.Encrypt(privateKey, publicKey, inputData);

                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(encryptedBytes);
                }
                MessageBox.Show($"File encrypted successfully: {outputFile}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid hex format in private or public key.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Encryption failed: {ex.Message}");
            }
        }

        public static void DecryptFile(string inputFile, string outputFile, string privateKeyHex, string publicKeyHex)
        {
            try
            {
                if (!TryParseKeys(privateKeyHex, publicKeyHex, out byte[] privateKey, out word publicKey))
                    return;

                using (FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    byte[] fileBytes = reader.ReadBytes((int)fs.Length);
                    byte[] decryptedBytes = A52.Decrypt(privateKey, publicKey, fileBytes);


                    File.WriteAllBytes(outputFile, decryptedBytes);
                }
                MessageBox.Show($"File decrypted successfully: {outputFile}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid hex format in private or public key.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Decryption failed: {ex.Message}");
            }
        }

        private static bool TryParseKeys(string privateKeyHex, string publicKeyHex, out byte[] privateKey, out word publicKey)
        {
            privateKey = null;
            publicKey = 0;

            if (privateKeyHex.Length != 16)
            {
                MessageBox.Show("Private key must be exactly 16 hex characters (8 bytes).");
                return false;
            }

            if (publicKeyHex.Length != 6)
            {
                MessageBox.Show("Public key must be exactly 6 hex characters (3 bytes / 22 bits).");
                return false;
            }

            try
            {
                privateKey = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    privateKey[i] = Convert.ToByte(privateKeyHex.Substring(i * 2, 2), 16);
                }

                publicKey = Convert.ToUInt32(publicKeyHex, 16);
                if (publicKey > 0x3FFFFF) // 22-bit max value
                {
                    MessageBox.Show("Public key (frame) must be a 22-bit number (0 to 4,194,303).");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Invalid hex format in private or public key.");
                return false;
            }

            return true;
        }
    }
}
