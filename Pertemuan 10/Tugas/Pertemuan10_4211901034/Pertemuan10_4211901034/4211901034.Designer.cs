namespace Pertemuan10_4211901034
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.pictureBox1 = new AForge.Controls.PictureBox();
            this.pictureBox2 = new AForge.Controls.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelBmax = new System.Windows.Forms.Label();
            this.labelGmax = new System.Windows.Forms.Label();
            this.labelRmax = new System.Windows.Forms.Label();
            this.labelBmin = new System.Windows.Forms.Label();
            this.labelGmin = new System.Windows.Forms.Label();
            this.labelRmin = new System.Windows.Forms.Label();
            this.trackBarBmax = new System.Windows.Forms.TrackBar();
            this.trackBarGmax = new System.Windows.Forms.TrackBar();
            this.trackBarRmax = new System.Windows.Forms.TrackBar();
            this.trackBarBmin = new System.Windows.Forms.TrackBar();
            this.trackBarGmin = new System.Windows.Forms.TrackBar();
            this.trackBarRmin = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRmin)).BeginInit();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(12, 42);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(320, 200);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = null;
            this.pictureBox1.Location = new System.Drawing.Point(348, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = null;
            this.pictureBox2.Location = new System.Drawing.Point(684, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 217);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Capture";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(188, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 30);
            this.button4.TabIndex = 4;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 124);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Camera Setting";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelBmax);
            this.groupBox2.Controls.Add(this.labelGmax);
            this.groupBox2.Controls.Add(this.labelRmax);
            this.groupBox2.Controls.Add(this.labelBmin);
            this.groupBox2.Controls.Add(this.labelGmin);
            this.groupBox2.Controls.Add(this.labelRmin);
            this.groupBox2.Controls.Add(this.trackBarBmax);
            this.groupBox2.Controls.Add(this.trackBarGmax);
            this.groupBox2.Controls.Add(this.trackBarRmax);
            this.groupBox2.Controls.Add(this.trackBarBmin);
            this.groupBox2.Controls.Add(this.trackBarGmin);
            this.groupBox2.Controls.Add(this.trackBarRmin);
            this.groupBox2.Location = new System.Drawing.Point(348, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 217);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RGB Image Detection";
            // 
            // labelBmax
            // 
            this.labelBmax.AutoSize = true;
            this.labelBmax.Location = new System.Drawing.Point(186, 139);
            this.labelBmax.Name = "labelBmax";
            this.labelBmax.Size = new System.Drawing.Size(46, 13);
            this.labelBmax.TabIndex = 11;
            this.labelBmax.Text = "BMax: 0";
            // 
            // labelGmax
            // 
            this.labelGmax.AutoSize = true;
            this.labelGmax.Location = new System.Drawing.Point(186, 84);
            this.labelGmax.Name = "labelGmax";
            this.labelGmax.Size = new System.Drawing.Size(47, 13);
            this.labelGmax.TabIndex = 10;
            this.labelGmax.Text = "GMax: 0";
            // 
            // labelRmax
            // 
            this.labelRmax.AutoSize = true;
            this.labelRmax.Location = new System.Drawing.Point(186, 28);
            this.labelRmax.Name = "labelRmax";
            this.labelRmax.Size = new System.Drawing.Size(47, 13);
            this.labelRmax.TabIndex = 9;
            this.labelRmax.Text = "RMax: 0";
            // 
            // labelBmin
            // 
            this.labelBmin.AutoSize = true;
            this.labelBmin.Location = new System.Drawing.Point(13, 139);
            this.labelBmin.Name = "labelBmin";
            this.labelBmin.Size = new System.Drawing.Size(43, 13);
            this.labelBmin.TabIndex = 8;
            this.labelBmin.Text = "BMin: 0";
            // 
            // labelGmin
            // 
            this.labelGmin.AutoSize = true;
            this.labelGmin.Location = new System.Drawing.Point(13, 84);
            this.labelGmin.Name = "labelGmin";
            this.labelGmin.Size = new System.Drawing.Size(44, 13);
            this.labelGmin.TabIndex = 7;
            this.labelGmin.Text = "GMin: 0";
            // 
            // labelRmin
            // 
            this.labelRmin.AutoSize = true;
            this.labelRmin.Location = new System.Drawing.Point(13, 28);
            this.labelRmin.Name = "labelRmin";
            this.labelRmin.Size = new System.Drawing.Size(44, 13);
            this.labelRmin.TabIndex = 6;
            this.labelRmin.Text = "RMin: 0";
            // 
            // trackBarBmax
            // 
            this.trackBarBmax.Location = new System.Drawing.Point(180, 153);
            this.trackBarBmax.Name = "trackBarBmax";
            this.trackBarBmax.Size = new System.Drawing.Size(140, 45);
            this.trackBarBmax.TabIndex = 5;
            this.trackBarBmax.Scroll += new System.EventHandler(this.trackBarBmax_Scroll);
            // 
            // trackBarGmax
            // 
            this.trackBarGmax.Location = new System.Drawing.Point(180, 98);
            this.trackBarGmax.Name = "trackBarGmax";
            this.trackBarGmax.Size = new System.Drawing.Size(140, 45);
            this.trackBarGmax.TabIndex = 4;
            this.trackBarGmax.Scroll += new System.EventHandler(this.trackBarGmax_Scroll);
            // 
            // trackBarRmax
            // 
            this.trackBarRmax.Location = new System.Drawing.Point(180, 42);
            this.trackBarRmax.Name = "trackBarRmax";
            this.trackBarRmax.Size = new System.Drawing.Size(140, 45);
            this.trackBarRmax.TabIndex = 3;
            this.trackBarRmax.Scroll += new System.EventHandler(this.trackBarRmax_Scroll);
            // 
            // trackBarBmin
            // 
            this.trackBarBmin.Location = new System.Drawing.Point(7, 153);
            this.trackBarBmin.Name = "trackBarBmin";
            this.trackBarBmin.Size = new System.Drawing.Size(140, 45);
            this.trackBarBmin.TabIndex = 2;
            this.trackBarBmin.Scroll += new System.EventHandler(this.trackBarBmin_Scroll);
            // 
            // trackBarGmin
            // 
            this.trackBarGmin.Location = new System.Drawing.Point(7, 98);
            this.trackBarGmin.Name = "trackBarGmin";
            this.trackBarGmin.Size = new System.Drawing.Size(140, 45);
            this.trackBarGmin.TabIndex = 1;
            this.trackBarGmin.Scroll += new System.EventHandler(this.trackBarGmin_Scroll);
            // 
            // trackBarRmin
            // 
            this.trackBarRmin.Location = new System.Drawing.Point(7, 42);
            this.trackBarRmin.Name = "trackBarRmin";
            this.trackBarRmin.Size = new System.Drawing.Size(140, 45);
            this.trackBarRmin.TabIndex = 0;
            this.trackBarRmin.Scroll += new System.EventHandler(this.trackBarRmin_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Webcam";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(345, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Detected Image";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(681, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tracked Image";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 478);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Name = "Form1";
            this.Text = "4211901034_Ricky Silitonga";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private AForge.Controls.PictureBox pictureBox1;
        private AForge.Controls.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelBmax;
        private System.Windows.Forms.Label labelGmax;
        private System.Windows.Forms.Label labelRmax;
        private System.Windows.Forms.Label labelBmin;
        private System.Windows.Forms.Label labelGmin;
        private System.Windows.Forms.Label labelRmin;
        private System.Windows.Forms.TrackBar trackBarBmax;
        private System.Windows.Forms.TrackBar trackBarGmax;
        private System.Windows.Forms.TrackBar trackBarRmax;
        private System.Windows.Forms.TrackBar trackBarBmin;
        private System.Windows.Forms.TrackBar trackBarGmin;
        private System.Windows.Forms.TrackBar trackBarRmin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

