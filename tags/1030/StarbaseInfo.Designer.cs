namespace EVEPOSMon
{
    partial class StarbaseInfo
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblXmlLastDownloaded = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDataCachedUntil = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStarbaseName = new System.Windows.Forms.Label();
            this.lblCombatSettings = new System.Windows.Forms.Label();
            this.lblOnStandingDrop = new System.Windows.Forms.Label();
            this.lblOnStatusDrop = new System.Windows.Forms.Label();
            this.lblOnAggression = new System.Windows.Forms.Label();
            this.lblOnCorporationWar = new System.Windows.Forms.Label();
            this.lblOnStandingDropValue = new System.Windows.Forms.Label();
            this.lblOnStatusDropValue = new System.Windows.Forms.Label();
            this.lblOnAggressionValue = new System.Windows.Forms.Label();
            this.lblOnCorporationWarValue = new System.Windows.Forms.Label();
            this.lblAllowCorporationMembers = new System.Windows.Forms.Label();
            this.lblAllowAllianceMembers = new System.Windows.Forms.Label();
            this.lblClaimingSovereignty = new System.Windows.Forms.Label();
            this.pbStationImage = new System.Windows.Forms.PictureBox();
            this.dgFuelList = new System.Windows.Forms.DataGridView();
            this.FuelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelRequiredQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pgFuelBay = new System.Windows.Forms.ProgressBar();
            this.lblFuelBay = new System.Windows.Forms.Label();
            this.lblStrontiumBay = new System.Windows.Forms.Label();
            this.pgStrontiumBay = new System.Windows.Forms.ProgressBar();
            this.lblFuelBayValue = new System.Windows.Forms.Label();
            this.lblStrontiumBayValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.throbber1 = new EVEMon.Throbber();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStationImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuelList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.throbber1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblXmlLastDownloaded,
            this.lblDataCachedUntil});
            this.statusStrip.Location = new System.Drawing.Point(0, 551);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(670, 22);
            this.statusStrip.TabIndex = 0;
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
            // lblStarbaseName
            // 
            this.lblStarbaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStarbaseName.Location = new System.Drawing.Point(171, 6);
            this.lblStarbaseName.Name = "lblStarbaseName";
            this.lblStarbaseName.Size = new System.Drawing.Size(115, 23);
            this.lblStarbaseName.TabIndex = 1;
            this.lblStarbaseName.Text = "starbase name";
            this.lblStarbaseName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCombatSettings
            // 
            this.lblCombatSettings.Location = new System.Drawing.Point(170, 40);
            this.lblCombatSettings.Name = "lblCombatSettings";
            this.lblCombatSettings.Size = new System.Drawing.Size(115, 18);
            this.lblCombatSettings.TabIndex = 2;
            this.lblCombatSettings.Text = "Combat Settings";
            // 
            // lblOnStandingDrop
            // 
            this.lblOnStandingDrop.Location = new System.Drawing.Point(170, 58);
            this.lblOnStandingDrop.Name = "lblOnStandingDrop";
            this.lblOnStandingDrop.Size = new System.Drawing.Size(115, 18);
            this.lblOnStandingDrop.TabIndex = 2;
            this.lblOnStandingDrop.Text = "On Standing Drop";
            // 
            // lblOnStatusDrop
            // 
            this.lblOnStatusDrop.Location = new System.Drawing.Point(172, 76);
            this.lblOnStatusDrop.Name = "lblOnStatusDrop";
            this.lblOnStatusDrop.Size = new System.Drawing.Size(113, 18);
            this.lblOnStatusDrop.TabIndex = 2;
            this.lblOnStatusDrop.Text = "On Status Drop";
            // 
            // lblOnAggression
            // 
            this.lblOnAggression.Location = new System.Drawing.Point(170, 94);
            this.lblOnAggression.Name = "lblOnAggression";
            this.lblOnAggression.Size = new System.Drawing.Size(115, 18);
            this.lblOnAggression.TabIndex = 2;
            this.lblOnAggression.Text = "On Aggression";
            // 
            // lblOnCorporationWar
            // 
            this.lblOnCorporationWar.Location = new System.Drawing.Point(170, 112);
            this.lblOnCorporationWar.Name = "lblOnCorporationWar";
            this.lblOnCorporationWar.Size = new System.Drawing.Size(115, 18);
            this.lblOnCorporationWar.TabIndex = 2;
            this.lblOnCorporationWar.Text = "On Corporation War";
            // 
            // lblOnStandingDropValue
            // 
            this.lblOnStandingDropValue.Location = new System.Drawing.Point(291, 58);
            this.lblOnStandingDropValue.Name = "lblOnStandingDropValue";
            this.lblOnStandingDropValue.Size = new System.Drawing.Size(115, 18);
            this.lblOnStandingDropValue.TabIndex = 2;
            this.lblOnStandingDropValue.Text = "Combat Settings";
            // 
            // lblOnStatusDropValue
            // 
            this.lblOnStatusDropValue.Location = new System.Drawing.Point(291, 76);
            this.lblOnStatusDropValue.Name = "lblOnStatusDropValue";
            this.lblOnStatusDropValue.Size = new System.Drawing.Size(115, 18);
            this.lblOnStatusDropValue.TabIndex = 2;
            this.lblOnStatusDropValue.Text = "Combat Settings";
            // 
            // lblOnAggressionValue
            // 
            this.lblOnAggressionValue.Location = new System.Drawing.Point(291, 94);
            this.lblOnAggressionValue.Name = "lblOnAggressionValue";
            this.lblOnAggressionValue.Size = new System.Drawing.Size(115, 18);
            this.lblOnAggressionValue.TabIndex = 2;
            this.lblOnAggressionValue.Text = "Combat Settings";
            // 
            // lblOnCorporationWarValue
            // 
            this.lblOnCorporationWarValue.Location = new System.Drawing.Point(291, 112);
            this.lblOnCorporationWarValue.Name = "lblOnCorporationWarValue";
            this.lblOnCorporationWarValue.Size = new System.Drawing.Size(115, 18);
            this.lblOnCorporationWarValue.TabIndex = 2;
            this.lblOnCorporationWarValue.Text = "Combat Settings";
            // 
            // lblAllowCorporationMembers
            // 
            this.lblAllowCorporationMembers.Location = new System.Drawing.Point(12, 140);
            this.lblAllowCorporationMembers.Name = "lblAllowCorporationMembers";
            this.lblAllowCorporationMembers.Size = new System.Drawing.Size(152, 18);
            this.lblAllowCorporationMembers.TabIndex = 2;
            this.lblAllowCorporationMembers.Text = "On Corporation War";
            // 
            // lblAllowAllianceMembers
            // 
            this.lblAllowAllianceMembers.Location = new System.Drawing.Point(12, 158);
            this.lblAllowAllianceMembers.Name = "lblAllowAllianceMembers";
            this.lblAllowAllianceMembers.Size = new System.Drawing.Size(152, 18);
            this.lblAllowAllianceMembers.TabIndex = 2;
            this.lblAllowAllianceMembers.Text = "On Corporation War";
            // 
            // lblClaimingSovereignty
            // 
            this.lblClaimingSovereignty.Location = new System.Drawing.Point(12, 176);
            this.lblClaimingSovereignty.Name = "lblClaimingSovereignty";
            this.lblClaimingSovereignty.Size = new System.Drawing.Size(152, 18);
            this.lblClaimingSovereignty.TabIndex = 2;
            this.lblClaimingSovereignty.Text = "On Corporation War";
            // 
            // pbStationImage
            // 
            this.pbStationImage.Location = new System.Drawing.Point(15, 6);
            this.pbStationImage.Name = "pbStationImage";
            this.pbStationImage.Size = new System.Drawing.Size(149, 124);
            this.pbStationImage.TabIndex = 3;
            this.pbStationImage.TabStop = false;
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
            this.dgFuelList.Size = new System.Drawing.Size(489, 355);
            this.dgFuelList.TabIndex = 4;
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
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgFuelList);
            this.panel1.Location = new System.Drawing.Point(0, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 355);
            this.panel1.TabIndex = 5;
            // 
            // pgFuelBay
            // 
            this.pgFuelBay.Location = new System.Drawing.Point(413, 58);
            this.pgFuelBay.Name = "pgFuelBay";
            this.pgFuelBay.Size = new System.Drawing.Size(135, 18);
            this.pgFuelBay.TabIndex = 6;
            // 
            // lblFuelBay
            // 
            this.lblFuelBay.AutoSize = true;
            this.lblFuelBay.Location = new System.Drawing.Point(410, 40);
            this.lblFuelBay.Name = "lblFuelBay";
            this.lblFuelBay.Size = new System.Drawing.Size(48, 13);
            this.lblFuelBay.TabIndex = 7;
            this.lblFuelBay.Text = "Fuel Bay";
            // 
            // lblStrontiumBay
            // 
            this.lblStrontiumBay.AutoSize = true;
            this.lblStrontiumBay.Location = new System.Drawing.Point(412, 94);
            this.lblStrontiumBay.Name = "lblStrontiumBay";
            this.lblStrontiumBay.Size = new System.Drawing.Size(72, 13);
            this.lblStrontiumBay.TabIndex = 7;
            this.lblStrontiumBay.Text = "Strontium Bay";
            // 
            // pgStrontiumBay
            // 
            this.pgStrontiumBay.Location = new System.Drawing.Point(415, 110);
            this.pgStrontiumBay.Name = "pgStrontiumBay";
            this.pgStrontiumBay.Size = new System.Drawing.Size(135, 18);
            this.pgStrontiumBay.TabIndex = 6;
            // 
            // lblFuelBayValue
            // 
            this.lblFuelBayValue.AutoSize = true;
            this.lblFuelBayValue.Location = new System.Drawing.Point(555, 58);
            this.lblFuelBayValue.Name = "lblFuelBayValue";
            this.lblFuelBayValue.Size = new System.Drawing.Size(35, 13);
            this.lblFuelBayValue.TabIndex = 8;
            this.lblFuelBayValue.Text = "label1";
            // 
            // lblStrontiumBayValue
            // 
            this.lblStrontiumBayValue.AutoSize = true;
            this.lblStrontiumBayValue.Location = new System.Drawing.Point(556, 110);
            this.lblStrontiumBayValue.Name = "lblStrontiumBayValue";
            this.lblStrontiumBayValue.Size = new System.Drawing.Size(35, 13);
            this.lblStrontiumBayValue.TabIndex = 8;
            this.lblStrontiumBayValue.Text = "label1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(596, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "00:00:00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // throbber1
            // 
            this.throbber1.Location = new System.Drawing.Point(614, 12);
            this.throbber1.MaximumSize = new System.Drawing.Size(24, 24);
            this.throbber1.MinimumSize = new System.Drawing.Size(24, 24);
            this.throbber1.Name = "throbber1";
            this.throbber1.Size = new System.Drawing.Size(24, 24);
            this.throbber1.State = EVEMon.Throbber.ThrobberState.Stopped;
            this.throbber1.TabIndex = 9;
            this.throbber1.TabStop = false;
            // 
            // StarbaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 573);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.throbber1);
            this.Controls.Add(this.lblStrontiumBayValue);
            this.Controls.Add(this.lblFuelBayValue);
            this.Controls.Add(this.lblStrontiumBay);
            this.Controls.Add(this.lblFuelBay);
            this.Controls.Add(this.pgStrontiumBay);
            this.Controls.Add(this.pgFuelBay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbStationImage);
            this.Controls.Add(this.lblClaimingSovereignty);
            this.Controls.Add(this.lblAllowAllianceMembers);
            this.Controls.Add(this.lblAllowCorporationMembers);
            this.Controls.Add(this.lblOnCorporationWar);
            this.Controls.Add(this.lblOnAggression);
            this.Controls.Add(this.lblOnStatusDrop);
            this.Controls.Add(this.lblOnStandingDrop);
            this.Controls.Add(this.lblOnCorporationWarValue);
            this.Controls.Add(this.lblOnAggressionValue);
            this.Controls.Add(this.lblOnStatusDropValue);
            this.Controls.Add(this.lblOnStandingDropValue);
            this.Controls.Add(this.lblCombatSettings);
            this.Controls.Add(this.lblStarbaseName);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.Name = "StarbaseInfo";
            this.Text = "StationInfo";
            this.Load += new System.EventHandler(this.StarbaseInfo_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStationImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuelList)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.throbber1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label lblStarbaseName;
        private System.Windows.Forms.Label lblCombatSettings;
        private System.Windows.Forms.Label lblOnStandingDrop;
        private System.Windows.Forms.Label lblOnStatusDrop;
        private System.Windows.Forms.Label lblOnAggression;
        private System.Windows.Forms.Label lblOnCorporationWar;
        private System.Windows.Forms.Label lblOnStandingDropValue;
        private System.Windows.Forms.Label lblOnStatusDropValue;
        private System.Windows.Forms.Label lblOnAggressionValue;
        private System.Windows.Forms.Label lblOnCorporationWarValue;
        private System.Windows.Forms.Label lblAllowCorporationMembers;
        private System.Windows.Forms.Label lblAllowAllianceMembers;
        private System.Windows.Forms.Label lblClaimingSovereignty;
        private System.Windows.Forms.PictureBox pbStationImage;
        private System.Windows.Forms.DataGridView dgFuelList;
        private System.Windows.Forms.ToolStripStatusLabel lblXmlLastDownloaded;
        private System.Windows.Forms.ToolStripStatusLabel lblDataCachedUntil;
        private System.Windows.Forms.ImageList imageList1;

        private System.Windows.Forms.DataGridViewTextBoxColumn FuelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelRequiredQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeRemaining;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pgFuelBay;
        private System.Windows.Forms.Label lblFuelBay;
        private System.Windows.Forms.Label lblStrontiumBay;
        private System.Windows.Forms.ProgressBar pgStrontiumBay;
        private System.Windows.Forms.Label lblFuelBayValue;
        private System.Windows.Forms.Label lblStrontiumBayValue;
        private EVEMon.Throbber throbber1;
        private System.Windows.Forms.Label label1;

    }
}