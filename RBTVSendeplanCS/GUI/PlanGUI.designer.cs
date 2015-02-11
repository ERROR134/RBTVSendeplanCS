namespace RBTVSendeplanCS
{
    partial class PlanGUI
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.scrollBar = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // scrollBar
            // 
            this.scrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrollBar.Location = new System.Drawing.Point(683, 0);
            this.scrollBar.Name = "scrollBar";
            this.scrollBar.Size = new System.Drawing.Size(17, 400);
            this.scrollBar.TabIndex = 0;
            this.scrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollBarScroll);
            // 
            // PlanGUI
            // 
            this.Controls.Add(this.scrollBar);
            this.Name = "PlanGUI";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.ControlLoad);
            this.SizeChanged += new System.EventHandler(this.ControlSizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlPaint);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.mouseWheel);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar scrollBar;
    }
}
