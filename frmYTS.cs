using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
namespace PlayerUI
{
    public partial class frmYTS : Form
    {
        public frmYTS()
        {
            InitializeComponent();
        }

        private void FrmYTS_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("https://yts.mx/");
        }
    }
}
