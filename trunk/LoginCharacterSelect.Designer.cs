namespace EVEPOSMon
{
    partial class LoginCharacterSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginCharacterSelect));
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.tbCharacter = new System.Windows.Forms.TextBox();
            this.btnGetCharacters = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUseProxy = new System.Windows.Forms.CheckBox();
            this.tbProxyAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(23, 129);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(46, 13);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "User ID:";
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(21, 155);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(48, 13);
            this.lblApiKey.TabIndex = 0;
            this.lblApiKey.Text = "API Key:";
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(75, 126);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(155, 20);
            this.tbUserId.TabIndex = 0;
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(75, 152);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(397, 20);
            this.tbApiKey.TabIndex = 1;
            // 
            // lblCharacter
            // 
            this.lblCharacter.AutoSize = true;
            this.lblCharacter.Location = new System.Drawing.Point(11, 187);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(56, 13);
            this.lblCharacter.TabIndex = 0;
            this.lblCharacter.Text = "Character:";
            // 
            // tbCharacter
            // 
            this.tbCharacter.Enabled = false;
            this.tbCharacter.Location = new System.Drawing.Point(75, 187);
            this.tbCharacter.Name = "tbCharacter";
            this.tbCharacter.Size = new System.Drawing.Size(145, 20);
            this.tbCharacter.TabIndex = 2;
            // 
            // btnGetCharacters
            // 
            this.btnGetCharacters.Location = new System.Drawing.Point(226, 187);
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
            this.btnOk.Location = new System.Drawing.Point(312, 302);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 24);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(391, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 91);
            this.label1.TabIndex = 5;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(165, 106);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(220, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://myeve.eve-online.com/api/default.asp";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Your keys can be found here:";
            // 
            // cbUseProxy
            // 
            this.cbUseProxy.AutoSize = true;
            this.cbUseProxy.Location = new System.Drawing.Point(23, 233);
            this.cbUseProxy.Name = "cbUseProxy";
            this.cbUseProxy.Size = new System.Drawing.Size(354, 17);
            this.cbUseProxy.TabIndex = 3;
            this.cbUseProxy.Text = "I am entering limited keys, use a proxy server when full keys are need:";
            this.cbUseProxy.UseVisualStyleBackColor = true;
            this.cbUseProxy.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbProxyAddress
            // 
            this.tbProxyAddress.Location = new System.Drawing.Point(24, 266);
            this.tbProxyAddress.Name = "tbProxyAddress";
            this.tbProxyAddress.Size = new System.Drawing.Size(346, 20);
            this.tbProxyAddress.TabIndex = 4;
            this.tbProxyAddress.Text = "http://www.example.com/";
            this.tbProxyAddress.Visible = false;
            // 
            // LoginCharacterSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 338);
            this.Controls.Add(this.tbProxyAddress);
            this.Controls.Add(this.cbUseProxy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnGetCharacters);
            this.Controls.Add(this.tbCharacter);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.tbUserId);
            this.Controls.Add(this.lblCharacter);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.lblUserId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginCharacterSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginCharacterSelect";
            this.Load += new System.EventHandler(this.LoginCharacterSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.TextBox tbCharacter;
        private System.Windows.Forms.Button btnGetCharacters;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbUseProxy;
        private System.Windows.Forms.TextBox tbProxyAddress;
    }
}
