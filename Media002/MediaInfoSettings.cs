using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MediaInfo
{
    public partial class MediaInfoSettings : Form
    {
        public UISettings ui;
        private static UISettingsCollection fixedCollection;    //working collection (fixed themes + user's themes)
        private UISettingsCollection userCollection;            //collection for user's themes only
        List<string> themeList;                                 //List of theme names
        MainForm mainForm;

        public MediaInfoSettings()
        {
            InitializeComponent();
            GetUI();
        }
        public MediaInfoSettings(MainForm main)
        {
            InitializeComponent();

            mainForm = main;

            GetUI();
        }

        private void MediaInfoSettings_Load(object sender, EventArgs e)
        {
            //GetUI();
            SetIni();
        }

        private void GetUI()
        {
            //Predefined hard codded collections
            UISettings uiBlack = new BlackTheme();
            UISettings uiRetro = new RetroTheme();

            //Collection with all available Themes
            fixedCollection = new UISettingsCollection();
            userCollection = new UISettingsCollection();

            //Get XML string from application settings
            XmlDocument uiXML1 = Properties.Settings.Default.UIXMLCollection;
            //Create object (UISettingsCollection) from XML
            userCollection = Serialization.CreateObject(uiXML1, userCollection);

            

            //Add predefined themes to fixedCollection (working collection)
            fixedCollection.Add(uiBlack);
            fixedCollection.Add(uiRetro);

            //Add user's themes to working collection (fixedCollection)
            foreach (UISettings u in userCollection)
            {
                fixedCollection.Add(u);
            }

            themeList = new List<string>();

            //Get list of all available Theme names
            foreach (UISettings u in fixedCollection)
            {
                themeList.Add(u.ThemeName);
            }

            GetIni(themeList);
        }

        public void GetIni(List<string> themeNames)
        {
            //initialize comboBox with theme names
            BindingSource bs = new BindingSource();
            bs.DataSource = themeNames;
            comboBoxTheme.DataSource = bs;
            comboBoxTheme.DropDownStyle = ComboBoxStyle.DropDownList;

            //If form first time or already open
            if(!this.Visible)
            {
                //Load last Theme name from application settings
                comboBoxTheme.SelectedItem = Properties.Settings.Default.ThemeName;
            }
            else
            {
                //Load with current UI
                comboBoxTheme.SelectedItem = ui.ThemeName;
            }

            GetCurrentUI();
        }

        private void GetCurrentUI()
        {
            foreach (UISettings u in fixedCollection)
            {
                if (u.ThemeName.Equals(comboBoxTheme.SelectedItem))
                {
                    ui = u;
                }
            }

            SetIni();
        }

        private static List<short> ConvertColor(string colorText)
        {
            string[] colorString;
            List<Int16> colorInt = new List<short>();

            colorString = colorText.Split(',');
            foreach (string c in colorString)
            {
                colorInt.Add(Convert.ToInt16(c));
            }

            return colorInt;
        }

        private static Color GetTextColor(int r, int g, int b)
        {
            Color color;

            if ((r + g + b) / 3 > 128)
            {
                color = Color.Black;
            }
            else
            {
                color = Color.White;
            }

            return color;
        }


        //Load UI settings to the form
        private void SetIni()
        {
            //Design
            #region
            textBoxThemeName.Text = ui.ThemeName;

            comboBoxAlbumSource.SelectedIndex = ui.AlbumSource;
            comboBoxAlbumSource.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxMainFormBGColor.BackColor = Color.FromArgb(ui.FormBGColor[0], ui.FormBGColor[1], ui.FormBGColor[2]);
            lblRGBMain.Text = ui.FormBGColor[0] + "," + ui.FormBGColor[1] + "," + ui.FormBGColor[2];
            lblRGBMain.ForeColor = Color.FromArgb(85, 85, 85);


            textBoxSongPanelBGColor.BackColor = Color.FromArgb(ui.SongBGColor[0], ui.SongBGColor[1], ui.SongBGColor[2]);
            lblSongRDB.Text = ui.SongBGColor[0] + "," + ui.SongBGColor[1] + "," + ui.SongBGColor[2];
            lblSongRDB.ForeColor = Color.FromArgb(85, 85, 85);


            textBoxOrqPanelBGColor.BackColor = Color.FromArgb(ui.OrqBGColor[0], ui.OrqBGColor[1], ui.OrqBGColor[2]);
            lblOrqRGB.Text = ui.OrqBGColor[0] + "," + ui.OrqBGColor[1] + "," + ui.OrqBGColor[2];
            lblOrqRGB.ForeColor = Color.FromArgb(85, 85, 85);


            textBoxImagePosition.Text = ui.ImgPosition.ToString();
            textBoxImagePosition.TextAlign = HorizontalAlignment.Center;

            checkBoxNextTanda.Checked = ui.NextTandaVisible;
            checkBoxOrqInfo.Checked = ui.OrqInfoVisible;

            comboBoxSongNumberMode.SelectedItem = ui.SongCountMode.ToString();
            comboBoxSongNumberMode.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxSNText.Text = ui.SongNumbOf;
            textBoxSNText.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Song Artist
            #region
            textBoxArtistFont.Text = ui.SongArtistFont;
            textBoxArtistFont.Font = new Font(ui.SongArtistFont, 8);

            textBoxArtistColor.BackColor = Color.FromArgb(ui.SongArtistColor[0], ui.SongArtistColor[1], ui.SongArtistColor[2]);
            textBoxArtistColor.Text = ui.SongArtistColor[0] + "," + ui.SongArtistColor[1] + "," + ui.SongArtistColor[2];
            textBoxArtistColor.ForeColor = GetTextColor(ui.SongArtistColor[0], ui.SongArtistColor[1], ui.SongArtistColor[2]);
            textBoxArtistColor.TextAlign = HorizontalAlignment.Center;

            textBoxArtistFontSize.Text = ui.FontSizeArtist.ToString();
            textBoxArtistFontSize.TextAlign = HorizontalAlignment.Center;

            lblArtistFontStyleSelected.Text = ui.SongArtistFontStyle;

            comboBoxArtistAlignment.SelectedItem = ui.SongArtistAlignment;
            comboBoxArtistAlignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxArtistVerticalLocation.Text = ui.VerticalLocationArtist.ToString();
            textBoxArtistVerticalLocation.TextAlign = HorizontalAlignment.Center;

            lblArtistHorizontal.Enabled = false;
            textBoxArtistHorizontalLocation.Text = "";
            textBoxArtistHorizontalLocation.TextAlign = HorizontalAlignment.Center;
            textBoxArtistHorizontalLocation.Enabled = false;

            textBoxArtistHight.Text = ui.HeightArtist.ToString();
            textBoxArtistHight.TextAlign = HorizontalAlignment.Center;

            textBoxArtistWidth.Text = ui.WidthArtist.ToString();
            textBoxArtistWidth.TextAlign = HorizontalAlignment.Center;

            #endregion

            //Song Title
            #region
            textBoxTitleFont.Text = ui.SongTitleFont;
            textBoxTitleFont.Font = new Font(ui.SongTitleFont, 8);

            textBoxTitleColor.BackColor = Color.FromArgb(ui.SongTitleColor[0], ui.SongTitleColor[1], ui.SongTitleColor[2]);
            textBoxTitleColor.Text = ui.SongTitleColor[0] + "," + ui.SongTitleColor[1] + "," + ui.SongTitleColor[2];
            textBoxTitleColor.ForeColor = GetTextColor(ui.SongTitleColor[0], ui.SongTitleColor[1], ui.SongTitleColor[2]);
            textBoxTitleColor.TextAlign = HorizontalAlignment.Center;

            textBoxTitleFontSize.Text = ui.FontSizeTitle.ToString();
            textBoxTitleFontSize.TextAlign = HorizontalAlignment.Center;

            lblTitleFontStyleSelected.Text = ui.SongTitleFontStyle;

            comboBoxTitleAlignment.SelectedItem = ui.SongTitleAlignment;
            comboBoxTitleAlignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxTitleVerticalLocation.Text = ui.VerticalLocationTitle.ToString();
            textBoxTitleVerticalLocation.TextAlign = HorizontalAlignment.Center;

            lblTitleHorizontal.Enabled = false;
            textBoxTitleHorizontalLocation.Text = "";
            textBoxTitleHorizontalLocation.TextAlign = HorizontalAlignment.Center;
            textBoxTitleHorizontalLocation.Enabled = false;

            textBoxTitleHight.Text = ui.HeightArtist.ToString();
            textBoxTitleHight.TextAlign = HorizontalAlignment.Center;

            textBoxTitleWidth.Text = ui.WidthArtist.ToString();
            textBoxTitleWidth.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Song Album
            #region
            textBoxAlbumFont.Text = ui.SongAlbumFont;
            textBoxAlbumFont.Font = new Font(ui.SongAlbumFont, 8);

            textBoxAlbumColor.BackColor = Color.FromArgb(ui.SongAlbumColor[0], ui.SongAlbumColor[1], ui.SongAlbumColor[2]);
            textBoxAlbumColor.Text = ui.SongAlbumColor[0] + "," + ui.SongAlbumColor[1] + "," + ui.SongAlbumColor[2];
            textBoxAlbumColor.ForeColor = GetTextColor(ui.SongAlbumColor[0], ui.SongAlbumColor[1], ui.SongAlbumColor[2]);
            textBoxAlbumColor.TextAlign = HorizontalAlignment.Center;

            textBoxAlbumFontSize.Text = ui.FontSizeAlbum.ToString();
            textBoxAlbumFontSize.TextAlign = HorizontalAlignment.Center;

            lblAlbumFontStyleSelected.Text = ui.SongAlbumFontStyle;

            comboBoxAlbumAlignment.SelectedItem = ui.SongAlbumAlignment;
            comboBoxAlbumAlignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxAlbumVerticalLocation.Text = ui.VerticalLocationAlbum.ToString();
            textBoxAlbumVerticalLocation.TextAlign = HorizontalAlignment.Center;

            lblAlbumHorizontal.Enabled = false;
            textBoxAlbumHorizontalLocation.Text = "";
            textBoxAlbumHorizontalLocation.TextAlign = HorizontalAlignment.Center;
            textBoxAlbumHorizontalLocation.Enabled = false;

            textBoxAlbumHight.Text = ui.HeightAlbum.ToString();
            textBoxAlbumHight.TextAlign = HorizontalAlignment.Center;

            textBoxAlbumWidth.Text = ui.WidthAlbum.ToString();
            textBoxAlbumWidth.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Next Tanda
            #region
            textBoxNextTandaFont.Text = ui.NextFont;
            textBoxNextTandaFont.Font = new Font(ui.NextFont, 8);

            textBoxNextTandaColor.BackColor = Color.FromArgb(ui.NextTandaColor[0], ui.NextTandaColor[1], ui.NextTandaColor[2]);
            textBoxNextTandaColor.Text = ui.NextTandaColor[0] + "," + ui.NextTandaColor[1] + "," + ui.NextTandaColor[2];
            textBoxNextTandaColor.ForeColor = GetTextColor(ui.NextTandaColor[0], ui.NextTandaColor[1], ui.NextTandaColor[2]);
            textBoxNextTandaColor.TextAlign = HorizontalAlignment.Center;

            textBoxNextTandaFontSize.Text = ui.FontSizeNext.ToString();
            textBoxNextTandaFontSize.TextAlign = HorizontalAlignment.Center;

            lblNextTandaFontStyleSelected.Text = ui.NextFontStyle;

            comboBoxNextTandaAlignment.SelectedItem = ui.NextTandaAlignment;
            comboBoxNextTandaAlignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxNextTandaVerticalLocation.Text = ui.VerticalLocationNext.ToString();
            textBoxNextTandaVerticalLocation.TextAlign = HorizontalAlignment.Center;

            lblNextTandaHorizontal.Enabled = false;
            textBoxNextTandaHorizontalLocation.Text = "";
            textBoxNextTandaHorizontalLocation.TextAlign = HorizontalAlignment.Center;
            textBoxNextTandaHorizontalLocation.Enabled = false;

            textBoxNextTandaHight.Text = ui.HeightNext.ToString();
            textBoxNextTandaHight.TextAlign = HorizontalAlignment.Center;

            textBoxNextTandaWidth.Text = ui.WidthNext.ToString();
            textBoxNextTandaWidth.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Orq1
            #region
            textBoxOrq1HLocation.Text = ui.HorizontalLocationOrq.ToString();
            textBoxOrq1HLocation.TextAlign = HorizontalAlignment.Center;

            textBoxOrq1Font.Text = ui.OrqInfoFont1;
            textBoxOrq1Font.Font = new Font(ui.OrqInfoFont1, 8);

            textBoxOrq1Color.BackColor = Color.FromArgb(ui.OrqInfoColor1[0], ui.OrqInfoColor1[1], ui.OrqInfoColor1[2]);
            textBoxOrq1Color.Text = ui.OrqInfoColor1[0] + "," + ui.OrqInfoColor1[1] + "," + ui.OrqInfoColor1[2];
            textBoxOrq1Color.ForeColor = GetTextColor(ui.OrqInfoColor1[0], ui.OrqInfoColor1[1], ui.OrqInfoColor1[2]);
            textBoxOrq1Color.TextAlign = HorizontalAlignment.Center;

            textBoxOrq1FontSize.Text = ui.FontSizeOrq1.ToString();
            textBoxOrq1FontSize.TextAlign = HorizontalAlignment.Center;

            lblOrq1FontStyleSelected.Text = ui.OrqInfoFontStyle1;

            comboBoxOrq1Alignment.SelectedItem = ui.OrqInfoAlignment1;
            comboBoxOrq1Alignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxOrq1VLocation.Text = ui.VerticalLocationOrq1.ToString();
            textBoxOrq1VLocation.TextAlign = HorizontalAlignment.Center;

            textBoxOrq1Hight.Text = ui.HeightOrq1.ToString();
            textBoxOrq1Hight.TextAlign = HorizontalAlignment.Center;

            textBoxOrq1Width.Text = ui.WidthOrq1.ToString();
            textBoxOrq1Width.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Orq2
            #region
            textBoxOrq2Font.Text = ui.OrqInfoFont2;
            textBoxOrq2Font.Font = new Font(ui.OrqInfoFont2, 8);

            textBoxOrq2Color.BackColor = Color.FromArgb(ui.OrqInfoColor2[0], ui.OrqInfoColor2[1], ui.OrqInfoColor2[2]);
            textBoxOrq2Color.Text = ui.OrqInfoColor2[0] + "," + ui.OrqInfoColor2[1] + "," + ui.OrqInfoColor2[2];
            textBoxOrq2Color.ForeColor = GetTextColor(ui.OrqInfoColor2[0], ui.OrqInfoColor2[1], ui.OrqInfoColor2[2]);
            textBoxOrq2Color.TextAlign = HorizontalAlignment.Center;

            textBoxOrq2FontSize.Text = ui.FontSizeOrq2.ToString();
            textBoxOrq2FontSize.TextAlign = HorizontalAlignment.Center;

            lblOrq2FontStyleSelected.Text = ui.OrqInfoFontStyle2;

            comboBoxOrq2Alignment.SelectedItem = ui.OrqInfoAlignment2;
            comboBoxOrq2Alignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxOrq2VLocation.Text = ui.VerticalLocationOrq2.ToString();
            textBoxOrq2VLocation.TextAlign = HorizontalAlignment.Center;

            textBoxOrq2Hight.Text = ui.HeightOrq2.ToString();
            textBoxOrq2Hight.TextAlign = HorizontalAlignment.Center;

            textBoxOrq2Width.Text = ui.WidthOrq2.ToString();
            textBoxOrq2Width.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Orq3
            #region
            textBoxOrq3Font.Text = ui.OrqInfoFont3;
            textBoxOrq3Font.Font = new Font(ui.OrqInfoFont3, 8);

            textBoxOrq3Color.BackColor = Color.FromArgb(ui.OrqInfoColor3[0], ui.OrqInfoColor3[1], ui.OrqInfoColor3[2]);
            textBoxOrq3Color.Text = ui.OrqInfoColor3[0] + "," + ui.OrqInfoColor3[1] + "," + ui.OrqInfoColor3[2];
            textBoxOrq3Color.ForeColor = GetTextColor(ui.OrqInfoColor3[0], ui.OrqInfoColor3[1], ui.OrqInfoColor3[2]);
            textBoxOrq3Color.TextAlign = HorizontalAlignment.Center;

            textBoxOrq3FontSize.Text = ui.FontSizeOrq3.ToString();
            textBoxOrq3FontSize.TextAlign = HorizontalAlignment.Center;

            lblOrq3FontStyleSelected.Text = ui.OrqInfoFontStyle3;

            comboBoxOrq3Alignment.SelectedItem = ui.OrqInfoAlignment3;
            comboBoxOrq3Alignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxOrq3VLocation.Text = ui.VerticalLocationOrq3.ToString();
            textBoxOrq3VLocation.TextAlign = HorizontalAlignment.Center;

            textBoxOrq3Hight.Text = ui.HeightOrq3.ToString();
            textBoxOrq3Hight.TextAlign = HorizontalAlignment.Center;

            textBoxOrq3Width.Text = ui.WidthOrq3.ToString();
            textBoxOrq3Width.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Song Numbers 1
            #region
            textBoxSN1HLocation.Text = ui.HorizontalLocationNumb.ToString();
            textBoxSN1HLocation.TextAlign = HorizontalAlignment.Center;

            textBoxSN1Font.Text = ui.SongNumbFont1;
            textBoxSN1Font.Font = new Font(ui.SongNumbFont1, 8);

            textBoxSN1Color.BackColor = Color.FromArgb(ui.SongNumbColor1[0], ui.SongNumbColor1[1], ui.SongNumbColor1[2]);
            textBoxSN1Color.Text = ui.SongNumbColor1[0] + "," + ui.SongNumbColor1[1] + "," + ui.SongNumbColor1[2];
            textBoxSN1Color.ForeColor = GetTextColor(ui.SongNumbColor1[0], ui.SongNumbColor1[1], ui.SongNumbColor1[2]);
            textBoxSN1Color.TextAlign = HorizontalAlignment.Center;

            textBoxSN1FontSize.Text = ui.FontSizeNumb1.ToString();
            textBoxSN1FontSize.TextAlign = HorizontalAlignment.Center;

            lblSN1FontStyleSelected.Text = ui.SongNumbFontStyle1;

            comboBoxSN1Alignment.SelectedItem = ui.SongNumberAlignment1;
            comboBoxSN1Alignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxSN1VLocation.Text = ui.VerticalLocationNumb1.ToString();
            textBoxSN1VLocation.TextAlign = HorizontalAlignment.Center;

            textBoxSN1Hight.Text = ui.HeightNumb1.ToString();
            textBoxSN1Hight.TextAlign = HorizontalAlignment.Center;

            textBoxSN1Width.Text = ui.WidthNumb1.ToString();
            textBoxSN1Width.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Song Numbers 2
            #region
            textBoxSN2Font.Text = ui.SongNumbFont2;
            textBoxSN2Font.Font = new Font(ui.SongNumbFont2, 8);

            textBoxSN2Color.BackColor = Color.FromArgb(ui.SongNumbColor2[0], ui.SongNumbColor2[1], ui.SongNumbColor2[2]);
            textBoxSN2Color.Text = ui.SongNumbColor2[0] + "," + ui.SongNumbColor2[1] + "," + ui.SongNumbColor2[2];
            textBoxSN2Color.ForeColor = GetTextColor(ui.SongNumbColor2[0], ui.SongNumbColor2[1], ui.SongNumbColor2[2]);
            textBoxSN2Color.TextAlign = HorizontalAlignment.Center;

            textBoxSN2FontSize.Text = ui.FontSizeNumb2.ToString();
            textBoxSN2FontSize.TextAlign = HorizontalAlignment.Center;

            lblSN2FontStyleSelected.Text = ui.SongNumbFontStyle2;

            comboBoxSN2Alignment.SelectedItem = ui.SongNumberAlignment2;
            comboBoxSN2Alignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxSN2VLocation.Text = ui.VerticalLocationNumb2.ToString();
            textBoxSN2VLocation.TextAlign = HorizontalAlignment.Center;

            textBoxSN2Hight.Text = ui.HeightNumb2.ToString();
            textBoxSN2Hight.TextAlign = HorizontalAlignment.Center;

            textBoxSN2Width.Text = ui.WidthNumb2.ToString();
            textBoxSN2Width.TextAlign = HorizontalAlignment.Center;
            #endregion

            //Song Numbers 3
            #region
            textBoxSN3Font.Text = ui.SongNumbFont3;
            textBoxSN3Font.Font = new Font(ui.SongNumbFont3, 8);

            textBoxSN3Color.BackColor = Color.FromArgb(ui.SongNumbColor3[0], ui.SongNumbColor3[1], ui.SongNumbColor3[2]);
            textBoxSN3Color.Text = ui.SongNumbColor3[0] + "," + ui.SongNumbColor3[1] + "," + ui.SongNumbColor3[2];
            textBoxSN3Color.ForeColor = GetTextColor(ui.SongNumbColor3[0], ui.SongNumbColor3[1], ui.SongNumbColor3[2]);
            textBoxSN3Color.TextAlign = HorizontalAlignment.Center;

            textBoxSN3FontSize.Text = ui.FontSizeNumb3.ToString();
            textBoxSN3FontSize.TextAlign = HorizontalAlignment.Center;

            lblSN3FontStyleSelected.Text = ui.SongNumbFontStyle3;

            comboBoxSN3Alignment.SelectedItem = ui.SongNumberAlignment3;
            comboBoxSN3Alignment.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxSN3VLocation.Text = ui.VerticalLocationNumb3.ToString();
            textBoxSN3VLocation.TextAlign = HorizontalAlignment.Center;

            textBoxSN3Hight.Text = ui.HeightNumb3.ToString();
            textBoxSN3Hight.TextAlign = HorizontalAlignment.Center;

            textBoxSN3Width.Text = ui.WidthNumb3.ToString();
            textBoxSN3Width.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private bool IsValidToDouble(string s)
        {
            bool v;

            try
            {
                var n = Double.Parse(s, CultureInfo.InvariantCulture);
                v = true;
            }
            catch (Exception e)
            {
                v = false;
            }
            return v;
        }

        //Validate fields for correct input values
        private bool ValidateUI()
        {
            bool valid = true;
            //Current song validation
            #region

            //Theme Name
            if (textBoxThemeName.Text.Equals(string.Empty))
            {
                valid = false;
                lblEmptyNameMsg.Visible = true;
            }
            else
            {

                lblEmptyNameMsg.Visible = false;
            }

            //Picture position
            if (IsValidToDouble(textBoxImagePosition.Text))
            {
                textBoxImagePosition.ForeColor = Color.Black;
            }
            else
            {
                textBoxImagePosition.ForeColor = Color.Red;
                valid = false;
            }

            //Artist font size
            if (IsValidToDouble(textBoxArtistFontSize.Text))
            {
                textBoxArtistFontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxArtistFontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Artist Vertical location
            if (IsValidToDouble(textBoxArtistVerticalLocation.Text))
            {
                textBoxArtistVerticalLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxArtistVerticalLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Artist Horizontal location
            if (IsValidToDouble(textBoxArtistHorizontalLocation.Text))
            {
                textBoxArtistHorizontalLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxArtistHorizontalLocation.ForeColor = Color.Red;
                //valid = false;
            }

            //Artist Hight
            if (IsValidToDouble(textBoxArtistHight.Text))
            {
                textBoxArtistHight.ForeColor = Color.Black;
            }
            else
            {
                textBoxArtistHight.ForeColor = Color.Red;
                valid = false;
            }

            //Artist Width
            if (IsValidToDouble(textBoxArtistWidth.Text))
            {
                textBoxArtistWidth.ForeColor = Color.Black;
            }
            else
            {
                textBoxArtistWidth.ForeColor = Color.Red;
                valid = false;
            }

            //Title font size
            if (IsValidToDouble(textBoxTitleFontSize.Text))
            {
                textBoxTitleFontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxTitleFontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Title Vertical location
            if (IsValidToDouble(textBoxTitleVerticalLocation.Text))
            {
                textBoxTitleVerticalLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxTitleVerticalLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Title Horizontal location
            if (IsValidToDouble(textBoxTitleHorizontalLocation.Text))
            {
                textBoxTitleHorizontalLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxTitleHorizontalLocation.ForeColor = Color.Red;
                //valid = false;
            }

            //Title Hight
            if (IsValidToDouble(textBoxTitleHight.Text))
            {
                textBoxTitleHight.ForeColor = Color.Black;
            }
            else
            {
                textBoxTitleHight.ForeColor = Color.Red;
                valid = false;
            }

            //Title Width
            if (IsValidToDouble(textBoxTitleWidth.Text))
            {
                textBoxTitleWidth.ForeColor = Color.Black;
            }
            else
            {
                textBoxTitleWidth.ForeColor = Color.Red;
                valid = false;
            }

            //Album font size
            if (IsValidToDouble(textBoxAlbumFontSize.Text))
            {
                textBoxAlbumFontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxAlbumFontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Album Vertical location
            if (IsValidToDouble(textBoxAlbumVerticalLocation.Text))
            {
                textBoxAlbumVerticalLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxAlbumVerticalLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Album Horizontal location
            if (IsValidToDouble(textBoxAlbumHorizontalLocation.Text))
            {
                textBoxAlbumHorizontalLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxAlbumHorizontalLocation.ForeColor = Color.Red;
                //valid = false;
            }

            //Album Hight
            if (IsValidToDouble(textBoxAlbumHight.Text))
            {
                textBoxAlbumHight.ForeColor = Color.Black;
            }
            else
            {
                textBoxAlbumHight.ForeColor = Color.Red;
                valid = false;
            }

            //Album Width
            if (IsValidToDouble(textBoxAlbumWidth.Text))
            {
                textBoxAlbumWidth.ForeColor = Color.Black;
            }
            else
            {
                textBoxAlbumWidth.ForeColor = Color.Red;
                valid = false;
            }

            //Tanda font size
            if (IsValidToDouble(textBoxNextTandaFontSize.Text))
            {
                textBoxNextTandaFontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxNextTandaFontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Tanda Vertical location
            if (IsValidToDouble(textBoxNextTandaVerticalLocation.Text))
            {
                textBoxNextTandaVerticalLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxNextTandaVerticalLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Tanda Horizontal location
            if (IsValidToDouble(textBoxNextTandaHorizontalLocation.Text))
            {
                textBoxNextTandaHorizontalLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxNextTandaHorizontalLocation.ForeColor = Color.Red;
                //valid = false;
            }

            //Tanda Hight
            if (IsValidToDouble(textBoxNextTandaHight.Text))
            {
                textBoxNextTandaHight.ForeColor = Color.Black;
            }
            else
            {
                textBoxNextTandaHight.ForeColor = Color.Red;
                valid = false;
            }

            //Tanda Width
            if (IsValidToDouble(textBoxNextTandaWidth.Text))
            {
                textBoxNextTandaWidth.ForeColor = Color.Black;
            }
            else
            {
                textBoxNextTandaWidth.ForeColor = Color.Red;
                valid = false;
            }
            #endregion
            //Orq validation
            #region
            //Orq1 font size
            if (IsValidToDouble(textBoxOrq1FontSize.Text))
            {
                textBoxOrq1FontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq1FontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Orq1 Vertical location
            if (IsValidToDouble(textBoxOrq1VLocation.Text))
            {
                textBoxOrq1VLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq1VLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Orq1 Hight
            if (IsValidToDouble(textBoxOrq1Hight.Text))
            {
                textBoxOrq1Hight.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq1Hight.ForeColor = Color.Red;
                valid = false;
            }

            //Orq1 Width
            if (IsValidToDouble(textBoxOrq1Width.Text))
            {
                textBoxOrq1Width.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq1Width.ForeColor = Color.Red;
                valid = false;
            }

            //Orq2 font size
            if (IsValidToDouble(textBoxOrq2FontSize.Text))
            {
                textBoxOrq2FontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq2FontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Orq2 Vertical location
            if (IsValidToDouble(textBoxOrq2VLocation.Text))
            {
                textBoxOrq2VLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq2VLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Orq2 Horizontal location
            if (IsValidToDouble(textBoxOrq2HLocation.Text))
            {
                textBoxOrq2HLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq2HLocation.ForeColor = Color.Red;
                //valid = false;
            }

            //Orq2 Hight
            if (IsValidToDouble(textBoxOrq2Hight.Text))
            {
                textBoxOrq2Hight.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq2Hight.ForeColor = Color.Red;
                valid = false;
            }

            //Orq2 Width
            if (IsValidToDouble(textBoxOrq2Width.Text))
            {
                textBoxOrq2Width.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq2Width.ForeColor = Color.Red;
                valid = false;
            }

            //Orq3 font size
            if (IsValidToDouble(textBoxOrq3FontSize.Text))
            {
                textBoxOrq3FontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq3FontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Orq3 Vertical location
            if (IsValidToDouble(textBoxOrq3VLocation.Text))
            {
                textBoxOrq3VLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq3VLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Orq3 Horizontal location
            if (IsValidToDouble(textBoxOrq3HLocation.Text))
            {
                textBoxOrq3HLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq3HLocation.ForeColor = Color.Red;
                //valid = false;
            }

            //Orq3 Hight
            if (IsValidToDouble(textBoxOrq3Hight.Text))
            {
                textBoxOrq3Hight.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq3Hight.ForeColor = Color.Red;
                valid = false;
            }

            //Orq3 Width
            if (IsValidToDouble(textBoxOrq3Width.Text))
            {
                textBoxOrq3Width.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq3Width.ForeColor = Color.Red;
                valid = false;
            }

            //Orq Horizontal location
            if (IsValidToDouble(textBoxOrq1HLocation.Text))
            {
                textBoxOrq1HLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxOrq1HLocation.ForeColor = Color.Red;
                valid = false;
            }
            #endregion
            //Song numbers validation
            #region
            //Song Number1 font size
            if (IsValidToDouble(textBoxSN1FontSize.Text))
            {
                textBoxSN1FontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN1FontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number1 Vertical location
            if (IsValidToDouble(textBoxSN1VLocation.Text))
            {
                textBoxSN1VLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN1VLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number1 Hight
            if (IsValidToDouble(textBoxSN1Hight.Text))
            {
                textBoxSN1Hight.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN1Hight.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number1 Width
            if (IsValidToDouble(textBoxSN1Width.Text))
            {
                textBoxSN1Width.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN1Width.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number2 font size
            if (IsValidToDouble(textBoxSN2FontSize.Text))
            {
                textBoxSN2FontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN2FontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number2 Vertical location
            if (IsValidToDouble(textBoxSN2VLocation.Text))
            {
                textBoxSN2VLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN2VLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number2 Horizontal location
            if (IsValidToDouble(textBoxSN2HLocation.Text))
            {
                textBoxSN2HLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN2HLocation.ForeColor = Color.Red;
                //valid = false;
            }

            //Song Number2 Hight
            if (IsValidToDouble(textBoxSN2Hight.Text))
            {
                textBoxSN2Hight.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN2Hight.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number2 Width
            if (IsValidToDouble(textBoxSN2Width.Text))
            {
                textBoxSN2Width.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN2Width.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number3 font size
            if (IsValidToDouble(textBoxSN3FontSize.Text))
            {
                textBoxSN3FontSize.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN3FontSize.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number3 Vertical location
            if (IsValidToDouble(textBoxSN3VLocation.Text))
            {
                textBoxSN3VLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN3VLocation.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number3 Horizontal location
            if (IsValidToDouble(textBoxSN3HLocation.Text))
            {
                textBoxSN3HLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN3HLocation.ForeColor = Color.Red;
                //valid = false;
            }

            //Song Number3 Hight
            if (IsValidToDouble(textBoxSN3Hight.Text))
            {
                textBoxSN3Hight.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN3Hight.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number3 Width
            if (IsValidToDouble(textBoxSN3Width.Text))
            {
                textBoxSN3Width.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN3Width.ForeColor = Color.Red;
                valid = false;
            }

            //Song Number Horizontal location
            if (IsValidToDouble(textBoxSN1HLocation.Text))
            {
                textBoxSN1HLocation.ForeColor = Color.Black;
            }
            else
            {
                textBoxSN1HLocation.ForeColor = Color.Red;
                valid = false;
            }
            #endregion

            return valid;
        }

        //Save Updated UI to UISettings object
        private void GetUpdatedUI()
        {
            UISettings nui = new UISettings();
            //nui = ui;


            //colorInt = 
            nui.ThemeName = textBoxThemeName.Text;
            nui.AlbumSource = (Int16)comboBoxAlbumSource.SelectedIndex;
            nui.FormBGColor = ConvertColor(lblRGBMain.Text);                            //Main Form BG Color
            nui.SongBGColor = ConvertColor(lblSongRDB.Text);                            //Song Info (Top Panel) BG Color
            nui.OrqBGColor = ConvertColor(lblOrqRGB.Text);                              //Orq Info (Bottom Panel) BG Color
            
            //nui.ImgPosition = ConvertStringToDouble(textBoxImagePosition.Text);
            nui.ImgPosition = Double.Parse(textBoxImagePosition.Text, CultureInfo.InvariantCulture);     //Image position (.5 - middle)
            nui.OrqInfoVisible = checkBoxOrqInfo.Checked;                               //Orquestra Info visability
            nui.NextTandaVisible = checkBoxNextTanda.Checked;                           //Next Tanda Visability
            nui.SongCountMode = int.Parse(comboBoxSongNumberMode.Text);                 //0 - invisible; 1 - three rows; 2 - one row;
            nui.SongNumbOf = textBoxSNText.Text;

            //*********************** Current Song Info ********************************  
            #region
            //Artist (Orquestra) label
            nui.SongArtistFont = textBoxArtistFont.Font.Name;
            nui.SongArtistFontStyle = lblArtistFontStyleSelected.Text;                  //FontStyle text
            nui.SongArtistColor = ConvertColor(textBoxArtistColor.Text);                //.FromArgb(247, 220, 111);
            nui.FontSizeArtist = Double.Parse(textBoxArtistFontSize.Text, CultureInfo.InvariantCulture); //FONT SIZE multiplyer Current song Artist (Orquestra)
            nui.VerticalLocationArtist = Double.Parse(textBoxArtistVerticalLocation.Text, CultureInfo.InvariantCulture);  //Vertical Location multiplyer Current song Artist (Orquestra) label
            nui.WidthArtist = Double.Parse(textBoxArtistWidth.Text, CultureInfo.InvariantCulture);     //WIDTH multiplyer Current Artist (Orquestra) label
            nui.HeightArtist = Double.Parse(textBoxArtistHight.Text, CultureInfo.InvariantCulture);    //HEIGHT multiplyer Current Artist (Orquestra) label
            nui.SongArtistAlignment = comboBoxArtistAlignment.SelectedItem.ToString();

            //Title label
            nui.SongTitleFont = textBoxTitleFont.Font.Name;
            nui.SongTitleFontStyle = lblTitleFontStyleSelected.Text;
            nui.SongTitleColor = ConvertColor(textBoxTitleColor.Text);
            nui.FontSizeTitle = Double.Parse(textBoxTitleFontSize.Text, CultureInfo.InvariantCulture);  //FONT SIZE multiplyer Current song Title
            nui.VerticalLocationTitle = Double.Parse(textBoxTitleVerticalLocation.Text, CultureInfo.InvariantCulture);  //Vertical Location multiplyer Current song Title label
            nui.WidthTitle = Double.Parse(textBoxTitleWidth.Text, CultureInfo.InvariantCulture);   //WIDTH multiplyer Current song Title label
            nui.HeightTitle = Double.Parse(textBoxTitleHight.Text, CultureInfo.InvariantCulture);  //HEIGHT multiplyer Current song Title label
            nui.SongTitleAlignment = comboBoxTitleAlignment.SelectedItem.ToString();

            //Album (Singer) label
            nui.SongAlbumFont = textBoxAlbumFont.Font.Name;
            nui.SongAlbumFontStyle = lblAlbumFontStyleSelected.Text;
            nui.SongAlbumColor = ConvertColor(textBoxAlbumColor.Text);
            nui.FontSizeAlbum = Double.Parse(textBoxAlbumFontSize.Text, CultureInfo.InvariantCulture);  //FONT SIZE multiplyer Current song Album (Singer)
            nui.VerticalLocationAlbum = Double.Parse(textBoxAlbumVerticalLocation.Text, CultureInfo.InvariantCulture);  //Vertical Location multiplyer Current song Album label
            nui.WidthAlbum = Double.Parse(textBoxAlbumWidth.Text, CultureInfo.InvariantCulture);  //WIDTH multiplyer Current song Album label
            nui.HeightAlbum = Double.Parse(textBoxAlbumHight.Text, CultureInfo.InvariantCulture);  //HEIGHT multiplyer Current song Album label
            nui.SongAlbumAlignment = comboBoxAlbumAlignment.SelectedItem.ToString();

            //Next Tanda label
            nui.NextFont = textBoxNextTandaFont.Font.Name;
            nui.NextFontStyle = lblNextTandaFontStyleSelected.Text;
            nui.NextTandaColor = ConvertColor(textBoxNextTandaColor.Text);
            nui.FontSizeNext = Double.Parse(textBoxNextTandaFontSize.Text, CultureInfo.InvariantCulture); //FONT SIZE multiplyer Next Tanda
            nui.VerticalLocationNext = Double.Parse(textBoxNextTandaVerticalLocation.Text, CultureInfo.InvariantCulture);  //Vertical Location multiplyer Next Tanda label
            nui.WidthNext = Double.Parse(textBoxNextTandaWidth.Text, CultureInfo.InvariantCulture);  //WIDTH multiplyer Next Tanda label
            nui.HeightNext = Double.Parse(textBoxNextTandaHight.Text, CultureInfo.InvariantCulture);  //HEIGHT multiplyer Next Tanda label
            nui.NextTandaAlignment = comboBoxNextTandaAlignment.SelectedItem.ToString();
            #endregion

            //**************************** Orquestra ***********************************
            #region
            //Orquestra Info 1 (Top label)
            nui.OrqInfoFont1 = textBoxOrq1Font.Font.Name;
            nui.OrqInfoFontStyle1 = lblOrq1FontStyleSelected.Text;
            nui.OrqInfoColor1 = ConvertColor(textBoxOrq1Color.Text);
            nui.FontSizeOrq1 = Double.Parse(textBoxOrq1FontSize.Text, CultureInfo.InvariantCulture);                                 //FONT SIZE multiplyer Orq Info 1
            nui.VerticalLocationOrq1 = Double.Parse(textBoxOrq1VLocation.Text, CultureInfo.InvariantCulture);  //Vertical Location multiplyer Orq Info 1 label 
            nui.WidthOrq1 = Double.Parse(textBoxOrq1Width.Text, CultureInfo.InvariantCulture);                                    //WIDTH multiplyer Orq Info 1 label
            nui.HeightOrq1 = Double.Parse(textBoxOrq1Hight.Text, CultureInfo.InvariantCulture);                                 //HEIGHT multiplyer Orq Info 1 label
            nui.OrqInfoAlignment1 = comboBoxOrq1Alignment.SelectedItem.ToString();

            ////Orquestra Info 2 (Middle label)
            nui.OrqInfoFont2 = textBoxOrq2Font.Font.Name;
            nui.OrqInfoFontStyle2 = lblOrq2FontStyleSelected.Text;
            nui.OrqInfoColor2 = ConvertColor(textBoxOrq2Color.Text);
            nui.FontSizeOrq2 = Double.Parse(textBoxOrq2FontSize.Text, CultureInfo.InvariantCulture);                                 //FONT SIZE multiplyer Orq Info 2
            nui.VerticalLocationOrq2 = Double.Parse(textBoxOrq2VLocation.Text, CultureInfo.InvariantCulture);  //Vertical Location multiplyer Orq Info 2 label
            nui.WidthOrq2 = Double.Parse(textBoxOrq2Width.Text, CultureInfo.InvariantCulture);                                    //WIDTH multiplyer Orq Info 1 label
            nui.HeightOrq2 = Double.Parse(textBoxOrq2Hight.Text, CultureInfo.InvariantCulture);                                 //HEIGHT multiplyer Orq Info 1 label
            nui.OrqInfoAlignment2 = comboBoxOrq2Alignment.SelectedItem.ToString();

            ////Orquestra Info 3 (Bottom label)
            nui.OrqInfoFont3 = textBoxOrq3Font.Font.Name;
            nui.OrqInfoFontStyle3 = lblOrq3FontStyleSelected.Text;
            nui.OrqInfoColor3 = ConvertColor(textBoxOrq3Color.Text);
            nui.FontSizeOrq3 = Double.Parse(textBoxOrq3FontSize.Text, CultureInfo.InvariantCulture);                                 //FONT SIZE multiplyer Orq Info 3
            nui.VerticalLocationOrq3 = Double.Parse(textBoxOrq3VLocation.Text, CultureInfo.InvariantCulture);   //Vertical Location multiplyer Orq Info 3 label
            nui.WidthOrq3 = Double.Parse(textBoxOrq3Width.Text, CultureInfo.InvariantCulture);                                    //WIDTH multiplyer Orq Info 1 label
            nui.HeightOrq3 = Double.Parse(textBoxOrq3Hight.Text, CultureInfo.InvariantCulture);                                 //HEIGHT multiplyer Orq Info 1 label
            nui.OrqInfoAlignment3 = comboBoxOrq3Alignment.SelectedItem.ToString();

            nui.HorizontalLocationOrq = Double.Parse(textBoxOrq1HLocation.Text, CultureInfo.InvariantCulture);                                 //Horisontal Location multiplyer ORQ Info
            #endregion

            //************************** Song Numbers **********************************
            #region
            //Song Numbers 1 (Top label)
            nui.SongNumbFont1 = textBoxSN1Font.Font.Name;
            nui.SongNumbFontStyle1 = lblSN1FontStyleSelected.Text;
            nui.SongNumbColor1 = ConvertColor(textBoxSN1Color.Text);
            nui.FontSizeNumb1 = Double.Parse(textBoxSN1FontSize.Text, CultureInfo.InvariantCulture);  //FONT SIZE multiplyer Song Numbers 1
            nui.VerticalLocationNumb1 = Double.Parse(textBoxSN1VLocation.Text, CultureInfo.InvariantCulture); //Vertical Location multiplyer Song Number Current label
            nui.WidthNumb1 = Double.Parse(textBoxSN1Width.Text, CultureInfo.InvariantCulture); //WIDTH multiplyer Song Numb 1 label
            nui.HeightNumb1 = Double.Parse(textBoxSN1Hight.Text, CultureInfo.InvariantCulture);  //HEIGHT multiplyer Song Numb 1 label
            nui.SongNumberAlignment1 = comboBoxSN1Alignment.SelectedItem.ToString();

            //Song Numbers 2 (Middle label)
            nui.SongNumbFont2 = textBoxSN2Font.Font.Name;
            nui.SongNumbFontStyle2 = lblSN2FontStyleSelected.Text;
            nui.SongNumbColor2 = ConvertColor(textBoxSN2Color.Text);
            nui.FontSizeNumb2 = Double.Parse(textBoxSN2FontSize.Text, CultureInfo.InvariantCulture);  //FONT SIZE multiplyer Song Numbers 2
            nui.VerticalLocationNumb2 = Double.Parse(textBoxSN2VLocation.Text, CultureInfo.InvariantCulture); //Vertical Location multiplyer Song Number Middle label
            nui.WidthNumb2 = Double.Parse(textBoxSN2Width.Text, CultureInfo.InvariantCulture);  //WIDTH multiplyer Song Numb 2 label
            nui.HeightNumb2 = Double.Parse(textBoxSN2Hight.Text, CultureInfo.InvariantCulture);  //HEIGHT multiplyer Song Numb 2 label
            nui.SongNumberAlignment2 = comboBoxSN2Alignment.SelectedItem.ToString();

            //Song Numbers 3 (Bottom label)
            nui.SongNumbFont3 = textBoxSN3Font.Font.Name;
            nui.SongNumbFontStyle3 = lblSN3FontStyleSelected.Text;
            nui.SongNumbColor3 = ConvertColor(textBoxSN3Color.Text);
            nui.FontSizeNumb3 = Double.Parse(textBoxSN3FontSize.Text, CultureInfo.InvariantCulture);  //FONT SIZE multiplyer Song Numbers 3
            nui.VerticalLocationNumb3 = Double.Parse(textBoxSN3VLocation.Text, CultureInfo.InvariantCulture);  //Vertical Location multiplyer Song Number Total label
            nui.WidthNumb3 = Double.Parse(textBoxSN3Width.Text, CultureInfo.InvariantCulture);  //WIDTH multiplyer Song Numb 3 label
            nui.HeightNumb3 = Double.Parse(textBoxSN3Hight.Text, CultureInfo.InvariantCulture);  //HEIGHT multiplyer Song Numb 3 label
            nui.SongNumberAlignment3 = comboBoxSN3Alignment.SelectedItem.ToString();

            nui.HorizontalLocationNumb = Double.Parse(textBoxSN1HLocation.Text, CultureInfo.InvariantCulture); //Horisontal Location multiplyer Song Numbers
            #endregion

            ui = nui;
        }

        private void UpdateMainForm()
        {
            if (!ValidateUI())
            {
                MessageBox.Show("Please, correct errors 'Values in Red or empty'!");
            }
            else
            {
                GetUpdatedUI();

                textBoxThemeName.Text = ui.ThemeName;
                textBoxThemeName.Focus();

                mainForm.UpdateIU(ui);
                mainForm.Show();
            }
        }

        private string GetDigital(string s)
        {
            var allowedChars = "01234567890.";
            var k = new string(s.Where(c => allowedChars.Contains(c)).ToArray());

            return k;
        }

        //****************************   Buttons & Events  *********************************

        private void MediaInfoSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //save last theme name in application settings
            Properties.Settings.Default.ThemeName = comboBoxTheme.Text;
            Properties.Settings.Default.Save();
        }

        private void ComboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCurrentUI();
        }

        //General buttons
        #region
        private void BtnApplyTheme_Click(object sender, EventArgs e)
        {
            UpdateMainForm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateUI())
            {
                MessageBox.Show("Please, correct errors 'Values in Red or empty'!");
            }
            else
            {
                string currentTheme = textBoxThemeName.Text;

                if (currentTheme.Equals("Black") || currentTheme.Equals("Retro"))
                {
                    MessageBox.Show("Theme Black and Retro cannot be changed! Save current theme with different name.", "Save Theme!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!themeList.Contains(textBoxThemeName.Text))
                    {
                        ui.ThemeName = textBoxThemeName.Text;

                        comboBoxTheme.SelectedItem = textBoxThemeName.Text;

                        fixedCollection.Add(ui);        //Add current settings to current working collection
                        userCollection.Add(ui);         //Add current settings to user defined collection to save
                        themeList.Add(ui.ThemeName);    //Add theme name to the list

                        //Save serialized userCollection in "settings"
                        Properties.Settings.Default.UIXMLCollection = Serialization.CreateXML(userCollection);
                        Properties.Settings.Default.Save();

                        GetIni(themeList);
                        //GetCurrentUI();
                    }
                    else
                    {
                        ui.ThemeName = textBoxThemeName.Text;

                        comboBoxTheme.SelectedItem = textBoxThemeName.Text;

                        UISettings tempUc = new UISettings();

                        foreach (UISettings uc in userCollection)
                        {
                            if (uc.ThemeName.Equals(currentTheme))
                            {
                                tempUc = uc;
                            }

                        }

                        fixedCollection.Remove(tempUc);
                        fixedCollection.Add(ui);

                        userCollection.Remove(tempUc);
                        userCollection.Add(ui);

                        //Save serialized userCollection in "settings"
                        Properties.Settings.Default.UIXMLCollection = Serialization.CreateXML(userCollection);
                        Properties.Settings.Default.Save();

                        GetIni(themeList);
                        //GetCurrentUI();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string currentTheme = comboBoxTheme.Text;

            UISettings uiToRemove = new UISettings();

            if (currentTheme.Equals("Black")|| currentTheme.Equals("Retro"))
            {
                MessageBox.Show("Only user defined theme can be deleted!", "Delete Theme Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show(("Delete '" + currentTheme + "' theme?"), "Delete Theme?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    foreach (UISettings u in userCollection)
                    {
                        if (u.ThemeName.Equals(currentTheme))
                        {
                            uiToRemove = u;
                            themeList.Remove(currentTheme);
                        }
                    }

                    
                    fixedCollection.Remove(uiToRemove);
                    userCollection.Remove(uiToRemove);

                    //Save serialized userCollection in "settings"
                    Properties.Settings.Default.UIXMLCollection = Serialization.CreateXML(userCollection);
                    Properties.Settings.Default.Save();

                    GetIni(themeList);
                    UpdateMainForm();
                    MessageBox.Show(currentTheme + " Deleted!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion
        //Design buttons
        #region
        private void BtnMaioFormBGColor_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxMainFormBGColor.BackColor;
            //colorDialog.ShowDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxMainFormBGColor.BackColor = c;
                lblRGBMain.Text = c.R + "," + c.G + "," + c.B;
            }
        }

        private void BtnSongPanelBGColor_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxSongPanelBGColor.BackColor;
            //colorDialog.ShowDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxSongPanelBGColor.BackColor = c;
                lblSongRDB.Text = c.R + "," + c.G + "," + c.B;
            }
        }

        private void BtnOrqPanelBGColor_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxOrqPanelBGColor.BackColor;
            //colorDialog.ShowDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxOrqPanelBGColor.BackColor = c;
                lblOrqRGB.Text = c.R + "," + c.G + "," + c.B;
            }
        }
        #endregion
        //Song panel buttons
        #region
        private void BtnArtistFont_Click(object sender, EventArgs e)
        {

            fontDialog.Font = textBoxArtistFont.Font;
            //fontDialog.Font.Style = textBoxArtistStyle.Font.Style;
            //fontDialog.Color = textBoxArtistColor.ForeColor;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxArtistFont.Text = fontDialog.Font.Name;
                textBoxArtistFont.Font = fontDialog.Font;

                lblArtistFontStyleSelected.Text = fontDialog.Font.Style.ToString();

                //comboBoxArtistFontStyle.SelectedText = fontDialog.Font.Style.ToString();
                //textBoxArtistColor.BackColor = fontDialog.Color;
                //textBoxArtistColor.Text = fontDialog.Color.R.ToString() + "," + fontDialog.Color.G.ToString() + "," + fontDialog.Color.B.ToString();
            }
        }

        private void BtnArtistColor_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxArtistColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxArtistColor.BackColor = c;
                textBoxArtistColor.Text = c.R + "," + c.G + "," + c.B;
                textBoxArtistColor.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }

        private void BtnTitleFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxTitleFont.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxTitleFont.Text = fontDialog.Font.Name;
                textBoxTitleFont.Font = fontDialog.Font;

                lblTitleFontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnTitleColor_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxTitleColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxTitleColor.BackColor = c;
                textBoxTitleColor.Text = c.R + "," + c.G + "," + c.B;
                textBoxTitleColor.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }

        private void BtnAlbumFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxTitleFont.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxAlbumFont.Text = fontDialog.Font.Name;
                textBoxAlbumFont.Font = fontDialog.Font;

                lblAlbumFontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnAlbumColor_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxAlbumColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxAlbumColor.BackColor = c;
                textBoxAlbumColor.Text = c.R + "," + c.G + "," + c.B;
                textBoxAlbumColor.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }

        private void BtnNextTandaFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxNextTandaFont.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxNextTandaFont.Text = fontDialog.Font.Name;
                textBoxNextTandaFont.Font = fontDialog.Font;

                lblNextTandaFontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnNextTandaColor_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxNextTandaColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxNextTandaColor.BackColor = c;
                textBoxNextTandaColor.Text = c.R + "," + c.G + "," + c.B;
                textBoxNextTandaColor.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }
        #endregion
        //Orquestra buttons
        #region
        private void BtnOrq1Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxOrq1Font.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxOrq1Font.Text = fontDialog.Font.Name;
                textBoxOrq1Font.Font = fontDialog.Font;

                lblOrq1FontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnOrq1Color_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxOrq1Color.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxOrq1Color.BackColor = c;
                textBoxOrq1Color.Text = c.R + "," + c.G + "," + c.B;
                textBoxOrq1Color.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }

        private void BtnOrq2Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxOrq2Font.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxOrq2Font.Text = fontDialog.Font.Name;
                textBoxOrq2Font.Font = fontDialog.Font;

                lblOrq2FontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnOrq2Color_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxOrq2Color.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxOrq2Color.BackColor = c;
                textBoxOrq2Color.Text = c.R + "," + c.G + "," + c.B;
                textBoxOrq2Color.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }

        private void BtnOrq3Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxOrq3Font.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxOrq3Font.Text = fontDialog.Font.Name;
                textBoxOrq3Font.Font = fontDialog.Font;

                lblOrq3FontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnOrq3Color_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxOrq3Color.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxOrq3Color.BackColor = c;
                textBoxOrq3Color.Text = c.R + "," + c.G + "," + c.B;
                textBoxOrq3Color.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }
        #endregion
        //Song Numbers buttons
        #region
        private void BtnSN1Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxSN1Font.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxSN1Font.Text = fontDialog.Font.Name;
                textBoxSN1Font.Font = fontDialog.Font;

                lblSN1FontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnSN1Color_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxSN1Color.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxSN1Color.BackColor = c;
                textBoxSN1Color.Text = c.R + "," + c.G + "," + c.B;
                textBoxSN1Color.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }

        private void BtnSN2Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxSN2Font.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxSN2Font.Text = fontDialog.Font.Name;
                textBoxSN2Font.Font = fontDialog.Font;

                lblSN2FontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnSN2Color_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxSN2Color.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxSN2Color.BackColor = c;
                textBoxSN2Color.Text = c.R + "," + c.G + "," + c.B;
                textBoxSN2Color.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }

        private void BtnSN3Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = textBoxSN3Font.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxSN3Font.Text = fontDialog.Font.Name;
                textBoxSN3Font.Font = fontDialog.Font;

                lblSN3FontStyleSelected.Text = fontDialog.Font.Style.ToString();
            }
        }

        private void BtnSN3Color_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxSN3Color.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var c = colorDialog.Color;
                textBoxSN3Color.BackColor = c;
                textBoxSN3Color.Text = c.R + "," + c.G + "," + c.B;
                textBoxSN3Color.ForeColor = GetTextColor(c.R, c.G, c.B);
            }
        }



        #endregion
        //Textbox change Song 
        #region
        private void TextBoxImagePosition_TextChanged(object sender, EventArgs e)
        {
            textBoxImagePosition.Text = GetDigital(textBoxImagePosition.Text);
        }

        //Artist
        private void TextBoxArtistFontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxArtistFontSize.Text = GetDigital(textBoxArtistFontSize.Text);
        }

        private void TextBoxArtistVerticalLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxArtistVerticalLocation.Text = GetDigital(textBoxArtistVerticalLocation.Text);
        }

        private void TextBoxArtistHorizontalLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxArtistHorizontalLocation.Text = GetDigital(textBoxArtistHorizontalLocation.Text);
        }

        private void TextBoxArtistHight_TextChanged(object sender, EventArgs e)
        {
            textBoxArtistHight.Text = GetDigital(textBoxArtistHight.Text);
        }

        private void TextBoxArtistWidth_TextChanged(object sender, EventArgs e)
        {
            textBoxArtistWidth.Text = GetDigital(textBoxArtistWidth.Text);
        }

        //Title
        private void TextBoxTitleFontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxTitleFontSize.Text = GetDigital(textBoxTitleFontSize.Text);
        }

        private void TextBoxTitleVerticalLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxTitleVerticalLocation.Text = GetDigital(textBoxTitleVerticalLocation.Text);
        }

        private void TextBoxTitleHorizontalLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxTitleHorizontalLocation.Text = GetDigital(textBoxTitleHorizontalLocation.Text);
        }

        private void TextBoxTitleHight_TextChanged(object sender, EventArgs e)
        {
            textBoxTitleHight.Text = GetDigital(textBoxTitleHight.Text);
        }

        private void TextBoxTitleWidth_TextChanged(object sender, EventArgs e)
        {
            textBoxTitleWidth.Text = GetDigital(textBoxTitleWidth.Text);
        }

        //Album
        private void TextBoxAlbumFontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxAlbumFontSize.Text = GetDigital(textBoxAlbumFontSize.Text);
        }

        private void TextBoxAlbumVerticalLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxAlbumVerticalLocation.Text = GetDigital(textBoxAlbumVerticalLocation.Text);
        }

        private void TextBoxAlbumHorizontalLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxAlbumHorizontalLocation.Text = GetDigital(textBoxAlbumHorizontalLocation.Text);
        }

        private void TextBoxAlbumHight_TextChanged(object sender, EventArgs e)
        {
            textBoxAlbumHight.Text = GetDigital(textBoxAlbumHight.Text);
        }

        private void TextBoxAlbumWidth_TextChanged(object sender, EventArgs e)
        {
            textBoxAlbumWidth.Text = GetDigital(textBoxAlbumWidth.Text);
        }

        //Tanda
        private void TextBoxNextTandaFontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxNextTandaFontSize.Text = GetDigital(textBoxNextTandaFontSize.Text);
        }

        private void TextBoxNextTandaVerticalLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxNextTandaVerticalLocation.Text = GetDigital(textBoxNextTandaVerticalLocation.Text);
        }

        private void TextBoxNextTandaHorizontalLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxNextTandaHorizontalLocation.Text = GetDigital(textBoxNextTandaHorizontalLocation.Text);
        }

        private void TextBoxNextTandaHight_TextChanged(object sender, EventArgs e)
        {
            textBoxNextTandaHight.Text = GetDigital(textBoxNextTandaHight.Text);
        }

        private void TextBoxNextTandaWidth_TextChanged(object sender, EventArgs e)
        {
            textBoxNextTandaWidth.Text = GetDigital(textBoxNextTandaWidth.Text);
        }
        #endregion
        //Textbox change Orq
        #region
        //Orq1
        private void TextBoxOrq1FontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq1FontSize.Text = GetDigital(textBoxOrq1FontSize.Text);
        }

        private void TextBoxOrq1VLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq1VLocation.Text = GetDigital(textBoxOrq1VLocation.Text);
        }

        private void TextBoxOrq1Hight_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq1Hight.Text = GetDigital(textBoxOrq1Hight.Text);
        }

        private void TextBoxOrq1Width_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq1Width.Text = GetDigital(textBoxOrq1Width.Text);
        }

        //Orq2
        private void TextBoxOrq2FontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq2FontSize.Text = GetDigital(textBoxOrq2FontSize.Text);
        }

        private void TextBoxOrq2VLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq2VLocation.Text = GetDigital(textBoxOrq2VLocation.Text);
        }

        private void TextBoxOrq2HLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq2HLocation.Text = GetDigital(textBoxOrq2HLocation.Text);
        }

        private void TextBoxOrq2Hight_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq2Hight.Text = GetDigital(textBoxOrq2Hight.Text);
        }

        private void TextBoxOrq2Width_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq2Width.Text = GetDigital(textBoxOrq2Width.Text);
        }

        //Orq3
        private void TextBoxOrq3FontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq3FontSize.Text = GetDigital(textBoxOrq3FontSize.Text);
        }

        private void TextBoxOrq3VLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq3VLocation.Text = GetDigital(textBoxOrq3VLocation.Text);
        }

        private void TextBoxOrq3HLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq3HLocation.Text = GetDigital(textBoxOrq3HLocation.Text);
        }

        private void TextBoxOrq3Hight_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq3Hight.Text = GetDigital(textBoxOrq3Hight.Text);
        }

        private void TextBoxOrq3Width_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq3Width.Text = GetDigital(textBoxOrq3Width.Text);
        }
        //Orq Horizontal location
        private void TextBoxOrq1HLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxOrq1HLocation.Text = GetDigital(textBoxOrq1HLocation.Text);
        }
        #endregion
        //Textbox change Numbers
        #region
        //Song Numbers 1
        private void TextBoxSN1FontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxSN1FontSize.Text = GetDigital(textBoxSN1FontSize.Text);
        }

        private void TextBoxSN1VLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxSN1VLocation.Text = GetDigital(textBoxSN1VLocation.Text);
        }

        private void TextBoxSN1Hight_TextChanged(object sender, EventArgs e)
        {
            textBoxSN1Hight.Text = GetDigital(textBoxSN1Hight.Text);
        }

        private void TextBoxSN1Width_TextChanged(object sender, EventArgs e)
        {
            textBoxSN1Width.Text = GetDigital(textBoxSN1Width.Text);
        }

        //Song Numbers 2
        private void TextBoxSN2FontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxSN2FontSize.Text = GetDigital(textBoxSN2FontSize.Text);
        }

        private void TextBoxSN2VLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxSN2VLocation.Text = GetDigital(textBoxSN2VLocation.Text);
        }

        private void TextBoxSN2HLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxSN2HLocation.Text = GetDigital(textBoxSN2HLocation.Text);
        }

        private void TextBoxSN2Hight_TextChanged(object sender, EventArgs e)
        {
            textBoxSN2Hight.Text = GetDigital(textBoxSN2Hight.Text);
        }

        private void TextBoxSN2Width_TextChanged(object sender, EventArgs e)
        {
            textBoxSN2Width.Text = GetDigital(textBoxSN2Width.Text);
        }

        //Song Numbers 3
        private void TextBoxSN3FontSize_TextChanged(object sender, EventArgs e)
        {
            textBoxSN3FontSize.Text = GetDigital(textBoxSN3FontSize.Text);
        }

        private void TextBoxSN3VLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxSN3VLocation.Text = GetDigital(textBoxSN3VLocation.Text);
        }

        private void TextBoxSN3HLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxSN3HLocation.Text = GetDigital(textBoxSN3HLocation.Text);
        }

        private void TextBoxSN3Hight_TextChanged(object sender, EventArgs e)
        {
            textBoxSN3Hight.Text = GetDigital(textBoxSN3Hight.Text);
        }

        private void TextBoxSN3Width_TextChanged(object sender, EventArgs e)
        {
            textBoxSN3Width.Text = GetDigital(textBoxSN3Width.Text);
        }
        //Song numbers Horizontal Location
        private void TextBoxSN1HLocation_TextChanged(object sender, EventArgs e)
        {
            textBoxSN1HLocation.Text = GetDigital(textBoxSN1HLocation.Text);
        }
        #endregion
    }
}
