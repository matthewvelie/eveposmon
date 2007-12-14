namespace EVEPOSMon
{
    partial class StarbaseMonitor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pbStationImage = new System.Windows.Forms.PictureBox();
            this.lblStarbaseName = new System.Windows.Forms.Label();
            this.lblStrontiumBayValue = new System.Windows.Forms.Label();
            this.lblFuelBayValue = new System.Windows.Forms.Label();
            this.lblStrontiumBay = new System.Windows.Forms.Label();
            this.pgStrontiumBay = new System.Windows.Forms.ProgressBar();
            this.pgFuelBay = new System.Windows.Forms.ProgressBar();
            this.lblClaimingSovereignty = new System.Windows.Forms.Label();
            this.lblAllowAllianceMembers = new System.Windows.Forms.Label();
            this.lblAllowCorporationMembers = new System.Windows.Forms.Label();
            this.lblOnCorporationWarValue = new System.Windows.Forms.Label();
            this.lblOnStatusDrop = new System.Windows.Forms.Label();
            this.lblOnStandingDrop = new System.Windows.Forms.Label();
            this.lblOnAggression = new System.Windows.Forms.Label();
            this.dgFuelList = new System.Windows.Forms.DataGridView();
            this.FuelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelRequiredQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOnCorporationWar = new System.Windows.Forms.Label();
            this.lblOnAggressionValue = new System.Windows.Forms.Label();
            this.lblOnStatusDropValue = new System.Windows.Forms.Label();
            this.lblOnStandingDropValue = new System.Windows.Forms.Label();
            this.lblCombatSettings = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFuelBay = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblXmlLastDownloaded = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDataCachedUntil = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLowestFuels = new System.Windows.Forms.Label();
            this.lblLowestFuelTitle1 = new System.Windows.Forms.Label();
            this.lblLowestFuelTime1 = new System.Windows.Forms.Label();
            this.lblLowestFuelTitle2 = new System.Windows.Forms.Label();
            this.lblLowestFuelTime2 = new System.Windows.Forms.Label();
            this.throbber1 = new EVEMon.Throbber();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPosSustainabilityTime = new System.Windows.Forms.Label();
            this.lblPosSustainabilityFuels = new System.Windows.Forms.Label();
            this.lblPosSustainability = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStationImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuelList)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.throbber1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(594, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // pbStationImage
            // 
            this.pbStationImage.Location = new System.Drawing.Point(4, 4);
            this.pbStationImage.Name = "pbStationImage";
            this.pbStationImage.Size = new System.Drawing.Size(154, 155);
            this.pbStationImage.TabIndex = 2;
            this.pbStationImage.TabStop = false;
            // 
            // lblStarbaseName
            // 
            this.lblStarbaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStarbaseName.Location = new System.Drawing.Point(164, 5);
            this.lblStarbaseName.Name = "lblStarbaseName";
            this.lblStarbaseName.Size = new System.Drawing.Size(115, 23);
            this.lblStarbaseName.TabIndex = 3;
            this.lblStarbaseName.Text = "starbase name";
            this.lblStarbaseName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStrontiumBayValue
            // 
            this.lblStrontiumBayValue.AutoSize = true;
            this.lblStrontiumBayValue.Location = new System.Drawing.Point(570, 119);
            this.lblStrontiumBayValue.Name = "lblStrontiumBayValue";
            this.lblStrontiumBayValue.Size = new System.Drawing.Size(35, 13);
            this.lblStrontiumBayValue.TabIndex = 25;
            this.lblStrontiumBayValue.Text = "label1";
            // 
            // lblFuelBayValue
            // 
            this.lblFuelBayValue.AutoSize = true;
            this.lblFuelBayValue.Location = new System.Drawing.Point(569, 67);
            this.lblFuelBayValue.Name = "lblFuelBayValue";
            this.lblFuelBayValue.Size = new System.Drawing.Size(35, 13);
            this.lblFuelBayValue.TabIndex = 26;
            this.lblFuelBayValue.Text = "label1";
            // 
            // lblStrontiumBay
            // 
            this.lblStrontiumBay.AutoSize = true;
            this.lblStrontiumBay.Location = new System.Drawing.Point(424, 103);
            this.lblStrontiumBay.Name = "lblStrontiumBay";
            this.lblStrontiumBay.Size = new System.Drawing.Size(72, 13);
            this.lblStrontiumBay.TabIndex = 24;
            this.lblStrontiumBay.Text = "Strontium Bay";
            // 
            // pgStrontiumBay
            // 
            this.pgStrontiumBay.Location = new System.Drawing.Point(429, 119);
            this.pgStrontiumBay.Name = "pgStrontiumBay";
            this.pgStrontiumBay.Size = new System.Drawing.Size(135, 18);
            this.pgStrontiumBay.TabIndex = 22;
            // 
            // pgFuelBay
            // 
            this.pgFuelBay.Location = new System.Drawing.Point(427, 67);
            this.pgFuelBay.Name = "pgFuelBay";
            this.pgFuelBay.Size = new System.Drawing.Size(135, 18);
            this.pgFuelBay.TabIndex = 23;
            // 
            // lblClaimingSovereignty
            // 
            this.lblClaimingSovereignty.Location = new System.Drawing.Point(6, 212);
            this.lblClaimingSovereignty.Name = "lblClaimingSovereignty";
            this.lblClaimingSovereignty.Size = new System.Drawing.Size(152, 18);
            this.lblClaimingSovereignty.TabIndex = 18;
            this.lblClaimingSovereignty.Text = "On Corporation War";
            // 
            // lblAllowAllianceMembers
            // 
            this.lblAllowAllianceMembers.Location = new System.Drawing.Point(6, 194);
            this.lblAllowAllianceMembers.Name = "lblAllowAllianceMembers";
            this.lblAllowAllianceMembers.Size = new System.Drawing.Size(152, 18);
            this.lblAllowAllianceMembers.TabIndex = 19;
            this.lblAllowAllianceMembers.Text = "On Corporation War";
            // 
            // lblAllowCorporationMembers
            // 
            this.lblAllowCorporationMembers.Location = new System.Drawing.Point(6, 176);
            this.lblAllowCorporationMembers.Name = "lblAllowCorporationMembers";
            this.lblAllowCorporationMembers.Size = new System.Drawing.Size(152, 18);
            this.lblAllowCorporationMembers.TabIndex = 20;
            this.lblAllowCorporationMembers.Text = "On Corporation War";
            // 
            // lblOnCorporationWarValue
            // 
            this.lblOnCorporationWarValue.Location = new System.Drawing.Point(286, 125);
            this.lblOnCorporationWarValue.Name = "lblOnCorporationWarValue";
            this.lblOnCorporationWarValue.Size = new System.Drawing.Size(115, 18);
            this.lblOnCorporationWarValue.TabIndex = 17;
            this.lblOnCorporationWarValue.Text = "Combat Settings";
            // 
            // lblOnStatusDrop
            // 
            this.lblOnStatusDrop.Location = new System.Drawing.Point(167, 89);
            this.lblOnStatusDrop.Name = "lblOnStatusDrop";
            this.lblOnStatusDrop.Size = new System.Drawing.Size(113, 18);
            this.lblOnStatusDrop.TabIndex = 11;
            this.lblOnStatusDrop.Text = "On Status Drop";
            // 
            // lblOnStandingDrop
            // 
            this.lblOnStandingDrop.Location = new System.Drawing.Point(165, 71);
            this.lblOnStandingDrop.Name = "lblOnStandingDrop";
            this.lblOnStandingDrop.Size = new System.Drawing.Size(115, 18);
            this.lblOnStandingDrop.TabIndex = 12;
            this.lblOnStandingDrop.Text = "On Standing Drop";
            // 
            // lblOnAggression
            // 
            this.lblOnAggression.Location = new System.Drawing.Point(165, 107);
            this.lblOnAggression.Name = "lblOnAggression";
            this.lblOnAggression.Size = new System.Drawing.Size(115, 18);
            this.lblOnAggression.TabIndex = 9;
            this.lblOnAggression.Text = "On Aggression";
            // 
            // dgFuelList
            // 
            this.dgFuelList.AllowUserToAddRows = false;
            this.dgFuelList.AllowUserToDeleteRows = false;
            this.dgFuelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFuelList.ColumnHeadersVisible = false;
            this.dgFuelList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FuelName,
            this.Quantity,
            this.FuelRequiredQuantity,
            this.TimeRemaining});
            this.dgFuelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFuelList.Location = new System.Drawing.Point(0, 0);
            this.dgFuelList.Name = "dgFuelList";
            this.dgFuelList.ReadOnly = true;
            this.dgFuelList.RowHeadersVisible = false;
            this.dgFuelList.Size = new System.Drawing.Size(625, 311);
            this.dgFuelList.TabIndex = 21;
            // 
            // FuelName
            // 
            this.FuelName.HeaderText = "Fuel Name";
            this.FuelName.Name = "FuelName";
            this.FuelName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Current Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // FuelRequiredQuantity
            // 
            this.FuelRequiredQuantity.HeaderText = "Required Quantity";
            this.FuelRequiredQuantity.Name = "FuelRequiredQuantity";
            this.FuelRequiredQuantity.ReadOnly = true;
            // 
            // TimeRemaining
            // 
            this.TimeRemaining.HeaderText = "Time Remaining";
            this.TimeRemaining.Name = "TimeRemaining";
            this.TimeRemaining.ReadOnly = true;
            // 
            // lblOnCorporationWar
            // 
            this.lblOnCorporationWar.Location = new System.Drawing.Point(165, 125);
            this.lblOnCorporationWar.Name = "lblOnCorporationWar";
            this.lblOnCorporationWar.Size = new System.Drawing.Size(115, 18);
            this.lblOnCorporationWar.TabIndex = 10;
            this.lblOnCorporationWar.Text = "On Corporation War";
            // 
            // lblOnAggressionValue
            // 
            this.lblOnAggressionValue.Location = new System.Drawing.Point(286, 107);
            this.lblOnAggressionValue.Name = "lblOnAggressionValue";
            this.lblOnAggressionValue.Size = new System.Drawing.Size(115, 18);
            this.lblOnAggressionValue.TabIndex = 15;
            this.lblOnAggressionValue.Text = "Combat Settings";
            // 
            // lblOnStatusDropValue
            // 
            this.lblOnStatusDropValue.Location = new System.Drawing.Point(286, 89);
            this.lblOnStatusDropValue.Name = "lblOnStatusDropValue";
            this.lblOnStatusDropValue.Size = new System.Drawing.Size(115, 18);
            this.lblOnStatusDropValue.TabIndex = 16;
            this.lblOnStatusDropValue.Text = "Combat Settings";
            // 
            // lblOnStandingDropValue
            // 
            this.lblOnStandingDropValue.Location = new System.Drawing.Point(286, 71);
            this.lblOnStandingDropValue.Name = "lblOnStandingDropValue";
            this.lblOnStandingDropValue.Size = new System.Drawing.Size(115, 18);
            this.lblOnStandingDropValue.TabIndex = 13;
            this.lblOnStandingDropValue.Text = "Combat Settings";
            // 
            // lblCombatSettings
            // 
            this.lblCombatSettings.Location = new System.Drawing.Point(165, 53);
            this.lblCombatSettings.Name = "lblCombatSettings";
            this.lblCombatSettings.Size = new System.Drawing.Size(115, 18);
            this.lblCombatSettings.TabIndex = 14;
            this.lblCombatSettings.Text = "Combat Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgFuelList);
            this.panel1.Location = new System.Drawing.Point(4, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 311);
            this.panel1.TabIndex = 27;
            // 
            // lblFuelBay
            // 
            this.lblFuelBay.AutoSize = true;
            this.lblFuelBay.Location = new System.Drawing.Point(426, 51);
            this.lblFuelBay.Name = "lblFuelBay";
            this.lblFuelBay.Size = new System.Drawing.Size(48, 13);
            this.lblFuelBay.TabIndex = 28;
            this.lblFuelBay.Text = "Fuel Bay";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblXmlLastDownloaded,
            this.lblDataCachedUntil});
            this.statusStrip.Location = new System.Drawing.Point(0, 673);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 29;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblXmlLastDownloaded
            // 
            this.lblXmlLastDownloaded.Name = "lblXmlLastDownloaded";
            this.lblXmlLastDownloaded.Size = new System.Drawing.Size(109, 17);
            this.lblXmlLastDownloaded.Text = "toolStripStatusLabel1";
            // 
            // lblDataCachedUntil
            // 
            this.lblDataCachedUntil.Name = "lblDataCachedUntil";
            this.lblDataCachedUntil.Size = new System.Drawing.Size(109, 17);
            this.lblDataCachedUntil.Text = "toolStripStatusLabel2";
            // 
            // lblLowestFuels
            // 
            this.lblLowestFuels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowestFuels.Location = new System.Drawing.Point(6, 601);
            this.lblLowestFuels.Name = "lblLowestFuels";
            this.lblLowestFuels.Size = new System.Drawing.Size(102, 18);
            this.lblLowestFuels.TabIndex = 10;
            this.lblLowestFuels.Text = "Lowest Fuels";
            // 
            // lblLowestFuelTitle1
            // 
            this.lblLowestFuelTitle1.Location = new System.Drawing.Point(114, 603);
            this.lblLowestFuelTitle1.Name = "lblLowestFuelTitle1";
            this.lblLowestFuelTitle1.Size = new System.Drawing.Size(115, 18);
            this.lblLowestFuelTitle1.TabIndex = 10;
            this.lblLowestFuelTitle1.Text = "On Corporation War";
            // 
            // lblLowestFuelTime1
            // 
            this.lblLowestFuelTime1.Location = new System.Drawing.Point(114, 621);
            this.lblLowestFuelTime1.Name = "lblLowestFuelTime1";
            this.lblLowestFuelTime1.Size = new System.Drawing.Size(115, 18);
            this.lblLowestFuelTime1.TabIndex = 10;
            this.lblLowestFuelTime1.Text = "On Corporation War";
            // 
            // lblLowestFuelTitle2
            // 
            this.lblLowestFuelTitle2.Location = new System.Drawing.Point(222, 603);
            this.lblLowestFuelTitle2.Name = "lblLowestFuelTitle2";
            this.lblLowestFuelTitle2.Size = new System.Drawing.Size(115, 18);
            this.lblLowestFuelTitle2.TabIndex = 10;
            this.lblLowestFuelTitle2.Text = "On Corporation War";
            // 
            // lblLowestFuelTime2
            // 
            this.lblLowestFuelTime2.Location = new System.Drawing.Point(222, 621);
            this.lblLowestFuelTime2.Name = "lblLowestFuelTime2";
            this.lblLowestFuelTime2.Size = new System.Drawing.Size(115, 18);
            this.lblLowestFuelTime2.TabIndex = 10;
            this.lblLowestFuelTime2.Text = "On Corporation War";
            // 
            // throbber1
            // 
            this.throbber1.Location = new System.Drawing.Point(605, 5);
            this.throbber1.MaximumSize = new System.Drawing.Size(24, 24);
            this.throbber1.MinimumSize = new System.Drawing.Size(24, 24);
            this.throbber1.Name = "throbber1";
            this.throbber1.Size = new System.Drawing.Size(24, 24);
            this.throbber1.State = EVEMon.Throbber.ThrobberState.Stopped;
            this.throbber1.TabIndex = 0;
            this.throbber1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 601);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lowest Fuels";
            // 
            // lblPosSustainabilityTime
            // 
            this.lblPosSustainabilityTime.Location = new System.Drawing.Point(502, 603);
            this.lblPosSustainabilityTime.Name = "lblPosSustainabilityTime";
            this.lblPosSustainabilityTime.Size = new System.Drawing.Size(115, 18);
            this.lblPosSustainabilityTime.TabIndex = 10;
            this.lblPosSustainabilityTime.Text = "On Corporation War";
            // 
            // lblPosSustainabilityFuels
            // 
            this.lblPosSustainabilityFuels.Location = new System.Drawing.Point(502, 621);
            this.lblPosSustainabilityFuels.Name = "lblPosSustainabilityFuels";
            this.lblPosSustainabilityFuels.Size = new System.Drawing.Size(115, 18);
            this.lblPosSustainabilityFuels.TabIndex = 10;
            this.lblPosSustainabilityFuels.Text = "On Corporation War";
            // 
            // lblPosSustainability
            // 
            this.lblPosSustainability.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosSustainability.Location = new System.Drawing.Point(394, 601);
            this.lblPosSustainability.Name = "lblPosSustainability";
            this.lblPosSustainability.Size = new System.Drawing.Size(102, 18);
            this.lblPosSustainability.TabIndex = 10;
            this.lblPosSustainability.Text = "Lowest Fuels";
            // 
            // StarbaseMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lblFuelBay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStrontiumBayValue);
            this.Controls.Add(this.lblFuelBayValue);
            this.Controls.Add(this.lblStrontiumBay);
            this.Controls.Add(this.pgStrontiumBay);
            this.Controls.Add(this.pgFuelBay);
            this.Controls.Add(this.lblClaimingSovereignty);
            this.Controls.Add(this.lblAllowAllianceMembers);
            this.Controls.Add(this.lblAllowCorporationMembers);
            this.Controls.Add(this.lblOnCorporationWarValue);
            this.Controls.Add(this.lblOnStatusDrop);
            this.Controls.Add(this.lblOnStandingDrop);
            this.Controls.Add(this.lblOnAggression);
            this.Controls.Add(this.lblPosSustainability);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLowestFuels);
            this.Controls.Add(this.lblLowestFuelTime2);
            this.Controls.Add(this.lblPosSustainabilityFuels);
            this.Controls.Add(this.lblLowestFuelTitle2);
            this.Controls.Add(this.lblPosSustainabilityTime);
            this.Controls.Add(this.lblLowestFuelTime1);
            this.Controls.Add(this.lblLowestFuelTitle1);
            this.Controls.Add(this.lblOnCorporationWar);
            this.Controls.Add(this.lblOnAggressionValue);
            this.Controls.Add(this.lblOnStatusDropValue);
            this.Controls.Add(this.lblOnStandingDropValue);
            this.Controls.Add(this.lblCombatSettings);
            this.Controls.Add(this.lblStarbaseName);
            this.Controls.Add(this.pbStationImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.throbber1);
            this.Name = "StarbaseMonitor";
            this.Size = new System.Drawing.Size(632, 695);
            this.Load += new System.EventHandler(this.StarbaseMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbStationImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuelList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.throbber1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EVEMon.Throbber throbber1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbStationImage;
        private System.Windows.Forms.Label lblStarbaseName;
        private System.Windows.Forms.Label lblStrontiumBayValue;
        private System.Windows.Forms.Label lblFuelBayValue;
        private System.Windows.Forms.Label lblStrontiumBay;
        private System.Windows.Forms.ProgressBar pgStrontiumBay;
        private System.Windows.Forms.ProgressBar pgFuelBay;
        private System.Windows.Forms.Label lblClaimingSovereignty;
        private System.Windows.Forms.Label lblAllowAllianceMembers;
        private System.Windows.Forms.Label lblAllowCorporationMembers;
        private System.Windows.Forms.Label lblOnCorporationWarValue;
        private System.Windows.Forms.Label lblOnStatusDrop;
        private System.Windows.Forms.Label lblOnStandingDrop;
        private System.Windows.Forms.Label lblOnAggression;
        private System.Windows.Forms.DataGridView dgFuelList;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelRequiredQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeRemaining;
        private System.Windows.Forms.Label lblOnCorporationWar;
        private System.Windows.Forms.Label lblOnAggressionValue;
        private System.Windows.Forms.Label lblOnStatusDropValue;
        private System.Windows.Forms.Label lblOnStandingDropValue;
        private System.Windows.Forms.Label lblCombatSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFuelBay;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblXmlLastDownloaded;
        private System.Windows.Forms.ToolStripStatusLabel lblDataCachedUntil;
        private System.Windows.Forms.Label lblLowestFuels;
        private System.Windows.Forms.Label lblLowestFuelTitle1;
        private System.Windows.Forms.Label lblLowestFuelTime1;
        private System.Windows.Forms.Label lblLowestFuelTitle2;
        private System.Windows.Forms.Label lblLowestFuelTime2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPosSustainabilityTime;
        private System.Windows.Forms.Label lblPosSustainabilityFuels;
        private System.Windows.Forms.Label lblPosSustainability;
    }
}
