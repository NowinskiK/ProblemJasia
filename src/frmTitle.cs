using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemJasiaRetro
{
    public partial class frmTitle : Form
    {

        Music m = new Music();


        public frmTitle()
        {
            InitializeComponent();
        }

        private void frmTitle_Shown(object sender, EventArgs e)
        {
            m.Play("title");
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
    }
}
