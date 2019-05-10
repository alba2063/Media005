using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongsDB;

namespace Media002
{
    //The Event Handler declaration
    public delegate void NewSongDel();

    public partial class MainForm : Form
    {
        //event is an instance of delegate
        //The Event declaration
        
        public event NewSongDel NewSongStarted = delegate { };
        public SDBApplicationClass sDB;
        private OrquestraCollection orqs;
        private UISettings ui;

        //************************ Genetal settings *********************************

        Color formBGColor = Color.FromArgb(64, 64, 64);     //Main Form BG Color
        Color songBGColor = Color.FromArgb(15, 15, 15);     //Song Info (Top Panel) BG Color
        Color orqBGColor = Color.FromArgb(50, 50, 50);      //Orq Info (Bottom Panel) BG Color
        double imgPosition = .5;        //Image position (.5 - middle)
        bool orqInfoVisible = true;     //Orquestra Info visability
        bool nextTandaVisible = true;   //Next Tanda Visability
        int songCountMode = 1;          //0 - invisible; 1 - three rows; 2 - one row;
        string songNumbOf = "out of";   //of, out of, empty, "/"

        //*********************** Current Song Info ********************************       
        #region
        //Artist (Orquestra) label
        string songArtistFont = "Courier";
        FontStyle songArtistFontStyle = FontStyle.Bold;
        Color songArtistColor = Color.FromArgb(247, 220, 111);
        double csofm = .045;   //FONT SIZE multiplyer Current song Artist (Orquestra)
        double csovl = .001;   //Vertical Location multiplyer Current song Artist (Orquestra) label
        double cswm1 = 1;      //WIDTH multiplyer Current Artist (Orquestra) label
        double cshm1 = .225;   //HEIGHT multiplyer Current Artist (Orquestra) label
        ContentAlignment songArtistAlignment = ContentAlignment.MiddleCenter;

        //Title label
        string songTitleFont = "Arial";
        FontStyle songTitleFontStyle = FontStyle.Bold;
        Color songTitleColor = Color.FromArgb(253, 243, 207);
        double cstfm = .035;   //FONT SIZE multiplyer Current song Title
        double cstvl = .28;    //Vertical Location multiplyer Current song Title label
        double cswm2 = 1;      //WIDTH multiplyer Current song Title label
        double cshm2 = .225;   //HEIGHT multiplyer Current song Title label
        ContentAlignment songTitleAlignment = ContentAlignment.MiddleCenter;

        //Album (Singer) label
        string songAlbumFont = "Arial";
        FontStyle songAlbumFontStyle = FontStyle.Bold;
        Color songAlbumColor = Color.FromArgb(253, 243, 207);
        double csafm = .030;   //FONT SIZE multiplyer Current song Album (Singer)
        double csavl = .55;    //Vertical Location multiplyer Current song Album label
        double cswm3 = 1;      //WIDTH multiplyer Current song Album label
        double cshm3 = .225;   //HEIGHT multiplyer Current song Album label
        ContentAlignment songAlbumAlignment = ContentAlignment.MiddleCenter;

        //Next Tanda label
        string nextFont = "Sitka Text";
        FontStyle nextFontStyle = FontStyle.Regular;
        Color nextTandaColor = Color.FromArgb(100, 100, 100);
        double ntfm = .02;     //FONT SIZE multiplyer Next Tanda
        double ntvl = .77;     //Vertical Location multiplyer Next Tanda label
        double cswm4 = 1;      //WIDTH multiplyer Next Tanda label
        double cshm4 = .225;   //HEIGHT multiplyer Next Tanda label
        ContentAlignment nextTandaAlignment = ContentAlignment.MiddleCenter;
        #endregion
        //**************************** Orquestra ***********************************
        #region
        //Orquestra Info 1 (Top label)
        string orqInfoFont1 = "Sitka Text";
        FontStyle orqInfoFontStyle1 = FontStyle.Italic;
        Color orqInfoColor1 = Color.FromArgb(95, 158, 160);
        double oifm1 = .04;   //FONT SIZE multiplyer Orq Info 1
        double oi1vl = .15;    //Vertical Location multiplyer Orq Info 1 label 
        double orqwm1 = 1;     //WIDTH multiplyer Orq Info 1 label
        double orqhm1 = .225;  //HEIGHT multiplyer Orq Info 1 label
        ContentAlignment orqInfoAlignment1 = ContentAlignment.MiddleLeft;

