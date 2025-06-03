using EncryptionApp.Algorithms;
using EncryptionApp.Encryption.Services;
using EncryptionApp.FileTransfer;
using EncryptionApp.Utils;
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
        private FileManager fileManager;
        private FileSender fileSender;
        private FileReceiver fileReceiver;

        public Form2()
        { 
            InitializeComponent();
            this.Text = "Cryptex - Algorithms";
            this.Size = new Size(700, 500);

            fileManager = new FileManager();
            fileSender = new FileSender();
            fileReceiver = new FileReceiver();
            fileSender.StatusUpdateAsync = async (msg) => await UpdateStatusAsync(tssLabelSend, msg);
            fileReceiver.StatusUpdateAsync = async (msg) => await UpdateStatusAsync(tssLabelReceive, msg);

            btnCrypt.Click += btnCrypt_Click;
            btnDecrypt.Click += btnDecrypt_Click;
            this.Load += new EventHandler(Form2_Load);
            rbDT.CheckedChanged += AlgorithmChanged;
            rbA52.CheckedChanged += AlgorithmChanged;
            rbEncrypt.CheckedChanged += OperationChanged;
            rbDecrypt.CheckedChanged += OperationChanged;
            cBoxFSW.CheckedChanged += cBoxFSW_CheckedChanged;
        }

        #region Main
        private void Form2_Load(object sender, EventArgs e)
        {
            rbDT.Checked = true;
            rbEncrypt.Checked = true;
            cBoxFSW.Checked = false;
            AlgorithmChanged(null, null);
            OperationChanged(null, null);
            fileManager.InitFSW(cBoxFSW.Checked);
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
        private void HandleFSWCheckChanged(CheckBox checkBox)
        {
            fileManager.InitFSW(checkBox.Checked);
            string status = checkBox.Checked ? "uključen" : "isključen";
            MessageBox.Show($"FileSystemWatcher je {status}.");
        }
        private void cBoxFSW_CheckedChanged(object sender, EventArgs e)
        {
            HandleFSWCheckChanged(sender as CheckBox);
        }
        private void btnAutoGen_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbDT.Checked)
                {
                    if (string.IsNullOrWhiteSpace(tbInputFile.Text))
                    {
                        MessageBox.Show("Polje za unos fajla ne sme biti prazno!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var (key1, key2) = KeyGenerator.AutoGenDTKeys(tbInputFile.Text);
                    tb1.Text = key1;
                    tb2.Text = key2;
                }
                else
                {
                    var (key1, key2) = KeyGenerator.AutoGenA52Keys();
                    tb1.Text = key1;
                    tb2.Text = key2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške pri generisanju ključeva: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBrowseInputFile_Click(object sender, EventArgs e)
        {
            string filePath = fileManager.BrowseFile(rbDecrypt.Checked, cBoxFSW.Checked);
            if (!string.IsNullOrEmpty(filePath))
            {
                tbInputFile.Text = filePath;
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
                    string outputFile = fileManager.GetEncryptedOutputFilePath(inputFile);

                    EncryptionService.EncryptDT(inputFile, outputFile, key1, key2);
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
                    string outputFile = fileManager.GetEncryptedOutputFilePath(inputFile);

                    EncryptionService.EncryptA52(inputFile, outputFile, privateKey, publicKey);
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

                    EncryptionService.DecryptDT(inputFile, outputFile, key1, key2);
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

                    EncryptionService.DecryptA52(inputFile, outputFile, privateKey, publicKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom dekripcije: " + ex.Message);
            }
        }

        #endregion

        #region Sender
        private void btnBrowseSendFile_Click(object sender, EventArgs e)
        {
            string filePath = fileManager.BrowseFile(rbDecrypt.Checked, false);
            if (!string.IsNullOrEmpty(filePath))
            {
                tbFileToSend.Text = filePath;
            }
        }
        private async void btnSendFile_Click(object sender, EventArgs e)
        {
            string selectedAlgorithm = comboBox1.SelectedItem?.ToString(); // algoritam
            string inputFile = tbFileToSend.Text; // ulazni fajl
            string outputFile = fileManager.GetEncryptedOutputFilePath(inputFile); // izlazni fajl

            if (string.IsNullOrEmpty(selectedAlgorithm) || string.IsNullOrEmpty(inputFile))
            {
                MessageBox.Show("Molimo Vas odaberite algoritam i fajl za kriptovanje.");
                return;
            }

            // kriptovanje fajla
            string key1, key2;
            string encryptionAlgorithm;

            if (selectedAlgorithm == "DoubleTransposition")
            {
                encryptionAlgorithm = "DoubleTransposition";
                (key1, key2) = KeyGenerator.AutoGenDTKeys(inputFile);
                EncryptionService.EncryptDT(inputFile, outputFile, key1, key2);
            }
                
            else if (selectedAlgorithm == "A52")
            {
                encryptionAlgorithm = "A52";
                (key1, key2) = KeyGenerator.AutoGenA52Keys();
                EncryptionService.EncryptA52(inputFile, outputFile, key1, key2);
            }
            else
                throw new InvalidOperationException("Nepoznat algoritam.");

            MessageBox.Show($"Fajl je uspešno kriptovan u {outputFile}.");

            // generisanje hash-a
            string md5Hash = FileHashGenerator.GenerateMD5Hash(outputFile);

            // slanje fajla putem TCP protokola
            await fileSender.SendFileAsync(tbIPAddress.Text, int.Parse(tbPortSender.Text), md5Hash, encryptionAlgorithm, key1, key2, outputFile);
        }

        #endregion

        #region Receiver
        private void btnStartListening_Click(object sender, EventArgs e)
        {
            int port = int.Parse(tbPortReceiver.Text);
            _ = Task.Run(() => fileReceiver.StartAsync(port));
        }
        private void btnStopListening_Click(object sender, EventArgs e)
        {
            fileReceiver.Stop();
        }

        #endregion
        private async Task UpdateStatusAsync(ToolStripStatusLabel statusLabel, string message)
        {
            if (InvokeRequired)
            {
                await InvokeAsync(() => statusLabel.Text = message);
            }
            else
            {
                statusLabel.Text = message;
            }
        }
        private Task InvokeAsync(Action action)
        {
            var tcs = new TaskCompletionSource<bool>();
            Invoke(new MethodInvoker(() =>
            {
                action();
                tcs.SetResult(true);
            }));
            return tcs.Task;
        }
    }
}
