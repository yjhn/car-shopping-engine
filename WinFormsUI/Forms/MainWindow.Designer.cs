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
            this.favoritesButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.browsePage = new CarEngine.BrowsePage();
            this.uploadPage = new CarEngine.Pages.UploadPage();
            this.searchPage = new CarEngine.SearchPage();
            this.profilePage = new CarEngine.Pages.ProfilePage();
            this.sidebarPanel.SuspendLayout();
            this.pagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.AutoScroll = true;
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.sidebarPanel.Controls.Add(this.favoritesButton);
            this.sidebarPanel.Controls.Add(this.uploadButton);
            this.sidebarPanel.Controls.Add(this.searchButton);
            this.sidebarPanel.Controls.Add(this.browseButton);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(126, 581);
            this.sidebarPanel.TabIndex = 0;
            // 
            // favoritesButton
            // 
            this.favoritesButton.BackColor = System.Drawing.Color.Transparent;
            this.favoritesButton.FlatAppearance.BorderSize = 0;
            this.favoritesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.favoritesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.favoritesButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.favoritesButton.ForeColor = System.Drawing.Color.Transparent;
            this.favoritesButton.Location = new System.Drawing.Point(0, 310);
            this.favoritesButton.Margin = new System.Windows.Forms.Padding(2);
            this.favoritesButton.Name = "favoritesButton";
            this.favoritesButton.Size = new System.Drawing.Size(126, 80);
            this.favoritesButton.TabIndex = 4;
            this.favoritesButton.Text = "favorites";
            this.favoritesButton.UseVisualStyleBackColor = false;
            this.favoritesButton.Click += new System.EventHandler(this.FavoritesButton_Click);
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
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(126, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(708, 26);
            this.topPanel.TabIndex = 1;
            // 
            // pagePanel
            // 
            this.pagePanel.AutoScroll = true;
            this.pagePanel.Controls.Add(this.browsePage);
            this.pagePanel.Controls.Add(this.uploadPage);
            this.pagePanel.Controls.Add(this.searchPage);
            this.pagePanel.Controls.Add(this.profilePage);
            this.pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePanel.Location = new System.Drawing.Point(126, 26);
            this.pagePanel.Margin = new System.Windows.Forms.Padding(2);
            this.pagePanel.MinimumSize = new System.Drawing.Size(660, 250);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(708, 555);
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
            this.browsePage.Size = new System.Drawing.Size(708, 555);
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
            this.uploadPage.Size = new System.Drawing.Size(708, 555);
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
            this.searchPage.Size = new System.Drawing.Size(708, 555);
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
            this.profilePage.Size = new System.Drawing.Size(708, 555);
            this.profilePage.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(834, 581);
            this.Controls.Add(this.pagePanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.sidebarPanel);
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
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button favoritesButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel pagePanel;
        private CarEngine.SearchPage searchPage;
        private CarEngine.BrowsePage browsePage;
        private CarEngine.Pages.ProfilePage profilePage;
        private CarEngine.Pages.UploadPage uploadPage;
    }
}