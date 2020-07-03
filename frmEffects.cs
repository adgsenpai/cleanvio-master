using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class frmEffects : Form
    {
        public frmEffects()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:sound");
        }

        private void FrmEffects_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.Text = "EFFECTS";
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            frmProfanity frm = new frmProfanity();
            frm.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmProfanity frm = new frmProfanity();
            frm.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:display");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:videoplayback");
        }

        private void FrmEffects_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain frm = new frmMain("");
            frm.Show();
        }
    }
}
