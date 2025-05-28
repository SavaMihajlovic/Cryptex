using EncryptionApp.Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionApp
{
    public partial class Form2 : Form
    {

        private FileSystemWatcher watcher;
        public Form2()
        {
            InitializeComponent();
            this.Text = "Cryptex - Algorithms";
            this.Size = new Size(750, 500);

            btnCrypt.Click += btnCrypt_Click;
            btnDecrypt.Click += btnDecrypt_Click;
            this.Load += new EventHandler(Form2_Load);
            rbDT.CheckedChanged += AlgorithmChanged;
            rbA52.CheckedChanged += AlgorithmChanged;
            rbEncrypt.CheckedChanged += OperationChanged;
            rbDecrypt.CheckedChanged += OperationChanged;
            cBoxFSW.CheckedChanged += cBoxFSW_CheckedChanged;
        }


        private void AlgorithmChanged(object sender, EventArgs e)
        {
            if (rbDT.Checked)
            {
                rbA52.Checked = false;
                tb1.Text = "";
                tb2.Text = "";
                lbl1.Visible = true;
                tb1.Visible = true;
                lbl2.Visible = true;
                tb2.Visible = true;
                lbl1.Text = "ColumnsKey:";
                lbl2.Text = "RowsKey:";
            }
            else if (rbA52.Checked)
            {
                rbDT.Checked = false;
                tb1.Text = "";
                tb2.Text = "";
                lbl2.Text = "Key:";
                lbl1.Text = "Frame: ";
            }
        }
        private void OperationChanged(object sender, EventArgs e)
        {
            if (rbEncrypt.Checked)
            {
                tbInputFile.Text = "";
                tbOutputFile.Text = "";
                lbl4.Visible = false;
                tbOutputFile.Visible = false;
                btnDecrypt.Enabled = false;
                btnCrypt.Enabled = true;
                btnBrowseOutputFile.Visible = false;
            }
            else if (rbDecrypt.Checked)
            {
                tbInputFile.Text = "";
                tbOutputFile.Text = "";
                lbl4.Visible = true;
                tbOutputFile.Visible = true;
                btnDecrypt.Enabled = true;
                btnCrypt.Enabled = false;
                btnBrowseOutputFile.Visible = true;
            }
        }
        private void btnCrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbDT.Checked)
                {
                    if (string.IsNullOrWhiteSpace(tb1.Text) || string.IsNullOrWhiteSpace(tb2.Text))
                    {
                        MessageBox.Show("Molimo unesite oba ključa za Double Transposition algoritam.");
                        return;
                    }

                    string key1 = tb1.Text;
                    string key2 = tb2.Text;
                    string inputFile = tbInputFile.Text;

                    string outputDirectory = @"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\X";
                    string inputFileName = Path.GetFileName(inputFile);
                    string encryptedFileName = "encrypted_" + inputFileName;
                    string outputFile = Path.Combine(outputDirectory, encryptedFileName);

                    DoubleTranspositionFileEncryptor.EncryptFile(inputFile, outputFile, key1, key2);
                }
                else if (rbA52.Checked)
                {
                    if (string.IsNullOrWhiteSpace(tb1.Text) || string.IsNullOrWhiteSpace(tb2.Text))
                    {
                        MessageBox.Show("Molimo unesite oba ključa za A52 algoritam.");
                        return;
                    }

                    string privateKey = tb1.Text;
                    string publicKey = tb2.Text;
                    string inputFile = tbInputFile.Text;

                    string outputDirectory = @"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\X";
                    string inputFileName = Path.GetFileName(inputFile);
                    string encryptedFileName = "encrypted_" + inputFileName;
                    string outputFile = Path.Combine(outputDirectory, encryptedFileName);

                    A52FileEncryptor.EncryptFile(inputFile, outputFile, privateKey, publicKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom enkripcije: " + ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbDT.Checked)
                {
                    if (string.IsNullOrWhiteSpace(tb1.Text) || string.IsNullOrWhiteSpace(tb2.Text))
                    {
                        MessageBox.Show("Molimo unesite oba ključa za Double Transposition algoritam.");
                        return;
                    }

                    string key1 = tb1.Text;
                    string key2 = tb2.Text;
                    string inputFile = tbInputFile.Text;
                    string outputFile = tbOutputFile.Text;

                    DoubleTranspositionFileEncryptor.DecryptFile(inputFile, outputFile, key1, key2);
                }
                else if (rbA52.Checked)
                {
                    if (string.IsNullOrWhiteSpace(tb1.Text) || string.IsNullOrWhiteSpace(tb2.Text))
                    {
                        MessageBox.Show("Molimo unesite oba ključa za A52 algoritam.");
                        return;
                    }

                    string privateKey = tb1.Text;
                    string publicKey = tb2.Text;
                    string inputFile = tbInputFile.Text;
                    string outputFile = tbOutputFile.Text;

                    A52FileEncryptor.DecryptFile(inputFile, outputFile, privateKey, publicKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom dekripcije: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rbDT.Checked = true;
            rbEncrypt.Checked = true;
            AlgorithmChanged(null, null);
            OperationChanged(null, null);
            InitFSW();
        }

        private void InitFSW()
        {
            watcher = new FileSystemWatcher(@"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\Target");
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Created += FileSystemWatcher_Created;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = cBoxFSW.Checked;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"Novi fajl je dodat: {e.Name}");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AutoGenDTKeys(string filePath)
        {
            try
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
                tb1.Text = key1;
                tb2.Text = key2;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške pri generisanju ključeva: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AutoGenA52Keys()
        {
            try
            {
                Random rnd = new Random();
                byte[] privateKey = new byte[8];
                rnd.NextBytes(privateKey);

                int publicKey = rnd.Next(0, 4194304);

                string formattedPrivateKey = string.Concat(privateKey.Select(b => b.ToString("X2")));
                string formattedPublicKey = publicKey.ToString("X6");

                tb1.Text = formattedPrivateKey;
                tb2.Text = formattedPublicKey;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške pri generisanju ključeva: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAutoGen_Click(object sender, EventArgs e)
        {
            if (rbDT.Checked)
            {
                AutoGenDTKeys(tbInputFile.Text);
            }
            else
            {
                AutoGenA52Keys();
            }
        }

        private void btnBrowseInputFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (rbDecrypt.Checked)
                {
                    openFileDialog.InitialDirectory = @"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\X";
                }
                else
                {
                    openFileDialog.InitialDirectory = "C:\\";
                }

                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (rbDecrypt.Checked)
                    {
                        tbInputFile.Text = filePath;
                    }
                    else
                    {
                        if (cBoxFSW.Checked)
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
                                tbInputFile.Text = targetFilePath;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Došlo je do greške pri kopiranju fajla: {ex.Message}");
                                tbInputFile.Text = filePath;
                            }
                        }
                        else
                        {

                            tbInputFile.Text = filePath;
                        }
                    }
                }
            }
        }

        private void btnBrowseOutputFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.Filter = "All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbOutputFile.Text = saveFileDialog.FileName;
                }
            }
        }

        private void cBoxFSW_CheckedChanged(object sender, EventArgs e)
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = cBoxFSW.Checked;
                string status = cBoxFSW.Checked ? "uključen" : "isključen";
                MessageBox.Show($"FileSystemWatcher je {status}.");
            }
        }
    }
}
