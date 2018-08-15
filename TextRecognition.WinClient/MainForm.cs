using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

// TODO: Rename to Text Recognition
namespace TextRecognition.WinClient
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
            var expectedResults = new Dictionary<int, string>()
            {
                { 1, "" },
                { 2, "" },
                { 3, "" },
                { 4, "" },
                { 5, "" },
                { 6, "" },
                { 7, "" },
                { 8, "" },
                { 9, "" },
            };

            var actualResults = new Dictionary<int, string>()
            {

            };

            Task.Run(() =>
            {
                foreach (var expected in expectedResults)
                {
                    var fileName = Path.Combine("Images", expected.Key + ".png");
                    var image = Image.FromFile(fileName);

                    var result = U.Profile(() => {
                        var text = U.Recognize(image);

                        Invoke((MethodInvoker)delegate() {
                            richTextBox1.Text += text;
                        });

                        
                    });

                    Invoke((MethodInvoker)delegate () {
                        richTextBox1.Text += ": " + result.ToString("s's 'fff'ms'") + Environment.NewLine;
                    });                    
                };
            });
        }
    }
}
