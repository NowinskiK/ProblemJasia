using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
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

        //https://stackoverflow.com/questions/2104099/c-sharp-if-then-directives-for-debug-vs-release
        public static bool isDebugging()
        {
            bool debugging = false;
            WellAreWe(ref debugging);
            return debugging;
        }

        [Conditional("DEBUG")]
        private static void WellAreWe(ref bool debugging)
        {
            debugging = true;
        }

        public static string GetAppVersion()
        {
            Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;
            return appVersion.Major + "." + appVersion.Minor + "." + appVersion.Build;
        }

    }

}
