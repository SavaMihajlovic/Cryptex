using EncryptionApp.Utils;
using System;
using System.Buffers.Text;
using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionApp.FileTransfer
{
    public class FileSender
    {
        public Func<string, Task> StatusUpdateAsync;

        public async Task SendFileAsync(string ipAddress, int port, string hash, string algorithm, string key1, string key2, string filePath)
        {
            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    await clientSocket.ConnectAsync(ipAddress, port);
                    await StatusUpdateAsync?.Invoke("Povezan sa serverom");

                    using (NetworkStream networkStream = new NetworkStream(clientSocket))
                    {
                        // 1. enkriptujemo privatne simetricne kljuceve

                        string encryptedKey1Base64 = "", encryptedKey1AESKeyBase64 = "", encryptedKey1AESIVBase64 = "";
                        string encryptedKey2Base64 = "", encryptedKey2AESKeyBase64 = "", encryptedKey2AESIVBase64 = "";

                        if (algorithm == "DoubleTransposition")
                        {
                            byte[] key1Bytes = AesEncryptionUtils.DecimalStringToBytes(key1);
                            byte[] key2Bytes = AesEncryptionUtils.DecimalStringToBytes(key2);

                            // Za key1
                            var encryptedKey1Result = AesEncryptionUtils.EncryptBytes_Aes(key1Bytes);
                            encryptedKey1Base64 = AesEncryptionUtils.BytesToBase64(encryptedKey1Result.EncryptedData);
                            encryptedKey1AESKeyBase64 = AesEncryptionUtils.BytesToBase64(encryptedKey1Result.Key);
                            encryptedKey1AESIVBase64 = AesEncryptionUtils.BytesToBase64(encryptedKey1Result.IV);  

                            // Za key2
                            var encryptedKey2Result = AesEncryptionUtils.EncryptBytes_Aes(key2Bytes);
                            encryptedKey2Base64 = AesEncryptionUtils.BytesToBase64(encryptedKey2Result.EncryptedData);
                            encryptedKey2AESKeyBase64 = AesEncryptionUtils.BytesToBase64(encryptedKey2Result.Key);
                            encryptedKey2AESIVBase64 = AesEncryptionUtils.BytesToBase64(encryptedKey2Result.IV);

                        }
                        else 
                        {
                            byte[] key1Bytes = AesEncryptionUtils.HexStringToBytes(key1);
                            byte[] key2Bytes = AesEncryptionUtils.HexStringToBytes(key2);

                            var encryptedKey1Result = AesEncryptionUtils.EncryptBytes_Aes(key1Bytes);
                            encryptedKey1Base64 = AesEncryptionUtils.BytesToBase64(encryptedKey1Result.EncryptedData);
                            encryptedKey1AESKeyBase64 = AesEncryptionUtils.BytesToBase64(encryptedKey1Result.Key);
                            encryptedKey1AESIVBase64 = AesEncryptionUtils.BytesToBase64(encryptedKey1Result.IV);

                            encryptedKey2Base64 = AesEncryptionUtils.BytesToBase64(key2Bytes);
                        }

                        // 2. pravimo objekat metadata i serijalizujemo ga u JSON string

                        var metadata = new FileMetadata
                        {
                            FileName = Path.GetFileName(filePath),
                            FileSize = new FileInfo(filePath).Length,
                            Hash = hash,
                            EncryptionAlgorithm = algorithm,

                            // Za DoubleTransposition
                            Key1 = encryptedKey1Base64,
                            PKey1 = encryptedKey1AESKeyBase64,
                            IV1 = encryptedKey1AESIVBase64,
                            Key2 = encryptedKey2Base64,
                            PKey2 = (algorithm == "DoubleTransposition") ? encryptedKey2AESKeyBase64 : null,
                            IV2 = (algorithm == "DoubleTransposition") ? encryptedKey2AESIVBase64 : null
                        };

                        string json = JsonSerializer.Serialize(metadata);
                        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                        byte[] jsonLength = BitConverter.GetBytes(jsonBytes.Length);

                        // 3. saljemo duzinu JSON-a i sam JSON
                        await networkStream.WriteAsync(jsonLength, 0, jsonLength.Length);
                        await networkStream.WriteAsync(jsonBytes, 0, jsonBytes.Length);

                        await StatusUpdateAsync?.Invoke("Slanje fajla u toku...");

                        // 4. saljemo enkriptovani fajl u blokovima
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;

                            while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await networkStream.WriteAsync(buffer, 0, bytesRead);
                            }
                        }

                        await StatusUpdateAsync?.Invoke("Fajl je uspešno poslat, čekam odgovor servera...");

                        // 5. citamo odgovor sa serverske strane
                        string response = await ReadStringAsync(networkStream);
                        await StatusUpdateAsync?.Invoke($"Server response: {response}");
                    }
                }
            }
            catch (Exception ex)
            {
                await StatusUpdateAsync?.Invoke($"Error: {ex.Message}");
            }
        }

        private async Task<string> ReadStringAsync(NetworkStream stream)
        {
            byte[] lengthBytes = new byte[4];
            await ReadExactAsync(stream, lengthBytes, 4);
            int length = BitConverter.ToInt32(lengthBytes, 0);

            byte[] stringBytes = new byte[length];
            await ReadExactAsync(stream, stringBytes, length);
            return Encoding.UTF8.GetString(stringBytes);
        }

        private async Task ReadExactAsync(NetworkStream stream, byte[] buffer, int length)
        {
            int totalRead = 0;
            while (totalRead < length)
            {
                int read = await stream.ReadAsync(buffer, totalRead, length - totalRead);
                if (read == 0)
                    throw new IOException("Connection closed unexpectedly.");
                totalRead += read;
            }
        }
    }
}
