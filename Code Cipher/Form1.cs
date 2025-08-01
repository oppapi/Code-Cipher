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
            txtPlain.Text = txtCipher.Text = txtKeyword.Text = "";
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string input = txtPlain.Text.ToUpper();
            string keyword = txtKeyword.Text.ToUpper();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a keyword.");
                return;
            }

            StringBuilder result = new StringBuilder();
            int keywordIndex = 0;

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    int shift = keyword[keywordIndex % keyword.Length] - 'A';
                    char encrypted = (char)(((c - 'A' + shift) % 26) + 'A');
                    result.Append(encrypted);
                    keywordIndex++;
                }
                else
                {
                    result.Append(c); 
                }
            }

            txtCipher.Text = result.ToString();
        }

        private void btnCopy_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(59, 153, 200);
        }

        private void btnCopy_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(238, 88, 115);
        }
    }
}