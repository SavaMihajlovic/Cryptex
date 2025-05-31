using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionApp.Utils
{
    public class KeyGenerator
    {
        public (string key1, string key2) AutoGenDTKeys(string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            int byteCount = fileBytes.Length;

            int keyColumns = (int)Math.Floor(Math.Sqrt(byteCount));
            int keyRows = (int)Math.Ceiling((double)byteCount / keyColumns);

            Random rand = new Random();
            string key1 = new string(Enumerable.Range(0, keyColumns)
                                               .Select(_ => (char)rand.Next(49, 57))
                                               .ToArray());
            string key2 = new string(Enumerable.Range(0, keyRows)
                                               .Select(_ => (char)rand.Next(49, 57))
                                               .ToArray());

            return (key1, key2);
        }
        public (string privateKeyHex, string publicKeyHex) AutoGenA52Keys()
        {
            Random rnd = new Random();
            byte[] privateKey = new byte[8];
            rnd.NextBytes(privateKey);

            int publicKey = rnd.Next(0, 4194304);

            string formattedPrivateKey = string.Concat(privateKey.Select(b => b.ToString("X2")));
            string formattedPublicKey = publicKey.ToString("X6");

            return (formattedPrivateKey, formattedPublicKey);
        }
    }
}
