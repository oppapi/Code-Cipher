using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCipher.Text)) { Clipboard.SetText(txtCipher.Text); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPlain.Text = txtCipher.Text = "";
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            btnEncrypt.Text = (btnEncrypt.Text=="Encrypt") ? "Decrypt" : "Encrypt";
        }
    }
}
