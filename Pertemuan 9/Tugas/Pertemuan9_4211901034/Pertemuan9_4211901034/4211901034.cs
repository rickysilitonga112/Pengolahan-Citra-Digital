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
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Math.Geometry;

namespace Pertemuan9_4211901034
{
    public partial class Form1 : Form
    {
        // global
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] snapshotCapabilities;
        private ArrayList listCamera = new ArrayList();
        public string pathFolder = Application.StartupPath + @"\ImageCapture\";
        //for capturing image
        bool needSnapshot = false;
        int imageChannel = 0;
        //image variabel
        Bitmap sourceImage = null;
        Bitmap processedImage = null;
        Bitmap grayImage = null;
        Bitmap invertImage = null;

        public Form1()
        {
            InitializeComponent();
            //list the available camera and add to comboBox
            getListCameraUSB();
        }

        private void getListCameraUSB()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count != 0)
            {
                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
            }
            else
            {
                comboBox1.Items.Add("No DirectShow devices found");
            }
            comboBox1.SelectedIndex = 0;
        }

        // usb camera definition
        private static string _usbcamera;
        public string usbcamera
        {
            get { return _usbcamera; }
            set { _usbcamera = value; }
        }
        // opening the video source
        private void OpenVideoSource(IVideoSource source)
        {
            try
            {
                // set busy cursor
                this.Cursor = Cursors.WaitCursor;
                // stop current video source
                CloseCurrentVideoSource();
                // start new video source
                videoSourcePlayer1.VideoSource = source;
                videoSourcePlayer1.Start();
                this.Cursor = Cursors.Default;
            }
            catch { }
        }
        public void CloseCurrentVideoSource()
        {
            try
            {
                if (videoSourcePlayer1.VideoSource != null)
                {
                    videoSourcePlayer1.SignalToStop();
                    // wait ~ 3 seconds
                    for (int i = 0; i < 30; i++)
                    {
                        if (!videoSourcePlayer1.IsRunning)
                            break;
                        System.Threading.Thread.Sleep(100);
                    }
                    if (videoSourcePlayer1.IsRunning)
                    {
                        videoSourcePlayer1.Stop();
                    }
                    videoSourcePlayer1.VideoSource = null;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenCamera();
        }

       private void OpenCamera()
        {
            try
            {
                usbcamera = comboBox1.SelectedIndex.ToString();
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count != 0)
                {
                    // add all devices to combo
                    foreach (FilterInfo device in videoDevices)
                    {
                        listCamera.Add(device.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Camera devices found");
                }
                videoDevice = new
                VideoCaptureDevice(videoDevices[Convert.ToInt32(usbcamera)].MonikerString);
                snapshotCapabilities = videoDevice.SnapshotCapabilities;
                if (snapshotCapabilities.Length == 0)
                {
                    MessageBox.Show("Camera Capture Not supported");
                }
                OpenVideoSource(videoDevice);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        public delegate void CaptureSnapshotManifast(Bitmap image);
        public void UpdateCaptureSnapshotManifast(Bitmap image)
        {
            try
            {
                needSnapshot = false;
                pictureBox2.Image = image;
                pictureBox2.Update();
                string namaImage = "sampleImage";
                string nameCapture = namaImage + "_" +
                DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
                if (Directory.Exists(pathFolder))
                {
                    pictureBox2.Image.Save(pathFolder + nameCapture,
                    ImageFormat.Bmp);
                }
                else
                {
                    Directory.CreateDirectory(pathFolder);
                    pictureBox2.Image.Save(pathFolder + nameCapture,
                    ImageFormat.Bmp);
                }
            }
            catch { }
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                DateTime now = DateTime.Now;
                Graphics g = Graphics.FromImage(image);
                sourceImage = image.Clone() as Bitmap;
                //process the image
                processedImage = channelFiltering(imageChannel);
                hitungHistogram(imageChannel);
                //display the processed image
                pictureBox1.Image = processedImage;
                // paint current time
                SolidBrush brush = new SolidBrush(Color.Red);
                g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
                brush.Dispose();
                if (needSnapshot)
                {
                    this.Invoke(new
                    CaptureSnapshotManifast(UpdateCaptureSnapshotManifast), processedImage);
                }
                g.Dispose();
            }
            catch
            {
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            needSnapshot = true;
        }

        private Bitmap channelFiltering(int channel)
        {
            if (sourceImage == null) return null;
            //image initialization
            Bitmap image = new Bitmap(sourceImage);
            // create filter
            ChannelFiltering filter = new ChannelFiltering();
            // RGB image
            if (channel == 0)
            {
                filter.Red = new IntRange(0, 255);
                filter.Green = new IntRange(0, 255);
                filter.Blue = new IntRange(0, 255);
                //apply the filter
                image = filter.Apply(sourceImage);
            }
            // R image
            else if (channel == 1)
            {
                filter.Red = new IntRange(0, 255);
                filter.Green = new IntRange(0, 0);
                filter.Blue = new IntRange(0, 0);
                //apply the filter
                image = filter.Apply(sourceImage);
            }
            // G image
            else if (channel == 2)
            {
                // tambahkan koding
                filter.Red = new IntRange(0, 0);
                filter.Green = new IntRange(0, 255);
                filter.Blue = new IntRange(0, 0);
                //apply the filter
                image = filter.Apply(sourceImage);
            }
            // B image
            else if (channel == 3)
            {
                // tambahkan koding
                filter.Red = new IntRange(0, 0);
                filter.Green = new IntRange(0, 0);
                filter.Blue = new IntRange(0, 255);
                //apply the filter
                image = filter.Apply(sourceImage);
            }
            else if (channel == 4)
            {
                FiltersSequence filter1 = new AForge.Imaging.Filters.FiltersSequence();
                filter1.Add(new Grayscale(0.299, 0.587, 0.144));
                grayImage = filter1.Apply(sourceImage);
                image = grayImage;
            }
            else if (channel == 5)
            {
                Invert filterInvert = new Invert();
                //apply the filter
                invertImage = filterInvert.Apply(sourceImage);
                image = invertImage;
            }
            return image;
        }

        int[] gabungHistogram(int[] r, int[] g, int[] b)
        {
            int[] c = new int[256 * 3];
            for (int i = 0; i < 256; i++)
                c[i] = r[i];
            for (int i = 256; i < 512; i++)
                c[i] = g[i - 256];
            for (int i = 512; i < 768; i++)
                c[i] = b[i - 512];
            return c;
        }

        private void setImageChannel(int channel)
        {
            imageChannel = channel;
        }

        private void radioButtonReset()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sourceImage == null) return;
            setImageChannel(0);
            radioButtonReset();
        }

        private void hitungHistogram(int channel)
        {
            if (sourceImage == null) return;
            ImageStatistics stat = new ImageStatistics(sourceImage);
            // RGB histogram
            if (channel == 0)
            {
                int[] redStat = stat.Red.Values;
                int[] greenStat = stat.Blue.Values;
                int[] blueStat = stat.Blue.Values;
                int[] gab = gabungHistogram(redStat, greenStat, blueStat);
                histogram1.Color = Color.Navy;
                histogram1.Values = gab;
            }
            // R histogram
            else if (channel == 1)
            {
                int[] redStat = stat.Red.Values;
                histogram1.Color = Color.Red;
                histogram1.Values = redStat;
            }
            // G histogram
            else if (channel == 2)
            {
                // tambahkan koding
                int[] greenStat = stat.Green.Values;
                histogram1.Color = Color.Green;
                histogram1.Values = greenStat;
            }
            // B histogram
            else if (channel == 3)
            {
                // tambahkan koding
                int[] blueStat = stat.Blue.Values;
                histogram1.Color = Color.Blue;
                histogram1.Values = blueStat;
            }
            // Gray histogram
            else if (channel == 4)
            {
                ImageStatistics grayStat = new ImageStatistics(grayImage);
                int[] grayHis = grayStat.Gray.Values;
                histogram1.Color = Color.Gray;
                histogram1.Values = grayHis;
            }
            // Invers histogram
            else if (channel == 5)
            {
                ImageStatistics invertStat = new ImageStatistics(invertImage);
                int[] redStat = invertStat.Red.Values;
                int[] greenStat = invertStat.Blue.Values;
                int[] blueStat = invertStat.Blue.Values;
                int[] gab = gabungHistogram(redStat, greenStat, blueStat);
                histogram1.Color = Color.Maroon;
                histogram1.Values = gab;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if the source image is not yet open..don't execute
            if (sourceImage == null) return;
            setImageChannel(1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //if the source image is not yet open..don't execute
            if (sourceImage == null) return;
            setImageChannel(2);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //if the source image is not yet open..don't execute
            if (sourceImage == null) return;
            setImageChannel(3);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //if the source image is not yet open..don't execute
            if (sourceImage == null) return;
            setImageChannel(4);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //if the source image is not yet open..don't execute
            if (sourceImage == null) return;
            setImageChannel(5);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoDevice != null && videoDevice.IsRunning)
                videoDevice.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
