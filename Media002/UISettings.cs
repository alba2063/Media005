using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MediaInfo
{
    public class UISettings
    {
        public string ThemeName { get; set; }       //Name of the theme
        public Color FormBGColor { get; set; }      //Main Form BG Color
        public Color SongBGColor { get; set; }      //Song Info (Top Panel) BG Color
        public Color OrqBGColor { get; set; }       //Orq Info (Bottom Panel) BG Color
        public double ImgPosition { get; set; }     //Image position (.5 - middle)
        public bool OrqInfoVisible { get; set; }    //Orquestra Info visability
        public bool NextTandaVisible { get; set; }  //Next Tanda Visability
        public int SongCountMode { get; set;}       //0 - invisible; 1 - three rows; 2 - one row;
        public string SongNumbOf { get; set; }      //of, out of, empty, "/"

        //************************* Current Song Info ********************************       
        #region
        //Artist (Orquestra) label
        public Font SongArtistFont { get; set; }
        public FontStyle SongArtistFontStyle { get; set; }
        public Color SongArtistColor { get; set; }
        public double FontSizeArtist { get; set; }              //FONT SIZE multiplyer Current song Artist (Orquestra)
        public double VerticalLocationArtist { get; set; }      //Vertical Location multiplyer Current song Artist (Orquestra) label
        public double WidthArtist { get; set; }                 //WIDTH multiplyer Current Artist (Orquestra) label
        public double HeightArtist { get; set; }                //HEIGHT multiplyer Current Artist (Orquestra) label
        public ContentAlignment SongArtistAlignment { get; set; }

        //Title label
        public Font SongTitleFont { get; set; }
        public FontStyle SongTitleFontStyle { get; set; }
        public Color SongTitleColor { get; set; }
        public double FontSizeTitle { get; set; }               //FONT SIZE multiplyer Current song Title
        public double VerticalLocationTitle { get; set; }       //Vertical Location multiplyer Current song Title label
        public double WidthTitle { get; set; }                  //WIDTH multiplyer Current song Title label
        public double HeightTitle { get; set; }                 //HEIGHT multiplyer Current song Title label
        public ContentAlignment SongTitleAlignment { get; set; }

        //Album (Singer) label
        public Font SongAlbumFont { get; set; }
        public FontStyle SongAlbumFontStyle { get; set; }
        public Color SongAlbumColor { get; set; }
        public double FontSizeAlbum { get; set; }               //FONT SIZE multiplyer Current song Album (Singer)
        public double VerticalLocationAlbum { get; set; }       //Vertical Location multiplyer Current song Album label
        public double WidthAlbum { get; set; }                  //WIDTH multiplyer Current song Album label
        public double HeightAlbum { get; set; }                 //HEIGHT multiplyer Current song Album label
        public ContentAlignment SongAlbumAlignment { get; set; }

        //Next Tanda label
        public Font NextFont { get; set; }
        public FontStyle NextFontStyle { get; set; }
        public Color NextTandaColor { get; set; }
        public double FontSizeNext { get; set; }                //FONT SIZE multiplyer Next Tanda
        public double VerticalLocationNext { get; set; }        //Vertical Location multiplyer Next Tanda label
        public double WidthNext { get; set; }                   //WIDTH multiplyer Next Tanda label
        public double HeightNext { get; set; }                  //HEIGHT multiplyer Next Tanda label
        public ContentAlignment NextTandaAlignment { get; set; }
        #endregion

        //**************************** Orquestra ***********************************
        #region
        //Orquestra Info 1 (Top label)
        public Font OrqInfoFont1 { get; set; }
        public FontStyle OrqInfoFontStyle1 { get; set; }
        public Color OrqInfoColor1 { get; set; }
        public double FontSizeOrq1 { get; set; }                //FONT SIZE multiplyer Orq Info 1
        public double VerticalLocationOrq1 { get; set; }        //Vertical Location multiplyer Orq Info 1 label 
        public double WidthOrq1 { get; set; }                   //WIDTH multiplyer Orq Info 1 label
        public double HeightOrq1 { get; set; }                  //HEIGHT multiplyer Orq Info 1 label
        public ContentAlignment OrqInfoAlignment1 { get; set; }

        //Orquestra Info 2 (Middle label)
        public Font OrqInfoFont2 { get; set; }
        public FontStyle OrqInfoFontStyle2 { get; set; }
        public Color OrqInfoColor2 { get; set; }
        public double FontSizeOrq2 { get; set; }                //FONT SIZE multiplyer Orq Info 2
        public double VerticalLocationOrq2 { get; set; }        //Vertical Location multiplyer Orq Info 2 label
        public double WidthOrq2 { get; set; }                   //WIDTH multiplyer Orq Info 1 label
        public double HeightOrq2 { get; set; }                  //HEIGHT multiplyer Orq Info 1 label
        public ContentAlignment OrqInfoAlignment2 { get; set; }

        //Orquestra Info 3 (Bottom label)
        public Font OrqInfoFont3 { get; set; }
        public FontStyle OrqInfoFontStyle3 { get; set; }
        public Color OrqInfoColor3 { get; set; }
        public double FontSizeOrq3 { get; set; }                //FONT SIZE multiplyer Orq Info 3
        public double VerticalLocationOrq3 { get; set; }        //Vertical Location multiplyer Orq Info 3 label
        public double WidthOrq3 { get; set; }                   //WIDTH multiplyer Orq Info 1 label
        public double HeightOrq3 { get; set; }                  //HEIGHT multiplyer Orq Info 1 label
        public ContentAlignment OrqInfoAlignment3 { get; set; }

        public double HorizontalLocationOrq { get; set; }       //Horisontal Location multiplyer ORQ Info
        #endregion

        //************************** Song Numbers **********************************
        #region
        //Song Numbers 1 (Top label)
        public Font SongNumbFont1 { get; set; }
        public FontStyle SongNumbFontStyle1 { get; set; }
        public Color SongNumbColor1 { get; set; }
        public double FontSizeNumb1 { get; set; }               //FONT SIZE multiplyer Song Numbers 1
        public double VerticalLocationNumb1 { get; set; }       //Vertical Location multiplyer Song Number Current label
        public double WidthNumb1 { get; set; }                  //WIDTH multiplyer Song Numb 1 label
        public double HeightNumb1 { get; set; }                 //HEIGHT multiplyer Song Numb 1 label
        public ContentAlignment SongNumberAlignment1 { get; set; }

        //Song Numbers 2 (Middle label)
        public Font SongNumbFont2 { get; set; }
        public FontStyle SongNumbFontStyle2 { get; set; }
        public Color SongNumbColor2 { get; set; }
        public double FontSizeNumb2 { get; set; }               //FONT SIZE multiplyer Song Numbers 2
        public double VerticalLocationNumb2 { get; set; }       //Vertical Location multiplyer Song Number Middle label
        public double WidthNumb2 { get; set; }                  //WIDTH multiplyer Song Numb 2 label
        public double HeightNumb2 { get; set; }                 //HEIGHT multiplyer Song Numb 2 label
        public ContentAlignment SongNumberAlignment2 { get; set; }

        //Song Numbers 3 (Bottom label)
        public Font SongNumbFont3 { get; set; }
        public FontStyle SongNumbFontStyle3 { get; set; }
        public Color SongNumbColor3 { get; set; }
        public double FontSizeNumb3 { get; set; }               //FONT SIZE multiplyer Song Numbers 3
        public double VerticalLocationNumb3 { get; set; }       //Vertical Location multiplyer Song Number Total label
        public double WidthNumb3 { get; set; }                  //WIDTH multiplyer Song Numb 3 label
        public double HeightNumb3 { get; set; }                 //HEIGHT multiplyer Song Numb 3 label
        public ContentAlignment SongNumberAlignment3 { get; set; }

        public double HorizontalLocationNumb { get; set; }      //Horisontal Location multiplyer Song Numbers
        #endregion
    }
}
