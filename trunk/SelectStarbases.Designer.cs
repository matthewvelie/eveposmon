namespace EVEPOSMon
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
            this.btnGetStationInfo = new System.Windows.Forms.Button();
            this.dgStations = new System.Windows.Forms.DataGridView();
            this.Column0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveAutoload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgStations)).BeginInit();
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
            this.btnLoadStations.Click += new System.EventHandler(this.btnLoadStations_Click);
            // 
            // btnGetStationInfo
            // 
            this.btnGetStationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetStationInfo.Location = new System.Drawing.Point(13, 298);
            this.btnGetStationInfo.Name = "btnGetStationInfo";
            this.btnGetStationInfo.Size = new System.Drawing.Size(111, 23);
            this.btnGetStationInfo.TabIndex = 2;
            this.btnGetStationInfo.Text = "Select Starbases";
            this.btnGetStationInfo.UseVisualStyleBackColor = true;
            this.btnGetStationInfo.Click += new System.EventHandler(this.btnGetStationInfo_Click);
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
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgStations.Location = new System.Drawing.Point(7, 40);
            this.dgStations.MultiSelect = false;
            this.dgStations.Name = "dgStations";
            this.dgStations.RowHeadersVisible = false;
            this.dgStations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStations.Size = new System.Drawing.Size(404, 249);
            this.dgStations.TabIndex = 3;
            this.dgStations.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStations_CellValueChanged_1);
            // 
            // Column0
            // 
            this.Column0.FalseValue = "false";
            this.Column0.HeaderText = "Load";
            this.Column0.Name = "Column0";
            this.Column0.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column0.TrueValue = "true";
            this.Column0.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Region";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Constellation";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "System/Planet/Moon";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // btnSaveAutoload
            // 
            this.btnSaveAutoload.Location = new System.Drawing.Point(130, 298);
            this.btnSaveAutoload.Name = "btnSaveAutoload";
            this.btnSaveAutoload.Size = new System.Drawing.Size(150, 23);
            this.btnSaveAutoload.TabIndex = 4;
            this.btnSaveAutoload.Text = "Save Selection for Auto-load";
            this.btnSaveAutoload.UseVisualStyleBackColor = true;
            this.btnSaveAutoload.Visible = false;
            this.btnSaveAutoload.Click += new System.EventHandler(this.btnSaveAutoload_Click);
            // 
            // SelectStarbases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 328);
            this.Controls.Add(this.btnSaveAutoload);
            this.Controls.Add(this.dgStations);
            this.Controls.Add(this.btnGetStationInfo);
            this.Controls.Add(this.btnLoadStations);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectStarbases";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EVEPOSMon Station Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectStarbases_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadStations;
        private System.Windows.Forms.Button btnGetStationInfo;
        private System.Windows.Forms.DataGridView dgStations;
        private System.Windows.Forms.Button btnSaveAutoload;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

