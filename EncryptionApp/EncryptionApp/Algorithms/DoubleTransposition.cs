using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EncryptionApp.Algorithms
{
    public class DoubleTransposition
    {
        private static DoubleTransposition instance;

        private DoubleTransposition() { }

        public static DoubleTransposition GetInstance()
        {
            if (instance != null)
                return instance;
            else
            {
                instance = new DoubleTransposition();
                return instance;
            }
        }

        // Transformiši ključ tako što ćemo ih sortirati prema ASCII vrednosti
        private static int[] TransformKey(string key)
        {
            return key.Select((ch, ind) => new { Char = ch, Index = ind })
              .OrderBy(x => x.Char)  // Sortiraj prema ASCII vrednosti karaktera
              .ThenBy(x => x.Index)  // Ako su isti karakteri, koristi njihov originalni indeks
              .Select((x, newIndex) => new { x.Index, NewIndex = newIndex })
              .OrderBy(x => x.Index)
              .Select(x => x.NewIndex)
              .ToArray();
        }
        private static int[] InvertKey(int[] key)
        {
            int[] invertedKey = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                invertedKey[key[i]] = i;
            }
            return invertedKey;
        }
        public static byte[] CleanText(byte[] data)
        {
            string text = Encoding.UTF8.GetString(data);  
            text = Regex.Replace(text, @"[^a-zA-Z0-9]", "").ToLower();
            return Encoding.UTF8.GetBytes(text);
        }
        private static byte[,] GenerateMatrix(byte[] message, int rows, int cols)
        {
            byte[,] matrix = new byte[rows, cols];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (index < message.Length)
                    {
                        matrix[i, j] = message[index];
                        index++;
                    }
                    else
                    {
                        matrix[i, j] = (byte)' ';
                    }
                }
            }
            return matrix;
        }
        private static void SwapRows(byte[,] matrix, int rows, int cols, int[] rKey)
        {
            byte[,] newMatrix = new byte[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int newRowIndex = rKey[i];
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = matrix[newRowIndex, j];
                }
            }

            Array.Copy(newMatrix, matrix, rows * cols);
        }
        private static void SwapColumns(byte[,] matrix, int rows, int cols, int[] cKey)
        {
            byte[,] newMatrix = new byte[rows, cols];
            for (int j = 0; j < cols; j++)
            {
                int newColIndex = cKey[j];
                for (int i = 0; i < rows; i++)
                {
                    newMatrix[i, j] = matrix[i, newColIndex];
                }
            }

            Array.Copy(newMatrix, matrix, rows * cols);
        }
        public static byte[] Encrypt(string rowsKey, string columnsKey, byte[] data)
        {
            
            int[] cKey = TransformKey(columnsKey);
            int[] rKey = TransformKey(rowsKey);

            byte[,] matrix = GenerateMatrix(data, rowsKey.Length, columnsKey.Length);
            SwapRows(matrix, rowsKey.Length, columnsKey.Length, rKey);
            SwapColumns(matrix, rowsKey.Length, columnsKey.Length, cKey);

            List<byte> encryptedMessage = new List<byte>();
            for (int i = 0; i < rowsKey.Length; i++)
            {
                for (int j = 0; j < columnsKey.Length; j++)
                {
                   encryptedMessage.Add(matrix[i, j]);
                }
            }
            return encryptedMessage.ToArray();
        }
        public static byte[] Decrypt(string rowsKey, string columnsKey, byte[] data)
        {
            int[] rKey = TransformKey(rowsKey);
            int[] cKey = TransformKey(columnsKey);

            int[] invertedRKey = InvertKey(rKey);
            int[] invertedCKey = InvertKey(cKey);

            byte[,] matrix = GenerateMatrix(data, rowsKey.Length, columnsKey.Length);
            SwapColumns(matrix, rowsKey.Length, columnsKey.Length, invertedCKey);
            SwapRows(matrix, rowsKey.Length, columnsKey.Length, invertedRKey);

            List<byte> decryptedMessage = new List<byte>();
            for (int i = 0; i < rowsKey.Length; i++) 
            {
                for (int j = 0; j < columnsKey.Length; j++)
                {
                    decryptedMessage.Add(matrix[i, j]);
                }
            }
            return decryptedMessage.ToArray();
        }
    }
}
