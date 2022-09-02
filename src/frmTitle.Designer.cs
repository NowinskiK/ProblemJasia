namespace ProblemJasiaRetro
{
    partial class frmTitle
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtScroll = new System.Windows.Forms.TextBox();
            this.scrollTimer = new System.Windows.Forms.Timer(this.components);
            this.txtTestHeight = new System.Windows.Forms.TextBox();
            this.picFilmRoll = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilmRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.txtScroll);
            this.panel1.Location = new System.Drawing.Point(0, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 120);
            this.panel1.TabIndex = 0;
            // 
            // txtScroll
            // 
            this.txtScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtScroll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtScroll.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtScroll.Font = new System.Drawing.Font("Cascadia Code", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScroll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(255)))), ((int)(((byte)(168)))));
            this.txtScroll.Location = new System.Drawing.Point(0, 0);
            this.txtScroll.Multiline = true;
            this.txtScroll.Name = "txtScroll";
            this.txtScroll.ReadOnly = true;
            this.txtScroll.ShortcutsEnabled = false;
            this.txtScroll.Size = new System.Drawing.Size(1095, 87);
            this.txtScroll.TabIndex = 0;
            this.txtScroll.TabStop = false;
            this.txtScroll.Text = "TEST TEST Zażółć";
            this.txtScroll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtScroll.WordWrap = false;
            // 
            // scrollTimer
            // 
            this.scrollTimer.Enabled = true;
            this.scrollTimer.Interval = 30;
            this.scrollTimer.Tick += new System.EventHandler(this.scrollTimer_Tick);
            // 
            // txtTestHeight
            // 
            this.txtTestHeight.BackColor = System.Drawing.Color.Black;
            this.txtTestHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTestHeight.Font = new System.Drawing.Font("Cascadia Code", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(255)))), ((int)(((byte)(168)))));
            this.txtTestHeight.Location = new System.Drawing.Point(857, 732);
            this.txtTestHeight.Name = "txtTestHeight";
            this.txtTestHeight.ShortcutsEnabled = false;
            this.txtTestHeight.Size = new System.Drawing.Size(238, 34);
            this.txtTestHeight.TabIndex = 1;
            this.txtTestHeight.Text = "TEST TEST";
            this.txtTestHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTestHeight.Visible = false;
            // 
            // picFilmRoll
            // 
            this.picFilmRoll.BackColor = System.Drawing.Color.Black;
            this.picFilmRoll.BackgroundImage = global::ProblemJasiaRetro.Properties.Resources.film_roll1;
            this.picFilmRoll.Enabled = false;
            this.picFilmRoll.Location = new System.Drawing.Point(32, 0);
            this.picFilmRoll.Name = "picFilmRoll";
            this.picFilmRoll.Size = new System.Drawing.Size(80, 2000);
            this.picFilmRoll.TabIndex = 2;
            this.picFilmRoll.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Transparent;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(217)))), ((int)(((byte)(109)))));
            this.textBox1.Location = new System.Drawing.Point(12, 243);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1072, 38);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "GRAFIKA, MUZYKA: JAKUB HUSAK";
            this.textBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.Transparent;
            this.textBox2.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(217)))), ((int)(((byte)(109)))));
            this.textBox2.Location = new System.Drawing.Point(12, 284);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1072, 38);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "KODOWANIE (PC EDITION): KAMIL NOWINSKI";
            this.textBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.textBox3.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(202)))), ((int)(((byte)(131)))));
            this.textBox3.Location = new System.Drawing.Point(12, 483);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(1072, 38);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "ENTER - START GRY";
            this.textBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.pictureBox1.Image = global::ProblemJasiaRetro.Properties.Resources.PJ_title_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1095, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.pictureBox2.Image = global::ProblemJasiaRetro.Properties.Resources.PJ_Mirage_logo;
            this.pictureBox2.Location = new System.Drawing.Point(19, 605);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1065, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // frmTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1096, 769);
            this.Controls.Add(this.txtTestHeight);
            this.Controls.Add(this.picFilmRoll);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(335, 232);
            this.Name = "frmTitle";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Problem Jasia Retro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTitle_FormClosing);
            this.Shown += new System.EventHandler(this.frmTitle_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTitle_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilmRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtScroll;
        private System.Windows.Forms.Timer scrollTimer;
        private System.Windows.Forms.TextBox txtTestHeight;
        private System.Windows.Forms.PictureBox picFilmRoll;
        private System.Windows.Forms.Label textBox1;
        private System.Windows.Forms.Label textBox2;
        private System.Windows.Forms.Label textBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}