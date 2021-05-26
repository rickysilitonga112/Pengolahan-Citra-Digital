using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Percobaan1_4211901034
{
    public partial class Form1 : Form
    {
        // global variable
        Bitmap sourceImage;

        public Form1()
        {
            InitializeComponent();
            comboAddString();
            comboBox1.SelectedIndex = 0;
        }

        // my function 
        private void comboAddString()
        {
            comboBox1.Items.Add("Please Select");
            comboBox1.Items.Add("Stretch Image");
            comboBox1.Items.Add("Normal Image");
            comboBox1.Items.Add("Zoom Image");
            comboBox1.Items.Add("Center Image");
            comboBox1.Items.Add("Auto Size");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = saveFileDialog1.ShowDialog();
            if(d == DialogResult.OK)
            {
                string ext = Path.GetExtension(saveFileDialog1.FileName).ToLower();
                string fileName = saveFileDialog1.FileName;

                ImageFormat format = ImageFormat.Jpeg;

                if(ext == ".bmp")
                {
                    format = ImageFormat.Bmp;
                }
                else if(ext == ".png")
                {
                    format = ImageFormat.Png;
                }
                else if (ext == ".gif")
                {
                    format = ImageFormat.Gif;
                }
                else if (ext == ".tiff")
                {
                    format = ImageFormat.Tiff;
                }

                try
                {
                    lock (this)
                    {
                        Bitmap image = (Bitmap)pictureBox1.Image;
                        image.Save(fileName, format);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Failed saving the image\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            sourceImage = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = sourceImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                // initial condiion
            }
            // stretch image
            else if(comboBox1.SelectedIndex == 1)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }

        // radio button

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
