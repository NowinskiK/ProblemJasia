using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemJasiaRetro
{
    public partial class frmTitle : Form
    {

        Music m = new Music();

        double x = 0;
        bool _p = false;


        public frmTitle()
        {
            InitializeComponent();
            txtTestHeight.Font = txtScroll.Font;
            txtScroll.Text = "\r\n\r\n\r\n" + Properties.Resources.TitleScroll.ToUpper();
            int linesCount = txtScroll.Text.Split('\r').Length;
            txtScroll.Height = (int)(txtTestHeight.Height * linesCount * 1.15);
        }

        private void frmTitle_Shown(object sender, EventArgs e)
        {
            m.Play("title", true);
            this.Text += " (version: " + Program.GetAppVersion() + ")";  
        }

        private void frmTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            if (e.KeyChar == (char)13 || e.KeyChar == (char)32)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmTitle_FormClosing(object sender, FormClosingEventArgs e)
        {
            m.player.controls.stop();
        }

        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            _p = !_p;
            if (_p)
            {
                if (txtScroll.Height + txtScroll.Location.Y < 0)
                {
                    txtScroll.Location = new Point(txtScroll.Location.X, 0);
                }
                else
                {
                    txtScroll.Location = new Point(txtScroll.Location.X, txtScroll.Location.Y - 1);
                }
            }

            //Roll of film movement
            double posX = (Math.Sin(x) + 1d) / 2d;
            double minBoundary = 20d;
            double maxBoundary = this.Width - picFilmRoll.Width - 30d;
            int locX = (int)(posX * (maxBoundary - minBoundary) + minBoundary);
            int newY = picFilmRoll.Location.Y - 4;
            if (newY + this.Height < 0) { newY = 0; }
            picFilmRoll.Location = new Point(locX, newY);
            x = x + (Math.PI * 2 / 100);
            x = x % (Math.PI * 2);
        }

    }
}
