using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MediaInfo
{
    [Serializable]
    public class UISettings
    {
        public string ThemeName { get; set; }       //Name of the theme
        public List<Int16> FormBGColor { get; set; }      //Main Form BG Color
        public List<Int16> SongBGColor { get; set; }      //Song Info (Top Panel) BG Color
        public List<Int16> OrqBGColor { get; set; }       //Orq Info (Bottom Panel) BG Color
        public double ImgPosition { get; set; }     //Image position (.5 - middle)
        public bool OrqInfoVisible { get; set; }    //Orquestra Info visability
        public bool NextTandaVisible { get; set; }  //Next Tanda Visability
        public int SongCountMode { get; set;}       //0 - invisible; 1 - three rows; 2 - one row;
        public string SongNumbOf { get; set; }      //of, out of, empty, "/"

        //************************* Current Song Info ********************************       
        #region
        //Artist (Orquestra) label
        public string SongArtistFont { get; set; }
        public string SongArtistFontStyle { get; set; }
        public List<Int16> SongArtistColor { get; set; }
        public double FontSizeArtist { get; set; }              //FONT SIZE multiplyer Current song Artist (Orquestra)
        public double VerticalLocationArtist { get; set; }      //Vertical Location multiplyer Current song Artist (Orquestra) label
        public double WidthArtist { get; set; }                 //WIDTH multiplyer Current Artist (Orquestra) label
        public double HeightArtist { get; set; }                //HEIGHT multiplyer Current Artist (Orquestra) label
        public string SongArtistAlignment { get; set; }

        //Title label
        public string SongTitleFont { get; set; }
        public string SongTitleFontStyle { get; set; }
        public List<Int16> SongTitleColor { get; set; }
        public double FontSizeTitle { get; set; }               //FONT SIZE multiplyer Current song Title
        public double VerticalLocationTitle { get; set; }       //Vertical Location multiplyer Current song Title label
        public double WidthTitle { get; set; }                  //WIDTH multiplyer Current song Title label
        public double HeightTitle { get; set; }                 //HEIGHT multiplyer Current song Title label
        public string SongTitleAlignment { get; set; }

        //Album (Singer) label
        public string SongAlbumFont { get; set; }
        public string SongAlbumFontStyle { get; set; }
        public List<Int16> SongAlbumColor { get; set; }
        public double FontSizeAlbum { get; set; }               //FONT SIZE multiplyer Current song Album (Singer)
        public double VerticalLocationAlbum { get; set; }       //Vertical Location multiplyer Current song Album label
        public double WidthAlbum { get; set; }                  //WIDTH multiplyer Current song Album label
        public double HeightAlbum { get; set; }                 //HEIGHT multiplyer Current song Album label
        public string SongAlbumAlignment { get; set; }

        //Next Tanda label
        public string NextFont { get; set; }
        public string NextFontStyle { get; set; }
        public List<Int16> NextTandaColor { get; set; }
        public double FontSizeNext { get; set; }                //FONT SIZE multiplyer Next Tanda
        public double VerticalLocationNext { get; set; }        //Vertical Location multiplyer Next Tanda label
        public double WidthNext { get; set; }                   //WIDTH multiplyer Next Tanda label
        public double HeightNext { get; set; }                  //HEIGHT multiplyer Next Tanda label
        public string NextTandaAlignment { get; set; }
        #endregion

        //**************************** Orquestra ***********************************
        #region
        //Orquestra Info 1 (Top label)
        public string OrqInfoFont1 { get; set; }
        public string OrqInfoFontStyle1 { get; set; }
        public List<Int16> OrqInfoColor1 { get; set; }
        public double FontSizeOrq1 { get; set; }                //FONT SIZE multiplyer Orq Info 1
        public double VerticalLocationOrq1 { get; set; }        //Vertical Location multiplyer Orq Info 1 label 
        public double WidthOrq1 { get; set; }                   //WIDTH multiplyer Orq Info 1 label
        public double HeightOrq1 { get; set; }                  //HEIGHT multiplyer Orq Info 1 label
        public string OrqInfoAlignment1 { get; set; }

        //Orquestra Info 2 (Middle label)
        public string OrqInfoFont2 { get; set; }
        public string OrqInfoFontStyle2 { get; set; }
        public List<Int16> OrqInfoColor2 { get; set; }
        public double FontSizeOrq2 { get; set; }                //FONT SIZE multiplyer Orq Info 2
        public double VerticalLocationOrq2 { get; set; }        //Vertical Location multiplyer Orq Info 2 label
        public double WidthOrq2 { get; set; }                   //WIDTH multiplyer Orq Info 1 label
        public double HeightOrq2 { get; set; }                  //HEIGHT multiplyer Orq Info 1 label
        public string OrqInfoAlignment2 { get; set; }

        //Orquestra Info 3 (Bottom label)
        public string OrqInfoFont3 { get; set; }
        public string OrqInfoFontStyle3 { get; set; }
        public List<Int16> OrqInfoColor3 { get; set; }
        public double FontSizeOrq3 { get; set; }                //FONT SIZE multiplyer Orq Info 3
        public double VerticalLocationOrq3 { get; set; }        //Vertical Location multiplyer Orq Info 3 label
        public double WidthOrq3 { get; set; }                   //WIDTH multiplyer Orq Info 1 label
        public double HeightOrq3 { get; set; }                  //HEIGHT multiplyer Orq Info 1 label
        public string OrqInfoAlignment3 { get; set; }

        public double HorizontalLocationOrq { get; set; }       //Horisontal Location multiplyer ORQ Info
        #endregion

        //************************** Song Numbers **********************************
        #region
        //Song Numbers 1 (Top label)
        public string SongNumbFont1 { get; set; }
        public string SongNumbFontStyle1 { get; set; }
        public List<Int16> SongNumbColor1 { get; set; }
        public double FontSizeNumb1 { get; set; }               //FONT SIZE multiplyer Song Numbers 1
        public double VerticalLocationNumb1 { get; set; }       //Vertical Location multiplyer Song Number Current label
        public double WidthNumb1 { get; set; }                  //WIDTH multiplyer Song Numb 1 label
        public double HeightNumb1 { get; set; }                 //HEIGHT multiplyer Song Numb 1 label
        public string SongNumberAlignment1 { get; set; }

        //Song Numbers 2 (Middle label)
        public string SongNumbFont2 { get; set; }
        public string SongNumbFontStyle2 { get; set; }
        public List<Int16> SongNumbColor2 { get; set; }
        public double FontSizeNumb2 { get; set; }               //FONT SIZE multiplyer Song Numbers 2
        public double VerticalLocationNumb2 { get; set; }       //Vertical Location multiplyer Song Number Middle label
        public double WidthNumb2 { get; set; }                  //WIDTH multiplyer Song Numb 2 label
        public double HeightNumb2 { get; set; }                 //HEIGHT multiplyer Song Numb 2 label
        public string SongNumberAlignment2 { get; set; }

        //Song Numbers 3 (Bottom label)
        public string SongNumbFont3 { get; set; }
        public string SongNumbFontStyle3 { get; set; }
        public List<Int16> SongNumbColor3 { get; set; }
        public double FontSizeNumb3 { get; set; }               //FONT SIZE multiplyer Song Numbers 3
        public double VerticalLocationNumb3 { get; set; }       //Vertical Location multiplyer Song Number Total label
        public double WidthNumb3 { get; set; }                  //WIDTH multiplyer Song Numb 3 label
        public double HeightNumb3 { get; set; }                 //HEIGHT multiplyer Song Numb 3 label
        public string SongNumberAlignment3 { get; set; }

        public double HorizontalLocationNumb { get; set; }      //Horisontal Location multiplyer Song Numbers
        #endregion
    }
}
