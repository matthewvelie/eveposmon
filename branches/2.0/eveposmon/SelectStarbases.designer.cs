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
            this.btnLoadStations = new System.Windows.Forms.Button();
            this.btnSelectStarbases = new System.Windows.Forms.Button();
            this.dgStations = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCachedUntil = new System.Windows.Forms.ToolStripStatusLabel();
            this.Monitor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MapRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MapConstellation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StarbaseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StarbaseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StarbaseOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgStations)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadStations
            // 
            this.btnLoadStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadStations.Location = new System.Drawing.Point(12, 12);
            this.btnLoadStations.Name = "btnLoadStations";
            this.btnLoadStations.Size = new System.Drawing.Size(135, 22);
            this.btnLoadStations.TabIndex = 1;
            this.btnLoadStations.Text = "Refresh Station List";
            this.btnLoadStations.UseVisualStyleBackColor = true;
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
            this.Monitor,
            this.MapRegion,
            this.MapConstellation,
            this.Moon,
            this.StarbaseStatus,
            this.StarbaseType,
            this.StarbaseOwner});
            this.dgStations.Location = new System.Drawing.Point(7, 40);
            this.dgStations.MultiSelect = false;
            this.dgStations.Name = "dgStations";
            this.dgStations.RowHeadersVisible = false;
            this.dgStations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStations.Size = new System.Drawing.Size(654, 249);
            this.dgStations.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.tsslCachedUntil});
            this.statusStrip1.Location = new System.Drawing.Point(0, 336);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(673, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel3.Text = "Next Update:";
            // 
            // tsslCachedUntil
            // 
            this.tsslCachedUntil.Name = "tsslCachedUntil";
            this.tsslCachedUntil.Size = new System.Drawing.Size(71, 17);
            this.tsslCachedUntil.Text = "CacheTillTime";
            // 
            // Monitor
            // 
            this.Monitor.FalseValue = "false";
            this.Monitor.HeaderText = "Monitor";
            this.Monitor.Name = "Monitor";
            this.Monitor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Monitor.TrueValue = "true";
            this.Monitor.Width = 50;
            // 
            // MapRegion
            // 
            this.MapRegion.HeaderText = "Region";
            this.MapRegion.Name = "MapRegion";
            this.MapRegion.ReadOnly = true;
            // 
            // MapConstellation
            // 
            this.MapConstellation.HeaderText = "Constellation";
            this.MapConstellation.Name = "MapConstellation";
            this.MapConstellation.ReadOnly = true;
            // 
            // Moon
            // 
            this.Moon.HeaderText = "Moon";
            this.Moon.Name = "Moon";
            // 
            // StarbaseStatus
            // 
            this.StarbaseStatus.HeaderText = "Status";
            this.StarbaseStatus.Name = "StarbaseStatus";
            // 
            // StarbaseType
            // 
            this.StarbaseType.HeaderText = "Starbase Type";
            this.StarbaseType.Name = "StarbaseType";
            // 
            // StarbaseOwner
            // 
            this.StarbaseOwner.HeaderText = "Owner";
            this.StarbaseOwner.Name = "StarbaseOwner";
            // 
            // SelectStarbases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 358);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgStations);
            this.Controls.Add(this.btnSelectStarbases);
            this.Controls.Add(this.btnLoadStations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectStarbases";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EVEPOSMon Station Selection";
            ((System.ComponentModel.ISupportInitialize)(this.dgStations)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadStations;
        private System.Windows.Forms.Button btnSelectStarbases;
        private System.Windows.Forms.DataGridView dgStations;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslCachedUntil;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Monitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MapRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn MapConstellation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moon;
        private System.Windows.Forms.DataGridViewTextBoxColumn StarbaseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn StarbaseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn StarbaseOwner;
    }
}

