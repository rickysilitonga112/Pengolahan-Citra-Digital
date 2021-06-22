using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// libraries
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Collections;

namespace Pertemuan10_4211901034
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private ArrayList listCamera = new ArrayList();
        //image variabel
        Bitmap sourceImage = null;
        Bitmap detectedImage = null;
        //trackbar variable
        int Rmin, Rmax, Gmin, Gmax, Bmin, Bmax;
        int TRACK_SPACE = 2; //space between trackBar

        public Form1()
        {
            InitializeComponent();
            trackBarEnable(false);
            trackBarReset();
            labelReset();
        }

        //RGB trackbar Enable
        private void trackBarEnable(bool enable = true)
        {
            //RGB trackbar Enable
            trackBarRmax.Enabled = enable;
            trackBarRmin.Enabled = enable;
            trackBarGmax.Enabled = enable;
            trackBarGmin.Enabled = enable;
            trackBarBmax.Enabled = enable;
            trackBarBmin.Enabled = enable;
        }
        private void trackBarReset()
        {
            //RGB trackbar init
            trackBarRmax.Maximum = 255;
            trackBarRmin.Maximum = 255;
            trackBarGmax.Maximum = 255;
            trackBarGmin.Maximum = 255;
            trackBarBmax.Maximum = 255;
            trackBarBmin.Maximum = 255;
            //RGB trackbar reset
            trackBarRmax.Value = 255;
            trackBarRmin.Value = 0;
            trackBarGmax.Value = 255;
            trackBarGmin.Value = 0;
            trackBarBmax.Value = 255;
            trackBarBmin.Value = 0;
            Rmin = trackBarRmin.Value;
            Rmax = trackBarRmax.Value;
            Bmin = trackBarBmin.Value;
            Bmax = trackBarBmax.Value;
            Gmin = trackBarGmin.Value;
            Gmax = trackBarGmax.Value;
        }
        //RGB label reset
        private void labelReset()
        {
            labelRmax.Text = string.Format("RMax : {0}", trackBarRmax.Value);
            labelRmin.Text = string.Format("RMin : {0}", trackBarRmin.Value);
            labelGmax.Text = string.Format("GMax : {0}", trackBarGmax.Value);
            labelGmin.Text = string.Format("Gmin : {0}", trackBarGmin.Value);
            labelBmax.Text = string.Format("Bmax : {0}", trackBarBmax.Value);
            labelBmin.Text = string.Format("Bmin : {0}", trackBarBmin.Value);
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            try
            {
                sourceImage = image.Clone() as Bitmap;
                //detect the image
                colorFiltering(sourceImage);
                //traking the image
                objectTracking(sourceImage);
            }
            catch
            {
            }
        }

        private void colorFiltering(Bitmap srcImage)
        {
            // create RGB color filter
            ColorFiltering filter = new ColorFiltering();
            // set color ranges to keep
            filter.Red = new IntRange(Rmin, Rmax);
            filter.Green = new IntRange(Gmin, Gmax);
            filter.Blue = new IntRange(Bmin, Bmax);
            // apply the filter
            detectedImage = filter.Apply(srcImage);
            //draw the picture
            pictureBox1.Image = detectedImage;
        }
        private void objectTracking(Bitmap srcImage)
        {
            if (srcImage == null || detectedImage == null) return;
            //copy detected image to the new one
            Bitmap newImage = (Bitmap)detectedImage.Clone();
            //blob counter on the detected image
            BlobCounter bc = new BlobCounter();
            bc.MinHeight = 20;
            bc.MinWidth = 20;
            bc.FilterBlobs = true;
            bc.ObjectsOrder = ObjectsOrder.Area;
            bc.ProcessImage(newImage);
            Rectangle[] rects = bc.GetObjectsRectangles();
            foreach (Rectangle recs in rects)
            {
                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0];
                    Graphics graph = Graphics.FromImage(srcImage);
                    using (Pen pen = new Pen(Color.FromArgb(255, 0, 0), 10))
                    {
                        graph.DrawRectangle(pen, objectRect);
                    }
                    graph.Dispose();
                }
            }
            //draw tracked object on picture box
            pictureBox2.Image = srcImage;
        }

        private static string _usbcamera;

        private void Form1_Load(object sender, EventArgs e)
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



        public string usbcamera
        {
            get { return _usbcamera; }
            set { _usbcamera = value; }
        }

        // opening video source
        private void OpenVideoSource(IVideoSource source)
        {   
            // set busy cursor
            try
            {
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

        // closing the video source
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

                videoDevice = new VideoCaptureDevice(videoDevices[Convert.ToInt32(usbcamera)].MonikerString);
                OpenVideoSource(videoDevice);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenCamera();
            trackBarEnable();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoDevice != null && videoDevice.IsRunning)
                videoDevice.Stop(); 
        }

        private void trackBarRmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarRmax.Value - trackBarRmin.Value <= TRACK_SPACE)
                trackBarRmin.Value = trackBarRmax.Value - TRACK_SPACE;
            Rmin = trackBarRmin.Value;
            labelRmin.Text = string.Format("RMin : {0}", Rmin);
        }

        private void trackBarRmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarRmax.Value - trackBarRmin.Value <= TRACK_SPACE)
                trackBarRmax.Value = trackBarRmin.Value + TRACK_SPACE;
            Rmax = trackBarRmax.Value;
            labelRmax.Text = string.Format("RMax : {0}", Rmax);
        }

        private void trackBarGmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarGmax.Value - trackBarGmin.Value <= TRACK_SPACE)
                trackBarGmin.Value = trackBarGmax.Value - TRACK_SPACE;
            Gmin = trackBarGmin.Value;
            labelGmin.Text = string.Format("Gmin : {0}", Gmin);
        }

        private void trackBarGmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarGmax.Value - trackBarGmin.Value <= TRACK_SPACE)
                trackBarGmax.Value = trackBarGmin.Value + TRACK_SPACE;
            Gmax = trackBarGmax.Value;
            labelGmax.Text = string.Format("GMax : {0}", Gmax);
        }

        private void trackBarBmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarBmax.Value - trackBarBmin.Value <= TRACK_SPACE)
                trackBarBmin.Value = trackBarBmax.Value - TRACK_SPACE;
            Bmin = trackBarBmin.Value;
            labelBmin.Text = string.Format("Bmin : {0}", Bmin);
        }

        private void trackBarBmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarBmax.Value - trackBarBmin.Value <= TRACK_SPACE)
                trackBarBmax.Value = trackBarBmin.Value + TRACK_SPACE;
            Bmax = trackBarBmax.Value;
            labelBmax.Text = string.Format("Bmax : {0}", Bmax);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((videoDevice != null))
            {
                try
                {
                    ((VideoCaptureDevice)videoDevice).DisplayPropertyPage(this.Handle);
                }
                catch (NotSupportedException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trackBarReset();
            labelReset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
