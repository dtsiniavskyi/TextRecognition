using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

// TODO: Rename to Text Recognition
namespace ImgRecognize.WinClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = U.Profile(() => {
                var text = U.Recognize(pictureBox1.Image);
                richTextBox1.Text = text;
            });

            richTextBox1.Text += ": " + result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
