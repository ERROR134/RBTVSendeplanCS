namespace RBTVSendeplanCS
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.eventListPanel = new System.Windows.Forms.Panel();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.picReddit = new System.Windows.Forms.PictureBox();
            this.picTwitch = new System.Windows.Forms.PictureBox();
            this.picFb = new System.Windows.Forms.PictureBox();
            this.picTwitter = new System.Windows.Forms.PictureBox();
            this.picG2a = new System.Windows.Forms.PictureBox();
            this.picRbShop = new System.Windows.Forms.PictureBox();
            this.picAmazon = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReddit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picG2a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRbShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAmazon)).BeginInit();
            this.SuspendLayout();
            // 
            // eventListPanel
            // 
            this.eventListPanel.AutoScroll = true;
            this.eventListPanel.Location = new System.Drawing.Point(12, 27);
            this.eventListPanel.Name = "eventListPanel";
            this.eventListPanel.Size = new System.Drawing.Size(285, 251);
            this.eventListPanel.TabIndex = 0;
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipText = "TExt";
            this.NotifyIcon.BalloonTipTitle = "Titel";
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "RBTV Sendeplan";
            this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(309, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // picReddit
            // 
            this.picReddit.Image = global::RBTVSendeplanCS.Properties.Resources.reddit;
            this.picReddit.Location = new System.Drawing.Point(191, 330);
            this.picReddit.Name = "picReddit";
            this.picReddit.Size = new System.Drawing.Size(62, 40);
            this.picReddit.TabIndex = 8;
            this.picReddit.TabStop = false;
            this.picReddit.Click += new System.EventHandler(this.picReddit_Click);
            this.picReddit.MouseEnter += new System.EventHandler(this.picReddit_MouseEnter);
            this.picReddit.MouseLeave += new System.EventHandler(this.picReddit_MouseLeave);
            // 
            // picTwitch
            // 
            this.picTwitch.Image = global::RBTVSendeplanCS.Properties.Resources.Twitch;
            this.picTwitch.Location = new System.Drawing.Point(123, 330);
            this.picTwitch.Name = "picTwitch";
            this.picTwitch.Size = new System.Drawing.Size(62, 40);
            this.picTwitch.TabIndex = 7;
            this.picTwitch.TabStop = false;
            this.picTwitch.Click += new System.EventHandler(this.picTwitch_Click);
            this.picTwitch.MouseEnter += new System.EventHandler(this.picTwitch_MouseEnter);
            this.picTwitch.MouseLeave += new System.EventHandler(this.picTwitch_MouseLeave);
            // 
            // picFb
            // 
            this.picFb.Image = global::RBTVSendeplanCS.Properties.Resources.facebook;
            this.picFb.Location = new System.Drawing.Point(55, 330);
            this.picFb.Name = "picFb";
            this.picFb.Size = new System.Drawing.Size(62, 40);
            this.picFb.TabIndex = 6;
            this.picFb.TabStop = false;
            this.picFb.Click += new System.EventHandler(this.picFb_Click);
            this.picFb.MouseEnter += new System.EventHandler(this.picFb_MouseEnter);
            this.picFb.MouseLeave += new System.EventHandler(this.picFb_MouseLeave);
            // 
            // picTwitter
            // 
            this.picTwitter.Image = global::RBTVSendeplanCS.Properties.Resources.twitter;
            this.picTwitter.Location = new System.Drawing.Point(226, 284);
            this.picTwitter.Name = "picTwitter";
            this.picTwitter.Size = new System.Drawing.Size(62, 40);
            this.picTwitter.TabIndex = 5;
            this.picTwitter.TabStop = false;
            this.picTwitter.Click += new System.EventHandler(this.picTwitter_Click);
            this.picTwitter.MouseEnter += new System.EventHandler(this.picTwitter_MouseEnter);
            this.picTwitter.MouseLeave += new System.EventHandler(this.picTwitter_MouseLeave);
            // 
            // picG2a
            // 
            this.picG2a.Image = global::RBTVSendeplanCS.Properties.Resources.g2a;
            this.picG2a.Location = new System.Drawing.Point(158, 284);
            this.picG2a.Name = "picG2a";
            this.picG2a.Size = new System.Drawing.Size(62, 40);
            this.picG2a.TabIndex = 3;
            this.picG2a.TabStop = false;
            this.picG2a.Click += new System.EventHandler(this.picG2a_Click);
            this.picG2a.MouseEnter += new System.EventHandler(this.picG2a_MouseEnter);
            this.picG2a.MouseLeave += new System.EventHandler(this.picG2a_MouseLeave);
            // 
            // picRbShop
            // 
            this.picRbShop.Image = global::RBTVSendeplanCS.Properties.Resources.rbshop;
            this.picRbShop.Location = new System.Drawing.Point(90, 284);
            this.picRbShop.Name = "picRbShop";
            this.picRbShop.Size = new System.Drawing.Size(62, 40);
            this.picRbShop.TabIndex = 2;
            this.picRbShop.TabStop = false;
            this.picRbShop.Click += new System.EventHandler(this.picRbShop_Click);
            this.picRbShop.MouseEnter += new System.EventHandler(this.picRbShop_MouseEnter);
            this.picRbShop.MouseLeave += new System.EventHandler(this.picRbShop_MouseLeave);
            // 
            // picAmazon
            // 
            this.picAmazon.Image = global::RBTVSendeplanCS.Properties.Resources.amazon_logo_SPOT;
            this.picAmazon.Location = new System.Drawing.Point(22, 284);
            this.picAmazon.Name = "picAmazon";
            this.picAmazon.Size = new System.Drawing.Size(62, 40);
            this.picAmazon.TabIndex = 1;
            this.picAmazon.TabStop = false;
            this.picAmazon.Click += new System.EventHandler(this.picAmazon_Click);
            this.picAmazon.MouseEnter += new System.EventHandler(this.picAmazon_MouseEnter);
            this.picAmazon.MouseLeave += new System.EventHandler(this.picAmazon_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 387);
            this.Controls.Add(this.picReddit);
            this.Controls.Add(this.picTwitch);
            this.Controls.Add(this.picFb);
            this.Controls.Add(this.picTwitter);
            this.Controls.Add(this.picG2a);
            this.Controls.Add(this.picRbShop);
            this.Controls.Add(this.picAmazon);
            this.Controls.Add(this.eventListPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RocketBeansTV";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReddit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picG2a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRbShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAmazon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.Panel eventListPanel;
        private System.Windows.Forms.PictureBox picAmazon;
        private System.Windows.Forms.PictureBox picRbShop;
        private System.Windows.Forms.PictureBox picG2a;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.PictureBox picTwitter;
        private System.Windows.Forms.PictureBox picReddit;
        private System.Windows.Forms.PictureBox picTwitch;
        private System.Windows.Forms.PictureBox picFb;



    }
}

