using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Percobaan6_4211901034
{
    public partial class Form1 : Form
    {
        // global variable
        Bitmap image1, image2, image3, image4;
        int BIN = 48;  // jumlah histogram BIN

        float[] h1 = new float[48]; //histogram object 1
        float[] h2 = new float[48]; //histogram object 2
        float[] h3 = new float[48]; //histogram object 3
        float[] h4 = new float[48]; //histogram object 4 (test object)
        float[] hBack = new float[48]; //histogram background

        public Form1()
        {
            InitializeComponent();
            chartClear();
            histogramEnable(false);
            //matching button
            button9.Enabled = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image4 = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox4.Image = image4;
                button8.Enabled = true;
                button9.Enabled = false;
                //delete the histogram
                //delete the histogram
                if (chart4.Series.Count > 0)
                {
                    chart4.Series.RemoveAt(0);
                    chart4.Titles.RemoveAt(0);
                }
            }
        }


        // function
        private void chartClear()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            chart4.Series.Clear();
        }

        

        private void histogramEnable(bool bEnable)
        {
            button2.Enabled = bEnable;
            button4.Enabled = bEnable;
            button6.Enabled = bEnable;
            button8.Enabled = bEnable;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image1 = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = image1;
                button2.Enabled = true; //histogram button
                button9.Enabled = false; //matching button
                                         //delete the histogram
                if (chart1.Series.Count > 0)
                    chart1.Series.RemoveAt(0);
                if (chart2.Series.Count > 0)
                    chart2.Series.RemoveAt(0);
                if (chart3.Series.Count > 0)
                    chart3.Series.RemoveAt(0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image2 = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = image2;
                button4.Enabled = true;
                button9.Enabled = false;
                //delete the histogram
                if (chart1.Series.Count > 0)
                    chart1.Series.RemoveAt(0);
                if (chart2.Series.Count > 0)
                    chart2.Series.RemoveAt(0);
                if (chart3.Series.Count > 0)
                    chart3.Series.RemoveAt(0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image3 = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox3.Image = image3;
                button6.Enabled = true;
                button9.Enabled = false;
                //delete the histogram
                if (chart1.Series.Count > 0)
                    chart1.Series.RemoveAt(0);
                if (chart2.Series.Count > 0)
                    chart2.Series.RemoveAt(0);
                if (chart3.Series.Count > 0)
                    chart3.Series.RemoveAt(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //chart init
            chart1.Series.Add("Image1");
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = hitungHistogram(image1);
            hBack = hitungHistogramBackgound();
            for (int i = 0; i < BIN; i++)
            {
                h1[i] = Math.Abs(h1[i] - hBack[i]);
            }
            for (int i = 0; i < BIN; i++)
            {
                chart1.Series["Image1"].Points.AddXY(i, h1[i]);
            }
            button2.Enabled = false;
            button4.Enabled = true;
            button6.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //chart init
            chart2.Series.Add("Image2");
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = hitungHistogram(image2);
            hBack = hitungHistogramBackgound();
            for (int i = 0; i < BIN; i++)
            {
                h2[i] = Math.Abs(h2[i] - hBack[i]);
            }
            for (int i = 0; i < BIN; i++)
            {
                chart2.Series["Image2"].Points.AddXY(i, h2[i]);
            }
            button2.Enabled = true;
            button4.Enabled = false;
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //chart init
            chart3.Series.Add("Image3");
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = hitungHistogram(image3);
            hBack = hitungHistogramBackgound();
            for (int i = 0; i < BIN; i++)
            {
                h3[i] = Math.Abs(h3[i] - hBack[i]);
            }
            for (int i = 0; i < BIN; i++)
            {
                chart3.Series["Image3"].Points.AddXY(i, h3[i]);
            }
            button2.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //chart init
            chart4.Series.Add("Image4");
            chart4.Titles.Add("Image4");
            foreach (var series in chart4.Series)
            {
                series.Points.Clear();
            }
            float[] his = new float[BIN];
            his = hitungHistogram(image4);
            h4 = his;
            for (int i = 0; i < BIN; i++)
            {
                chart4.Series["Image4"].Points.AddXY(i, his[i]);
            }
            button8.Enabled = false;
            button9.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (chart1.Series.Count == 0 || chart2.Series.Count == 0 ||
chart3.Series.Count == 0) return;
            if (chart4.Series.Count == 0) return;
            float[] d = new float[3];
            float di = 0;
            int j;
            hBack = hitungHistogramBackgound();
            h1 = hitungHistogram(image1);
            h2 = hitungHistogram(image2);
            h3 = hitungHistogram(image3);
            h4 = hitungHistogram(image4);
            for (int i = 0; i < BIN; i++)
            {
                h1[i] = Math.Abs(h1[i] - hBack[i]);
                h2[i] = Math.Abs(h2[i] - hBack[i]);
                h3[i] = Math.Abs(h3[i] - hBack[i]);
                h4[i] = Math.Abs(h4[i] - hBack[i]);
            }
            //Fungsi untuk melakukan proses matching
            // membandingkan test image dengan image ref 1
            d[0] = 0;
            for (j = 0; j < BIN; j++)
                di = di + Math.Abs(h4[j] - h1[j]);
            di = di / BIN;
            d[0] = di;
            // membandingkan test image dengan image ref 2
            di = 0;
            d[1] = 0;
            for (j = 0; j < BIN; j++)
                di = di + Math.Abs(h4[j] - h2[j]);
            di = di / BIN;
            d[1] = di;
            // membandingkan test image dengan image ref 3
            di = 0;
            d[2] = 0;
            for (j = 0; j < BIN; j++)
                di = di + Math.Abs(h4[j] - h3[j]);
            di = di / BIN;
            d[2] = di;
            //mencari nilai minimum
            float min = 1F;
            float TH = 0.2F;
            bool Over = false;
            if (min > d[0]) min = d[0];
            if (min > d[1]) min = d[1];
            if (min > d[2]) min = d[2];
            if (min >= TH) Over = true;
            if (Over)
            {
                textBox4.Text = "Tidak ada object yang matching";
                pictureBox5.Image = null;
            }
            else
            {
                if (min == d[0])
                {
                    textBox4.Text = textBox1.Text;
                    pictureBox5.Image = image1;
                }
                else if (min == d[1])
                {
                    textBox4.Text = textBox2.Text;
                    pictureBox5.Image = image2;
                }
                else if (min == d[2])
                {
                    textBox4.Text = textBox3.Text;
                    pictureBox5.Image = image3;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // C:\\Users\\ricky\\OneDrive\\Desktop\\Matkul Semester 4\\Pengolahan Citra\\Pertemuan 6\\gambar\\ref\\matang01.jpg
            // alamat file disesuaikan dengan tempat penyimpanannya
            // Loading the reference image
            image1 = (Bitmap)Bitmap.FromFile("C:\\Users\\ricky\\OneDrive\\Desktop\\Matkul Semester 4\\Pengolahan Citra\\Pertemuan 6\\gambar\\ref\\matang01.jpg");
            pictureBox1.Image = image1;
            image2 = (Bitmap)Bitmap.FromFile("C:\\Users\\ricky\\OneDrive\\Desktop\\Matkul Semester 4\\Pengolahan Citra\\Pertemuan 6\\gambar\\ref\\mentah01.jpg");
            pictureBox2.Image = image2;
            image3 = (Bitmap)Bitmap.FromFile("C:\\Users\\ricky\\OneDrive\\Desktop\\Matkul Semester 4\\Pengolahan Citra\\Pertemuan 6\\gambar\\ref\\sedang01.jpg");
            pictureBox3.Image = image3;

            // initialization for the text box
            textBox1.Text = "Buah matang\r\nBerwarna merah\r\nManis rasanya";
            textBox2.Text = "Buah mentah\r\nBerwarna hijau\r\nPahit rasanya";
            textBox3.Text = "Buah sedang\r\nBerwarna jingga\r\nAsam rasanya";
            // chart init
            chart1.Series.Add("Image1");
            chart1.Titles.Add("Image1");
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            //chart init
            chart2.Series.Add("Image2");
            chart2.Titles.Add("Image2");
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            //chart init
            chart3.Series.Add("Image3");
            chart3.Titles.Add("Image3");
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            hBack = hitungHistogramBackgound();
            for (int i = 0; i < BIN; i++)
            {
                h1[i] = Math.Abs(h1[i] - hBack[i]);
                h2[i] = Math.Abs(h2[i] - hBack[i]);
                h3[i] = Math.Abs(h3[i] - hBack[i]);
            }
            for (int i = 0; i < BIN; i++)
            {
                chart1.Series["Image1"].Points.AddXY(i, h1[i]);
                chart2.Series["Image2"].Points.AddXY(i, h2[i]);
                chart3.Series["Image3"].Points.AddXY(i, h3[i]);
            }
        }

        private float[] hitungHistogram(Bitmap srcImage)
        {
            float[] h = new float[BIN];
            float maxHis = 0;
            //histogram yang dibuat adalah histogram untuk RGB image dengan jumlah
            //masing2 256 intensitas (bin)
            //untuk memudahkan dinormalisasi masing masing ke dalam 16 intensitas (bin)
            //sehingga jumlah intensitasnya 48
            //masing-masing warna dibagi 16
            //histogram init
            for (int i = 0; i < BIN; i++)
            {
                h[i] = 0; // dalam 48 bin
            }
            //histogram calculation
            for (int x = 0; x < srcImage.Width; x++)
            {
                for (int y = 0; y < srcImage.Height; y++)
                {
                    Color w = srcImage.GetPixel(x, y);
                    int red = (int)(w.R / 16); //dibagi 16 shingga menjadi 16 bin
                    int green = (int)(w.G / 16); //dibagi 16 shingga menjadi 16 bin
                    int blue = (int)(w.B / 16); //dibagi 16 shingga menjadi 16 bin
                    h[red] = h[red] + 1;
                    h[green + 16] = h[green + 16] + 1;
                    h[blue + 32] = h[blue + 32] + 1;
                    if (maxHis < h[red])
                        maxHis = h[red];
                    if (maxHis < h[green + 16])
                        maxHis = h[green + 16];
                    if (maxHis < h[blue + 32])
                        maxHis = h[blue + 32];
                }
            }
            for (int i = 0; i < BIN; i++)
            {
                h[i] = h[i] / maxHis;
            }
            return h;
        }
        private float[] hitungHistogramBackgound()
        {
            for (int i = 0; i < BIN; i++)
            {
                h1[i] = 0;
                h2[i] = 0;
                h3[i] = 0;
            }
            h1 = hitungHistogram(image1);
            h2 = hitungHistogram(image2);
            h3 = hitungHistogram(image3);
            for (int i = 0; i < BIN; i++)
            {
                float hMin = 1;
                if (hMin > h1[i])
                {
                    hMin = h1[i];
                }
                if (hMin > h2[i])
                {
                    hMin = h2[i];
                }
                if (hMin > h3[i])
                {
                    hMin = h3[i];
                }
                hBack[i] = hMin;
            }
            return hBack;
        }
    }
}
