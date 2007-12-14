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
            this.lbStations = new System.Windows.Forms.DataGridView();
            this.Column0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hidden_object = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveAutoload = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lbStations)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadStations
            // 
            this.btnLoadStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadStations.Location = new System.Drawing.Point(12, 55);
            this.btnLoadStations.Name = "btnLoadStations";
            this.btnLoadStations.Size = new System.Drawing.Size(104, 22);
            this.btnLoadStations.TabIndex = 1;
            this.btnLoadStations.Text = "Get Station List";
            this.btnLoadStations.UseVisualStyleBackColor = true;
            this.btnLoadStations.Click += new System.EventHandler(this.btnLoadStations_Click);
            // 
            // btnGetStationInfo
            // 
            this.btnGetStationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetStationInfo.Location = new System.Drawing.Point(13, 341);
            this.btnGetStationInfo.Name = "btnGetStationInfo";
            this.btnGetStationInfo.Size = new System.Drawing.Size(111, 23);
            this.btnGetStationInfo.TabIndex = 2;
            this.btnGetStationInfo.Text = "Get Station Info";
            this.btnGetStationInfo.UseVisualStyleBackColor = true;
            this.btnGetStationInfo.Click += new System.EventHandler(this.btnGetStationInfo_Click);
            // 
            // lbStations
            // 
            this.lbStations.AllowUserToAddRows = false;
            this.lbStations.AllowUserToDeleteRows = false;
            this.lbStations.AllowUserToOrderColumns = true;
            this.lbStations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lbStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column3,
            this.hidden_object});
            this.lbStations.Location = new System.Drawing.Point(9, 86);
            this.lbStations.Name = "lbStations";
            this.lbStations.RowHeadersVisible = false;
            this.lbStations.Size = new System.Drawing.Size(404, 249);
            this.lbStations.TabIndex = 3;
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
            // hidden_object
            // 
            this.hidden_object.HeaderText = "Column4";
            this.hidden_object.Name = "hidden_object";
            this.hidden_object.Visible = false;
            // 
            // btnSaveAutoload
            // 
            this.btnSaveAutoload.Location = new System.Drawing.Point(130, 341);
            this.btnSaveAutoload.Name = "btnSaveAutoload";
            this.btnSaveAutoload.Size = new System.Drawing.Size(150, 23);
            this.btnSaveAutoload.TabIndex = 4;
            this.btnSaveAutoload.Text = "Save Selection for Auto-load";
            this.btnSaveAutoload.UseVisualStyleBackColor = true;
            this.btnSaveAutoload.Click += new System.EventHandler(this.btnSaveAutoload_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(423, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.characterInformationToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // characterInformationToolStripMenuItem
            // 
            this.characterInformationToolStripMenuItem.Name = "characterInformationToolStripMenuItem";
            this.characterInformationToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.characterInformationToolStripMenuItem.Text = "Character Information";
            this.characterInformationToolStripMenuItem.Click += new System.EventHandler(this.characterInformationToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 19);
            this.button1.TabIndex = 6;
            this.button1.Text = "Fuel Calculator";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectStarbases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(423, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSaveAutoload);
            this.Controls.Add(this.lbStations);
            this.Controls.Add(this.btnGetStationInfo);
            this.Controls.Add(this.btnLoadStations);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SelectStarbases";
            this.Text = "EVEPOSMon Station Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectStarbases_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbStations)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadStations;
        private System.Windows.Forms.Button btnGetStationInfo;
        private System.Windows.Forms.DataGridView lbStations;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn hidden_object;
        private System.Windows.Forms.Button btnSaveAutoload;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem characterInformationToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

