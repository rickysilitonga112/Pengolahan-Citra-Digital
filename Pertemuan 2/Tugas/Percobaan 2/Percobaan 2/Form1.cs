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

namespace Percobaan_2
{
    public partial class Form1 : Form
    {
        // global variable

        Bitmap sourceImage, tempImage;
        int imageHeight, imageWidth;

        // image flipping
        int imageFlipping;

        // image rotation
        int imageRotation;

        public Form1()
        {
            InitializeComponent();
            trackbarInitialization();
            textBoxInitialization();
        }

        // my function
        private void trackbarInitialization()
        {
            // trackbar init
            trackBar1.Value = 0;
            trackBar2.Value = 0;
        }

        private void textBoxInitialization()
        {
            textBox3.Text = "0";
            textBox4.Text = "0";
        }

        // flip
        private void setImageFlipping(int flipping)
        {
            if (tempImage == null) return;

            Bitmap flipImage = new Bitmap(tempImage);

            /* Image flipping
               1. Horizontal
               2. Vertical
            */ 

            for(int x=0; x<imageWidth; x++)
            {
                for(int y=0; y<imageHeight; y++)
                {
                    Color w = flipImage.GetPixel(x, y);

                    if(flipping == 1)
                    {
                        tempImage.SetPixel(imageWidth - 1 - x, y, w); // flip horizontal
                    }
                    else if(flipping == 2)
                    {
                        tempImage.SetPixel(x, imageHeight - 1 - y, w); // flip vertical
                    }
                }
            }
            pictureBox1.Image = tempImage;
        }

        // image rotate
        private void setImageRotation(int rotation)
        {
            if (tempImage == null) return;

            if(rotation == 90)
            {
                tempImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (rotation == 180)
            {
                tempImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (rotation == 270)
            {
                tempImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            pictureBox1.Image = tempImage;
        }

        // image translation
        private void setTranslation(int xTrans, int yTrans)
        {
            Bitmap transImage = new Bitmap(imageWidth, imageHeight);
            for(int x=0; x<imageWidth; x++)
            {
                for(int y=0; y<imageHeight; y++)
                {
                    Color w = tempImage.GetPixel(x, y);

                    byte wMerah = w.R;
                    byte wHijau = w.G;
                    int xT = x + xTrans;
                    int yT = y + yTrans;
                    if(yT < imageHeight && yT > 0 && xT < imageWidth && xT > 0)
                    {
                        transImage.SetPixel(xT, yT, w);
                    }
                }
                pictureBox1.Image = transImage;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            sourceImage = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
            tempImage = new Bitmap(sourceImage);

            pictureBox1.Image = sourceImage;

            // mencari tinggi dan lebar image
            imageHeight = sourceImage.Height;
            imageWidth = sourceImage.Width;

            // translation trackbar init
            trackBar1.Minimum = -imageWidth / 2;
            trackBar1.Maximum = imageWidth / 2;

            trackBar2.Minimum = -imageWidth / 2;
            trackBar2.Maximum = imageWidth / 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sourceImage == null) return;
            pictureBox1.Image = sourceImage;

            // init
            trackbarInitialization();
            textBoxInitialization();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if (tempImage == null) return;

            int xTrans = int.Parse(textBox3.Text);
            int yTrans = int.Parse(textBox4.Text);

            // set translation
            setTranslation(xTrans, yTrans);

            // menampilkan nilai pada trackbar
            trackBar1.Value = int.Parse(textBox3.Text);
            trackBar2.Value = int.Parse(textBox4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d = saveFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                string ext = Path.GetExtension(saveFileDialog1.FileName).ToLower();
                string fileName = saveFileDialog1.FileName;

                ImageFormat format = ImageFormat.Jpeg;

                if (ext == ".bmp")
                {
                    format = ImageFormat.Bmp;
                }
                else if (ext == ".png")
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
                catch (Exception ex)
                {
                    MessageBox.Show("Failed saving the image\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            }
        }


        // flip button
        private void button5_Click(object sender, EventArgs e)
        {
            imageFlipping = 1; // flip horizontal ( horizontal == 1)
            setImageFlipping(imageFlipping);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            imageFlipping = 2; // flip vartical ( vertical == 2)
            setImageFlipping(imageFlipping);
        }

        // image rotation button
        private void button7_Click(object sender, EventArgs e)
        {
            imageRotation = 90; // rotatasi 90 deg
            setImageRotation(imageRotation);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            imageRotation = 180; // rotasi 180 deg
            setImageRotation(imageRotation);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            imageRotation = 270;  // rotasi 270 deg
            setImageRotation(imageRotation);
        }


        // trackbar
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (tempImage == null) return;

            int xTrans = trackBar1.Value;
            int yTrans = trackBar2.Value;

            setTranslation(xTrans, yTrans);

            // menampilkan nilai translasi pada textbox
            textBox3.Text = string.Format("{0}", trackBar1.Value);
            textBox4.Text = string.Format("{0}", trackBar2.Value);
        }
    private void trackBar2_Scroll(object sender, EventArgs e)
    {
        if (tempImage == null) return;

        int xTrans = trackBar1.Value;
        int yTrans = trackBar2.Value;

        setTranslation(xTrans, yTrans);

        // menampilkan nilai translasi pada textbox
        textBox3.Text = string.Format("{0}", trackBar1.Value);
        textBox4.Text = string.Format("{0}", trackBar2.Value);
    }

        // flipping radio button

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            imageFlipping = 1;
            setImageFlipping(imageFlipping);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            imageFlipping = 2;
            setImageFlipping(imageFlipping);
        }

        // rotation radio button       
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            imageRotation = 90;
            setImageRotation(imageRotation);
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            imageRotation = 180;
            setImageRotation(imageRotation);
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            imageRotation = 270;
            setImageRotation(imageRotation);
        }

        // 
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
