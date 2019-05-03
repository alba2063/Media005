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

        string songArtistFont = "Courier";
        FontStyle songArtistFontStyle = FontStyle.Bold;
        string songTitleFont = "Arial";
        FontStyle songTitleFontStyle = FontStyle.Bold;
        string songAlbumFont = "Arial";
        FontStyle songAlbumFontStyle = FontStyle.Bold;
        string nextFont = "Algerian";
        FontStyle nextFontStyle = FontStyle.Regular;
        double cswm = 1;      //WIDTH multiplyer Current song label
        double cshm = .225;   //HEIGHT multiplyer Current song label 
        double csofm = .045;  //FONT multiplyer Current song Orquestra
        double cstfm = .035;  //FONT multiplyer Current song Title
        double csafm = .030;  //FONT multiplyer Current song Album (Singer)
        double ntfm = .02;    //FONT multiplyer Next Tanda
        double csovl = .001;  //Vertical Location multiplyer Current song Orquestra label 
        double cstvl = .28;   //Vertical Location multiplyer Current song Title label 
        double csavl = .55;   //Vertical Location multiplyer Current song Album label 

        string orqInfoFont1 = "Arial";
        FontStyle orqInfoFontStyle1 = FontStyle.Bold;
        string orqInfoFont2 = "Arial";
        FontStyle orqInfoFontStyle2 = FontStyle.Bold;
        string orqInfoFont3 = "Arial";
        FontStyle orqInfoFontStyle3 = FontStyle.Bold;
        double oifm1 = .035;   //FONT multiplyer Orq Info 1
        double oifm2 = .035;   //FONT multiplyer Orq Info 2
        double oifm3 = .035;   //FONT multiplyer Orq Info 3
        double oihl = .15;    //Horisontal Location multiplyer ORQ Info
        double oi1vl = .15;   //Vertical Location multiplyer Orq Info 1 label 
        double oi2vl = .38;   //Vertical Location multiplyer Orq Info 2 label 
        double oi3vl = .6;    //Vertical Location multiplyer Orq Info 3 label

        double snfm = .04;   //FONT multiplyer Song Numbers
        double snhl = .25;    //Horisontal Location multiplyer Song Numbers
        double sncvl = .15;   //Vertical Location multiplyer Song Number Current label 
        double snmvl = .4;   //Vertical Location multiplyer Song Number Middle label 
        double sntvl = .66;    //Vertical Location multiplyer Song Number Total label

        public MainForm()
        {
            InitializeComponent();

            // instantiate the delegate and register a method with the new instance.
            NewSongDel newSong = new NewSongDel(onNewSongStarted);

            Reader reader = new Reader();
            orqs = reader.ReadIni();

            sDB = new SDBApplicationClass();
            sDB.OnPlay += newSong.Invoke;   //OnPlay event from MediaMonkey API

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
                //songNumbers = "(" + songCurrent + " out of " + songTotal + ")";
                songNumbers = "out of";
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


            //********************************* Orq Info *************************************

            lblOrqInfo2.AutoSize = false;
            lblOrqInfo3.AutoSize = false;
            lblOrqInfo1.AutoSize = false;

            //Load Orq Info
            ShowOrqInfo(curSong.Artist);
            FormatOrqInfo();           
          
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

            int lblWidthCur = (int)(splitContainerBig.Panel1.Width * cswm);       //Label wigth for current song
            int lblHeightCur = (int)(splitContainerBig.Panel1.Height * cshm);     //Label height for current song

            lblCurSongArtist.Font = new Font(songArtistFont, fontSizeCurO, songArtistFontStyle);
            lblCurSongTitle.Font = new Font(songTitleFont, fontSizeCurT, songTitleFontStyle);
            lblCurSongAlbum.Font = new Font(songAlbumFont, fontSizeCurA, songAlbumFontStyle);
            lblNext.Font = new Font(nextFont, fontSizeNextTanda, nextFontStyle);

            //Current song Artist (Orquestra)
            lblCurSongArtist.Width = lblWidthCur;
            lblCurSongArtist.Height = lblHeightCur;
            lblCurSongArtist.TextAlign = ContentAlignment.MiddleCenter;
            lblCurSongArtist.Location = new Point(0, (int)(splitContainerBig.Panel1.Height * csovl));

            //Current song Title (Song Name)
            lblCurSongTitle.Width = lblWidthCur;
            lblCurSongTitle.Height = lblHeightCur;
            lblCurSongTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblCurSongTitle.Location = new Point(0, (int)(splitContainerBig.Panel1.Height * cstvl));

            //Current song Album (Singer)
            lblCurSongAlbum.Width = lblWidthCur;
            lblCurSongAlbum.Height = lblHeightCur;
            lblCurSongAlbum.TextAlign = ContentAlignment.MiddleCenter;
            lblCurSongAlbum.Location = new Point(0, (int)(splitContainerBig.Panel1.Height * csavl));

            //Next Tanda Info
            lblNext.Width = lblWidthCur;
            lblNext.Height = lblHeightCur;
            lblNext.TextAlign = ContentAlignment.MiddleCenter;
            lblNext.Location = new Point(0, (int)(splitContainerBig.Panel1.Height * 0.77));
        }

        private void ResizeOrqSplitPanel()
        {
            splitContainerOrq.SplitterDistance = (splitContainerBig.Width / 2 + pictureBox.Width / 2) - 5;
        }

        private void FormatSongNumbers()
        {
            int fontSizeSongNumbers = (int)(splitContainerOrq.Panel1.Width * snfm);
            int xPosition = (int)(splitContainerOrq.Panel1.Width * snhl);

            //lblSongInTanda.Text = songCurrent;
            lblSongInTanda.Font = new Font("Arial", fontSizeSongNumbers, FontStyle.Bold);
            lblSongInTanda.Width = (int)(splitContainerOrq.Panel1.Width * .3);
            lblSongInTanda.Height = (int)(splitContainerOrq.Panel1.Height * .2);
            lblSongInTanda.TextAlign = ContentAlignment.MiddleCenter;
            lblSongInTanda.Location = new Point(xPosition, (int)(splitContainerOrq.Panel1.Height * sncvl)); //Vertical location

            //lblOutOf.Text = songNumbers;
            lblOutOf.Font = new Font("Arial", fontSizeSongNumbers, FontStyle.Bold);
            lblOutOf.Width = (int)(splitContainerOrq.Panel1.Width * .3);
            lblOutOf.Height = (int)(splitContainerOrq.Panel1.Height * .2);
            lblOutOf.TextAlign = ContentAlignment.MiddleCenter;
            lblOutOf.Location = new Point(xPosition, (int)(splitContainerOrq.Panel1.Height * snmvl)); //Vertical location

            //lblsongsTotal.Text = songTotal;
            lblsongsTotal.Font = new Font("Arial", fontSizeSongNumbers, FontStyle.Bold);
            lblsongsTotal.Width = (int)(splitContainerOrq.Panel1.Width * .3);
            lblsongsTotal.Height = (int)(splitContainerOrq.Panel1.Height * .2);
            lblsongsTotal.TextAlign = ContentAlignment.MiddleCenter;
            lblsongsTotal.Location = new Point(xPosition, (int)(splitContainerOrq.Panel1.Height * sntvl)); //Vertical location
        }

        private void FormatOrqInfo()
        {
            //Orq Info Formating
            int fontSizeOrq1 = (int)(splitContainerOrq.Panel2.Width * oifm1);     //Font size for Orq Info 1
            int fontSizeOrq2 = (int)(splitContainerOrq.Panel2.Width * oifm2);     //Font size for Orq Info 2
            int fontSizeOrq3 = (int)(splitContainerOrq.Panel2.Width * oifm3);     //Font size for Orq Info 3
            int lblWidthOrq = (int)(splitContainerOrq.Panel2.Width * cswm);     //Label wigth for Orq Info
            int lblHeightOrq = (int)(splitContainerOrq.Panel2.Height * cshm);   //Label height for Orq Info

            int xPosition = (int)(splitContainerOrq.Panel2.Width * oihl);
            //
            pictureBox.Width = pictureBox.Height = (int)(splitContainerOrq.Panel1.Height - 10);

            lblOrqInfo1.Location = new Point(xPosition, (int)(splitContainerOrq.Panel2.Height * oi1vl));
            lblOrqInfo2.Location = new Point(xPosition, (int)(splitContainerOrq.Panel2.Height * oi2vl));
            lblOrqInfo3.Location = new Point(xPosition, (int)(splitContainerOrq.Panel2.Height * oi3vl));

            //Orquestro Info 1
            lblOrqInfo1.Width = lblWidthOrq;
            lblOrqInfo1.Height = lblHeightOrq;
            lblOrqInfo1.TextAlign = ContentAlignment.MiddleLeft;

            //Orquestro Info 2
            lblOrqInfo2.Width = lblWidthOrq;
            lblOrqInfo2.Height = lblHeightOrq;
            lblOrqInfo2.TextAlign = ContentAlignment.MiddleLeft;

            //Orquestro Info 3
            lblOrqInfo3.Width = lblWidthOrq;
            lblOrqInfo3.Height = lblHeightOrq;
            lblOrqInfo3.TextAlign = ContentAlignment.MiddleLeft;

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
            }
        }
    }
}
