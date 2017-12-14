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
            this.lbContent1 = new System.Windows.Forms.ListBox();
            this.lbContent2 = new System.Windows.Forms.ListBox();
            this.lbContent3 = new System.Windows.Forms.ListBox();
            this.lblContent1 = new System.Windows.Forms.Label();
            this.lblContent2 = new System.Windows.Forms.Label();
            this.lblContent3 = new System.Windows.Forms.Label();
            this.tbSaveDirectory = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
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
            // lbContent1
            // 
            this.lbContent1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContent1.FormattingEnabled = true;
            this.lbContent1.Location = new System.Drawing.Point(12, 54);
            this.lbContent1.Name = "lbContent1";
            this.lbContent1.Size = new System.Drawing.Size(699, 121);
            this.lbContent1.TabIndex = 7;
            this.lbContent1.DoubleClick += new System.EventHandler(this.lbContent_DoubleClick);
            // 
            // lbContent2
            // 
            this.lbContent2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContent2.FormattingEnabled = true;
            this.lbContent2.Location = new System.Drawing.Point(12, 194);
            this.lbContent2.Name = "lbContent2";
            this.lbContent2.Size = new System.Drawing.Size(699, 121);
            this.lbContent2.TabIndex = 9;
            this.lbContent2.DoubleClick += new System.EventHandler(this.lbContent_DoubleClick);
            // 
            // lbContent3
            // 
            this.lbContent3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContent3.FormattingEnabled = true;
            this.lbContent3.Location = new System.Drawing.Point(12, 334);
            this.lbContent3.Name = "lbContent3";
            this.lbContent3.Size = new System.Drawing.Size(699, 121);
            this.lbContent3.TabIndex = 10;
            this.lbContent3.DoubleClick += new System.EventHandler(this.lbContent_DoubleClick);
            // 
            // lblContent1
            // 
            this.lblContent1.AutoSize = true;
            this.lblContent1.Location = new System.Drawing.Point(12, 38);
            this.lblContent1.Name = "lblContent1";
            this.lblContent1.Size = new System.Drawing.Size(187, 13);
            this.lblContent1.TabIndex = 11;
            this.lblContent1.Text = "DEUTSCHE-DJ-PLAYLIST - TOP 100";
            // 
            // lblContent2
            // 
            this.lblContent2.AutoSize = true;
            this.lblContent2.Location = new System.Drawing.Point(12, 178);
            this.lblContent2.Name = "lblContent2";
            this.lblContent2.Size = new System.Drawing.Size(232, 13);
            this.lblContent2.TabIndex = 12;
            this.lblContent2.Text = "DEUTSCHE-DJ-PLAYLIST - NEUEINSTEIGER";
            // 
            // lblContent3
            // 
            this.lblContent3.AutoSize = true;
            this.lblContent3.Location = new System.Drawing.Point(12, 318);
            this.lblContent3.Name = "lblContent3";
            this.lblContent3.Size = new System.Drawing.Size(253, 13);
            this.lblContent3.TabIndex = 13;
            this.lblContent3.Text = "DEUTSCHE-DJ-PLAYLIST - WIEDEREINSTEIGER";
            // 
            // tbSaveDirectory
            // 
            this.tbSaveDirectory.Location = new System.Drawing.Point(175, 13);
            this.tbSaveDirectory.Name = "tbSaveDirectory";
            this.tbSaveDirectory.Size = new System.Drawing.Size(455, 20);
            this.tbSaveDirectory.TabIndex = 14;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(636, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 15;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // DPPManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 468);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbSaveDirectory);
            this.Controls.Add(this.lblContent3);
            this.Controls.Add(this.lblContent2);
            this.Controls.Add(this.lblContent1);
            this.Controls.Add(this.lbContent3);
            this.Controls.Add(this.lbContent2);
            this.Controls.Add(this.lbContent1);
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
        private System.Windows.Forms.ListBox lbContent1;
        private System.Windows.Forms.ListBox lbContent2;
        private System.Windows.Forms.ListBox lbContent3;
        private System.Windows.Forms.Label lblContent1;
        private System.Windows.Forms.Label lblContent2;
        private System.Windows.Forms.Label lblContent3;
        private System.Windows.Forms.TextBox tbSaveDirectory;
        private System.Windows.Forms.Button btnOpen;
    }
}

