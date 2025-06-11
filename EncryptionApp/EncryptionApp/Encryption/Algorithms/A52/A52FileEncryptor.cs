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
                if (!TryParseKeys(privateKeyHex, publicKeyHex, out byte[] privateKey, out word publicKey))
                {
                    throw new ArgumentException("Invalid keys provided.");
                }

                byte[] inputData = File.ReadAllBytes(inputFile);
                byte[] encryptedBytes = A52.EncryptCFB(privateKey, publicKey, inputData);

                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(encryptedBytes);
                }
        }

        public static void DecryptFile(string inputFile, string outputFile, string privateKeyHex, string publicKeyHex)
        {
                if (!TryParseKeys(privateKeyHex, publicKeyHex, out byte[] privateKey, out word publicKey))
                {
                    throw new ArgumentException("Invalid keys provided.");
                }

                using (FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    byte[] fileBytes = reader.ReadBytes((int)fs.Length);
                    byte[] decryptedBytes = A52.DecryptCFB(privateKey, publicKey, fileBytes);

                    File.WriteAllBytes(outputFile, decryptedBytes);
                }
        }

        private static bool TryParseKeys(string privateKeyHex, string publicKeyHex, out byte[] privateKey, out word publicKey)
        {
            privateKey = null;
            publicKey = 0;

            if (privateKeyHex.Length != 16)
            {
                return false;
            }

            if (publicKeyHex.Length != 6)
            {
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
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
