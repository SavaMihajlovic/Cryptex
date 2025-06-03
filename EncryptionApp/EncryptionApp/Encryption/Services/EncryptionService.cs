using EncryptionApp.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionApp.Encryption.Services
{
    public class EncryptionService
    {
        public static void EncryptDT(string inputFile, string outputFile, string key1, string key2)
        {
            DoubleTranspositionFileEncryptor.EncryptFile(inputFile, outputFile, key1, key2);
        }

        public static void DecryptDT(string inputFile, string outputFile, string key1, string key2)
        {
            DoubleTranspositionFileEncryptor.DecryptFile(inputFile, outputFile, key1, key2);
        }

        public static void EncryptA52(string inputFile, string outputFile, string privateKey, string publicKey)
        {
            A52FileEncryptor.EncryptFile(inputFile, outputFile, privateKey, publicKey);
        }

        public static void DecryptA52(string inputFile, string outputFile, string privateKey, string publicKey)
        {
            A52FileEncryptor.DecryptFile(inputFile, outputFile, privateKey, publicKey);
        }
    }
}
