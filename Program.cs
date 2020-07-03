using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    static class Program
    {
        /// <summary>
     
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                Application.Run(new SplashScreen(""));

            }
            else
            {
                Application.Run(new SplashScreen(args[0]));

            }

        }
    }
}