        //Orquestra Info 2 (Middle label)
        string orqInfoFont2 = "Sitka Text";
        FontStyle orqInfoFontStyle2 = FontStyle.Italic;
        Color orqInfoColor2 = Color.FromArgb(95, 158, 160);
        double oifm2 = .04;   //FONT SIZE multiplyer Orq Info 2
        double oi2vl = .38;    //Vertical Location multiplyer Orq Info 2 label
        double orqwm2 = 1;     //WIDTH multiplyer Orq Info 1 label
        double orqhm2 = .225;  //HEIGHT multiplyer Orq Info 1 label
        ContentAlignment orqInfoAlignment2 = ContentAlignment.MiddleLeft;

        //Orquestra Info 3 (Bottom label)
        string orqInfoFont3 = "Sitka Text";
        FontStyle orqInfoFontStyle3 = FontStyle.Italic;
        Color orqInfoColor3 = Color.FromArgb(95, 158, 160);
        double oifm3 = .04;   //FONT SIZE multiplyer Orq Info 3
        double oi3vl = .6;     //Vertical Location multiplyer Orq Info 3 label
        double orqwm3 = 1;     //WIDTH multiplyer Orq Info 1 label
        double orqhm3 = .225;  //HEIGHT multiplyer Orq Info 1 label
        ContentAlignment orqInfoAlignment3 = ContentAlignment.MiddleLeft;

        double oihl = .15;     //Horisontal Location multiplyer ORQ Info
        #endregion
        //************************** Song Numbers **********************************
        #region
        string songNumbFont1 = "Arial";
        FontStyle songNumbFontStyle1 = FontStyle.Bold;
        Color songNumbColor1 = Color.FromArgb(95, 158, 160);
        double snfm1 = .03;   //FONT SIZE multiplyer Song Numbers 1
        double sncvl = .14;   //Vertical Location multiplyer Song Number Current label
        double snwm1 = .3;     //WIDTH multiplyer Song Numb 1 label
        double snhm1 = .2;  //HEIGHT multiplyer Song Numb 1 label
        ContentAlignment songNumberAlignment1 = ContentAlignment.MiddleCenter;

        string songNumbFont2 = "Arial";
        FontStyle songNumbFontStyle2 = FontStyle.Bold;
        Color songNumbColor2 = Color.FromArgb(95, 158, 160);
        double snfm2 = .03;   //FONT SIZE multiplyer Song Numbers 2
        double snmvl = .39;    //Vertical Location multiplyer Song Number Middle label
        double snwm2 = .3;     //WIDTH multiplyer Song Numb 2 label
        double snhm2 = .2;  //HEIGHT multiplyer Song Numb 2 label
        ContentAlignment songNumberAlignment2 = ContentAlignment.MiddleCenter;

        string songNumbFont3 = "Arial";
        FontStyle songNumbFontStyle3 = FontStyle.Bold;
        Color songNumbColor3 = Color.FromArgb(95, 158, 160);
        double snfm3 = .03;   //FONT SIZE multiplyer Song Numbers 3
        double sntvl = .63;   //Vertical Location multiplyer Song Number Total label
        double snwm3 = .3;     //WIDTH multiplyer Song Numb 3 label
        double snhm3 = .2;  //HEIGHT multiplyer Song Numb 3 label
        ContentAlignment songNumberAlignment3 = ContentAlignment.MiddleCenter;

        double snhl = .25;    //Horisontal Location multiplyer Song Numbers
        #endregion



        public MainForm()
        {
            InitializeComponent();

            // instantiate the delegate and register a method with the new instance.
            NewSongDel newSong = new NewSongDel(onNewSongStarted);

            Reader reader = new Reader();
            orqs = reader.ReadIni();

            sDB = new SDBApplicationClass();
            sDB.OnPlay += newSong.Invoke;   //OnPlay event from MediaMonkey API

            ui = MediaInfoSettings.GetUI();

            this.BackColor = formBGColor;                       //Main Form BG Color
            splitContainerBig.Panel1.BackColor = songBGColor;   //Song Info (Top Panel) BG Color
            splitContainerOrq.BackColor = orqBGColor;           //Orq Info (Bottom Panel) BG Color

            SetNextTandaVisability();
            SetSongNumbVisability();
            SetOrqInfoVisability();
            ShowInfo();
        }

        protected virtual void onNewSongStarted()
        {
            ShowInfo();
        }

