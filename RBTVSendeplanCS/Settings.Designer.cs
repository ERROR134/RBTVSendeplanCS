namespace RBTVSendeplanCS
{
    partial class Settings
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
            this.grp_UpdateInterval = new System.Windows.Forms.GroupBox();
            this.cb_UpdateInterval = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.grp_UpdateInterval.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_UpdateInterval
            // 
            this.grp_UpdateInterval.Controls.Add(this.cb_UpdateInterval);
            this.grp_UpdateInterval.Location = new System.Drawing.Point(12, 29);
            this.grp_UpdateInterval.Name = "grp_UpdateInterval";
            this.grp_UpdateInterval.Size = new System.Drawing.Size(144, 49);
            this.grp_UpdateInterval.TabIndex = 1;
            this.grp_UpdateInterval.TabStop = false;
            this.grp_UpdateInterval.Text = "Update Interval (Minuten)";
            // 
            // cb_UpdateInterval
            // 
            this.cb_UpdateInterval.FormattingEnabled = true;
            this.cb_UpdateInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "20",
            "30",
            "60",
            "120"});
            this.cb_UpdateInterval.Location = new System.Drawing.Point(6, 19);
            this.cb_UpdateInterval.Name = "cb_UpdateInterval";
            this.cb_UpdateInterval.Size = new System.Drawing.Size(107, 21);
            this.cb_UpdateInterval.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(104, 244);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(136, 40);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Änderungen speichern";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 296);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.grp_UpdateInterval);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.grp_UpdateInterval.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_UpdateInterval;
        private System.Windows.Forms.ComboBox cb_UpdateInterval;
        private System.Windows.Forms.Button btn_save;

    }
}