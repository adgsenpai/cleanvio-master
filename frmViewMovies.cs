using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class frmViewMovies : Form
    {
        public bool bMainOpen = true;
        public List<string> movd = new List<string>();
        public List<String> files = new List<String>();
        public frmViewMovies()
        {
            InitializeComponent();
        }

        private void FrmViewMovies_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            if (Directory.Exists(strWorkPath+ @"\CLEANVIDMOVIES") == true)
            {

               

                string path = strWorkPath + @"\CLEANVIDMOVIES";
                MovieSearch(path);

                movd = files.Distinct().ToList();

         

            }
            else
            {
                listBox1.Items.Clear();

            }
        }

     
        private List<String> MovieSearch(string sDir)
        {
           
            try
            {
                int c = 0;
                foreach (string f in Directory.GetFiles(sDir))
                {

                    files.Add(f);
                    if (Path.GetExtension(f) == ".mp4" ^ Path.GetExtension(f) == ".mkv" ^ Path.GetExtension(f) == ".avi" ^ Path.GetExtension(f) == ".mpeg" ^ Path.GetExtension(f) == ".webm" ^ Path.GetExtension(f) == ".mov" ^ Path.GetExtension(f) == ".flv")
                    {
                      
                        
                        listBox1.Items.Add(Path.GetFileName(f));

                    }

                }
                foreach (string d in Directory.GetDirectories(sDir, "*", SearchOption.AllDirectories))
                {
                  files.AddRange(MovieSearch(d));

                }
               
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
  
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string path = movd.ElementAt(index);
            frmMain frm = new frmMain(path);
            frm.Show();
            bMainOpen = false;
            this.Close();






        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string path = movd.ElementAt(index);
            frmMain frm = new frmMain(path);
            frm.Show();
            bMainOpen = false;
            this.Close();

        }

        private void FrmViewMovies_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bMainOpen == false)
            {
               
            }
            else
            {
                frmMain frm = new frmMain("");
                frm.Show();
            }
           
        }
    }
}
