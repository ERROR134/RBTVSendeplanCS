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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            RBTVSendeplanCS.Properties.Settings.Default.UpdateInterval = Convert.ToInt32(cb_UpdateInterval.SelectedItem);

            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            cb_UpdateInterval.SelectedText = RBTVSendeplanCS.Properties.Settings.Default.UpdateInterval.ToString();

            switch(RBTVSendeplanCS.Properties.Settings.Default.NotificationTime)
            {
                case 0:
                    rbtn_notify_never.Checked = true;
                    break;
                case 5:
                    rbtn_notify_5min.Checked = true;
                    break;
                case 10:
                    rbtn_notify_10min.Checked = true;
                    break;
                case 15:
                    rbtn_notify_15min.Checked = true;
                    break;
            }
        }
    }
}
