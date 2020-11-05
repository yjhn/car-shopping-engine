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
            this.likedAdsLabel = new System.Windows.Forms.Label();
            this.likedAdsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.uploadedAdsPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // profilePicture
            // 
            this.profilePicture.AccessibleDescription = "user profile picture";
            this.profilePicture.AccessibleName = "user profile picture";
            this.profilePicture.Location = new System.Drawing.Point(195, 0);
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
            this.usernameLabel.Location = new System.Drawing.Point(301, 25);
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
            this.uploadedLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.uploadedLabel.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadedLabel.Location = new System.Drawing.Point(0, 89);
            this.uploadedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uploadedLabel.Name = "uploadedLabel";
            this.uploadedLabel.Size = new System.Drawing.Size(724, 25);
            this.uploadedLabel.TabIndex = 1;
            this.uploadedLabel.Text = "Ads uploaded by Guest";
            this.uploadedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // likedAdsLabel
            // 
            this.likedAdsLabel.AccessibleDescription = "favorite user ads";
            this.likedAdsLabel.AccessibleName = "favorite user ads";
            this.likedAdsLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.likedAdsLabel.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.likedAdsLabel.Location = new System.Drawing.Point(0, 350);
            this.likedAdsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.likedAdsLabel.Name = "likedAdsLabel";
            this.likedAdsLabel.Size = new System.Drawing.Size(724, 25);
            this.likedAdsLabel.TabIndex = 3;
            this.likedAdsLabel.Text = "Ads liked by Guest";
            this.likedAdsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // likedAdsPanel
            // 
            this.likedAdsPanel.AutoScroll = true;
            this.likedAdsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.likedAdsPanel.Location = new System.Drawing.Point(0, 375);
            this.likedAdsPanel.Name = "likedAdsPanel";
            this.likedAdsPanel.Size = new System.Drawing.Size(724, 352);
            this.likedAdsPanel.TabIndex = 6;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.profilePicture);
            this.topPanel.Controls.Add(this.usernameLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(724, 89);
            this.topPanel.TabIndex = 7;
            // 
            // uploadedAdsPanel
            // 
            this.uploadedAdsPanel.AutoScroll = true;
            this.uploadedAdsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadedAdsPanel.Location = new System.Drawing.Point(0, 114);
            this.uploadedAdsPanel.Name = "uploadedAdsPanel";
            this.uploadedAdsPanel.Size = new System.Drawing.Size(724, 236);
            this.uploadedAdsPanel.TabIndex = 8;
            // 
            // ProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadedAdsPanel);
            this.Controls.Add(this.uploadedLabel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.likedAdsLabel);
            this.Controls.Add(this.likedAdsPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProfilePage";
            this.Size = new System.Drawing.Size(724, 727);
            this.VisibleChanged += new System.EventHandler(this.ProfilePage_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label uploadedLabel;
        private System.Windows.Forms.Label likedAdsLabel;
        private System.Windows.Forms.FlowLayoutPanel likedAdsPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.FlowLayoutPanel uploadedAdsPanel;
    }
}
