using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MediaInfo
{
    class RetroTheme : UISettings
    {
        public RetroTheme()
        {
            base.ThemeName = "Retro";                               //Name of the theme
            base.FormBGColor = Color.FromArgb(238, 232, 170);       //Main Form BG Color
            base.SongBGColor = Color.FromArgb(250, 250, 210);       //Song Info (Top Panel) BG Color
            base.OrqBGColor = Color.FromArgb(255, 255, 224);        //Orq Info (Bottom Panel) BG Color
            base.ImgPosition = .5;                                  //Image position (.5 - middle)
            base.OrqInfoVisible = true;                             //Orquestra Info visability
            base.NextTandaVisible = true;                           //Next Tanda Visability
            base.SongCountMode = 1;                                 //0 - invisible; 1 - three rows; 2 - one row;
            base.SongNumbOf = "out of";                             //"of", "out of", "/" or empty

            //*********************** Current Song Info ********************************  
            #region
            //Artist (Orquestra) label
            base.SongArtistFont = new Font("Calibri", 12);
            base.SongArtistFontStyle = FontStyle.Bold;// | FontStyle.Italic;
            base.SongArtistColor = Color.FromArgb(47, 79, 79);
            base.FontSizeArtist = .045;                                 //FONT SIZE multiplyer Current song Artist (Orquestra)
            base.VerticalLocationArtist = .001;                         //Vertical Location multiplyer Current song Artist (Orquestra) label
            base.WidthArtist = 1;                                       //WIDTH multiplyer Current Artist (Orquestra) label
            base.HeightArtist = .225;                                   //HEIGHT multiplyer Current Artist (Orquestra) label
            base.SongArtistAlignment = ContentAlignment.MiddleCenter;

            //Title label
            base.SongTitleFont = new Font("Arial", 12);
            base.SongTitleFontStyle = FontStyle.Bold;
            base.SongTitleColor = Color.FromArgb(139, 69, 19);
            base.FontSizeTitle = .035;                                  //FONT SIZE multiplyer Current song Title
            base.VerticalLocationTitle = .28;                           //Vertical Location multiplyer Current song Title label
            base.WidthTitle = 1;                                        //WIDTH multiplyer Current song Title label
            base.HeightTitle = .225;                                    //HEIGHT multiplyer Current song Title label
            base.SongTitleAlignment = ContentAlignment.MiddleCenter;

            //Album (Singer) label
            base.SongAlbumFont = new Font("Arial", 12);
            base.SongAlbumFontStyle = FontStyle.Bold;
            base.SongAlbumColor = Color.FromArgb(139, 69, 19);
            base.FontSizeAlbum = .030;                                  //FONT SIZE multiplyer Current song Album (Singer)
            base.VerticalLocationAlbum = .55;                           //Vertical Location multiplyer Current song Album label
            base.WidthAlbum = 1;                                        //WIDTH multiplyer Current song Album label
            base.HeightAlbum = .225;                                    //HEIGHT multiplyer Current song Album label
            base.SongAlbumAlignment = ContentAlignment.MiddleCenter;

            //Next Tanda label
            base.NextFont = new Font("Sitka Text", 12);
            base.NextFontStyle = FontStyle.Regular;
            base.NextTandaColor = Color.FromArgb(140, 140, 150);
            base.FontSizeNext = .02;                                    //FONT SIZE multiplyer Next Tanda
            base.VerticalLocationNext = .77;                            //Vertical Location multiplyer Next Tanda label
            base.WidthNext = 1;                                         //WIDTH multiplyer Next Tanda label
            base.HeightNext = .225;                                     //HEIGHT multiplyer Next Tanda label
            base.NextTandaAlignment = ContentAlignment.MiddleCenter;
            #endregion

            //**************************** Orquestra ***********************************
            #region
            //Orquestra Info 1 (Top label)
            base.OrqInfoFont1 = new Font("Arial", 12);
            base.OrqInfoFontStyle1 = FontStyle.Bold;
            base.OrqInfoColor1 = Color.FromArgb(128, 128, 128);
            base.FontSizeOrq1 = .035;                                   //FONT SIZE multiplyer Orq Info 1
            base.VerticalLocationOrq1 = .15;                            //Vertical Location multiplyer Orq Info 1 label 
            base.WidthOrq1 = 1;                                         //WIDTH multiplyer Orq Info 1 label
            base.HeightOrq1 = .225;                                     //HEIGHT multiplyer Orq Info 1 label
            base.OrqInfoAlignment1 = ContentAlignment.MiddleLeft;

            //Orquestra Info 2 (Middle label)
            base.OrqInfoFont2 = new Font("Arial", 12);
            base.OrqInfoFontStyle2 = FontStyle.Bold;
            base.OrqInfoColor2 = Color.FromArgb(128, 128, 128);
            base.FontSizeOrq2 = .035;                                   //FONT SIZE multiplyer Orq Info 2
            base.VerticalLocationOrq2 = .38;                            //Vertical Location multiplyer Orq Info 2 label
            base.WidthOrq2 = 1;                                         //WIDTH multiplyer Orq Info 1 label
            base.HeightOrq2 = .225;                                     //HEIGHT multiplyer Orq Info 1 label
            base.OrqInfoAlignment2 = ContentAlignment.MiddleLeft;

            //Orquestra Info 3 (Bottom label)
            base.OrqInfoFont3 = new Font("Arial", 12);
            base.OrqInfoFontStyle3 = FontStyle.Bold;
            base.OrqInfoColor3 = Color.FromArgb(128, 128, 128);
            base.FontSizeOrq3 = .035;                                   //FONT SIZE multiplyer Orq Info 3
            base.VerticalLocationOrq3 = .6;                             //Vertical Location multiplyer Orq Info 3 label
            base.WidthOrq3 = 1;                                         //WIDTH multiplyer Orq Info 1 label
            base.HeightOrq3 = .225;                                     //HEIGHT multiplyer Orq Info 1 label
            base.OrqInfoAlignment3 = ContentAlignment.MiddleLeft;

            base.HorizontalLocationOrq = .15;                           //Horisontal Location multiplyer ORQ Info
            #endregion

            //************************** Song Numbers **********************************
            #region
            //Song Numbers 1 (Top label)
            base.SongNumbFont1 = new Font("Arial", 12);
            base.SongNumbFontStyle1 = FontStyle.Bold;
            base.SongNumbColor1 = Color.FromArgb(85, 107, 47);
            base.FontSizeNumb1 = .03;                                   //FONT SIZE multiplyer Song Numbers 1
            base.VerticalLocationNumb1 = .14;                           //Vertical Location multiplyer Song Number Current label
            base.WidthNumb1 = .3;                                       //WIDTH multiplyer Song Numb 1 label
            base.HeightNumb1 = .2;                                      //HEIGHT multiplyer Song Numb 1 label
            base.SongNumberAlignment1 = ContentAlignment.MiddleCenter;

            //Song Numbers 2 (Middle label)
            base.SongNumbFont2 = new Font("Arial", 12);
            base.SongNumbFontStyle2 = FontStyle.Bold;
            base.SongNumbColor2 = Color.FromArgb(85, 107, 47);
            base.FontSizeNumb2 = .03;                                   //FONT SIZE multiplyer Song Numbers 2
            base.VerticalLocationNumb2 = .39;                           //Vertical Location multiplyer Song Number Middle label
            base.WidthNumb2 = .3;                                       //WIDTH multiplyer Song Numb 2 label
            base.HeightNumb2 = .2;                                      //HEIGHT multiplyer Song Numb 2 label
            base.SongNumberAlignment2 = ContentAlignment.MiddleCenter;

            //Song Numbers 3 (Bottom label)
            base.SongNumbFont3 = new Font("Arial", 12);
            base.SongNumbFontStyle3 = FontStyle.Bold;
            base.SongNumbColor3 = Color.FromArgb(85, 107, 47);
            base.FontSizeNumb3 = .03;                                   //FONT SIZE multiplyer Song Numbers 3
            base.VerticalLocationNumb3 = .63;                           //Vertical Location multiplyer Song Number Total label
            base.WidthNumb3 = .3;                                       //WIDTH multiplyer Song Numb 3 label
            base.HeightNumb3 = .2;                                      //HEIGHT multiplyer Song Numb 3 label
            base.SongNumberAlignment3 = ContentAlignment.MiddleCenter;

            base.HorizontalLocationNumb = .25;                          //Horisontal Location multiplyer Song Numbers
            #endregion
        }
    }
}
