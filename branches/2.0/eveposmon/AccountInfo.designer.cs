namespace eveposmon
{
    partial class AccountInfo
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
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.tbCharacterName = new System.Windows.Forms.TextBox();
            this.btnGetCharacters = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCharaterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCharacterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(6, 46);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(46, 13);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "User ID:";
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(8, 72);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(48, 13);
            this.lblApiKey.TabIndex = 0;
            this.lblApiKey.Text = "API Key:";
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(69, 43);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(155, 20);
            this.tbUserId.TabIndex = 0;
            this.tbUserId.TextChanged += new System.EventHandler(this.tbUserId_TextChanged);
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(69, 69);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(393, 20);
            this.tbApiKey.TabIndex = 1;
            this.tbApiKey.TextChanged += new System.EventHandler(this.tbApiKey_TextChanged);
            // 
            // lblCharacter
            // 
            this.lblCharacter.AutoSize = true;
            this.lblCharacter.Location = new System.Drawing.Point(6, 101);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(56, 13);
            this.lblCharacter.TabIndex = 0;
            this.lblCharacter.Text = "Character:";
            // 
            // tbCharacterName
            // 
            this.tbCharacterName.Enabled = false;
            this.tbCharacterName.Location = new System.Drawing.Point(69, 98);
            this.tbCharacterName.Name = "tbCharacterName";
            this.tbCharacterName.ReadOnly = true;
            this.tbCharacterName.Size = new System.Drawing.Size(155, 20);
            this.tbCharacterName.TabIndex = 2;
            // 
            // btnGetCharacters
            // 
            this.btnGetCharacters.Enabled = false;
            this.btnGetCharacters.Location = new System.Drawing.Point(231, 98);
            this.btnGetCharacters.Name = "btnGetCharacters";
            this.btnGetCharacters.Size = new System.Drawing.Size(31, 20);
            this.btnGetCharacters.TabIndex = 2;
            this.btnGetCharacters.Text = "...";
            this.btnGetCharacters.UseVisualStyleBackColor = true;
            this.btnGetCharacters.Click += new System.EventHandler(this.btnGetCharacters_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(218, 356);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 24);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Close";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(159, 23);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(220, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://myeve.eve-online.com/api/default.asp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Your keys can be found here:";
            // 
            // dgAccounts
            // 
            this.dgAccounts.AllowUserToAddRows = false;
            this.dgAccounts.AllowUserToDeleteRows = false;
            this.dgAccounts.AllowUserToOrderColumns = true;
            this.dgAccounts.AllowUserToResizeColumns = false;
            this.dgAccounts.AllowUserToResizeRows = false;
            this.dgAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCharaterName,
            this.dgvCharacterId,
            this.dgvUserId,
            this.dgvDelete});
            this.dgAccounts.Location = new System.Drawing.Point(12, 15);
            this.dgAccounts.MultiSelect = false;
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.ReadOnly = true;
            this.dgAccounts.RowHeadersVisible = false;
            this.dgAccounts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAccounts.Size = new System.Drawing.Size(478, 188);
            this.dgAccounts.TabIndex = 11;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Enabled = false;
            this.btnAddAccount.Location = new System.Drawing.Point(354, 96);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(108, 24);
            this.btnAddAccount.TabIndex = 12;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblUserId);
            this.groupBox1.Controls.Add(this.lblApiKey);
            this.groupBox1.Controls.Add(this.btnAddAccount);
            this.groupBox1.Controls.Add(this.lblCharacter);
            this.groupBox1.Controls.Add(this.tbUserId);
            this.groupBox1.Controls.Add(this.tbApiKey);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.tbCharacterName);
            this.groupBox1.Controls.Add(this.btnGetCharacters);
            this.groupBox1.Location = new System.Drawing.Point(11, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 129);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Account";
            // 
            // dgvCharaterName
            // 
            this.dgvCharaterName.DataPropertyName = "CharacterName";
            this.dgvCharaterName.HeaderText = "Character Name";
            this.dgvCharaterName.Name = "dgvCharaterName";
            this.dgvCharaterName.ReadOnly = true;
            this.dgvCharaterName.Width = 150;
            // 
            // dgvCharacterId
            // 
            this.dgvCharacterId.DataPropertyName = "CharacterId";
            this.dgvCharacterId.HeaderText = "Character ID";
            this.dgvCharacterId.Name = "dgvCharacterId";
            this.dgvCharacterId.ReadOnly = true;
            // 
            // dgvUserId
            // 
            this.dgvUserId.DataPropertyName = "UserId";
            this.dgvUserId.HeaderText = "User ID";
            this.dgvUserId.Name = "dgvUserId";
            this.dgvUserId.ReadOnly = true;
            // 
            // dgvDelete
            // 
            this.dgvDelete.HeaderText = "Delete";
            this.dgvDelete.Name = "dgvDelete";
            this.dgvDelete.ReadOnly = true;
            // 
            // AccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 385);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgAccounts);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Data";
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.TextBox tbCharacterName;
        private System.Windows.Forms.Button btnGetCharacters;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgAccounts;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCharaterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCharacterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUserId;
        private System.Windows.Forms.DataGridViewButtonColumn dgvDelete;
    }
}
