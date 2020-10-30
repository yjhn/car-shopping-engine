namespace CarEngine.Pages
{
    partial class ProfilePage
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
            this.profilePicture = new System.Windows.Forms.PictureBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.uploadedLabel = new System.Windows.Forms.Label();
            this.favoriteAdsLabel = new System.Windows.Forms.Label();
            this.uploadedPanel = new System.Windows.Forms.Panel();
            this.favoriteAds = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // profilePicture
            // 
            this.profilePicture.AccessibleDescription = "user profile picture";
            this.profilePicture.AccessibleName = "user profile picture";
            this.profilePicture.Location = new System.Drawing.Point(265, 31);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(146, 142);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 0;
            this.profilePicture.TabStop = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AccessibleDescription = "user name";
            this.usernameLabel.AccessibleName = "user name";
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.usernameLabel.Location = new System.Drawing.Point(417, 75);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(336, 57);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "usernameTest1";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uploadedLabel
            // 
            this.uploadedLabel.AccessibleDescription = "ads uploaded by user";
            this.uploadedLabel.AccessibleName = "ads uploaded by user";
            this.uploadedLabel.AutoSize = true;
            this.uploadedLabel.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadedLabel.Location = new System.Drawing.Point(44, 208);
            this.uploadedLabel.Name = "uploadedLabel";
            this.uploadedLabel.Size = new System.Drawing.Size(470, 38);
            this.uploadedLabel.TabIndex = 1;
            this.uploadedLabel.Text = "Ads uploaded by usernameTest1";
            this.uploadedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // favoriteAdsLabel
            // 
            this.favoriteAdsLabel.AccessibleDescription = "favorite user ads";
            this.favoriteAdsLabel.AccessibleName = "favorite user ads";
            this.favoriteAdsLabel.AutoSize = true;
            this.favoriteAdsLabel.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.favoriteAdsLabel.Location = new System.Drawing.Point(44, 711);
            this.favoriteAdsLabel.Name = "favoriteAdsLabel";
            this.favoriteAdsLabel.Size = new System.Drawing.Size(408, 38);
            this.favoriteAdsLabel.TabIndex = 3;
            this.favoriteAdsLabel.Text = "usernameTest1 favorite Ads";
            this.favoriteAdsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uploadedPanel
            // 
            this.uploadedPanel.AccessibleDescription = "uploaded ads";
            this.uploadedPanel.AccessibleName = "uploaded ads";
            this.uploadedPanel.Location = new System.Drawing.Point(44, 252);
            this.uploadedPanel.Name = "uploadedPanel";
            this.uploadedPanel.Size = new System.Drawing.Size(911, 408);
            this.uploadedPanel.TabIndex = 2;
            // 
            // favoriteAds
            // 
            this.favoriteAds.AccessibleDescription = "favorite ads";
            this.favoriteAds.AccessibleName = "favorite ads";
            this.favoriteAds.Location = new System.Drawing.Point(44, 752);
            this.favoriteAds.Name = "favoriteAds";
            this.favoriteAds.Size = new System.Drawing.Size(911, 408);
            this.favoriteAds.TabIndex = 4;
            // 
            // ProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.favoriteAds);
            this.Controls.Add(this.uploadedPanel);
            this.Controls.Add(this.favoriteAdsLabel);
            this.Controls.Add(this.uploadedLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.profilePicture);
            this.Name = "ProfilePage";
            this.Size = new System.Drawing.Size(1034, 1212);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label uploadedLabel;
        private System.Windows.Forms.Label favoriteAdsLabel;
        private System.Windows.Forms.Panel uploadedPanel;
        private System.Windows.Forms.Panel favoriteAds;
    }
}
