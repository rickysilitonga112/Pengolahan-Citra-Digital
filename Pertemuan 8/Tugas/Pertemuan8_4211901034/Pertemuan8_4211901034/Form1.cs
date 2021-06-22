using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Pertemuan8_4211901034
{
    public partial class Form1 : Form
    {
        // global variable
        Bitmap sourceImage;
        Bitmap HSLImage, RGBImage, YCbCrImage;
        
        //Space antara min Trackbar dan max Trackbar
        int TRACK_SPACE = 2;
        
        //HSL trackbar variable
        int Hmin, Hmax;
        float Smin, Smax, Lmin, Lmax;
       
        //RGB trackbar variable
        int Rmin, Rmax, Gmin, Gmax, Bmin, Bmax;

        //YCbCr trackbar variable
        float Ymin, Ymax, Cbmin, Cbmax, Crmin, Crmax;

        private void trackBarHmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarHmax.Value - trackBarHmin.Value <= TRACK_SPACE)
                trackBarHmin.Value = trackBarHmax.Value - TRACK_SPACE;
            Hmin = trackBarHmin.Value;
            labelHmin.Text = string.Format("HueMin : {0}", Hmin);
            HSLFiltering(sourceImage);
        }

        private void trackBarHmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarHmax.Value - trackBarHmin.Value <= TRACK_SPACE)
                trackBarHmax.Value = trackBarHmin.Value + TRACK_SPACE;
            Hmax = trackBarHmax.Value;
            labelHmax.Text = string.Format("HueMax : {0}", Hmax);
            HSLFiltering(sourceImage);
        }

        private void trackBarYmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarYmax.Value - trackBarYmin.Value <= TRACK_SPACE)
                trackBarYmin.Value = trackBarYmax.Value - TRACK_SPACE;
            Ymin = (float)trackBarYmin.Value / 100;
            labelYmin.Text = string.Format("Ymin : {0}", Ymin);
            YCbCrFiltering(sourceImage);
        }

        private void trackBarYmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarYmax.Value - trackBarYmin.Value <= TRACK_SPACE)
                trackBarYmax.Value = trackBarYmin.Value + TRACK_SPACE;
            Ymax = (float)trackBarYmax.Value / 100;
            labelYmax.Text = string.Format("Ymax : {0}", Ymax);
            YCbCrFiltering(sourceImage);
        }

        private void trackBarCbmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarCbmax.Value - trackBarCbmin.Value <= TRACK_SPACE)
                trackBarCbmin.Value = trackBarCbmax.Value - TRACK_SPACE;
            Cbmin = (float)trackBarCbmin.Value / 100;
            labelCbmin.Text = string.Format("Cbmin : {0}", Cbmin);
            YCbCrFiltering(sourceImage);
        }

        private void trackBarCbmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarCbmax.Value - trackBarCbmin.Value <= TRACK_SPACE)
                trackBarCbmax.Value = trackBarCbmin.Value + TRACK_SPACE;
            Cbmax = (float)trackBarCbmax.Value / 100;
            labelCbmax.Text = string.Format("Cbmax : {0}", Cbmax);
            YCbCrFiltering(sourceImage);
        }

        private void trackBarCrmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarCrmax.Value - trackBarCrmin.Value <= TRACK_SPACE)
                trackBarCrmin.Value = trackBarCrmax.Value - TRACK_SPACE;
            Crmin = (float)trackBarCrmin.Value / 100;
            labelCrmin.Text = string.Format("Crmin : {0}", Crmin);
            YCbCrFiltering(sourceImage);
        }

        private void trackBarCrmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarCrmax.Value - trackBarCrmin.Value <= TRACK_SPACE)
                trackBarCrmax.Value = trackBarCrmin.Value + TRACK_SPACE;
            Crmax = (float)trackBarCrmax.Value / 100;
            labelCrmax.Text = string.Format("Crmax : {0}", Crmax);
            YCbCrFiltering(sourceImage);
        }

        private void trackBarSmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarSmax.Value - trackBarSmin.Value <= TRACK_SPACE)
                trackBarSmin.Value = trackBarSmax.Value - TRACK_SPACE;
            Smin = (float)trackBarSmin.Value / 100; ;
            labelSmin.Text = string.Format("SMin : {0}", Smin);
            HSLFiltering(sourceImage);
        }

        private void buttonRGBTrack_Click(object sender, EventArgs e)
        {
            if (RGBImage == null) return;
            Bitmap tempImage = new Bitmap(sourceImage);
            pictureBoxRGB.Image = tempImage;
            BlobCounter bc = new BlobCounter();
            bc.MinHeight = 5;
            bc.MinWidth = 5;
            bc.FilterBlobs = true;
            bc.ObjectsOrder = ObjectsOrder.Area;
            bc.ProcessImage(RGBImage);
            Rectangle[] rects = bc.GetObjectsRectangles();
            foreach (Rectangle recs in rects)
                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0]; //= recs;
                    Graphics graph = Graphics.FromImage(tempImage);
                    using (Pen pen = new Pen(Color.FromArgb(255, 0, 0), 2))
                    {
                        graph.DrawRectangle(pen, objectRect);
                    }
                    graph.Dispose();
                }
        }

        private void buttonHSLTrack_Click(object sender, EventArgs e)
        {
            if (HSLImage == null) return;
            Bitmap tempImage = new Bitmap(sourceImage);
            pictureBoxHSL.Image = tempImage;
            BlobCounter bc = new BlobCounter();
            bc.MinHeight = 5;
            bc.MinWidth = 5;
            bc.FilterBlobs = true;
            bc.ObjectsOrder = ObjectsOrder.Area;
            bc.ProcessImage(HSLImage);
            Rectangle[] rects = bc.GetObjectsRectangles();
            foreach (Rectangle recs in rects)
                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0]; //= recs;
                    Graphics graph = Graphics.FromImage(tempImage);
                    using (Pen pen = new Pen(Color.FromArgb(255, 0, 0), 2))
                    {
                        graph.DrawRectangle(pen, objectRect);
                    }
                    graph.Dispose();
                }
        }

        private void buttonYCbCrTrack_Click(object sender, EventArgs e)
        {
            if (YCbCrImage == null) return;
            Bitmap tempImage = new Bitmap(sourceImage);
            pictureBoxYCbCr.Image = tempImage;
            BlobCounter bc = new BlobCounter();
            bc.MinHeight = 5;
            bc.MinWidth = 5;
            bc.FilterBlobs = true;
            bc.ObjectsOrder = ObjectsOrder.Area;
            bc.ProcessImage(YCbCrImage);
            Rectangle[] rects = bc.GetObjectsRectangles();
            foreach (Rectangle recs in rects)
                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0]; //= recs;
                    Graphics graph = Graphics.FromImage(tempImage);
                    using (Pen pen = new Pen(Color.FromArgb(255, 0, 0), 2))
                    {
                        graph.DrawRectangle(pen, objectRect);
                    }
                    graph.Dispose();
                }
        }

        private void buttonRGBreset_Click(object sender, EventArgs e)
        {
            pictureBoxRGB.Image = sourceImage;
            trackBarReset(true, false, false);
            labelReset(true, false, false);
        }

        private void buttonHSLreset_Click(object sender, EventArgs e)
        {
            pictureBoxHSL.Image = sourceImage;
            trackBarReset(false, true, false);
            labelReset(false, true, false);
        }

        private void buttonYCbCrReset_Click(object sender, EventArgs e)
        {
            pictureBoxYCbCr.Image = sourceImage;
            trackBarReset(false, false, true);
            labelReset(false, false, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trackBarGmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarGmax.Value - trackBarGmin.Value <= TRACK_SPACE)
                trackBarGmin.Value = trackBarGmax.Value - TRACK_SPACE;
            Gmin = trackBarGmin.Value;
            labelGmin.Text = string.Format("GMin : {0}", Gmin);
            RGBFiltering(sourceImage);
        }

        private void trackBarGmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarGmax.Value - trackBarGmin.Value <= TRACK_SPACE)
                trackBarGmax.Value = trackBarGmin.Value + TRACK_SPACE;
            Gmax = trackBarGmax.Value;
            labelGmax.Text = string.Format("GMax : {0}", Gmax);
            RGBFiltering(sourceImage);
        }

        private void trackBarBmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarBmax.Value - trackBarBmin.Value <= TRACK_SPACE)
                trackBarBmax.Value = trackBarBmin.Value + TRACK_SPACE;
            Bmax = trackBarBmax.Value;
            labelBmax.Text = string.Format("BMax : {0}", Bmax);
            RGBFiltering(sourceImage);
        }

        private void trackBarBmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarBmax.Value - trackBarBmin.Value <= TRACK_SPACE)
                trackBarBmin.Value = trackBarBmax.Value - TRACK_SPACE;
            Bmin = trackBarBmin.Value;
            labelBmin.Text = string.Format("BMin : {0}", Bmin);
            RGBFiltering(sourceImage);
        }

        private void trackBarSmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarSmax.Value - trackBarSmin.Value <= TRACK_SPACE)
                trackBarSmax.Value = trackBarSmin.Value + TRACK_SPACE;
            Smax = (float)trackBarSmax.Value / 100;
            labelSmax.Text = string.Format("SMax : {0}", Smax);
            HSLFiltering(sourceImage);
        }

        private void trackBarLmin_Scroll(object sender, EventArgs e)
        {
            if (trackBarLmax.Value - trackBarLmin.Value <= TRACK_SPACE)
                trackBarLmin.Value = trackBarLmax.Value - TRACK_SPACE;
            Lmin = (float)trackBarLmin.Value / 100;
            labelLmin.Text = string.Format("LMin : {0}", Lmin);
            HSLFiltering(sourceImage);
        }

        private void trackBarLmax_Scroll(object sender, EventArgs e)
        {
            if (trackBarLmax.Value - trackBarLmin.Value <= TRACK_SPACE)
                trackBarLmax.Value = trackBarLmin.Value + TRACK_SPACE;
            Lmax = (float)trackBarLmax.Value / 100;
            labelLmax.Text = string.Format("LMax : {0}", Lmax);
            HSLFiltering(sourceImage);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            //trackbar init
            trackBarInit();
            trackBarReset(true, true, true);
            trackBarEnable(false);
            //fullscreen display
            WindowState = FormWindowState.Maximized;
        }

        private void trackBarInit()
        {
            trackBarYmax.Maximum = 100;
            trackBarYmin.Maximum = 100;
            trackBarCbmax.Maximum = 50;
            trackBarCbmax.Minimum = -50;
            trackBarCbmin.Maximum = 50;
            trackBarCbmin.Minimum = -50;
            trackBarCrmax.Maximum = 50;
            trackBarCrmax.Minimum = -50;
            trackBarCrmin.Maximum = 50;
            trackBarCrmin.Minimum = -50;
            trackBarHmin.Maximum = 360;
            trackBarHmax.Maximum = 360;
            trackBarSmax.Maximum = 100;
            trackBarSmin.Maximum = 100;
            trackBarLmax.Maximum = 100;
            trackBarLmin.Maximum = 100;
            trackBarRmax.Maximum = 255;
            trackBarRmin.Maximum = 255;
            trackBarGmax.Maximum = 255;
            trackBarGmin.Maximum = 255;
            trackBarBmax.Maximum = 255;
            trackBarBmin.Maximum = 255;
        }

        private void trackBarReset(bool RGB, Boolean HSL, bool YCbCr)
        {
            // RGB trackbar reset
            if (RGB)
            {
                trackBarRmax.Value = 255;
                trackBarRmin.Value = 0;
                trackBarGmax.Value = 255;
                trackBarGmin.Value = 0;
                trackBarBmax.Value = 255;
                trackBarBmin.Value = 0;
                Rmin = 0; Rmax = 255;
                Gmin = 0; Gmax = 255;
                Bmin = 0; Bmax = 255;
            }

            //YCbCr trackbar reset
            if (YCbCr)
            {
                trackBarYmax.Value = 100;
                trackBarYmin.Value = 0;
                trackBarCbmax.Value = 50;
                trackBarCbmin.Value = -50;
                trackBarCrmax.Value = 50;
                trackBarCrmin.Value = -50;
                Ymin = (float)trackBarYmin.Value / 100;
                Ymax = (float)trackBarYmax.Value / 100;
                Crmin = (float)trackBarCrmin.Value / 100;
                Crmax = (float)trackBarCrmax.Value / 100;
                Cbmin = (float)trackBarCbmin.Value / 100;
                Cbmax = (float)trackBarCbmax.Value / 100;
            }

            // HSL trackbar
            if (HSL)
            {
                trackBarHmax.Value = 360;
                trackBarHmin.Value = 0;
                trackBarSmax.Value = 100;
                trackBarSmin.Value = 0;
                trackBarLmax.Value = 100;
                trackBarLmin.Value = 0;
                Hmin = trackBarHmin.Value;
                Hmax = trackBarHmax.Value;
                Smin = (float)trackBarSmin.Value / 100;
                Smax = (float)trackBarSmax.Value / 100;
                Lmin = (float)trackBarLmin.Value / 100;
                Lmax = (float)trackBarLmax.Value / 100;
            }
        }

        // trackbar enable
        private void trackBarEnable(bool enable = true)
        {
            //HSL tracbar Enable
            trackBarHmax.Enabled = enable;
            trackBarHmin.Enabled = enable;
            trackBarSmax.Enabled = enable;
            trackBarSmin.Enabled = enable;
            trackBarLmax.Enabled = enable;
            trackBarLmin.Enabled = enable;
            //RGB trackbar Enable
            trackBarRmax.Enabled = enable;
            trackBarRmin.Enabled = enable;
            trackBarGmax.Enabled = enable;
            trackBarGmin.Enabled = enable;
            trackBarBmax.Enabled = enable;
            trackBarBmin.Enabled = enable;
            //YCbCr trackbar disable
            trackBarYmax.Enabled = enable;
            trackBarYmin.Enabled = enable;
            trackBarCbmax.Enabled = enable;
            trackBarCbmin.Enabled = enable;
            trackBarCrmax.Enabled = enable;
            trackBarCrmin.Enabled = enable;
            buttonHSLreset.Enabled = enable;
            buttonRGBreset.Enabled = enable;
            buttonYCbCrReset.Enabled = enable;
        }

        //Reseting Label
        private void labelReset(bool RGB, bool HSL, bool YCbCr)
        {
            //HSL label reset
            if (HSL)
            {
                labelHmax.Text = string.Format("HueMax : {0}", trackBarHmax.Value);
                labelHmin.Text = string.Format("HueMin : {0}", trackBarHmin.Value);
                labelSmin.Text = string.Format("SMin : {0}", (float)trackBarSmin.Value / 100);
                labelSmax.Text = string.Format("SMax : {0}", (float)trackBarSmax.Value / 100);
                labelLmax.Text = string.Format("LumMax : {0}", (float)trackBarLmax.Value / 100);
                labelLmin.Text = string.Format("LumMin : {0}", (float)trackBarLmin.Value / 100);
            }
            //RGB label reset
            if (RGB)
            {
                labelRmax.Text = string.Format("RMax : {0}", trackBarRmax.Value);
                labelRmin.Text = string.Format("RMin : {0}", trackBarRmin.Value);
                labelGmax.Text = string.Format("GMax : {0}", trackBarGmax.Value);
                labelGmin.Text = string.Format("Gmin : {0}", trackBarGmin.Value);
                labelBmax.Text = string.Format("Bmax : {0}", trackBarBmax.Value);
                labelBmin.Text = string.Format("Bmin : {0}", trackBarBmin.Value);
            }
            //YCbCr label reset
            if (YCbCr)
            {
                labelYmax.Text = string.Format("Ymax : {0}", (float)trackBarYmax.Value / 100);
                labelYmin.Text = string.Format("Ymin : {0}", (float)trackBarYmin.Value / 100);
                labelCbmax.Text = string.Format("Cbmax : {0}", (float)trackBarCbmax.Value / 100);
                labelCbmin.Text = string.Format("Cbmin : {0}", (float)trackBarCbmin.Value / 100);
                labelCrmax.Text = string.Format("Crmax : {0}", (float)trackBarCrmax.Value / 100);
                labelCrmin.Text = string.Format("Crmin : {0}", (float)trackBarCrmin.Value / 100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceImage = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBoxOri.Image = sourceImage;
                pictureBoxHSL.Image = sourceImage;
                pictureBoxRGB.Image = sourceImage;
                pictureBoxYCbCr.Image = sourceImage;
                trackBarReset(true, true, true);
                labelReset(true, true, true);
                trackBarEnable();
            }
        }


        private void RGBFiltering(Bitmap srcImage)
        {
            // create filter
            ColorFiltering filter = new ColorFiltering();
            // set color ranges to keep
            filter.Red = new IntRange(Rmin, Rmax);
            filter.Green = new IntRange(Gmin, Gmax);
            filter.Blue = new IntRange(Bmin, Bmax);
            // apply the filter
            RGBImage = filter.Apply(sourceImage);
            pictureBoxRGB.Image = RGBImage;
        }


        private void YCbCrFiltering(Bitmap srcImage)
        {
            // create filter
            YCbCrFiltering filter = new YCbCrFiltering();
            // set color ranges to keep
            filter.Y = new Range(Ymin, Ymax);
            filter.Cb = new Range(Cbmin, Cbmax);
            filter.Cr = new Range(Crmin, Crmax);
            YCbCrImage = filter.Apply(sourceImage);
            //draw the picture
            pictureBoxYCbCr.Image = YCbCrImage;
        }


        private void HSLFiltering(Bitmap sourceImage)
        {
            // create filter
            HSLFiltering filter = new HSLFiltering();
            filter.Hue = new IntRange(Hmin, Hmax);
            filter.Saturation = new Range(Smin, Smax);
            filter.Luminance = new Range(Lmin, Lmax);
            // apply the filter
            HSLImage = filter.Apply(sourceImage);
            pictureBoxHSL.Image = HSLImage;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBarRmax.Value - trackBarRmin.Value <= TRACK_SPACE)
                trackBarRmin.Value = trackBarRmax.Value - TRACK_SPACE;
            Rmin = trackBarRmin.Value;
            labelRmin.Text = string.Format("RMin : {0}", Rmin);
            RGBFiltering(sourceImage);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBarRmax.Value - trackBarRmin.Value <= TRACK_SPACE)
                trackBarRmax.Value = trackBarRmin.Value + TRACK_SPACE;
            Rmax = trackBarRmax.Value;
            labelRmax.Text = string.Format("RMax : {0}", Rmax);
            RGBFiltering(sourceImage);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