        public void ShowInfo()
        {
            Dig dig = new Dig();
            
            TextBox.CheckForIllegalCrossThreadCalls = false;

            Song curSong = new Song();
            Song nextTandaSong = new Song();
            curSong = dig.CurrentSong();    //Current Song

            //Required to resize labels
            lblCurSongTitle.AutoSize = false;
            lblCurSongArtist.AutoSize = false;
            lblCurSongAlbum.AutoSize = false;
            lblNext.AutoSize = false;

            lblSongInTanda.AutoSize = false;
            lblOutOf.AutoSize = false;
            lblsongsTotal.AutoSize = false;

            lblOrqInfo2.AutoSize = false;
            lblOrqInfo3.AutoSize = false;
            lblOrqInfo1.AutoSize = false;

            FormatCurSong();

            //PlayList Info
            nextTandaSong = dig.NextTanda();    //song
            var songOrder = dig.SongCount();    //int array
            string songCurrent;
            string songTotal;
            string songNumbers;

            if (songOrder[1] > 4)
            {
                songCurrent = "";
                songTotal = "";
                songNumbers = "--";
            }
            else
            {
                songCurrent = songOrder[0].ToString();
                songTotal = songOrder[1].ToString();

                switch (songCountMode)
                {
                    case 1:
                        songNumbers = songNumbOf;   //of or out of
                        break;
                    case 2:
                        songNumbers = songCurrent + " " + songNumbOf + " " + songTotal;
                        break;
                    default:
                        songNumbers = songNumbOf;   //of or out of
                        break;
                }
            }

            if (songOrder[0] == 1 && songOrder[1] == 1)
            {
                songCurrent = "";
                songNumbers = "";
                songTotal = "";
            }

            if (songOrder[0] == 0 && songOrder[1] == 0)
            {
                songCurrent = "";
                songNumbers = "";
                songTotal = "";
            }

            //Load current song
            lblCurSongArtist.Text = curSong.Artist;// + " " + curSong.Year;
            lblCurSongTitle.Text = curSong.Title;// + " " + songNumbers;
            lblCurSongAlbum.Text = curSong.Album;
            lblNext.Text = " Next Tanda: " + nextTandaSong.Genre + " -- " + nextTandaSong.Artist;

            //Load and format song numbers
            lblSongInTanda.Text = songCurrent;
            lblOutOf.Text = songNumbers;
            lblsongsTotal.Text = songTotal;

            FormatSongNumbers();


            //********************************* Orq Info *********************************
            //Load Orq Info
            ShowOrqInfo(curSong.Artist);
            ResizeOrqSplitPanel();
            FormatOrqInfo();           
          
        }

