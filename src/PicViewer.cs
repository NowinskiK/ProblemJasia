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
    public partial class PicViewer : Form
    {
        public PicViewer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(128, 160);
            string file = @"d:\GitHub\NowinskiK\ProblemJasia\images\original\pic" + trackBar1.Value.ToString("00") + ".dat";
            byte[] buffer = System.IO.File.ReadAllBytes(file);
            Color c = new Color();
            int x = 0;
            int y = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                byte b = buffer[i];
                for (int bt = 0; bt < 4; bt++)
                {
                    int col = ((b >> (6 - bt * 2)) & 3);
                    if (col == 0) { col = 16; }
                    if (col == 2) { col = 98; }
                    if (col == 1) { col = 153; }
                    if (col == 3) { col = 214; }
                    c = Color.FromArgb(col, col, col);
                    bmp.SetPixel(x, y, c);
                    bmp.SetPixel(x+1, y, c);
                    x=x+2;
                    if (x == bmp.Width) { x = 0; y++; }
                }
            }

            Bitmap destbmp = new Bitmap(bmp, new Size(128 * 4, 160 * 4));
            pictureBox1.Image = destbmp;
            //targetFile = file.Replace(".dat", "_512px.png");
            //destbmp.Save(targetFile, System.Drawing.Imaging.ImageFormat.Png);
            string targetFile = file.Replace(".dat", ".png");
            bmp.Save(targetFile, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
