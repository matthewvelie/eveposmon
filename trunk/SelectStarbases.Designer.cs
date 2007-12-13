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
            this.lbStations = new System.Windows.Forms.ListBox();
            this.btnLoadStations = new System.Windows.Forms.Button();
            this.btnGetStationInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbStations
            // 
            this.lbStations.FormattingEnabled = true;
            this.lbStations.Location = new System.Drawing.Point(12, 83);
            this.lbStations.Name = "lbStations";
            this.lbStations.Size = new System.Drawing.Size(339, 251);
            this.lbStations.TabIndex = 0;
            // 
            // btnLoadStations
            // 
            this.btnLoadStations.Location = new System.Drawing.Point(12, 54);
            this.btnLoadStations.Name = "btnLoadStations";
            this.btnLoadStations.Size = new System.Drawing.Size(106, 23);
            this.btnLoadStations.TabIndex = 1;
            this.btnLoadStations.Text = "Get Station List";
            this.btnLoadStations.UseVisualStyleBackColor = true;
            this.btnLoadStations.Click += new System.EventHandler(this.btnLoadStations_Click);
            // 
            // btnGetStationInfo
            // 
            this.btnGetStationInfo.Location = new System.Drawing.Point(13, 341);
            this.btnGetStationInfo.Name = "btnGetStationInfo";
            this.btnGetStationInfo.Size = new System.Drawing.Size(105, 23);
            this.btnGetStationInfo.TabIndex = 2;
            this.btnGetStationInfo.Text = "Get Station Info";
            this.btnGetStationInfo.UseVisualStyleBackColor = true;
            this.btnGetStationInfo.Click += new System.EventHandler(this.btnGetStationInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 393);
            this.Controls.Add(this.btnGetStationInfo);
            this.Controls.Add(this.btnLoadStations);
            this.Controls.Add(this.lbStations);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbStations;
        private System.Windows.Forms.Button btnLoadStations;
        private System.Windows.Forms.Button btnGetStationInfo;
    }
}

