using EncryptionApp.Utils;
using System;
using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
                        // 1. pravimo objekat metadata i serijalizujemo ga u JSON string

                        var metadata = new
                        {
                            FileName = Path.GetFileName(filePath),
                            FileSize = new FileInfo(filePath).Length,
                            Hash = hash,
                            EncryptionAlgorithm = algorithm,
                            Key1 = key1,
                            Key2 = key2
                        };

                        string json = JsonSerializer.Serialize(metadata);
                        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                        byte[] jsonLength = BitConverter.GetBytes(jsonBytes.Length);

                        // 2. saljemo duzinu JSON-a i sam JSON
                        await networkStream.WriteAsync(jsonLength, 0, jsonLength.Length);
                        await networkStream.WriteAsync(jsonBytes, 0, jsonBytes.Length);

                        // 3. saljemo enkriptovani fajl u blokovima
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;

                            while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await networkStream.WriteAsync(buffer, 0, bytesRead);
                            }
                        }

                        // 4. citamo odgovor sa serverske strane
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
