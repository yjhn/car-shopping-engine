namespace Test1
{
    partial class MainWindow
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
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.loginBtn = new System.Windows.Forms.Button();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.profileButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.browsePage = new CarEngine.BrowsePage();
            this.uploadPage = new CarEngine.Pages.UploadPage();
            this.searchPage = new CarEngine.SearchPage();
            this.profilePage = new CarEngine.Pages.ProfilePage();
            this.networkErrorMessage = new System.Windows.Forms.Label();
            this.sidebarPanel.SuspendLayout();
            this.pagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.AutoScroll = true;
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.sidebarPanel.Controls.Add(this.loginBtn);
            this.sidebarPanel.Controls.Add(this.userNameLabel);
            this.sidebarPanel.Controls.Add(this.profileButton);
            this.sidebarPanel.Controls.Add(this.uploadButton);
            this.sidebarPanel.Controls.Add(this.searchButton);
            this.sidebarPanel.Controls.Add(this.browseButton);
            this.sidebarPanel.Controls.Add(this.logoutBtn);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(126, 581);
            this.sidebarPanel.TabIndex = 0;
            // 
            // loginBtn
            // 
            this.loginBtn.AccessibleDescription = "log in button";
            this.loginBtn.AccessibleName = "log in button";
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.loginBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loginBtn.ForeColor = System.Drawing.Color.Transparent;
            this.loginBtn.Location = new System.Drawing.Point(0, 497);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(126, 42);
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "log in";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.VisibleChanged += new System.EventHandler(this.LoginBtn_VisibleChanged);
            this.loginBtn.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userNameLabel.ForeColor = System.Drawing.Color.Yellow;
            this.userNameLabel.Location = new System.Drawing.Point(0, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(126, 56);
            this.userNameLabel.TabIndex = 5;
            this.userNameLabel.Text = "Guest";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.userNameLabel.Click += new System.EventHandler(this.UserNameLabel_Click);
            // 
            // profileButton
            // 
            this.profileButton.BackColor = System.Drawing.Color.Transparent;
            this.profileButton.Enabled = false;
            this.profileButton.FlatAppearance.BorderSize = 0;
            this.profileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.profileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.profileButton.ForeColor = System.Drawing.Color.Transparent;
            this.profileButton.Location = new System.Drawing.Point(0, 310);
            this.profileButton.Margin = new System.Windows.Forms.Padding(2);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(126, 80);
            this.profileButton.TabIndex = 4;
            this.profileButton.Text = "profile";
            this.profileButton.UseVisualStyleBackColor = false;
            this.profileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.Transparent;
            this.uploadButton.FlatAppearance.BorderSize = 0;
            this.uploadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadButton.ForeColor = System.Drawing.Color.Transparent;
            this.uploadButton.Location = new System.Drawing.Point(0, 226);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(2);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(126, 80);
            this.uploadButton.TabIndex = 3;
            this.uploadButton.Text = "upload";
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Transparent;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchButton.ForeColor = System.Drawing.Color.Transparent;
            this.searchButton.Location = new System.Drawing.Point(0, 142);
            this.searchButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(126, 80);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.Transparent;
            this.browseButton.FlatAppearance.BorderSize = 0;
            this.browseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.browseButton.ForeColor = System.Drawing.Color.Transparent;
            this.browseButton.Location = new System.Drawing.Point(0, 58);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(126, 80);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "browse";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.AccessibleDescription = "log out button";
            this.logoutBtn.AccessibleName = "log out button";
            this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.logoutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logoutBtn.ForeColor = System.Drawing.Color.Transparent;
            this.logoutBtn.Location = new System.Drawing.Point(0, 539);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(2);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(126, 42);
            this.logoutBtn.TabIndex = 7;
            this.logoutBtn.Text = "log out";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Visible = false;
            this.logoutBtn.VisibleChanged += new System.EventHandler(this.LogoutBtn_VisibleChanged);
            this.logoutBtn.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // pagePanel
            // 
            this.pagePanel.AutoScroll = true;
            this.pagePanel.Controls.Add(this.browsePage);
            this.pagePanel.Controls.Add(this.uploadPage);
            this.pagePanel.Controls.Add(this.searchPage);
            this.pagePanel.Controls.Add(this.profilePage);
            this.pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePanel.Location = new System.Drawing.Point(126, 0);
            this.pagePanel.Margin = new System.Windows.Forms.Padding(2);
            this.pagePanel.MinimumSize = new System.Drawing.Size(660, 250);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(708, 581);
            this.pagePanel.TabIndex = 2;
            // 
            // browsePage
            // 
            this.browsePage.AutoScroll = true;
            this.browsePage.AutoSize = true;
            this.browsePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browsePage.Location = new System.Drawing.Point(0, 0);
            this.browsePage.Margin = new System.Windows.Forms.Padding(1);
            this.browsePage.MinimumSize = new System.Drawing.Size(660, 250);
            this.browsePage.Name = "browsePage";
            this.browsePage.Size = new System.Drawing.Size(708, 581);
            this.browsePage.TabIndex = 0;
            this.browsePage.TabStop = false;
            // 
            // uploadPage
            // 
            this.uploadPage.AutoScroll = true;
            this.uploadPage.AutoSize = true;
            this.uploadPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uploadPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadPage.Location = new System.Drawing.Point(0, 0);
            this.uploadPage.Margin = new System.Windows.Forms.Padding(1);
            this.uploadPage.Name = "uploadPage";
            this.uploadPage.Size = new System.Drawing.Size(708, 581);
            this.uploadPage.TabIndex = 2;
            // 
            // searchPage
            // 
            this.searchPage.AccessibleDescription = "vehicle search page";
            this.searchPage.AccessibleName = "search page";
            this.searchPage.AutoScroll = true;
            this.searchPage.AutoSize = true;
            this.searchPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPage.Location = new System.Drawing.Point(0, 0);
            this.searchPage.Margin = new System.Windows.Forms.Padding(1);
            this.searchPage.Name = "searchPage";
            this.searchPage.Size = new System.Drawing.Size(708, 581);
            this.searchPage.TabIndex = 1;
            // 
            // profilePage
            // 
            this.profilePage.AutoScroll = true;
            this.profilePage.AutoSize = true;
            this.profilePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilePage.Location = new System.Drawing.Point(0, 0);
            this.profilePage.Margin = new System.Windows.Forms.Padding(1);
            this.profilePage.Name = "profilePage";
            this.profilePage.Size = new System.Drawing.Size(708, 581);
            this.profilePage.TabIndex = 3;
            // 
            // networkErrorMessage
            // 
            this.networkErrorMessage.AccessibleDescription = "network error message";
            this.networkErrorMessage.AccessibleName = "network error message";
            this.networkErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkErrorMessage.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.networkErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.networkErrorMessage.Location = new System.Drawing.Point(0, 0);
            this.networkErrorMessage.Name = "networkErrorMessage";
            this.networkErrorMessage.Size = new System.Drawing.Size(834, 581);
            this.networkErrorMessage.TabIndex = 3;
            this.networkErrorMessage.Text = "No connection to server";
            this.networkErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.networkErrorMessage.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(834, 581);
            this.Controls.Add(this.pagePanel);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.networkErrorMessage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(850, 450);
            this.Name = "MainWindow";
            this.Text = "Car shopping engine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.sidebarPanel.ResumeLayout(false);
            this.pagePanel.ResumeLayout(false);
            this.pagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel pagePanel;
        private CarEngine.SearchPage searchPage;
        private CarEngine.BrowsePage browsePage;
        private CarEngine.Pages.ProfilePage profilePage;
        private CarEngine.Pages.UploadPage uploadPage;
        private System.Windows.Forms.Label networkErrorMessage;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label userNameLabel;
    }
}