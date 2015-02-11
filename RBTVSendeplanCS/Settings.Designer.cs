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
            this.grp_notifyTime = new System.Windows.Forms.GroupBox();
            this.rbtn_notify_5min = new System.Windows.Forms.RadioButton();
            this.rbtn_notify_15min = new System.Windows.Forms.RadioButton();
            this.rbtn_notify_10min = new System.Windows.Forms.RadioButton();
            this.rbtn_notify_never = new System.Windows.Forms.RadioButton();
            this.grp_UpdateInterval.SuspendLayout();
            this.grp_notifyTime.SuspendLayout();
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
            this.cb_UpdateInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // grp_notifyTime
            // 
            this.grp_notifyTime.Controls.Add(this.rbtn_notify_never);
            this.grp_notifyTime.Controls.Add(this.rbtn_notify_10min);
            this.grp_notifyTime.Controls.Add(this.rbtn_notify_15min);
            this.grp_notifyTime.Controls.Add(this.rbtn_notify_5min);
            this.grp_notifyTime.Location = new System.Drawing.Point(162, 28);
            this.grp_notifyTime.Name = "grp_notifyTime";
            this.grp_notifyTime.Size = new System.Drawing.Size(188, 112);
            this.grp_notifyTime.TabIndex = 3;
            this.grp_notifyTime.TabStop = false;
            this.grp_notifyTime.Text = "Erinnerung (vor jeder Sendung)";
            // 
            // rbtn_notify_5min
            // 
            this.rbtn_notify_5min.AutoSize = true;
            this.rbtn_notify_5min.Location = new System.Drawing.Point(6, 19);
            this.rbtn_notify_5min.Name = "rbtn_notify_5min";
            this.rbtn_notify_5min.Size = new System.Drawing.Size(72, 17);
            this.rbtn_notify_5min.TabIndex = 0;
            this.rbtn_notify_5min.TabStop = true;
            this.rbtn_notify_5min.Text = "5 Minuten";
            this.rbtn_notify_5min.UseVisualStyleBackColor = true;
            // 
            // rbtn_notify_15min
            // 
            this.rbtn_notify_15min.AutoSize = true;
            this.rbtn_notify_15min.Location = new System.Drawing.Point(6, 65);
            this.rbtn_notify_15min.Name = "rbtn_notify_15min";
            this.rbtn_notify_15min.Size = new System.Drawing.Size(78, 17);
            this.rbtn_notify_15min.TabIndex = 1;
            this.rbtn_notify_15min.TabStop = true;
            this.rbtn_notify_15min.Text = "15 Minuten";
            this.rbtn_notify_15min.UseVisualStyleBackColor = true;
            // 
            // rbtn_notify_10min
            // 
            this.rbtn_notify_10min.AutoSize = true;
            this.rbtn_notify_10min.Location = new System.Drawing.Point(6, 42);
            this.rbtn_notify_10min.Name = "rbtn_notify_10min";
            this.rbtn_notify_10min.Size = new System.Drawing.Size(78, 17);
            this.rbtn_notify_10min.TabIndex = 2;
            this.rbtn_notify_10min.TabStop = true;
            this.rbtn_notify_10min.Text = "10 Minuten";
            this.rbtn_notify_10min.UseVisualStyleBackColor = true;
            // 
            // rbtn_notify_never
            // 
            this.rbtn_notify_never.AutoSize = true;
            this.rbtn_notify_never.Location = new System.Drawing.Point(6, 88);
            this.rbtn_notify_never.Name = "rbtn_notify_never";
            this.rbtn_notify_never.Size = new System.Drawing.Size(171, 17);
            this.rbtn_notify_never.TabIndex = 3;
            this.rbtn_notify_never.TabStop = true;
            this.rbtn_notify_never.Text = "keine automatische Erinnerung";
            this.rbtn_notify_never.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 296);
            this.Controls.Add(this.grp_notifyTime);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.grp_UpdateInterval);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.grp_UpdateInterval.ResumeLayout(false);
            this.grp_notifyTime.ResumeLayout(false);
            this.grp_notifyTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_UpdateInterval;
        private System.Windows.Forms.ComboBox cb_UpdateInterval;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.GroupBox grp_notifyTime;
        private System.Windows.Forms.RadioButton rbtn_notify_never;
        private System.Windows.Forms.RadioButton rbtn_notify_10min;
        private System.Windows.Forms.RadioButton rbtn_notify_15min;
        private System.Windows.Forms.RadioButton rbtn_notify_5min;

    }
}