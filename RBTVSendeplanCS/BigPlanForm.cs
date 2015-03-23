using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace RBTVSendeplanCS
{
    public partial class BigPlanForm : PlanForm
    {
        #region moving
        //variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        //const
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //function
        private void BigPlanForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private PlanGUI gui;
        private MainForm mainForm;
        private List<RbtvEvent> events;

        public BigPlanForm(MainForm m)
        {
            mainForm = m;
            InitializeComponent();
        }

        private void BigPlanForm_Load(object sender, EventArgs e)
        {
            this.Controls.Add(mainForm.GetMenuStrip());
            gui = new PlanGUI();
            gui.MouseDown += new MouseEventHandler(BigPlanForm_MouseDown);
            this.Controls.Add(gui);
            this.Size = gui.Size;
            List<RbtvEvent> events = mainForm.Events;
            gui.updateEvents(mainForm.Events);
        }

        public override void RbtvEventsLoaded(List<RbtvEvent> e)
        {
            events = e;
            gui.updateEvents(events);
            gui.updateControl();
        }
    }
}
