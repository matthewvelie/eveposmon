namespace eveposmon
{
    partial class SelectStarbases
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
            this.btnSelectStarbases = new System.Windows.Forms.Button();
            this.dgStations = new System.Windows.Forms.DataGridView();
            this.dgvMonitor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvMapRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMapConstellation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStarbaseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStarbaseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAPIAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgStations)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectStarbases
            // 
            this.btnSelectStarbases.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelectStarbases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectStarbases.Location = new System.Drawing.Point(13, 298);
            this.btnSelectStarbases.Name = "btnSelectStarbases";
            this.btnSelectStarbases.Size = new System.Drawing.Size(111, 23);
            this.btnSelectStarbases.TabIndex = 2;
            this.btnSelectStarbases.Text = "Select Starbases";
            this.btnSelectStarbases.UseVisualStyleBackColor = true;
            // 
            // dgStations
            // 
            this.dgStations.AllowUserToAddRows = false;
            this.dgStations.AllowUserToDeleteRows = false;
            this.dgStations.AllowUserToOrderColumns = true;
            this.dgStations.AllowUserToResizeColumns = false;
            this.dgStations.AllowUserToResizeRows = false;
            this.dgStations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMonitor,
            this.dgvMapRegion,
            this.dgvMapConstellation,
            this.dgvMoon,
            this.dgvStarbaseStatus,
            this.dgvStarbaseType,
            this.dgvAPIAccount});
            this.dgStations.Location = new System.Drawing.Point(7, 12);
            this.dgStations.MultiSelect = false;
            this.dgStations.Name = "dgStations";
            this.dgStations.RowHeadersVisible = false;
            this.dgStations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStations.Size = new System.Drawing.Size(654, 275);
            this.dgStations.TabIndex = 3;
            // 
            // dgvMonitor
            // 
            this.dgvMonitor.FalseValue = "false";
            this.dgvMonitor.HeaderText = "Monitor";
            this.dgvMonitor.Name = "dgvMonitor";
            this.dgvMonitor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonitor.TrueValue = "true";
            this.dgvMonitor.Width = 50;
            // 
            // dgvMapRegion
            // 
            this.dgvMapRegion.HeaderText = "Region";
            this.dgvMapRegion.Name = "dgvMapRegion";
            this.dgvMapRegion.ReadOnly = true;
            // 
            // dgvMapConstellation
            // 
            this.dgvMapConstellation.HeaderText = "Constellation";
            this.dgvMapConstellation.Name = "dgvMapConstellation";
            this.dgvMapConstellation.ReadOnly = true;
            // 
            // dgvMoon
            // 
            this.dgvMoon.HeaderText = "Moon";
            this.dgvMoon.Name = "dgvMoon";
            // 
            // dgvStarbaseStatus
            // 
            this.dgvStarbaseStatus.HeaderText = "Status";
            this.dgvStarbaseStatus.Name = "dgvStarbaseStatus";
            // 
            // dgvStarbaseType
            // 
            this.dgvStarbaseType.HeaderText = "Starbase Type";
            this.dgvStarbaseType.Name = "dgvStarbaseType";
            // 
            // dgvAPIAccount
            // 
            this.dgvAPIAccount.HeaderText = "Account";
            this.dgvAPIAccount.Name = "dgvAPIAccount";
            // 
            // SelectStarbases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 332);
            this.Controls.Add(this.dgStations);
            this.Controls.Add(this.btnSelectStarbases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectStarbases";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EVEPOSMon Station Selection";
            ((System.ComponentModel.ISupportInitialize)(this.dgStations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectStarbases;
        private System.Windows.Forms.DataGridView dgStations;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMapRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMapConstellation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMoon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStarbaseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStarbaseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAPIAccount;
    }
}

