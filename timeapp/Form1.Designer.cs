﻿namespace timeapp
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
            this.ckTopMost = new System.Windows.Forms.CheckBox();
            this.ckGetPublicIp = new System.Windows.Forms.CheckBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpTime = new System.Windows.Forms.TabPage();
            this.lblUTCTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocalTime = new System.Windows.Forms.Label();
            this.tpStopwatch = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.btnResetSw = new System.Windows.Forms.Button();
            this.btnStopSw = new System.Windows.Forms.Button();
            this.btnStartSw = new System.Windows.Forms.Button();
            this.tpCountdown = new System.Windows.Forms.TabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numSecs = new System.Windows.Forms.NumericUpDown();
            this.numMins = new System.Windows.Forms.NumericUpDown();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.btnResetCd = new System.Windows.Forms.Button();
            this.btnStopCd = new System.Windows.Forms.Button();
            this.btnStartCd = new System.Windows.Forms.Button();
            this.tpIpAddresses = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblIPAddress6 = new System.Windows.Forms.Label();
            this.lblIPAddress4 = new System.Windows.Forms.Label();
            this.tpOptions = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.timerSw = new System.Windows.Forms.Timer(this.components);
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.tcMain.SuspendLayout();
            this.tpTime.SuspendLayout();
            this.tpStopwatch.SuspendLayout();
            this.tpCountdown.SuspendLayout();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSecs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            this.tpIpAddresses.SuspendLayout();
            this.tpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "TimeApp";
            // 
            // ckTopMost
            // 
            this.ckTopMost.AutoSize = true;
            this.ckTopMost.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckTopMost.Location = new System.Drawing.Point(8, 3);
            this.ckTopMost.Name = "ckTopMost";
            this.ckTopMost.Size = new System.Drawing.Size(142, 21);
            this.ckTopMost.TabIndex = 12;
            this.ckTopMost.Text = "Topmost window";
            this.toolTip1.SetToolTip(this.ckTopMost, "When checked, keep the window on top of other windows");
            this.ckTopMost.UseVisualStyleBackColor = true;
            // 
            // ckGetPublicIp
            // 
            this.ckGetPublicIp.AutoSize = true;
            this.ckGetPublicIp.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckGetPublicIp.Location = new System.Drawing.Point(12, 86);
            this.ckGetPublicIp.Name = "ckGetPublicIp";
            this.ckGetPublicIp.Size = new System.Drawing.Size(142, 21);
            this.ckGetPublicIp.TabIndex = 25;
            this.ckGetPublicIp.Text = "Get public IPs";
            this.toolTip1.SetToolTip(this.ckGetPublicIp, "When checked, query public IP addresses every 5 minutes. To force a refresh, unch" +
        "eck and recheck.");
            this.ckGetPublicIp.UseVisualStyleBackColor = true;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpTime);
            this.tcMain.Controls.Add(this.tpStopwatch);
            this.tcMain.Controls.Add(this.tpCountdown);
            this.tcMain.Controls.Add(this.tpIpAddresses);
            this.tcMain.Controls.Add(this.tpOptions);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.HotTrack = true;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(824, 137);
            this.tcMain.TabIndex = 7;
            // 
            // tpTime
            // 
            this.tpTime.Controls.Add(this.lblUTCTime);
            this.tpTime.Controls.Add(this.label3);
            this.tpTime.Controls.Add(this.label2);
            this.tpTime.Controls.Add(this.lblLocalTime);
            this.tpTime.Location = new System.Drawing.Point(4, 26);
            this.tpTime.Name = "tpTime";
            this.tpTime.Padding = new System.Windows.Forms.Padding(3);
            this.tpTime.Size = new System.Drawing.Size(816, 107);
            this.tpTime.TabIndex = 0;
            this.tpTime.Text = "The time";
            this.tpTime.UseVisualStyleBackColor = true;
            // 
            // lblUTCTime
            // 
            this.lblUTCTime.AutoSize = true;
            this.lblUTCTime.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTCTime.Location = new System.Drawing.Point(131, 46);
            this.lblUTCTime.Name = "lblUTCTime";
            this.lblUTCTime.Size = new System.Drawing.Size(804, 55);
            this.lblUTCTime.TabIndex = 10;
            this.lblUTCTime.Text = "11/14/2016 14:20:30.737980 -05";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 55);
            this.label3.TabIndex = 9;
            this.label3.Text = "UTC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 55);
            this.label2.TabIndex = 8;
            this.label2.Text = "Local";
            // 
            // lblLocalTime
            // 
            this.lblLocalTime.AutoSize = true;
            this.lblLocalTime.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalTime.Location = new System.Drawing.Point(131, 3);
            this.lblLocalTime.Name = "lblLocalTime";
            this.lblLocalTime.Size = new System.Drawing.Size(804, 55);
            this.lblLocalTime.TabIndex = 7;
            this.lblLocalTime.Text = "11/14/2016 14:20:30.737980 -05";
            // 
            // tpStopwatch
            // 
            this.tpStopwatch.Controls.Add(this.label1);
            this.tpStopwatch.Controls.Add(this.lblElapsed);
            this.tpStopwatch.Controls.Add(this.btnResetSw);
            this.tpStopwatch.Controls.Add(this.btnStopSw);
            this.tpStopwatch.Controls.Add(this.btnStartSw);
            this.tpStopwatch.Location = new System.Drawing.Point(4, 26);
            this.tpStopwatch.Name = "tpStopwatch";
            this.tpStopwatch.Padding = new System.Windows.Forms.Padding(3);
            this.tpStopwatch.Size = new System.Drawing.Size(756, 107);
            this.tpStopwatch.TabIndex = 1;
            this.tpStopwatch.Text = "The stopwatch";
            this.tpStopwatch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Format is \'Days.Hours:Minutes:Seconds.Tenths\'";
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Font = new System.Drawing.Font("Consolas", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsed.Location = new System.Drawing.Point(8, 3);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(62, 69);
            this.lblElapsed.TabIndex = 8;
            this.lblElapsed.Text = "0";
            // 
            // btnResetSw
            // 
            this.btnResetSw.Location = new System.Drawing.Point(165, 82);
            this.btnResetSw.Name = "btnResetSw";
            this.btnResetSw.Size = new System.Drawing.Size(75, 23);
            this.btnResetSw.TabIndex = 3;
            this.btnResetSw.Text = "Reset";
            this.btnResetSw.UseVisualStyleBackColor = true;
            // 
            // btnStopSw
            // 
            this.btnStopSw.Enabled = false;
            this.btnStopSw.Location = new System.Drawing.Point(84, 82);
            this.btnStopSw.Name = "btnStopSw";
            this.btnStopSw.Size = new System.Drawing.Size(75, 23);
            this.btnStopSw.TabIndex = 2;
            this.btnStopSw.Text = "Stop";
            this.btnStopSw.UseVisualStyleBackColor = true;
            // 
            // btnStartSw
            // 
            this.btnStartSw.Location = new System.Drawing.Point(3, 82);
            this.btnStartSw.Name = "btnStartSw";
            this.btnStartSw.Size = new System.Drawing.Size(75, 23);
            this.btnStartSw.TabIndex = 1;
            this.btnStartSw.Text = "Start";
            this.btnStartSw.UseVisualStyleBackColor = true;
            // 
            // tpCountdown
            // 
            this.tpCountdown.Controls.Add(this.panelSettings);
            this.tpCountdown.Controls.Add(this.lblCountdown);
            this.tpCountdown.Controls.Add(this.btnResetCd);
            this.tpCountdown.Controls.Add(this.btnStopCd);
            this.tpCountdown.Controls.Add(this.btnStartCd);
            this.tpCountdown.Location = new System.Drawing.Point(4, 26);
            this.tpCountdown.Name = "tpCountdown";
            this.tpCountdown.Padding = new System.Windows.Forms.Padding(3);
            this.tpCountdown.Size = new System.Drawing.Size(756, 107);
            this.tpCountdown.TabIndex = 2;
            this.tpCountdown.Text = "The countdown";
            this.tpCountdown.UseVisualStyleBackColor = true;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.label7);
            this.panelSettings.Controls.Add(this.label6);
            this.panelSettings.Controls.Add(this.label5);
            this.panelSettings.Controls.Add(this.numSecs);
            this.panelSettings.Controls.Add(this.numMins);
            this.panelSettings.Controls.Add(this.numHours);
            this.panelSettings.Controls.Add(this.numDays);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Location = new System.Drawing.Point(370, 48);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(376, 63);
            this.panelSettings.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(285, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 25;
            this.label7.Text = "Seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(192, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 23);
            this.label6.TabIndex = 24;
            this.label6.Text = "Minutes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hours";
            // 
            // numSecs
            // 
            this.numSecs.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSecs.Location = new System.Drawing.Point(282, 32);
            this.numSecs.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSecs.Name = "numSecs";
            this.numSecs.Size = new System.Drawing.Size(84, 31);
            this.numSecs.TabIndex = 21;
            // 
            // numMins
            // 
            this.numMins.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMins.Location = new System.Drawing.Point(192, 32);
            this.numMins.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMins.Name = "numMins";
            this.numMins.Size = new System.Drawing.Size(84, 31);
            this.numMins.TabIndex = 20;
            // 
            // numHours
            // 
            this.numHours.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHours.Location = new System.Drawing.Point(102, 32);
            this.numHours.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(84, 31);
            this.numHours.TabIndex = 19;
            // 
            // numDays
            // 
            this.numDays.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDays.Location = new System.Drawing.Point(12, 32);
            this.numDays.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(84, 31);
            this.numDays.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Days";
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Font = new System.Drawing.Font("Consolas", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(8, 3);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(62, 69);
            this.lblCountdown.TabIndex = 9;
            this.lblCountdown.Text = "0";
            // 
            // btnResetCd
            // 
            this.btnResetCd.Location = new System.Drawing.Point(165, 82);
            this.btnResetCd.Name = "btnResetCd";
            this.btnResetCd.Size = new System.Drawing.Size(75, 23);
            this.btnResetCd.TabIndex = 6;
            this.btnResetCd.Text = "Reset";
            this.btnResetCd.UseVisualStyleBackColor = true;
            // 
            // btnStopCd
            // 
            this.btnStopCd.Enabled = false;
            this.btnStopCd.Location = new System.Drawing.Point(84, 82);
            this.btnStopCd.Name = "btnStopCd";
            this.btnStopCd.Size = new System.Drawing.Size(75, 23);
            this.btnStopCd.TabIndex = 5;
            this.btnStopCd.Text = "Stop";
            this.btnStopCd.UseVisualStyleBackColor = true;
            // 
            // btnStartCd
            // 
            this.btnStartCd.Location = new System.Drawing.Point(3, 82);
            this.btnStartCd.Name = "btnStartCd";
            this.btnStartCd.Size = new System.Drawing.Size(75, 23);
            this.btnStartCd.TabIndex = 4;
            this.btnStartCd.Text = "Start";
            this.btnStartCd.UseVisualStyleBackColor = true;
            // 
            // tpIpAddresses
            // 
            this.tpIpAddresses.Controls.Add(this.lblStatus);
            this.tpIpAddresses.Controls.Add(this.lblIPAddress6);
            this.tpIpAddresses.Controls.Add(this.lblIPAddress4);
            this.tpIpAddresses.Controls.Add(this.ckGetPublicIp);
            this.tpIpAddresses.Location = new System.Drawing.Point(4, 26);
            this.tpIpAddresses.Name = "tpIpAddresses";
            this.tpIpAddresses.Padding = new System.Windows.Forms.Padding(3);
            this.tpIpAddresses.Size = new System.Drawing.Size(756, 107);
            this.tpIpAddresses.TabIndex = 4;
            this.tpIpAddresses.Text = "IP addresses";
            this.tpIpAddresses.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 98);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 28;
            // 
            // lblIPAddress6
            // 
            this.lblIPAddress6.AutoSize = true;
            this.lblIPAddress6.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress6.Location = new System.Drawing.Point(297, 3);
            this.lblIPAddress6.Name = "lblIPAddress6";
            this.lblIPAddress6.Size = new System.Drawing.Size(59, 32);
            this.lblIPAddress6.TabIndex = 27;
            this.lblIPAddress6.Text = "aaa";
            // 
            // lblIPAddress4
            // 
            this.lblIPAddress4.AutoSize = true;
            this.lblIPAddress4.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress4.Location = new System.Drawing.Point(8, 3);
            this.lblIPAddress4.Name = "lblIPAddress4";
            this.lblIPAddress4.Size = new System.Drawing.Size(59, 32);
            this.lblIPAddress4.TabIndex = 26;
            this.lblIPAddress4.Text = "aaa";
            // 
            // tpOptions
            // 
            this.tpOptions.Controls.Add(this.label9);
            this.tpOptions.Controls.Add(this.ckTopMost);
            this.tpOptions.Location = new System.Drawing.Point(4, 26);
            this.tpOptions.Name = "tpOptions";
            this.tpOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tpOptions.Size = new System.Drawing.Size(756, 107);
            this.tpOptions.TabIndex = 3;
            this.tpOptions.Text = "Options";
            this.tpOptions.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(328, 34);
            this.label9.TabIndex = 14;
            this.label9.Text = "Written by Eric Zimmerman\r\nhttps://github.com/EricZimmerman/timeapp";
            // 
            // timerCountdown
            // 
            this.timerCountdown.Interval = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 137);
            this.Controls.Add(this.tcMain);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(780, 176);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The time, and more!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcMain.ResumeLayout(false);
            this.tpTime.ResumeLayout(false);
            this.tpTime.PerformLayout();
            this.tpStopwatch.ResumeLayout(false);
            this.tpStopwatch.PerformLayout();
            this.tpCountdown.ResumeLayout(false);
            this.tpCountdown.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSecs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            this.tpIpAddresses.ResumeLayout(false);
            this.tpIpAddresses.PerformLayout();
            this.tpOptions.ResumeLayout(false);
            this.tpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpTime;
        private System.Windows.Forms.TabPage tpStopwatch;
        private System.Windows.Forms.Label lblUTCTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLocalTime;
        private System.Windows.Forms.TabPage tpCountdown;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Button btnResetSw;
        private System.Windows.Forms.Button btnStopSw;
        private System.Windows.Forms.Button btnStartSw;
        private System.Windows.Forms.Button btnResetCd;
        private System.Windows.Forms.Button btnStopCd;
        private System.Windows.Forms.Button btnStartCd;
        private System.Windows.Forms.Timer timerSw;
        private System.Windows.Forms.TabPage tpOptions;
        private System.Windows.Forms.CheckBox ckTopMost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numSecs;
        private System.Windows.Forms.NumericUpDown numMins;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tpIpAddresses;
        private System.Windows.Forms.Label lblIPAddress6;
        private System.Windows.Forms.Label lblIPAddress4;
        private System.Windows.Forms.CheckBox ckGetPublicIp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label9;
    }
}

