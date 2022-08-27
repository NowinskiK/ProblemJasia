using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemJasiaRetro
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmTitle f;
            do
            {
                f = new frmTitle();
                Application.Run(f);
                if (f.DialogResult == DialogResult.OK)
                {
                    Application.Run(new frmGame());
                }
            }
            while (f.DialogResult == DialogResult.OK);
        }
    }
}
