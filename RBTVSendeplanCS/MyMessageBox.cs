using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;


namespace RBTVSendeplanCS
{
    class MyMessageBox : Form
    {
        private static Form frm;
        private static TextBox txt;
        private static string link;

        public static DialogResult ShowDialog(string caption, string text, string hyperlink)
        {
            //Init Label
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Location = new Point(88, 8);
            lbl.Size = new Size(400, 88);

            //Init linklabel
            LinkLabel btn1 = new LinkLabel();
            btn1.Text = "DOWNLOAD";
            btn1.Size = new Size(72, 23);
            btn1.Location = new Point(416, 96);
            btn1.Click += new EventHandler(btn1_Click);

            //
            Button btnOk = new Button();
            btnOk.Text = "&Ok";
            btnOk.Size = new Size(72, 23);
            btnOk.Location = new Point(224, 130);
            btnOk.Anchor = AnchorStyles.Bottom;
            btnOk.Click += new EventHandler(btnOk_Click);
            btnOk.DialogResult = DialogResult.OK;

            //Init Form
            frm = new Form();
            frm.Size = new Size(510, 195);
            frm.Text = caption;
            frm.ShowInTaskbar = false;
            frm.ControlBox = false;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.Controls.Add(lbl);
            frm.Controls.Add(btn1);
            frm.Controls.Add(btnOk);
            frm.AcceptButton = btnOk;

            link = hyperlink;
            return frm.ShowDialog();
        }

        private static void btn1_Click(Object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(link);
        }

        private static void btnOk_Click(Object sender, EventArgs e)
        {
            frm.Close();
        }

    }
}
