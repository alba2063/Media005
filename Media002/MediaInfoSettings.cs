using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaInfo
{
    public partial class MediaInfoSettings : Form
    {
        public UISettings ui;
        private static UISettingsCollection uiCollection;

        public MediaInfoSettings()
        {
            InitializeComponent();

            GetUI();
            GetIni();

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
            uiCollection = new UISettingsCollection();
            uiCollection.Add(uiBlack);
            uiCollection.Add(uiRetro);

        }

        public UISettings GetIni()
        {
            List<string> themeList = new List<string>();

            //Get list of all available Themes
            foreach (UISettings u in uiCollection)
            {
                themeList.Add(u.ThemeName);
            }
            
            comboBoxTheme.DataSource = themeList;
            //Load last Theme name
            comboBoxTheme.SelectedItem = Properties.Settings.Default.ThemeName;
            
            //Set last UI as staring UI
            foreach (UISettings u in uiCollection)
            {
                if (u.ThemeName.Equals(comboBoxTheme.SelectedItem))
                {
                    ui = u;
                }         
            }

            return ui;
        }

        private void SetIni()
        {
            //Design
            #region
            textBoxMainFormBGColor.BackColor = ui.FormBGColor;
            lblRGBMain.Text = ui.FormBGColor.R + "," + ui.FormBGColor.G + "," + ui.FormBGColor.B;
            lblRGBMain.ForeColor = Color.FromArgb(85, 85, 85);


            textBoxSongPanelBGColor.BackColor = ui.SongBGColor;
            lblSongRDB.Text = ui.SongBGColor.R + "," + ui.SongBGColor.G + "," + ui.SongBGColor.B;
            lblSongRDB.ForeColor = Color.FromArgb(85, 85, 85);


            textBoxOrqPanelBGColor.BackColor = ui.OrqBGColor;
            lblOrqRGB.Text = ui.OrqBGColor.R + "," + ui.OrqBGColor.G + "," + ui.OrqBGColor.B;
            lblOrqRGB.ForeColor = Color.FromArgb(85, 85, 85);


            textBoxImagePosition.Text = ui.ImgPosition.ToString();
            textBoxImagePosition.TextAlign = HorizontalAlignment.Center;

            checkBoxNextTanda.Checked = ui.NextTandaVisible;
            checkBoxOrqInfo.Checked = ui.OrqInfoVisible;

            comboBoxSongNumberMode.SelectedItem = ui.SongCountMode.ToString();
            //comboBoxSongNumberMode.SelectedText. = HorizontalAlignment.Center;

            textBoxSNText.Text = ui.SongNumbOf;
            textBoxSNText.TextAlign = HorizontalAlignment.Center;

            textBoxThemeName.Text = ui.ThemeName;
            textBoxArtistFont.Text = ui.SongArtistFont.Name;
            #endregion

            //Song Artist
            #region
            textBoxArtistFont.Text = ui.SongArtistFont.Name;
            textBoxArtistColor.BackColor = ui.SongArtistColor;

            textBoxArtistSize.Text = ui.FontSizeArtist.ToString();
            textBoxArtistSize.TextAlign = HorizontalAlignment.Center;

            comboBoxArtistAlignment.SelectedItem = ui.SongArtistAlignment.ToString();

            textBoxArtistVerticalLocation.Text = ui.VerticalLocationArtist.ToString();
            textBoxArtistVerticalLocation.TextAlign = HorizontalAlignment.Center;

            textBoxArtistHorizontalLocation.Text = "";
            textBoxArtistHorizontalLocation.TextAlign = HorizontalAlignment.Center;

            textBoxArtistHight.Text = ui.HeightArtist.ToString();
            textBoxArtistHight.TextAlign = HorizontalAlignment.Center;

            textBoxArtistWidth.Text = ui.WidthArtist.ToString();
            textBoxArtistWidth.TextAlign = HorizontalAlignment.Center;

            #endregion

            //Song Title
            #region



            #endregion
        }

        private void BtnArtistFont_Click(object sender, EventArgs e)
        {

            fontDialog.Font = textBoxArtistFont.Font;
            //fontDialog.Font.Style = textBoxArtistStyle.Font.Style;
            fontDialog.Color = textBoxArtistColor.ForeColor;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                textBoxArtistFont.Text = fontDialog.Font.Name;
                textBoxArtistFont.Font = fontDialog.Font;
                //textBoxArtistColor.BackColor = fontDialog.Color;
                //textBoxArtistColor.Text = fontDialog.Color.R.ToString() + "," + fontDialog.Color.G.ToString() + "," + fontDialog.Color.B.ToString();
            }
        }

        private void BtnArtistColor_Click(object sender, EventArgs e)
        {
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            colorDialog.Color = textBoxArtistColor.BackColor;
            //colorDialog.ShowDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxArtistColor.BackColor = colorDialog.Color;
            }
        }

        private void MediaInfoSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ThemeName = comboBoxTheme.Text;
            Properties.Settings.Default.Save();
        }

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
    }
}
