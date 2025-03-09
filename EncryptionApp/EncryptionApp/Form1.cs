using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace EncryptionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Cryptex";
            this.BackgroundImage = Image.FromFile(@"C:\Users\msava\OneDrive\Desktop\IV GODINA\SEMESTAR 7\ZASTITA INFORMACIJA\Cryptex\EncryptionApp\EncryptionApp\Images\encryption.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cryptex je aplikacija koja implementira dve snažne tehnike kriptovanja: Double Transposition i A52. Ova aplikacija omogućava korisnicima da bezbedno šifruju i dešifruju fajlove koristeći ove algoritme, pružajući zaštitu podataka pri njihovom skladištenju ili prenosu.", "O Cryptex-u", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
