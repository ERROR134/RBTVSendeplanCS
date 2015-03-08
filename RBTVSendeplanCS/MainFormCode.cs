using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RBTVSendeplanCS
{
    public partial class MainForm : Form
    {
        void Init()
        {
            //Set SizeMode to Zoom. So Images will fit perfectly
            picAmazon.SizeMode = PictureBoxSizeMode.Zoom;
            picG2a.SizeMode = PictureBoxSizeMode.Zoom;
            picRbShop.SizeMode = PictureBoxSizeMode.Zoom;
            picTwitter.SizeMode = PictureBoxSizeMode.Zoom;
            picFb.SizeMode = PictureBoxSizeMode.Zoom;
            picTwitch.SizeMode = PictureBoxSizeMode.Zoom;
            picReddit.SizeMode = PictureBoxSizeMode.Zoom;

            m_toolTip = new ToolTip(this.components);

            UpdateTimer.Interval = RBTVSendeplanCS.Properties.Settings.Default.UpdateInterval * 60 * 1000;
            UpdateTimer.Enabled = true;

			Label loadingLabel = new Label() { Text = "Loading events...", Font = new Font(Font.Name, 10, FontStyle.Regular), Location = new Point(5, 10), Size = new Size(eventListPanel.Size.Width, 20) };
			eventListPanel.Controls.Add(loadingLabel);
        }

        bool CheckForSettingsFile()
        {
            return false;
        }

        bool SaveSettings()
        {
            RbtvPlanSettings newSettings = new RbtvPlanSettings();
            newSettings.UpdateInterval = RBTVSendeplanCS.Properties.Settings.Default.UpdateInterval;
            newSettings.NotificationTime = RBTVSendeplanCS.Properties.Settings.Default.NotificationTime;
            newSettings.Version = RBTVSendeplanCS.Properties.Settings.Default.Version;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            newSettings.Context.

            newSettings.Save();
            return true;
        }

        bool LoadSettings()
        {
            return true;
        }

        #region Menustrip Code
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anfang erstellt von http://www.reddit.com/user/ERROR134 .\nMittlerweile von der Community auf Github gewartet.\nVersion 0.6\nDie Links auf Amazon, G2A und Rocketbeans-shop habe ich von den Bohnen kopiert, damit jegliches Geld daraus ihnen zur Verfügung steht. Dieser Sendeplan wurde von der Rocketbeans-Community ( http://www.reddit.de/r/rocketbeans ) erstellt und steht jedem kostenlos zur Verfügung.\nDas Programm ist zur Zeit noch Work in Progress, um Infos über neue Versionen zu bekommen und diese runterzuladen bitte den entsprechen Post in Reddit besuchen (http://www.reddit.com/r/rocketbeans/comments/2tk4vk/rbtv_sendeplan_windows/)");
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            if (settings.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                UpdateTimer.Interval = RBTVSendeplanCS.Properties.Settings.Default.UpdateInterval * 1000 * 60;
                UpdateTimer.Start();
            }
        }
        #endregion

        #region PictureBox Mouse Events
        private void picAmazon_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.amazon.de/?_encoding=UTF8&camp=1638&creative=19454&linkCode=ur2&site-redirect=de&tag=rocketbeansde-21&linkId=TS4VQU7BZNNUKCKO");
        }
        private void picAmazon_MouseEnter(object sender, EventArgs e)
        {
            m_toolTip.Show("Amazon", picAmazon);
            Cursor = Cursors.Hand;
        }
        private void picAmazon_MouseLeave(object sender, EventArgs e)
        {
            m_toolTip.Hide(picAmazon);
            Cursor = Cursors.Arrow;
        }

        private void picRbShop_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.rocketbeans-shop.de");
        }
        private void picRbShop_MouseEnter(object sender, EventArgs e)
        {
            m_toolTip.Show("Rocketbeans-Shop", picRbShop);
            Cursor = Cursors.Hand;
        }
        private void picRbShop_MouseLeave(object sender, EventArgs e)
        {
            m_toolTip.Hide(picRbShop);
            Cursor = Cursors.Arrow;
        }

        private void picG2a_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.g2a.com/r/rocket-beans");
        }
        private void picG2a_MouseEnter(object sender, EventArgs e)
        {
            m_toolTip.Show("G2A", picG2a);
            Cursor = Cursors.Hand;
        }
        private void picG2a_MouseLeave(object sender, EventArgs e)
        {
            m_toolTip.Hide(picG2a);
            Cursor = Cursors.Arrow;
        }

        private void picTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/TheRocketBeans");
        }
        private void picTwitter_MouseEnter(object sender, EventArgs e)
        {
            m_toolTip.Show("Twitter", picTwitter);
            Cursor = Cursors.Hand;
        }
        private void picTwitter_MouseLeave(object sender, EventArgs e)
        {
            m_toolTip.Hide(picTwitter);
            Cursor = Cursors.Arrow;
        }

        private void picFb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/RocketBeansTV");
        }
        private void picFb_MouseEnter(object sender, EventArgs e)
        {
            m_toolTip.Show("Facebook", picFb);
            Cursor = Cursors.Hand;
        }
        private void picFb_MouseLeave(object sender, EventArgs e)
        {
            m_toolTip.Hide(picFb);
            Cursor = Cursors.Arrow;
        }

        private void picTwitch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitch.tv/rocketbeanstv");
        }
        private void picTwitch_MouseEnter(object sender, EventArgs e)
        {
            m_toolTip.Show("Stream öffnen", picTwitch);
            Cursor = Cursors.Hand;
        }
        private void picTwitch_MouseLeave(object sender, EventArgs e)
        {
            m_toolTip.Hide(picTwitch);
            Cursor = Cursors.Arrow;
        }

        private void picReddit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.reddit.com/r/rocketbeans/");
        }
        private void picReddit_MouseEnter(object sender, EventArgs e)
        {
            m_toolTip.Show("Reddit", picReddit);
            Cursor = Cursors.Hand;
        }
        private void picReddit_MouseLeave(object sender, EventArgs e)
        {
            m_toolTip.Hide(picReddit);
            Cursor = Cursors.Arrow;
        }
        #endregion
    }

}