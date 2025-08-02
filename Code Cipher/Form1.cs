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
            if (btnType.Text == "Vigenere")
            {
                vigenere();
            }
            else
            {
                morse();
            }
        }
        private void morse()
        {
            string input = txtPlain.Text.ToUpper();
            StringBuilder result = new StringBuilder();
            Dictionary<char, string> morseCode = new Dictionary<char, string>
            {
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
                {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
                {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
                {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
                {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
                {'Z', "--.."}
            };
            foreach (char c in input)
            {
                if (morseCode.ContainsKey(c))
                {
                    result.Append(morseCode[c] + " ");
                }
                else if (c == ' ')
                {
                    result.Append("  "); 
                }
            }
            txtCipher.Text = result.ToString().Trim();
        }
        private void vigenere()
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

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(59, 153, 155);
        }

        private void btnType_Click_1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = (button.Text == "Vigenere") ? "Morse" : "Vigenere";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCipher.Text);
        }
    }
}