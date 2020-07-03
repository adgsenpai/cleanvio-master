//Ashlin Darius Govindasamy 


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace PlayerUI
{

    public partial class frmMain : Form
    {
        public string path;
        public static bool bClose = false;
        public void EndApp(bool uClose)
        {
            bClose = uClose;
        }

        public frmMain(string fn)
        {
            InitializeComponent();
            hideSubMenu();
            path = fn;

        }

        private void hideSubMenu()
        {
            panelMediaSubMenu.Visible = false;

            panelToolsSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMediaSubMenu);


        }

        #region MediaSubMenu
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
            axVLCPlugin21.playlist.items.clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axVLCPlugin21.playlist.add(@"file:///" + openFileDialog1.FileName, openFileDialog1.SafeFileName, null);
                axVLCPlugin21.playlist.next();
                axVLCPlugin21.playlist.play();

                int Length = (axVLCPlugin21.volume / 100) * 200;
                pnlT.Width = Length;
                pnlSound.Visible = true;
                lblVol.Text = axVLCPlugin21.volume.ToString();
                pnlT.Visible = true;

                pictureBox2.Tag = "Pause";
                pictureBox2.Image = PlayerUI.Properties.Resources._16427;
                pictureBox2.Refresh();
                this.Text = "CLEANVIO - Now Playing " + openFileDialog1.FileName;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {

        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelToolsSubMenu);
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            var screensize = Screen.PrimaryScreen.Bounds;
            var programsize = Bounds;

            string url = Microsoft.VisualBasic.Interaction.InputBox("Type in link to stream from website", "CLEANVIO", "", 100, 200);
            if (url == "")
            {

            }
            else
            {
                axVLCPlugin21.playlist.add(url);

            }
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {


            bClose = true;
            this.Close();
            frmEffects frm = new frmEffects();
            frm.Show();
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To be added soon");
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            hideSubMenu();
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ashlin Darius Govindasamy, (c) ADG STUDIOS 2020");
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        public void PlayVideo(string Path)
        {
            axVLCPlugin21.playlist.items.clear();
            axVLCPlugin21.playlist.add("file:///" + path, null);
            axVLCPlugin21.playlist.next();
            axVLCPlugin21.playlist.play();



        }
        public void SetTheme(string Colour)
        {
            if (Colour == "Light" ^ Colour == "Dark")
            {
                if (Colour == "Light")
                {
                    //White

                }
                else
                {
                    //DARK MODE  //11, 7, 17
               

                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           
            axVLCPlugin21.Branding = false;

            if (File.Exists(path))
            {
                axVLCPlugin21.playlist.add("file:///"+path, null);
                axVLCPlugin21.playlist.play();


            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bClose == false)
            {
                Application.Exit();
            }
            else
            {

            }
            
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Panel4_MouseClick(object sender, MouseEventArgs e)
        {
            //1331 max
            //1132 min

            //location 389, 42
            //size of pnl
            //200, 5 length , breath

            int X = Cursor.Position.X;

            double cal;

            cal = ((X - 1132) *100d) / (1331-1132);
            lblVol.Text = Math.Round(cal).ToString()+"%";

            if (cal>0)
            {
                pnlSound.Visible = true;
            }
            else
            {
                pnlSound.Visible = false;

            }

            double Length = Math.Round(cal)/100 * 200;
            pnlSound.Width = Convert.ToInt32(Length);
           
            axVLCPlugin21.volume = Convert.ToInt32(cal);
        }

  

        private void PnlSound_Click(object sender, EventArgs e)
        {
                //1331 max
                //1132 min

                //location 389, 42
                //size of pnl
                //200, 5 length , breath

                int X = Cursor.Position.X;

                double cal;

                cal = ((X - 1132) * 100d) / (1331 - 1132);
                lblVol.Text = Math.Round(cal).ToString() + "%";

                if (cal > 0)
                {
                    pnlSound.Visible = true;
                }
                else
                {
                    pnlSound.Visible = false;

                }

            double Length = Math.Round(cal) / 100 * 200;
            pnlSound.Width = Convert.ToInt32(Length);
            axVLCPlugin21.volume = Convert.ToInt32(cal);

        }

        private void PanelPlayer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VlcControl1_Click(object sender, EventArgs e)
        {

        }

        private void PnlSound_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.video.toggleFullscreen();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            //size 43, 43
            //size 
           
            if (pictureBox2.Tag.ToString() == "Play")
            {
                axVLCPlugin21.playlist.play();
                pictureBox2.Tag = "Pause";
                pictureBox2.Width = 43;
                pictureBox2.Height = 43;
                pictureBox2.Image = PlayerUI.Properties.Resources._16427;
                pictureBox2.Refresh();
                //pictureBox2.Visible = true;
            }
            else       
            {
                axVLCPlugin21.playlist.pause();
                pictureBox2.Tag = "Play";
                pictureBox2.Width = 43;
                pictureBox2.Height = 43;
                pictureBox2.Image = PlayerUI.Properties.Resources._10_109461_multimedia_music_player_play_button_music_player_play;
                pictureBox2.Refresh();
                //pictureBox2.Visible = true;
            }
           
        }

        private void TmrCount_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(axVLCPlugin21.input.time);
            lblProgress.Text = ts.ToString(@"hh\:mm\:ss");
            ts = TimeSpan.FromMilliseconds(axVLCPlugin21.input.length);
            lblEnd.Text = ts.ToString(@"hh\:mm\:ss");

            pnlT.Visible = true;

            if (axVLCPlugin21.input.time == -1 ^ axVLCPlugin21.input.time == axVLCPlugin21.input.length)
            {

            }
            else
            {
                double len = pnlTrack.Width;
                double cal = 0;
                cal = Math.Round((axVLCPlugin21.input.time / axVLCPlugin21.input.length) * len);
                int length = Convert.ToInt32(cal);
                pnlT.Width = length;


            }


            double cal2;
            cal2 = axVLCPlugin21.audio.volume / 100;


            double Length = Math.Round(cal2) * 200;
            lblVol.Text = axVLCPlugin21.audio.volume.ToString() + '%';
            pnlSound.Visible = true;
            //pnlSound.Width = Convert.ToInt32(Length);
           // MessageBox.Show(Length.ToString());




        }

        private void PnlTrack_Click(object sender, EventArgs e)
        {
    
        }

        private void PnlTrack_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void PnlT_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                if (pictureBox2.Tag.ToString() == "Play")
                {
                    axVLCPlugin21.playlist.play();
                    pictureBox2.Tag = "Pause";
                    pictureBox2.Image = PlayerUI.Properties.Resources._16427;
                    pictureBox2.Refresh();
                    //pictureBox2.Visible = true;
                }
                else
                {
                    axVLCPlugin21.playlist.pause();
                    pictureBox2.Tag = "Play";
                    pictureBox2.Image = PlayerUI.Properties.Resources._10_109461_multimedia_music_player_play_button_music_player_play;
                    pictureBox2.Refresh();
                    //pictureBox2.Visible = true;
                }
            }
        }

        private void AxVLCPlugin21_Enter(object sender, EventArgs e)
        {

        }

        private void PbSettings_Click(object sender, EventArgs e)
        {
      
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;

            }
        }

        private void BtnSubs_Click(object sender, EventArgs e)
        {
           

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Subtitle Files .srt|*.srt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axVLCPlugin21.playlist.add("file:///" + openFileDialog1.FileName, null);
                axVLCPlugin21.video.subtitle = 1;
            }


        }

        private void AxVLCPlugin21_MediaPlayerStopped(object sender, EventArgs e)
        {
            pictureBox2.Tag = "Play";
            pictureBox2.Image = PlayerUI.Properties.Resources._10_109461_multimedia_music_player_play_button_music_player_play;
            pictureBox2.Refresh();
        }

        private void AxVLCPlugin21_MediaPlayerBuffering(object sender, AxAXVLC.DVLCEvents_MediaPlayerBufferingEvent e)
        {

        }

        private void AxVLCPlugin21_MediaPlayerMuted(object sender, EventArgs e)
        {

        }

        private void AxVLCPlugin21_MediaPlayerPaused(object sender, EventArgs e)
        {
            pictureBox2.Tag = "Play";
            pictureBox2.Image = PlayerUI.Properties.Resources._10_109461_multimedia_music_player_play_button_music_player_play;
            pictureBox2.Refresh();
        }

        private void AxVLCPlugin21_MediaPlayerPlaying(object sender, EventArgs e)
        {
            pictureBox2.Tag = "Pause";
            pictureBox2.Image = PlayerUI.Properties.Resources._16427;
            pictureBox2.Refresh();
        }

        private void AxVLCPlugin21_MediaPlayerAudioVolume(object sender, AxAXVLC.DVLCEvents_MediaPlayerAudioVolumeEvent e)
        {
            //1331 max
            //1132 min

            //location 389, 42
            //size of pnl
            //200, 5 length , breath
            
          
        
        }

        private void AxVLCPlugin21_ClickEvent(object sender, EventArgs e)
        {

   
        }

        private void LblVol_TextChanged(object sender, EventArgs e)
        {
            double cal = (axVLCPlugin21.audio.volume / 100d);
            double Length = Math.Round(cal) * 200d;
            pnlSound.Visible = true;
            pnlSound.Width = Convert.ToInt32(Math.Round(Length));
            
         }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            bClose = true;
     
            frmViewMovies frm = new frmViewMovies();
            frm.Show();
            this.Close();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
       
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            bClose = false;
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Feature does not work yet, uses Chrome Plugin to view webpage");
            frmYTS frm = new frmYTS();
            frm.Show();
        }
    }
 
}

