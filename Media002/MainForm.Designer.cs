namespace Media002
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblOrqInfo1 = new System.Windows.Forms.Label();
            this.lblOrqInfo3 = new System.Windows.Forms.Label();
            this.lblNextSongArtist = new System.Windows.Forms.Label();
            this.lblOrqInfo2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerOrq = new System.Windows.Forms.SplitContainer();
            this.lblsongsTotal = new System.Windows.Forms.Label();
            this.lblOutOf = new System.Windows.Forms.Label();
            this.lblSongInTanda = new System.Windows.Forms.Label();
            this.splitContainerBig = new System.Windows.Forms.SplitContainer();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblCurSongAlbum = new System.Windows.Forms.Label();
            this.lblCurSongTitle = new System.Windows.Forms.Label();
            this.lblCurSongArtist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOrq)).BeginInit();
            this.splitContainerOrq.Panel1.SuspendLayout();
            this.splitContainerOrq.Panel2.SuspendLayout();
            this.splitContainerOrq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBig)).BeginInit();
            this.splitContainerBig.Panel1.SuspendLayout();
            this.splitContainerBig.Panel2.SuspendLayout();
            this.splitContainerBig.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox.Location = new System.Drawing.Point(398, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(225, 241);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDoubleClick);
            // 
            // lblOrqInfo1
            // 
            this.lblOrqInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrqInfo1.AutoSize = true;
            this.lblOrqInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOrqInfo1.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblOrqInfo1.Location = new System.Drawing.Point(8, 9);
            this.lblOrqInfo1.Name = "lblOrqInfo1";
            this.lblOrqInfo1.Size = new System.Drawing.Size(60, 13);
            this.lblOrqInfo1.TabIndex = 5;
            this.lblOrqInfo1.Text = "<OrqInfo1>";
            // 
            // lblOrqInfo3
            // 
            this.lblOrqInfo3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrqInfo3.AutoSize = true;
            this.lblOrqInfo3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOrqInfo3.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblOrqInfo3.Location = new System.Drawing.Point(8, 157);
            this.lblOrqInfo3.Name = "lblOrqInfo3";
            this.lblOrqInfo3.Size = new System.Drawing.Size(60, 13);
            this.lblOrqInfo3.TabIndex = 4;
            this.lblOrqInfo3.Text = "<OrqInfo3>";
            // 
            // lblNextSongArtist
            // 
            this.lblNextSongArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextSongArtist.AutoSize = true;
            this.lblNextSongArtist.Location = new System.Drawing.Point(339, 211);
            this.lblNextSongArtist.Name = "lblNextSongArtist";
            this.lblNextSongArtist.Size = new System.Drawing.Size(0, 13);
            this.lblNextSongArtist.TabIndex = 2;
            // 
            // lblOrqInfo2
            // 
            this.lblOrqInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrqInfo2.AutoSize = true;
            this.lblOrqInfo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOrqInfo2.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblOrqInfo2.Location = new System.Drawing.Point(8, 78);
            this.lblOrqInfo2.Name = "lblOrqInfo2";
            this.lblOrqInfo2.Size = new System.Drawing.Size(60, 13);
            this.lblOrqInfo2.TabIndex = 1;
            this.lblOrqInfo2.Text = "<OrqInfo2>";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(0, 13);
            this.lbl1.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Method";
            this.dataGridViewTextBoxColumn1.HeaderText = "Method";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Target";
            this.dataGridViewTextBoxColumn2.HeaderText = "Target";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // splitContainerOrq
            // 
            this.splitContainerOrq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.splitContainerOrq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOrq.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOrq.Name = "splitContainerOrq";
            // 
            // splitContainerOrq.Panel1
            // 
            this.splitContainerOrq.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.splitContainerOrq.Panel1.Controls.Add(this.lblsongsTotal);
            this.splitContainerOrq.Panel1.Controls.Add(this.lblOutOf);
            this.splitContainerOrq.Panel1.Controls.Add(this.lblSongInTanda);
            this.splitContainerOrq.Panel1.Controls.Add(this.lbl1);
            this.splitContainerOrq.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainerOrq.Panel2
            // 
            this.splitContainerOrq.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.splitContainerOrq.Panel2.Controls.Add(this.lblOrqInfo3);
            this.splitContainerOrq.Panel2.Controls.Add(this.lblNextSongArtist);
            this.splitContainerOrq.Panel2.Controls.Add(this.lblOrqInfo2);
            this.splitContainerOrq.Panel2.Controls.Add(this.lblOrqInfo1);
            this.splitContainerOrq.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerOrq.Size = new System.Drawing.Size(1024, 241);
            this.splitContainerOrq.SplitterDistance = 623;
            this.splitContainerOrq.TabIndex = 2;
            this.splitContainerOrq.SizeChanged += new System.EventHandler(this.splitContainer_SizeChanged);
            // 
            // lblsongsTotal
            // 
            this.lblsongsTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblsongsTotal.AutoSize = true;
            this.lblsongsTotal.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblsongsTotal.Location = new System.Drawing.Point(12, 211);
            this.lblsongsTotal.Name = "lblsongsTotal";
            this.lblsongsTotal.Size = new System.Drawing.Size(69, 13);
            this.lblsongsTotal.TabIndex = 6;
            this.lblsongsTotal.Text = "<totalSongs>";
            // 
            // lblOutOf
            // 
            this.lblOutOf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutOf.AutoSize = true;
            this.lblOutOf.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblOutOf.Location = new System.Drawing.Point(12, 96);
            this.lblOutOf.Name = "lblOutOf";
            this.lblOutOf.Size = new System.Drawing.Size(34, 13);
            this.lblOutOf.TabIndex = 6;
            this.lblOutOf.Text = "out of";
            // 
            // lblSongInTanda
            // 
            this.lblSongInTanda.AutoSize = true;
            this.lblSongInTanda.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblSongInTanda.Location = new System.Drawing.Point(12, 22);
            this.lblSongInTanda.Name = "lblSongInTanda";
            this.lblSongInTanda.Size = new System.Drawing.Size(82, 13);
            this.lblSongInTanda.TabIndex = 6;
            this.lblSongInTanda.Text = "<songInTanda>";
            // 
            // splitContainerBig
            // 
            this.splitContainerBig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBig.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBig.Name = "splitContainerBig";
            this.splitContainerBig.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBig.Panel1
            // 
            this.splitContainerBig.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.splitContainerBig.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainerBig.Panel1.Controls.Add(this.lblNext);
            this.splitContainerBig.Panel1.Controls.Add(this.lblCurSongAlbum);
            this.splitContainerBig.Panel1.Controls.Add(this.lblCurSongTitle);
            this.splitContainerBig.Panel1.Controls.Add(this.lblCurSongArtist);
            this.splitContainerBig.Panel1.ForeColor = System.Drawing.Color.DarkGray;
            // 
            // splitContainerBig.Panel2
            // 
            this.splitContainerBig.Panel2.BackColor = System.Drawing.Color.Ivory;
            this.splitContainerBig.Panel2.Controls.Add(this.splitContainerOrq);
            this.splitContainerBig.Size = new System.Drawing.Size(1024, 576);
            this.splitContainerBig.SplitterDistance = 331;
            this.splitContainerBig.TabIndex = 9;
            // 
            // lblNext
            // 
            this.lblNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNext.AutoSize = true;
            this.lblNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.lblNext.Location = new System.Drawing.Point(3, 305);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(39, 13);
            this.lblNext.TabIndex = 9;
            this.lblNext.Text = "<next>";
            // 
            // lblCurSongAlbum
            // 
            this.lblCurSongAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurSongAlbum.AutoSize = true;
            this.lblCurSongAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblCurSongAlbum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(207)))));
            this.lblCurSongAlbum.Location = new System.Drawing.Point(3, 201);
            this.lblCurSongAlbum.Name = "lblCurSongAlbum";
            this.lblCurSongAlbum.Size = new System.Drawing.Size(63, 13);
            this.lblCurSongAlbum.TabIndex = 8;
            this.lblCurSongAlbum.Text = "<curAlbum>";
            // 
            // lblCurSongTitle
            // 
            this.lblCurSongTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurSongTitle.AutoEllipsis = true;
            this.lblCurSongTitle.AutoSize = true;
            this.lblCurSongTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblCurSongTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(207)))));
            this.lblCurSongTitle.Location = new System.Drawing.Point(3, 104);
            this.lblCurSongTitle.Name = "lblCurSongTitle";
            this.lblCurSongTitle.Size = new System.Drawing.Size(54, 13);
            this.lblCurSongTitle.TabIndex = 6;
            this.lblCurSongTitle.Text = "<curTitle>";
            // 
            // lblCurSongArtist
            // 
            this.lblCurSongArtist.AutoSize = true;
            this.lblCurSongArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lblCurSongArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(220)))), ((int)(((byte)(111)))));
            this.lblCurSongArtist.Location = new System.Drawing.Point(3, 9);
            this.lblCurSongArtist.Name = "lblCurSongArtist";
            this.lblCurSongArtist.Size = new System.Drawing.Size(57, 13);
            this.lblCurSongArtist.TabIndex = 7;
            this.lblCurSongArtist.Text = "<curArtist>";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1024, 576);
            this.Controls.Add(this.splitContainerBig);
            this.ForeColor = System.Drawing.Color.Gray;
            this.MinimumSize = new System.Drawing.Size(1024, 576);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Media Info by Alex Baliasnikau - v1.0";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.splitContainerOrq.Panel1.ResumeLayout(false);
            this.splitContainerOrq.Panel1.PerformLayout();
            this.splitContainerOrq.Panel2.ResumeLayout(false);
            this.splitContainerOrq.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOrq)).EndInit();
            this.splitContainerOrq.ResumeLayout(false);
            this.splitContainerBig.Panel1.ResumeLayout(false);
            this.splitContainerBig.Panel1.PerformLayout();
            this.splitContainerBig.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBig)).EndInit();
            this.splitContainerBig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNextSongArtist;
        private System.Windows.Forms.Label lblOrqInfo2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lblOrqInfo3;
        private System.Windows.Forms.Label lblOrqInfo1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.SplitContainer splitContainerOrq;
        private System.Windows.Forms.Label lblCurSongAlbum;
        private System.Windows.Forms.Label lblCurSongArtist;
        private System.Windows.Forms.Label lblCurSongTitle;
        private System.Windows.Forms.SplitContainer splitContainerBig;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblsongsTotal;
        private System.Windows.Forms.Label lblOutOf;
        private System.Windows.Forms.Label lblSongInTanda;
    }
}

