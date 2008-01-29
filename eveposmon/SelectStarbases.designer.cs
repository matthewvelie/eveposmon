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
            this.dgvStarbaseList = new System.Windows.Forms.DataGridView();
            this.dgvMonitor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConstellation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStarbaseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStarbaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStarbaseList
            // 
            this.dgvStarbaseList.AllowUserToAddRows = false;
            this.dgvStarbaseList.AllowUserToDeleteRows = false;
            this.dgvStarbaseList.AllowUserToOrderColumns = true;
            this.dgvStarbaseList.AllowUserToResizeColumns = false;
            this.dgvStarbaseList.AllowUserToResizeRows = false;
            this.dgvStarbaseList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStarbaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStarbaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMonitor,
            this.dgvRegion,
            this.dgvConstellation,
            this.dgvMoon,
            this.dgvStatus,
            this.dgvStarbaseType,
            this.dgvAccount});
            this.dgvStarbaseList.Location = new System.Drawing.Point(7, 12);
            this.dgvStarbaseList.MultiSelect = false;
            this.dgvStarbaseList.Name = "dgvStarbaseList";
            this.dgvStarbaseList.ReadOnly = true;
            this.dgvStarbaseList.RowHeadersVisible = false;
            this.dgvStarbaseList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStarbaseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStarbaseList.Size = new System.Drawing.Size(654, 275);
            this.dgvStarbaseList.TabIndex = 3;
            this.dgvStarbaseList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStarbaseList_CellContentClick);
            // 
            // dgvMonitor
            // 
            this.dgvMonitor.DataPropertyName = "Monitored";
            this.dgvMonitor.FalseValue = "false";
            this.dgvMonitor.HeaderText = "Monitor";
            this.dgvMonitor.Name = "dgvMonitor";
            this.dgvMonitor.ReadOnly = true;
            this.dgvMonitor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonitor.TrueValue = "true";
            this.dgvMonitor.Width = 50;
            // 
            // dgvRegion
            // 
            this.dgvRegion.DataPropertyName = "Region";
            this.dgvRegion.HeaderText = "Region";
            this.dgvRegion.Name = "dgvRegion";
            this.dgvRegion.ReadOnly = true;
            // 
            // dgvConstellation
            // 
            this.dgvConstellation.DataPropertyName = "Constellation";
            this.dgvConstellation.HeaderText = "Constellation";
            this.dgvConstellation.Name = "dgvConstellation";
            this.dgvConstellation.ReadOnly = true;
            // 
            // dgvMoon
            // 
            this.dgvMoon.DataPropertyName = "Moon";
            this.dgvMoon.HeaderText = "Moon";
            this.dgvMoon.Name = "dgvMoon";
            this.dgvMoon.ReadOnly = true;
            // 
            // dgvStatus
            // 
            this.dgvStatus.DataPropertyName = "Status";
            this.dgvStatus.HeaderText = "Status";
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.ReadOnly = true;
            // 
            // dgvStarbaseType
            // 
            this.dgvStarbaseType.DataPropertyName = "StarbaseType";
            this.dgvStarbaseType.HeaderText = "Starbase Type";
            this.dgvStarbaseType.Name = "dgvStarbaseType";
            this.dgvStarbaseType.ReadOnly = true;
            // 
            // dgvAccount
            // 
            this.dgvAccount.DataPropertyName = "AccountName";
            this.dgvAccount.HeaderText = "Account";
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(505, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(586, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SelectStarbases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 332);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvStarbaseList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectStarbases";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EVEPOSMon Station Selection";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStarbaseList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStarbaseList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConstellation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMoon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStarbaseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAccount;
    }
}

