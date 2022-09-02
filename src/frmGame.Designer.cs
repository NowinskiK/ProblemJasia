namespace ProblemJasiaRetro
{
    partial class frmGame
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
        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Form1
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(1194, 624);
        //    this.Name = "Form1";
        //    this.Text = "Form1";
        //    this.ResumeLayout(false);

        //}

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.selector = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picRedArrow = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.bombTimer = new System.Windows.Forms.Timer(this.components);
            this.lblDebug = new System.Windows.Forms.Label();
            this.scrollTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblScroll = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRedArrow)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // selector
            // 
            this.selector.BackColor = System.Drawing.Color.Transparent;
            this.selector.Image = global::ProblemJasiaRetro.Properties.Resources.selector;
            this.selector.Location = new System.Drawing.Point(709, 98);
            this.selector.Name = "selector";
            this.selector.Size = new System.Drawing.Size(128, 128);
            this.selector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selector.TabIndex = 0;
            this.selector.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Location = new System.Drawing.Point(464, 495);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 28);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // picRedArrow
            // 
            this.picRedArrow.BackColor = System.Drawing.Color.Transparent;
            this.picRedArrow.Image = global::ProblemJasiaRetro.Properties.Resources.red_arrow;
            this.picRedArrow.ImageLocation = "";
            this.picRedArrow.Location = new System.Drawing.Point(543, 95);
            this.picRedArrow.Name = "picRedArrow";
            this.picRedArrow.Size = new System.Drawing.Size(128, 128);
            this.picRedArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRedArrow.TabIndex = 5;
            this.picRedArrow.TabStop = false;
            this.picRedArrow.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.BackColor = System.Drawing.Color.Transparent;
            this.lblMinutes.Font = new System.Drawing.Font("Montserrat ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.ForeColor = System.Drawing.Color.White;
            this.lblMinutes.Location = new System.Drawing.Point(225, 572);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(30, 33);
            this.lblMinutes.TabIndex = 6;
            this.lblMinutes.Text = "5";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.BackColor = System.Drawing.Color.Transparent;
            this.lblSeconds.Font = new System.Drawing.Font("Montserrat ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.White;
            this.lblSeconds.Location = new System.Drawing.Point(294, 572);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(47, 33);
            this.lblSeconds.TabIndex = 7;
            this.lblSeconds.Text = "00";
            // 
            // bombTimer
            // 
            this.bombTimer.Tick += new System.EventHandler(this.bombTimer_Tick);
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.BackColor = System.Drawing.Color.Transparent;
            this.lblDebug.Font = new System.Drawing.Font("Montserrat ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebug.ForeColor = System.Drawing.Color.White;
            this.lblDebug.Location = new System.Drawing.Point(250, 633);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(24, 33);
            this.lblDebug.TabIndex = 8;
            this.lblDebug.Text = "-";
            // 
            // scrollTimer
            // 
            this.scrollTimer.Enabled = true;
            this.scrollTimer.Interval = 25;
            this.scrollTimer.Tick += new System.EventHandler(this.scrollTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lblScroll);
            this.panel2.Location = new System.Drawing.Point(63, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 33);
            this.panel2.TabIndex = 100;
            // 
            // lblScroll
            // 
            this.lblScroll.AutoSize = true;
            this.lblScroll.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScroll.ForeColor = System.Drawing.Color.White;
            this.lblScroll.Location = new System.Drawing.Point(3, 0);
            this.lblScroll.Name = "lblScroll";
            this.lblScroll.Size = new System.Drawing.Size(0, 32);
            this.lblScroll.TabIndex = 0;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProblemJasiaRetro.Properties.Resources.background_1280px;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1274, 766);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.selector);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.picRedArrow);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Problem Jasia Retro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGame_FormClosing);
            this.Shown += new System.EventHandler(this.frmGame_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGame_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmGame_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.selector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRedArrow)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox selector;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picRedArrow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Timer bombTimer;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Timer scrollTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblScroll;
    }
}

