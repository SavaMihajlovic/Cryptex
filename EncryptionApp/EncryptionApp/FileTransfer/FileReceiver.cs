using EncryptionApp.Encryption.Services;
using EncryptionApp.Utils;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionApp.FileTransfer
{
    public class FileReceiver
    {
        private Socket serverSocket;
        public Func<string, Task> StatusUpdateAsync;
        private bool isRunning = false;

        public async Task StartAsync(int port)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                serverSocket.Listen(5);
                isRunning = true;

                await StatusUpdateAsync?.Invoke("Server je spreman i osluškuje konekcije");

                while (isRunning)
                {
                    try
                    {
                        Socket clientSocket = await serverSocket.AcceptAsync();
                        _ = Task.Run(() => HandleClientAsync(clientSocket));
                    }
                    catch (ObjectDisposedException)
                    {
                        // Socket je zatvoren — očekivano pri gašenju servera
                        await StatusUpdateAsync?.Invoke("Server je zaustavljen.");
                        break;
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.Interrupted || !isRunning)
                        {
                            await StatusUpdateAsync?.Invoke("Server je zaustavljen.");
                        }
                        else
                        {
                            await StatusUpdateAsync?.Invoke($"Socket greška: {ex.Message}");
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                await StatusUpdateAsync?.Invoke($"Fatalna greška: {ex.Message}");
            }
            finally
            {
                serverSocket?.Close();
            }
        }

        public void Stop()
        {
            isRunning = false;
            serverSocket?.Close();
        }

        private async Task HandleClientAsync(Socket clientSocket)
        {
            try
            {
                using (NetworkStream networkStream = new NetworkStream(clientSocket))
                {

                    // 1. preuzimamo JSON string i vrsimo deserijalizaciju

                    byte[] jsonLengthBytes = new byte[4];
                    await ReadExactAsync(networkStream, jsonLengthBytes, 4);
                    int jsonLength = BitConverter.ToInt32(jsonLengthBytes, 0);

                    byte[] jsonBytes = new byte[jsonLength];
                    await ReadExactAsync(networkStream, jsonBytes, jsonLength);
                    string json = Encoding.UTF8.GetString(jsonBytes);

                   
                    var metadata = JsonSerializer.Deserialize<FileMetadata>(json);

                    await StatusUpdateAsync?.Invoke($"Preuzimanje fajla: {metadata.FileName} ({metadata.FileSize} bytes)");

                    // 2. preuzimamo enkriptovani fajl

                    string savePath = Path.Combine(Directory.GetCurrentDirectory(), "received_" + metadata.FileName);
                    using (FileStream fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[4096];
                        long totalBytesReceived = 0;

                        while (totalBytesReceived < metadata.FileSize)
                        {
                            int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;

                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesReceived += bytesRead;
                        }
                    }

                    // 3. racunamo hash i uporedjujemo sa prosledjenim 
                    // da utvrdimo da li je fajl ispravno prenet

                    string calculatedHash = FileHashGenerator.GenerateMD5Hash(savePath);
                    bool isValid = string.Equals(metadata.Hash, calculatedHash, StringComparison.OrdinalIgnoreCase);

                    string response = isValid ? "Fajl je uspešno preuzet i hash se poklapa."
                                              : "Fajl je preuzet, ali hash NE ODGOVARA - moguća greška u prenosu.";

                    // 4. ukoliko je fajl ispravno prenet vrsimo dekriptovanje

                    if(isValid)
                    {
                        string decryptedPath = Path.Combine(@"C:\Users\msava\OneDrive\Desktop", "decrypted_" + metadata.FileName);

                        switch (metadata.EncryptionAlgorithm)
                        {
                            case "DoubleTransposition":
                                EncryptionService.DecryptDT(savePath, decryptedPath, metadata.Key1, metadata.Key2);
                                break;

                            case "A52":
                                EncryptionService.DecryptA52(savePath, decryptedPath, metadata.Key1, metadata.Key2);
                                break;

                            default:
                                await StatusUpdateAsync?.Invoke("Nepoznat algoritam dekriptovanja: " + metadata.EncryptionAlgorithm);
                                break;
                        }

                        await StatusUpdateAsync?.Invoke($"Fajl dekriptovan i sačuvan na desktopu kao: {Path.GetFileName(decryptedPath)}");
                    }

                    await StatusUpdateAsync?.Invoke($"Fajl {metadata.FileName} uspešno preuzet.");

                    // 5. saljemo odgovor klijentskoj strani

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    byte[] responseLength = BitConverter.GetBytes(responseBytes.Length);
                    await networkStream.WriteAsync(responseLength, 0, responseLength.Length);
                    await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                }
            }
            catch (Exception ex)
            {
                await StatusUpdateAsync?.Invoke($"Error handling client: {ex.Message}");
            }
            finally
            {
                clientSocket.Close();
            }
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
