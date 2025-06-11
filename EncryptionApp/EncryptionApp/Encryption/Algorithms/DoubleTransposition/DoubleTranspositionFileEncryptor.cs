using EncryptionApp.Algorithms;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class DoubleTranspositionFileEncryptor
{
    public static void EncryptFile(string inputFile, string outputFile, string columnsKey, string rowsKey)
    {
        byte[] fileBytes = File.ReadAllBytes(inputFile);
        byte[] processedBytes = IsTextFile(Path.GetExtension(inputFile)) ? DoubleTransposition.CleanText(fileBytes) : fileBytes;

        byte[] encryptedBytes = DoubleTransposition.Encrypt(rowsKey, columnsKey, processedBytes);

        using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            writer.Write(encryptedBytes);
        }
    }

    public static void DecryptFile(string inputFile, string outputFile, string columnsKey, string rowsKey)
    {

        using (FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            byte[] fileBytes = reader.ReadBytes((int)fs.Length);
            byte[] decryptedBytes = DoubleTransposition.Decrypt(rowsKey, columnsKey, fileBytes);

            if (IsTextFile(Path.GetExtension(inputFile)))
            {
                string trimmedMessage = Encoding.UTF8.GetString(decryptedBytes).TrimEnd();
                decryptedBytes = Encoding.UTF8.GetBytes(trimmedMessage);
            }

            File.WriteAllBytes(outputFile, decryptedBytes);
        }
    }
    private static bool IsTextFile(string extension)
    {
        return extension == ".txt" || extension == ".csv" || extension == ".html" || extension == ".xml";
    }
}
