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
        public Form2()
        {
            InitializeComponent();
            this.Text = "Cryptex - Algorithms";

            btnCrypt.Click += btnCrypt_Click;
            btnDecrypt.Click += btnDecrypt_Click;
            this.Load += new EventHandler(Form2_Load);
            rbDT.CheckedChanged += AlgorithmChanged;
            rbA52.CheckedChanged += AlgorithmChanged;

            //Input_File_txt.Text = "Input_Plain.txt";
            tbInputFile.Text = "C:\\Users\\msava\\OneDrive\\Desktop\\input.txt";
            //Output_File_txt.Text = "Output_Encrypted.txt";
            tbOutputFile.Text = "C:\\Users\\msava\\OneDrive\\Desktop\\output.txt";
        }

        private void AlgorithmChanged(object sender, EventArgs e)
        {
            if (rbDT.Checked)
            {
                rbA52.Checked = false;

                lbl1.Visible = true;
                tb1.Visible = true;
                lbl2.Visible = true;
                tb2.Visible = true;
                lbl4.Visible = true;
                tbOutputFile.Visible = true;

                lbl1.Text = "ColumnsKey:";
                lbl2.Text = "RowsKey:";
            }
            else if (rbA52.Checked)
            {
                rbDT.Checked = false;

                lbl4.Visible = false;
                tbOutputFile.Visible = false;

                lbl1.Text = "Key:";
                lbl2.Text = "Data: ";
            }
        }
        private void btnCrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if ((rbDT.Checked || rbA52.Checked)
                    && tb1.Text != null
                    && tb2.Text != null)
                {
                    string key1 = tb1.Text;
                    string key2 = tb2.Text;
                    string inputFile = tbInputFile.Text;
                    string outputFile = tbOutputFile.Text;
                    DoubleTranspositionFileEncryptor.EncryptFile(inputFile, outputFile, key1, key2);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Niste uneli oba kljuca " + ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (rbDT.Checked)
            {
                string key1 = tb1.Text;
                string key2 = tb2.Text;
                string inputFile = tbInputFile.Text;
                string outputFile = tbOutputFile.Text;
                DoubleTranspositionFileEncryptor.DecryptFile(inputFile, outputFile, key1, key2);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filePath = openFileDialog.FileName;

                    string targetDirectory = @"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\Target"; 

                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    string targetFilePath = Path.Combine(targetDirectory, Path.GetFileName(filePath));

                    try
                    {
                        File.Copy(filePath, targetFilePath);
                        MessageBox.Show($"Fajl je uspešno učitan u:\n {targetFilePath}");
                        tbInputFile.Text = targetFilePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Došlo je do greške pri kopiranju fajla: {ex.Message}");
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rbDT.Checked = true;
            AlgorithmChanged(null, null);
            InitFSW();
        }

        private void InitFSW()
        {
            using (var watcher = new FileSystemWatcher(@"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\Target"))
            {
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Filter = "*.*";
                watcher.Created += FileSystemWatcher_Created;
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;

                Application.DoEvents();
            }
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"Novi fajl je dodat: {e.Name}");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AutoGenKeys(string filePath)
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

        private void btnAutoGenDT_Click(object sender, EventArgs e)
        {
            AutoGenKeys(tbInputFile.Text);
        }
    }
}
