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

namespace Percobaan5_4211901034
{
    public partial class Form1 : Form
    {
        // global variable
        Bitmap sourceImage;
        int BIN = 256; // jumlah histogram bin
        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
            label2.Text = "Original Image";
            textBox1.Text = "256";
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceImage = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = sourceImage;
                //delete the histogram
                if (chart1.Series.Count > 0)
                {
                    chart1.Series.RemoveAt(0);
                }
                radioButtonHisClear();
                radioButtonHisAppClear();
                checkTextBox();
                BIN = int.Parse(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            sourceImage = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = sourceImage;
        }

        // function reset
        private void radioButtonHisClear()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
        }
        private void radioButtonHisAppClear()
        {
            radioButton6.Checked = false;
            radioButton7.Checked = false;
        }
        private void checkTextBox()
        {
            if(int.Parse(textBox1.Text) < 0)
            {
                textBox1.Text = "0";
            }
            else if(int.Parse(textBox1.Text) > 256)
            {
                textBox1.Text = "256";
            }
        }
        // fungsi untuk mengkonversi image
        private Bitmap imageConvert(int imageChannel)
        {
            if (sourceImage == null) return null;
            Bitmap convImage = new Bitmap(sourceImage);
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    //get the RGB value of the pixel at (x,y)
                    Color w = sourceImage.GetPixel(x, y);
                    byte r = w.R; //red value
                    byte g = w.G; // green value
                    byte b = w.B; // blue value
                                  //calculate gray channel
                    byte gray = (byte)(0.5 * r + 0.419 * g + 0.081 * b);
                    //set the color of each channel
                    //red channel image
                    Color redColor = Color.FromArgb(r, 0, 0);
                    Color greenColor = Color.FromArgb(0, g, 0);
                    Color blueColor = Color.FromArgb(0, 0, b);
                    Color grayColor = Color.FromArgb(gray, gray,gray );
                    //for green, blue and gray channel image,
                    //please add yourself the coding for them
                    // tambah coding sendiri
                    //set the image pixel
                    if (imageChannel == 1) //red
                    {
                        convImage.SetPixel(x, y, redColor);
                    }
                    else if (imageChannel == 2) //green
                    {
                        // tambah coding sendiri
                        convImage.SetPixel(x, y, greenColor);
                    }
                    else if (imageChannel == 3) //blue
                    {
                        // tambah coding sendiri
                        convImage.SetPixel(x, y, blueColor);
                    }
                    else if (imageChannel == 4) //gray
                    {
                        // tambah coding sendiri
                        convImage.SetPixel(x, y, grayColor);
                    }
                }
            return convImage;
        }
        // fungsi untuk menghitung histogram
        private float[] hitungHistogram(int imageChannel)
        {
            //init of bins
            checkTextBox();
            BIN = int.Parse(textBox1.Text);
            //initializaation of histogram el
            float[] h = new float[BIN];
            //histogram init
            for (int i = 0; i < BIN; i++)
            {
                h[i] = 0;
            }
            //histogram calculation
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color w = sourceImage.GetPixel(x, y);
                    int r = (int)(w.R * BIN / 256);
                    int g = (int)(w.G * BIN / 256);
                    int b = (int)(w.B * BIN / 256);
                    //calculate gray channel
                    int gray = (int)((0.5 * w.R + 0.419 * w.G + 0.081 * w.B) * BIN / 256);
                    //calculate histogram
                    if (imageChannel == 1)
                        h[r] = h[r] + 1;
                    else if (imageChannel == 2)
                        h[g] = h[g] + 1;
                    else if (imageChannel == 3)
                        h[b] = h[b] + 1;
                    else if (imageChannel == 4)
                        h[gray] = h[gray] + 1;
                }
            return h;
        }

        // fungsi untuk menghitung histogram rgb
        private float[] hitungHistogramRGB()
        {
            //initializaation of histogram
            checkTextBox();
            BIN = int.Parse(textBox1.Text);
            float[] h = new float[BIN * 3];
            //histogram init
            for (int i = 0; i < BIN * 3; i++)
            {
                h[i] = 0;
            }
            //histogram calculation
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color w = sourceImage.GetPixel(x, y);
                    int r = (int)(w.R * BIN / 256);
                    int g = (int)(w.G * BIN / 256);
                    int b = (int)(w.B * BIN / 256);
                    //calculate histogram
                    h[r] = h[r] + 1; //0 - BIN
                    h[g + BIN] = h[g + BIN] + 1; //BIN - 2*BIN
                    h[b + 2 * BIN] = h[b + 2 * BIN] + 1; //2*BIN - 3*BIN
                }
            return h;
        }

        // menampilkan histogram rgb
        private void histogramRGBDisplay()
        {
            //delete the histogram
            if (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
            }
            //chart init
            chart1.Series.Add("RGB Image");
            chart1.Series["RGB Image"].Color = Color.Maroon;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN * 3];
            his = hitungHistogramRGB();
            for (int i = 0; i < BIN * 3; i++)
            {
                chart1.Series["RGB Image"].Points.AddXY(i, his[i]);
            }
            label2.ForeColor = Color.Maroon;
            label2.Text = "RGB Image";
            label3.ForeColor = Color.Maroon;
            label3.Text = string.Format("RGB Image Histogram {0} Bins", BIN * 3);
        
        }

        // histogram equalization
        private float[] histogramEqualization()
        {
            Bitmap grayEqIm = new Bitmap(sourceImage);
            float[] h = new float[BIN];
            float[] c = new float[BIN];
            //histogram init
            for (int i = 0; i < BIN; i++)
            {
                h[i] = 0;
            }
            //histogram calculation
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color w = sourceImage.GetPixel(x, y);
                    byte r = w.R;
                    byte g = w.G;
                    byte b = w.B;
                    //calculate gray channel
                    byte gray = (byte)(0.5 * r + 0.419 * g + 0.081 * b);
                    h[gray] = h[gray] + 1;
                }
            c[0] = h[0];
            //calculate the cummulative histogram
            for (int i = 1; i < 256; i++)
                c[i] = c[i - 1] + h[i];
            //image equalization
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color w = sourceImage.GetPixel(x, y);
                    byte r = w.R;
                    byte g = w.G;
                    byte b = w.B;
                    byte gray = (byte)(0.5 * r + 0.419 * g + 0.081 * b);
                    byte grayEq = (byte)(255 * c[gray] / (sourceImage.Width / sourceImage.Height));
                    Color gEq = Color.FromArgb(grayEq, grayEq, grayEq);
                    grayEqIm.SetPixel(x, y, gEq);
                    h[grayEq] = h[grayEq] + 1;
                }
            //displaying Equalization Image
            pictureBox1.Image = grayEqIm;
            return h;
        }
        private float[] histogramAutoLevel()
        {
            Bitmap grayAuto = new Bitmap(sourceImage);
            float[] h = new float[BIN];
            int grayMin = 255;
            int grayMax = 0;
            //histogram init
            for (int i = 0; i < BIN; i++)
            {
                h[i] = 0;
            }
            //histogram calculation
            for (int x = 0; x < sourceImage.Width; x++)
            { 
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color w = sourceImage.GetPixel(x, y);
                    int r = (int)(w.R * BIN / 256);
                    int g = (int)(w.G * BIN / 256);
                    int b = (int)(w.B * BIN / 256);
                    //calculate gray channel
                    int gray = (int)((0.5 * w.R + 0.419 * w.G + 0.081 * w.B) * BIN / 256);
                    if (grayMin > gray) grayMin = gray;
                    if (grayMax < gray) grayMax = gray;
                }
            }
            //histogram AutoLevel calculation
            for (int x = 0; x < sourceImage.Width; x++)
                { 
                    for (int y = 0; y < sourceImage.Height; y++)
                     {
                        Color w = sourceImage.GetPixel(x, y);
                        int r = (int)(w.R * BIN / 256);
                        int g = (int)(w.G * BIN / 256);
                        int b = (int)(w.B * BIN / 256);
                        //calculate gray channel
                        int gray = (int)((0.5 * w.R + 0.419 * w.G + 0.081 * w.B) * BIN / 256);
                        int grayEq = (byte)(255 * (gray - grayMin) / (grayMax - grayMin) * BIN / 256);
                        Color gEq = Color.FromArgb(grayEq, grayEq, grayEq);
                        grayAuto.SetPixel(x, y, gEq);
                        h[grayEq] = h[grayEq] + 1;
                    }
                }
            //displaying Auto Level Image
            pictureBox1.Image = grayAuto;
            return h;
        }

        // radio
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (sourceImage == null) return;
            if (radioButton1.Checked == false) return;
            radioButtonHisAppClear();
            int pilChannel = 1;
            //delete the histogram
            if (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
            }
            //chart init
            chart1.Series.Add("Red Channel Image");
            chart1.Series["Red Channel Image"].Color = Color.Red;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = hitungHistogram(pilChannel);
            for (int i = 0; i < BIN; i++)
            {
                chart1.Series["Red Channel Image"].Points.AddXY(i, his[i]);
            }
            //displaying Red Channel
            Bitmap redImage = imageConvert(pilChannel);
            pictureBox1.Image = redImage;
            label2.Text = "Red Channel Image";
            label2.ForeColor = Color.Red;
            label3.ForeColor = Color.Red;
            label3.Text = string.Format("Red Channel Image Histogram {0} Bins", BIN);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (sourceImage == null) return;
            if (radioButton5.Checked == false) return;
            radioButtonHisAppClear();
            histogramRGBDisplay();
            pictureBox1.Image = sourceImage;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (sourceImage == null) return;
            if (radioButton6.Checked == false) return;
            radioButtonHisClear();
            //delete the histogram
            if (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
            }
            //chart init
            chart1.Series.Add("EQ");
            chart1.Series["EQ"].Color = Color.Silver;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = histogramEqualization();
            for (int i = 0; i < BIN; i++)
            {
                chart1.Series["EQ"].Points.AddXY(i, his[i]);
            }
            label2.ForeColor = Color.Navy;
            label2.Text = "Equalization Image";
            label3.ForeColor = Color.Navy;
            label3.Text = string.Format("Histogram Equalization {0} Bins", BIN);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (sourceImage == null) return;
            if (radioButton7.Checked == false) return;
            radioButtonHisClear();
            //delete the histogram
            if (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
            }
            //chart init
            chart1.Series.Add("Auto");
            chart1.Series["Auto"].Color = Color.Silver;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = histogramAutoLevel();
            for (int i = 0; i < BIN; i++)
            {
                chart1.Series["Auto"].Points.AddXY(i, his[i]);
            }
            label2.Text = "Auto Level Image";
            label2.ForeColor = Color.Navy;
            label3.ForeColor = Color.Navy;
            label3.Text = string.Format("Histogram AutoLevel {0} Bins", BIN);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (sourceImage == null) return;
            if (radioButton2.Checked == false) return;
            radioButtonHisAppClear();
            int pilChannel = 2;
            //delete the histogram
            if (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
            }
            //chart init
            chart1.Series.Add("Green Channel Image");
            chart1.Series["Green Channel Image"].Color = Color.Green;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = hitungHistogram(pilChannel);
            for (int i = 0; i < BIN; i++)
            {
                chart1.Series["Green Channel Image"].Points.AddXY(i, his[i]);
            }
            //displaying Red Channel
            Bitmap greenImage = imageConvert(pilChannel);
            pictureBox1.Image = greenImage;
            label2.Text = "Green Channel Image";
            label2.ForeColor = Color.Green;
            label3.ForeColor = Color.Green;
            label3.Text = string.Format("Green Channel Image Histogram {0} Bins", BIN);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (sourceImage == null) return;
            if (radioButton3.Checked == false) return;
            radioButtonHisAppClear();
            int pilChannel = 3;
            //delete the histogram
            if (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
            }
            //chart init
            chart1.Series.Add("Blue Channel Image");
            chart1.Series["Blue Channel Image"].Color = Color.Blue;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = hitungHistogram(pilChannel);
            for (int i = 0; i < BIN; i++)
            {
                chart1.Series["Blue Channel Image"].Points.AddXY(i, his[i]);
            }
            //displaying Red Channel
            Bitmap blueImage = imageConvert(pilChannel);
            pictureBox1.Image = blueImage;
            label2.Text = "Blue Channel Image";
            label2.ForeColor = Color.Blue;
            label3.ForeColor = Color.Blue;
            label3.Text = string.Format("Blue Channel Image Histogram {0} Bins", BIN);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            // gray image channel
            if (sourceImage == null) return;
            if (radioButton4.Checked == false) return;
            radioButtonHisAppClear();
            int pilChannel = 4;
            //delete the histogram
            if (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
            }
            //chart init
            chart1.Series.Add("Gray Channel Image");
            chart1.Series["Gray Channel Image"].Color = Color.Silver;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = hitungHistogram(pilChannel);
            for (int i = 0; i < BIN; i++)
            {
                chart1.Series["Gray Channel Image"].Points.AddXY(i, his[i]);
            }
            //displaying gray Channel
            Bitmap grayImage = imageConvert(pilChannel);
            pictureBox1.Image = grayImage;
            label2.Text = "Gray Channel Image";
            label2.ForeColor = Color.Navy;
            label3.ForeColor = Color.Navy;
            label3.Text = string.Format("Gray Channel Image Histogram {0} Bins", BIN);
        }
    }
}
