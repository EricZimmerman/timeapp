namespace timeapp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ckGetPublicIp = new System.Windows.Forms.CheckBox();
            this.ckTopMost = new System.Windows.Forms.CheckBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpTime = new System.Windows.Forms.TabPage();
            this.lblError = new System.Windows.Forms.Label();
            this.lblIPAddress6 = new System.Windows.Forms.Label();
            this.lblIPAddress4 = new System.Windows.Forms.Label();
            this.lblUTCTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocalTime = new System.Windows.Forms.Label();
            this.tpStopwatch = new System.Windows.Forms.TabPage();
            this.tpCountdown = new System.Windows.Forms.TabPage();
            this.tcMain.SuspendLayout();
            this.tpTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "TimeApp";
            // 
            // ckGetPublicIp
            // 
            this.ckGetPublicIp.AutoSize = true;
            this.ckGetPublicIp.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckGetPublicIp.Location = new System.Drawing.Point(14, 126);
            this.ckGetPublicIp.Name = "ckGetPublicIp";
            this.ckGetPublicIp.Size = new System.Drawing.Size(104, 17);
            this.ckGetPublicIp.TabIndex = 12;
            this.ckGetPublicIp.Text = "Get public IP";
            this.toolTip1.SetToolTip(this.ckGetPublicIp, "When checked, query public IP address every 5 minutes. To force a refresh, unchec" +
        "k and recheck.");
            this.ckGetPublicIp.UseVisualStyleBackColor = true;
            // 
            // ckTopMost
            // 
            this.ckTopMost.AutoSize = true;
            this.ckTopMost.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckTopMost.Location = new System.Drawing.Point(15, 104);
            this.ckTopMost.Name = "ckTopMost";
            this.ckTopMost.Size = new System.Drawing.Size(110, 17);
            this.ckTopMost.TabIndex = 11;
            this.ckTopMost.Text = "Topmost window";
            this.toolTip1.SetToolTip(this.ckTopMost, "When checked, keep the window on top of other windows");
            this.ckTopMost.UseVisualStyleBackColor = true;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpTime);
            this.tcMain.Controls.Add(this.tpStopwatch);
            this.tcMain.Controls.Add(this.tpCountdown);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1096, 259);
            this.tcMain.TabIndex = 7;
            // 
            // tpTime
            // 
            this.tpTime.Controls.Add(this.lblError);
            this.tpTime.Controls.Add(this.lblIPAddress6);
            this.tpTime.Controls.Add(this.lblIPAddress4);
            this.tpTime.Controls.Add(this.ckGetPublicIp);
            this.tpTime.Controls.Add(this.ckTopMost);
            this.tpTime.Controls.Add(this.lblUTCTime);
            this.tpTime.Controls.Add(this.label3);
            this.tpTime.Controls.Add(this.label2);
            this.tpTime.Controls.Add(this.lblLocalTime);
            this.tpTime.Location = new System.Drawing.Point(4, 22);
            this.tpTime.Name = "tpTime";
            this.tpTime.Padding = new System.Windows.Forms.Padding(3);
            this.tpTime.Size = new System.Drawing.Size(1088, 233);
            this.tpTime.TabIndex = 0;
            this.tpTime.Text = "The time";
            this.tpTime.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(11, 165);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(1069, 54);
            this.lblError.TabIndex = 15;
            // 
            // lblIPAddress6
            // 
            this.lblIPAddress6.AutoSize = true;
            this.lblIPAddress6.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress6.Location = new System.Drawing.Point(199, 133);
            this.lblIPAddress6.Name = "lblIPAddress6";
            this.lblIPAddress6.Size = new System.Drawing.Size(0, 32);
            this.lblIPAddress6.TabIndex = 14;
            // 
            // lblIPAddress4
            // 
            this.lblIPAddress4.AutoSize = true;
            this.lblIPAddress4.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress4.Location = new System.Drawing.Point(199, 101);
            this.lblIPAddress4.Name = "lblIPAddress4";
            this.lblIPAddress4.Size = new System.Drawing.Size(0, 32);
            this.lblIPAddress4.TabIndex = 13;
            // 
            // lblUTCTime
            // 
            this.lblUTCTime.AutoSize = true;
            this.lblUTCTime.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTCTime.Location = new System.Drawing.Point(198, 46);
            this.lblUTCTime.Name = "lblUTCTime";
            this.lblUTCTime.Size = new System.Drawing.Size(619, 43);
            this.lblUTCTime.TabIndex = 10;
            this.lblUTCTime.Text = "11/14/2016 14:20:30.737980 -05";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 43);
            this.label3.TabIndex = 9;
            this.label3.Text = "UTC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 43);
            this.label2.TabIndex = 8;
            this.label2.Text = "Local";
            // 
            // lblLocalTime
            // 
            this.lblLocalTime.AutoSize = true;
            this.lblLocalTime.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalTime.Location = new System.Drawing.Point(198, 3);
            this.lblLocalTime.Name = "lblLocalTime";
            this.lblLocalTime.Size = new System.Drawing.Size(619, 43);
            this.lblLocalTime.TabIndex = 7;
            this.lblLocalTime.Text = "11/14/2016 14:20:30.737980 -05";
            // 
            // tpStopwatch
            // 
            this.tpStopwatch.Location = new System.Drawing.Point(4, 22);
            this.tpStopwatch.Name = "tpStopwatch";
            this.tpStopwatch.Padding = new System.Windows.Forms.Padding(3);
            this.tpStopwatch.Size = new System.Drawing.Size(1213, 439);
            this.tpStopwatch.TabIndex = 1;
            this.tpStopwatch.Text = "The stopwatch";
            this.tpStopwatch.UseVisualStyleBackColor = true;
            // 
            // tpCountdown
            // 
            this.tpCountdown.Location = new System.Drawing.Point(4, 22);
            this.tpCountdown.Name = "tpCountdown";
            this.tpCountdown.Padding = new System.Windows.Forms.Padding(3);
            this.tpCountdown.Size = new System.Drawing.Size(1213, 439);
            this.tpCountdown.TabIndex = 2;
            this.tpCountdown.Text = "The Countdown";
            this.tpCountdown.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 259);
            this.Controls.Add(this.tcMain);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The time, and more!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcMain.ResumeLayout(false);
            this.tpTime.ResumeLayout(false);
            this.tpTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpTime;
        private System.Windows.Forms.TabPage tpStopwatch;
        private System.Windows.Forms.Label lblIPAddress4;
        private System.Windows.Forms.CheckBox ckGetPublicIp;
        private System.Windows.Forms.CheckBox ckTopMost;
        private System.Windows.Forms.Label lblUTCTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLocalTime;
        private System.Windows.Forms.TabPage tpCountdown;
        private System.Windows.Forms.Label lblIPAddress6;
        private System.Windows.Forms.Label lblError;
    }
}

