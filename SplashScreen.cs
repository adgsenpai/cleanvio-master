using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class SplashScreen : Form
    {
        private double i;
        public string path;
        public SplashScreen(string input)
        {
            InitializeComponent();
            path = input;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            i += 0.05;
            if (i >= 1)
            {//if form is fully visible, we execute the Fade Out Effect
                this.Opacity = 1;
                timerFadeIn.Enabled = false;//stop the Fade In Effect
                timerFadeOut.Enabled = true;//start the Fade Out Effect
                return;
            }
            this.Opacity = i;
        }

        private void TimerFadeOut_Tick(object sender, EventArgs e)
        {

            Thread.Sleep(2000);
            i -= 0.05;
            if (i <= 0.01)
            {//if form is invisible, we execute the Fade In Effect again
                this.Opacity = 0.0;
                timerFadeIn.Enabled = true;//start the Fade In Effect
                timerFadeOut.Enabled = false;//stop the Fade Out Effect
                return;
            }
            this.Opacity = i;
            if (path == "")
            {
                frmMain form3 = new frmMain("");
               
                form3.Show();
            }
            else
            {
                frmMain form3 = new frmMain(path);
              
                form3.Show();

            }
          
            this.Visible = false;
            timerFadeIn.Enabled = false;
            timerFadeOut.Enabled = false;
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            timerFadeIn.Enabled = true;//Enable the timerFadeIn to start Fade In Effect
            timerFadeOut.Enabled = false;
        }
    }
}
