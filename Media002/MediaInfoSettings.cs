using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media002
{
    public partial class MediaInfoSettings : Form
    {
        private UISettings ui;

        public MediaInfoSettings()
        {
            InitializeComponent();
        }

        public static UISettings GetUI()
        {
            UISettings ui1 = new UISettings();
            return ui1;
        }

        private void BtnArtistFont_Click(object sender, EventArgs e)
        {
            //fontDialog.ShowColor = true;

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
            colorDialog.ShowDialog();
            textBoxArtistColor.BackColor = colorDialog.Color;
        }
    }
}
