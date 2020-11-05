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
            this.logoutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // profilePicture
            // 
            this.profilePicture.AccessibleDescription = "user profile picture";
            this.profilePicture.AccessibleName = "user profile picture";
            this.profilePicture.Location = new System.Drawing.Point(186, 19);
            this.profilePicture.Margin = new System.Windows.Forms.Padding(2);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(102, 85);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 0;
            this.profilePicture.TabStop = false;
            this.profilePicture.Click += new System.EventHandler(this.ProfilePicture_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AccessibleDescription = "user name";
            this.usernameLabel.AccessibleName = "user name";
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.usernameLabel.Location = new System.Drawing.Point(292, 45);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(97, 38);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Guest";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.usernameLabel.Click += new System.EventHandler(this.ProfilePicture_Click);
            // 
            // uploadedLabel
            // 
            this.uploadedLabel.AccessibleDescription = "ads uploaded by user";
            this.uploadedLabel.AccessibleName = "ads uploaded by user";
            this.uploadedLabel.AutoSize = true;
            this.uploadedLabel.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadedLabel.Location = new System.Drawing.Point(31, 125);
            this.uploadedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uploadedLabel.Name = "uploadedLabel";
            this.uploadedLabel.Size = new System.Drawing.Size(227, 25);
            this.uploadedLabel.TabIndex = 1;
            this.uploadedLabel.Text = "Ads uploaded by Guest";
            this.uploadedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // favoriteAdsLabel
            // 
            this.favoriteAdsLabel.AccessibleDescription = "favorite user ads";
            this.favoriteAdsLabel.AccessibleName = "favorite user ads";
            this.favoriteAdsLabel.AutoSize = true;
            this.favoriteAdsLabel.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.favoriteAdsLabel.Location = new System.Drawing.Point(31, 427);
            this.favoriteAdsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.favoriteAdsLabel.Name = "favoriteAdsLabel";
            this.favoriteAdsLabel.Size = new System.Drawing.Size(186, 25);
            this.favoriteAdsLabel.TabIndex = 3;
            this.favoriteAdsLabel.Text = "Guest favorite Ads";
            this.favoriteAdsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uploadedPanel
            // 
            this.uploadedPanel.AccessibleDescription = "uploaded ads";
            this.uploadedPanel.AccessibleName = "uploaded ads";
            this.uploadedPanel.Location = new System.Drawing.Point(31, 151);
            this.uploadedPanel.Margin = new System.Windows.Forms.Padding(2);
            this.uploadedPanel.Name = "uploadedPanel";
            this.uploadedPanel.Size = new System.Drawing.Size(638, 245);
            this.uploadedPanel.TabIndex = 2;
            // 
            // favoriteAds
            // 
            this.favoriteAds.AccessibleDescription = "favorite ads";
            this.favoriteAds.AccessibleName = "favorite ads";
            this.favoriteAds.Location = new System.Drawing.Point(31, 451);
            this.favoriteAds.Margin = new System.Windows.Forms.Padding(2);
            this.favoriteAds.Name = "favoriteAds";
            this.favoriteAds.Size = new System.Drawing.Size(638, 245);
            this.favoriteAds.TabIndex = 4;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(0, 0);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(164, 33);
            this.logoutBtn.TabIndex = 5;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Visible = false;
            // 
            // ProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.favoriteAds);
            this.Controls.Add(this.uploadedPanel);
            this.Controls.Add(this.favoriteAdsLabel);
            this.Controls.Add(this.uploadedLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.profilePicture);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProfilePage";
            this.Size = new System.Drawing.Size(724, 727);
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
        private System.Windows.Forms.Button logoutBtn;
    }
}
