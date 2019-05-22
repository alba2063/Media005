using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MediaInfo
{
    public class BlackTheme : UISettings
    {

        public BlackTheme()
        {
            base.ThemeName          = "Black";                        //Name of the theme
            base.FormBGColor        = Color.FromArgb(64, 64, 64);     //Main Form BG Color
            base.SongBGColor        = Color.FromArgb(15, 15, 15);     //Song Info (Top Panel) BG Color
            base.OrqBGColor         = Color.FromArgb(50, 50, 50);     //Orq Info (Bottom Panel) BG Color
            base.ImgPosition        = .5;                             //Image position (.5 - middle)
            base.OrqInfoVisible     = true;                           //Orquestra Info visability
            base.NextTandaVisible   = true;                           //Next Tanda Visability
            base.SongCountMode      = 1;                              //0 - invisible; 1 - three rows; 2 - one row;
            base.SongNumbOf         = "out of";                       //of, out of, empty, "/"

            //*********************** Current Song Info ********************************  
            #region
            //Artist (Orquestra) label
            base.SongArtistFont             = "Courier";
            base.SongArtistFontStyle        = "Bold";
            base.SongArtistColor            = Color.FromArgb(247, 220, 111);
            base.FontSizeArtist             = .045;                                 //FONT SIZE multiplyer Current song Artist (Orquestra)
            base.VerticalLocationArtist     = .001;                                 //Vertical Location multiplyer Current song Artist (Orquestra) label
            base.WidthArtist                = 1;                                    //WIDTH multiplyer Current Artist (Orquestra) label
            base.HeightArtist               = .225;                                 //HEIGHT multiplyer Current Artist (Orquestra) label
            base.SongArtistAlignment        = "MiddleCenter";

            //Title label
            base.SongTitleFont              = "Arial";
            base.SongTitleFontStyle         = "Bold";
            base.SongTitleColor             = Color.FromArgb(253, 243, 207);
            base.FontSizeTitle              = .035;                                 //FONT SIZE multiplyer Current song Title
            base.VerticalLocationTitle      = .28;                                  //Vertical Location multiplyer Current song Title label
            base.WidthTitle                 = 1;                                    //WIDTH multiplyer Current song Title label
            base.HeightTitle                = .225;                                 //HEIGHT multiplyer Current song Title label
            base.SongTitleAlignment         = "MiddleCenter";

            //Album (Singer) label
            base.SongAlbumFont              = "Arial";
            base.SongAlbumFontStyle         = "Bold";
            base.SongAlbumColor             = Color.FromArgb(253, 243, 207);
            base.FontSizeAlbum              = .030;                                 //FONT SIZE multiplyer Current song Album (Singer)
            base.VerticalLocationAlbum      = .55;                                  //Vertical Location multiplyer Current song Album label
            base.WidthAlbum                 = 1;                                    //WIDTH multiplyer Current song Album label
            base.HeightAlbum                = .225;                                 //HEIGHT multiplyer Current song Album label
            base.SongAlbumAlignment         = "MiddleCenter";

            //Next Tanda label
            base.NextFont                   = "Sitka Text";
            base.NextFontStyle              = "Regular";
            base.NextTandaColor             = Color.FromArgb(100, 100, 100);
            base.FontSizeNext               = .02;                                  //FONT SIZE multiplyer Next Tanda
            base.VerticalLocationNext       = .77;                                  //Vertical Location multiplyer Next Tanda label
            base.WidthNext                  = 1;                                    //WIDTH multiplyer Next Tanda label
            base.HeightNext                 = .225;                                 //HEIGHT multiplyer Next Tanda label
            base.NextTandaAlignment         = "MiddleCenter";
            #endregion

            //**************************** Orquestra ***********************************
            #region
            //Orquestra Info 1 (Top label)
            base.OrqInfoFont1               = "Arial";
            base.OrqInfoFontStyle1          = "Bold";
            base.OrqInfoColor1              = Color.FromArgb(95, 158, 160);
            base.FontSizeOrq1               = .035;                                 //FONT SIZE multiplyer Orq Info 1
            base.VerticalLocationOrq1       = .15;                                  //Vertical Location multiplyer Orq Info 1 label 
            base.WidthOrq1                  = 1;                                    //WIDTH multiplyer Orq Info 1 label
            base.HeightOrq1                 = .225;                                 //HEIGHT multiplyer Orq Info 1 label
            base.OrqInfoAlignment1          = "MiddleLeft";

            //Orquestra Info 2 (Middle label)
            base.OrqInfoFont2               = "Arial";
            base.OrqInfoFontStyle2          = "Bold";
            base.OrqInfoColor2              = Color.FromArgb(95, 158, 160);
            base.FontSizeOrq2               = .035;                                 //FONT SIZE multiplyer Orq Info 2
            base.VerticalLocationOrq2       = .38;                                  //Vertical Location multiplyer Orq Info 2 label
            base.WidthOrq2                  = 1;                                    //WIDTH multiplyer Orq Info 1 label
            base.HeightOrq2                 = .225;                                 //HEIGHT multiplyer Orq Info 1 label
            base.OrqInfoAlignment2          = "MiddleLeft";

            //Orquestra Info 3 (Bottom label)
            base.OrqInfoFont3               = "Arial";
            base.OrqInfoFontStyle3          = "Bold";
            base.OrqInfoColor3              = Color.FromArgb(95, 158, 160);
            base.FontSizeOrq3               = .035;                                 //FONT SIZE multiplyer Orq Info 3
            base.VerticalLocationOrq3       = .6;                                   //Vertical Location multiplyer Orq Info 3 label
            base.WidthOrq3                  = 1;                                    //WIDTH multiplyer Orq Info 1 label
            base.HeightOrq3                 = .225;                                 //HEIGHT multiplyer Orq Info 1 label
            base.OrqInfoAlignment3          = "MiddleLeft";

            base.HorizontalLocationOrq      = .15;                                  //Horisontal Location multiplyer ORQ Info
            #endregion

            //************************** Song Numbers **********************************
            #region
            //Song Numbers 1 (Top label)
            base.SongNumbFont1              = "Arial";
            base.SongNumbFontStyle1         = "Bold";
            base.SongNumbColor1             = Color.FromArgb(95, 158, 160);
            base.FontSizeNumb1              = .03;                                  //FONT SIZE multiplyer Song Numbers 1
            base.VerticalLocationNumb1      = .14;                                  //Vertical Location multiplyer Song Number Current label
            base.WidthNumb1                 = .3;                                   //WIDTH multiplyer Song Numb 1 label
            base.HeightNumb1                = .2;                                   //HEIGHT multiplyer Song Numb 1 label
            base.SongNumberAlignment1       = "MiddleCenter";

            //Song Numbers 2 (Middle label)
            base.SongNumbFont2              = "Arial";
            base.SongNumbFontStyle2         = "Bold";
            base.SongNumbColor2             = Color.FromArgb(95, 158, 160);
            base.FontSizeNumb2              = .03;                                  //FONT SIZE multiplyer Song Numbers 2
            base.VerticalLocationNumb2      = .39;                                  //Vertical Location multiplyer Song Number Middle label
            base.WidthNumb2                 = .3;                                   //WIDTH multiplyer Song Numb 2 label
            base.HeightNumb2                = .2;                                   //HEIGHT multiplyer Song Numb 2 label
            base.SongNumberAlignment2       = "MiddleCenter";

            //Song Numbers 3 (Bottom label)
            base.SongNumbFont3              = "Arial";
            base.SongNumbFontStyle3         = "Bold";
            base.SongNumbColor3             = Color.FromArgb(95, 158, 160);
            base.FontSizeNumb3              = .03;                                  //FONT SIZE multiplyer Song Numbers 3
            base.VerticalLocationNumb3      = .63;                                  //Vertical Location multiplyer Song Number Total label
            base.WidthNumb3                 = .3;                                   //WIDTH multiplyer Song Numb 3 label
            base.HeightNumb3                = .2;                                   //HEIGHT multiplyer Song Numb 3 label
            base.SongNumberAlignment3       = "MiddleCenter";

            base.HorizontalLocationNumb     = .25;                                  //Horisontal Location multiplyer Song Numbers
            #endregion
        }

    }
}
