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
            this.SuspendLayout();
            // 
            // frmTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProblemJasiaRetro.Properties.Resources.title_336x240;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1279, 769);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTitle";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Problem Jasia Retro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTitle_FormClosing);
            this.Shown += new System.EventHandler(this.frmTitle_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTitle_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
    }
}