        private void SetSongNumbVisability()
        {
            switch (songCountMode)
            {
                case 0:
                    lblSongInTanda.Visible = false;
                    lblOutOf.Visible = false;
                    lblsongsTotal.Visible = false;
                    break;
                case 1:
                    //lblSongInTanda.Visible = false;
                    //lblOutOf.Visible = false;
                    //lblsongsTotal.Visible = false;
                    break;
                case 2:
                    lblSongInTanda.Visible = false;
                    lblOutOf.Visible = true;
                    lblsongsTotal.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void SetOrqInfoVisability()
        {
            if (!orqInfoVisible)
            {
                lblOrqInfo1.Visible = false;
                lblOrqInfo2.Visible = false;
                lblOrqInfo3.Visible = false;
            }
        }

        private void SetNextTandaVisability()
        {
            if (!nextTandaVisible)
            {
                lblNext.Visible = false;
            }
        }

        //Load Orquestra Info
        private void ShowOrqInfo(string artist)
        {
            bool pic = false;

            foreach (Orquestra orq in orqs)
            {
                if (artist.Contains(orq.OrqName))
                {
                    pictureBox.ImageLocation = orq.ImageFile;
                    lblOrqInfo1.Text = orq.Info_1;
                    lblOrqInfo2.Text = orq.Info_2;
                    lblOrqInfo3.Text = orq.Info_3;

                    pic = true;

                    break;
                }
            }

            if (!pic)
            {
                pictureBox.ImageLocation = "Images\\music001.jpg";
                lblOrqInfo1.Text = string.Empty;
                lblOrqInfo2.Text = string.Empty;
                lblOrqInfo3.Text = string.Empty;
            }
        }

        //Scaleing fonts and positions with container size
        private void splitContainer_SizeChanged(object sender, EventArgs e)
        {
            //Song Info
            FormatCurSong();

            //Song Numbers
            FormatSongNumbers();

            //Orq Info
            FormatOrqInfo();

            //Picture to the center
            ResizeOrqSplitPanel();
        }

        private void FormatCurSong()
        {
            int fontSizeCurO = (int)(splitContainerBig.Panel1.Width * csofm);     //Font size for current song Orquestra
            int fontSizeCurT = (int)(splitContainerBig.Panel1.Width * cstfm);     //Font size for current song Title
            int fontSizeCurA = (int)(splitContainerBig.Panel1.Width * csafm);     //Font size for current song Album (Singer)
            int fontSizeNextTanda = (int)(splitContainerBig.Panel1.Width * ntfm); //Font size for Netx Tanda

            lblCurSongArtist.Font = new Font(songArtistFont, fontSizeCurO, songArtistFontStyle);
            lblCurSongTitle.Font = new Font(songTitleFont, fontSizeCurT, songTitleFontStyle);
            lblCurSongAlbum.Font = new Font(songAlbumFont, fontSizeCurA, songAlbumFontStyle);
            lblNext.Font = new Font(nextFont, fontSizeNextTanda, nextFontStyle);

            lblCurSongArtist.ForeColor = songArtistColor;
            lblCurSongTitle.ForeColor = songTitleColor;
            lblCurSongAlbum.ForeColor = songAlbumColor;
            lblNext.ForeColor = nextTandaColor;

            //Current song Artist (Orquestra)
            lblCurSongArtist.Width = (int)(splitContainerBig.Panel1.Width * cswm1);
            lblCurSongArtist.Height = (int)(splitContainerBig.Panel1.Height * cshm1);
            lblCurSongArtist.TextAlign = songArtistAlignment;
            lblCurSongArtist.Location = new Point(0, (int)(splitContainerBig.Panel1.Height * csovl));

            //Current song Title (Song Name)
            lblCurSongTitle.Width = (int)(splitContainerBig.Panel1.Width * cswm2);
            lblCurSongTitle.Height = (int)(splitContainerBig.Panel1.Height * cshm2);
            lblCurSongTitle.TextAlign = songTitleAlignment;
            lblCurSongTitle.Location = new Point(0, (int)(splitContainerBig.Panel1.Height * cstvl));

            //Current song Album (Singer)
            lblCurSongAlbum.Width = (int)(splitContainerBig.Panel1.Width * cswm3);
            lblCurSongAlbum.Height = (int)(splitContainerBig.Panel1.Height * cshm3);
            lblCurSongAlbum.TextAlign = songAlbumAlignment;
            lblCurSongAlbum.Location = new Point(0, (int)(splitContainerBig.Panel1.Height * csavl));

            //Next Tanda Info
            lblNext.Width = (int)(splitContainerBig.Panel1.Width * cswm4);
            lblNext.Height = (int)(splitContainerBig.Panel1.Height * cshm4);
            lblNext.TextAlign = nextTandaAlignment;
            lblNext.Location = new Point(0, (int)(splitContainerBig.Panel1.Height * ntvl));
        }

        private void ResizeOrqSplitPanel()
        {
            splitContainerOrq.SplitterDistance = ((int)(splitContainerBig.Width * imgPosition) + (int)(pictureBox.Width * .5)) - 5;
        }

        private void FormatSongNumbers()
        {
            int fontSizeSongNumbers1 = (int)(splitContainerOrq.Panel1.Width * snfm1);
            int fontSizeSongNumbers2 = (int)(splitContainerOrq.Panel1.Width * snfm2);
            int fontSizeSongNumbers3 = (int)(splitContainerOrq.Panel1.Width * snfm3);

            int xPosition = (int)(splitContainerOrq.Panel1.Width * snhl);

            lblSongInTanda.ForeColor = songNumbColor1;
            lblOutOf.ForeColor = songNumbColor2;
            lblsongsTotal.ForeColor = songNumbColor3;

            //lblSongInTanda.Text = songCurrent;
            lblSongInTanda.Font = new Font(songNumbFont1, fontSizeSongNumbers1, songNumbFontStyle1);
            lblSongInTanda.Width = (int)(splitContainerOrq.Panel1.Width * snwm1);
            lblSongInTanda.Height = (int)(splitContainerOrq.Panel1.Height * snhm1);
            lblSongInTanda.TextAlign = songNumberAlignment1;
            lblSongInTanda.Location = new Point(xPosition, (int)(splitContainerOrq.Panel1.Height * sncvl)); //Vertical location

            //lblOutOf.Text = songNumbers;
            lblOutOf.Font = new Font(songNumbFont2, fontSizeSongNumbers2, songNumbFontStyle2);
            lblOutOf.Width = (int)(splitContainerOrq.Panel1.Width * snwm2);
            lblOutOf.Height = (int)(splitContainerOrq.Panel1.Height * snhm2);
            lblOutOf.TextAlign = songNumberAlignment2;
            lblOutOf.Location = new Point(xPosition, (int)(splitContainerOrq.Panel1.Height * snmvl)); //Vertical location

            //lblsongsTotal.Text = songTotal;
            lblsongsTotal.Font = new Font(songNumbFont3, fontSizeSongNumbers3, songNumbFontStyle3);
            lblsongsTotal.Width = (int)(splitContainerOrq.Panel1.Width * snwm3);
            lblsongsTotal.Height = (int)(splitContainerOrq.Panel1.Height * snhm3);
            lblsongsTotal.TextAlign = songNumberAlignment3;
            lblsongsTotal.Location = new Point(xPosition, (int)(splitContainerOrq.Panel1.Height * sntvl)); //Vertical location
        }

        private void FormatOrqInfo()
        {
            //Orq Info Formating
            int fontSizeOrq1 = (int)(splitContainerOrq.Panel2.Width * oifm1);     //Font size for Orq Info 1
            int fontSizeOrq2 = (int)(splitContainerOrq.Panel2.Width * oifm2);     //Font size for Orq Info 2
            int fontSizeOrq3 = (int)(splitContainerOrq.Panel2.Width * oifm3);     //Font size for Orq Info 3

            int xPosition = (int)(splitContainerOrq.Panel2.Width * oihl);
            //
            pictureBox.Width = pictureBox.Height = (int)(splitContainerOrq.Panel1.Height - 10);           

            lblOrqInfo1.Location = new Point(xPosition, (int)(splitContainerOrq.Panel2.Height * oi1vl));
            lblOrqInfo2.Location = new Point(xPosition, (int)(splitContainerOrq.Panel2.Height * oi2vl));
            lblOrqInfo3.Location = new Point(xPosition, (int)(splitContainerOrq.Panel2.Height * oi3vl));

            lblOrqInfo1.ForeColor = orqInfoColor1;
            lblOrqInfo2.ForeColor = orqInfoColor2;
            lblOrqInfo3.ForeColor = orqInfoColor3;

            //Orquestro Info 1
            lblOrqInfo1.Width = (int)(splitContainerOrq.Panel2.Width * orqwm1);
            lblOrqInfo1.Height = (int)(splitContainerOrq.Panel2.Height * orqhm1);
            lblOrqInfo1.TextAlign = orqInfoAlignment1;

            //Orquestro Info 2
            lblOrqInfo2.Width = (int)(splitContainerOrq.Panel2.Width * orqwm2);
            lblOrqInfo2.Height = (int)(splitContainerOrq.Panel2.Height * orqhm2);
            lblOrqInfo2.TextAlign = orqInfoAlignment2;

            //Orquestro Info 3
            lblOrqInfo3.Width = (int)(splitContainerOrq.Panel2.Width * orqwm3);
            lblOrqInfo3.Height = (int)(splitContainerOrq.Panel2.Height * orqhm3);
            lblOrqInfo3.TextAlign = orqInfoAlignment3;

            lblOrqInfo1.Font = new Font(orqInfoFont1, fontSizeOrq1, orqInfoFontStyle1);
            lblOrqInfo2.Font = new Font(orqInfoFont2, fontSizeOrq2, orqInfoFontStyle2);
            lblOrqInfo3.Font = new Font(orqInfoFont3, fontSizeOrq3, orqInfoFontStyle3);
        }

        //Original size and frame when double click on the picture
        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            } 
        }

        //Remove frame when maximazed
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                //this.Bounds = Screen.PrimaryScreen.Bounds;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {                
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.Sizable;                 
                }
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MediaInfoSettings settings = new MediaInfoSettings();
                settings.Show();
                //MessageBox.Show("Hi there this is my Tango contribution for DJ", "Programed by AlexB");
            }
        }
    }
}
