namespace DDP_Manager
{
    partial class DPPManager
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DPPManager));
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbURL = new System.Windows.Forms.ComboBox();
            this.lbContent = new System.Windows.Forms.ListBox();
            this.cbReentry = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbURL
            // 
            this.cbURL.AllowDrop = true;
            this.cbURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbURL.FormattingEnabled = true;
            this.cbURL.Items.AddRange(new object[] {
            "http://www.deutsche-dj-playlist.de/DDP-Charts/",
            "http://www.deutsche-dj-playlist.de/DDP-Charts-Top100/",
            "http://www.deutsche-dj-playlist.de/DDP-Charts-Hot50/",
            "http://www.deutsche-dj-playlist.de/DDP-Charts-Neueinsteiger/",
            "http://www.deutsche-dj-playlist.de/DDP-Charts-Regional/?acn=7",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=ewig",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2005",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2006",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2007",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2008",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2009",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2010",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2011",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2012",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2013",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2014",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2015",
            "http://www.deutsche-dj-playlist.de/DDP-Jahrescharts/?ddpJahr=2016",
            "http://www.deutsche-dj-playlist.de/DDP-Schlager-Charts/",
            "http://www.deutsche-dj-playlist.de/DDP-Schlager-Charts-Top100/",
            "http://www.deutsche-dj-playlist.de/DDP-Schlager-Charts-Hot50/",
            "http://www.deutsche-dj-playlist.de/DDP-Schlager-Charts-Neueinsteiger/"});
            this.cbURL.Location = new System.Drawing.Point(174, 12);
            this.cbURL.Name = "cbURL";
            this.cbURL.Size = new System.Drawing.Size(465, 21);
            this.cbURL.TabIndex = 5;
            // 
            // lbContent
            // 
            this.lbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContent.FormattingEnabled = true;
            this.lbContent.Location = new System.Drawing.Point(12, 41);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(699, 368);
            this.lbContent.TabIndex = 7;
            this.lbContent.DoubleClick += new System.EventHandler(this.lbContent_DoubleClick);
            // 
            // cbReentry
            // 
            this.cbReentry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReentry.AutoSize = true;
            this.cbReentry.Location = new System.Drawing.Point(645, 16);
            this.cbReentry.Name = "cbReentry";
            this.cbReentry.Size = new System.Drawing.Size(66, 17);
            this.cbReentry.TabIndex = 8;
            this.cbReentry.Text = "Re-entry";
            this.cbReentry.UseVisualStyleBackColor = true;
            // 
            // DPPManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 426);
            this.Controls.Add(this.cbReentry);
            this.Controls.Add(this.lbContent);
            this.Controls.Add(this.cbURL);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DPPManager";
            this.Text = "DDP Manager";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbURL;
        private System.Windows.Forms.ListBox lbContent;
        private System.Windows.Forms.CheckBox cbReentry;
    }
}

