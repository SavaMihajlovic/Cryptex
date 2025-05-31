using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionApp.Utils
{
    public class FileManager
    {
        private FileSystemWatcher watcher;
        public void InitFSW(bool isFSWChecked)
        {
            watcher = new FileSystemWatcher(@"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\Target")
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.*"
            };
            watcher.Created += FileSystemWatcher_Created;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = isFSWChecked;
        }
        public void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"Novi fajl je dodat: {e.Name}");
        }
        public string BrowseFile(bool isDecryption, bool isFSWChecked)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (isDecryption)
                {
                    openFileDialog.InitialDirectory = @"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\X";
                }
                else
                {
                    openFileDialog.InitialDirectory = @"C:\\";
                }

                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (isDecryption)
                    {
                        return filePath;
                    }
                    else
                    {
                        if (isFSWChecked)
                        {
                            string targetDirectory = @"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\Target";

                            if (!Directory.Exists(targetDirectory))
                            {
                                Directory.CreateDirectory(targetDirectory);
                            }

                            string targetFilePath = Path.Combine(targetDirectory, Path.GetFileName(filePath));

                            try
                            {
                                File.Copy(filePath, targetFilePath, true);
                                return targetFilePath;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Došlo je do greške pri kopiranju fajla: {ex.Message}");
                                return filePath;
                            }
                        }
                        else
                        {

                            return filePath;
                        }
                    }
                }
            }
            return null;
        }
    }
}
