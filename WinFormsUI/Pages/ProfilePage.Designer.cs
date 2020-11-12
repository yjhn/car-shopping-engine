namespace CarEngine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfilePage));
            this.profilePicture = new System.Windows.Forms.PictureBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.uploadedLabel = new System.Windows.Forms.Label();
            this.likedAdsLabel = new System.Windows.Forms.Label();
            this.likedAdsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.uploadedAdsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.likedPanel = new System.Windows.Forms.Panel();
            this.sortingLikedAdsPnl = new System.Windows.Forms.Panel();
            this.sortLikedAdsBtn = new System.Windows.Forms.Button();
            this.sortLikedAdsByCombobox = new System.Windows.Forms.ComboBox();
            this.sortLikedAdsByLbl = new System.Windows.Forms.Label();
            this.likedAdsPageNrLbl = new System.Windows.Forms.Label();
            this.likedAdsPrevPageBtn = new System.Windows.Forms.Button();
            this.likedAdsNextPageBtn = new System.Windows.Forms.Button();
            this.sortLikedAdsAscDescPnl = new System.Windows.Forms.Panel();
            this.sortLikedAdsAscRdBtn = new System.Windows.Forms.RadioButton();
            this.sortLikedAdsDescRdBtn = new System.Windows.Forms.RadioButton();
            this.uploadedPanel = new System.Windows.Forms.Panel();
            this.sortingUploadedAdsPnl = new System.Windows.Forms.Panel();
            this.sortUploadedAdsBtn = new System.Windows.Forms.Button();
            this.sortUploadedAdsByCombobox = new System.Windows.Forms.ComboBox();
            this.refreshUploadedAdsBtn = new System.Windows.Forms.Button();
            this.sortUploadedAdsByLbl = new System.Windows.Forms.Label();
            this.uploadedAdsPageNrLbl = new System.Windows.Forms.Label();
            this.uploadedAdsPrevPageBtn = new System.Windows.Forms.Button();
            this.uploadedAdsNextPageBtn = new System.Windows.Forms.Button();
            this.sortUploadedAdsAscDescPnl = new System.Windows.Forms.Panel();
            this.sortUploadedAdsAscRdBtn = new System.Windows.Forms.RadioButton();
            this.sortUploadedAdsDescRdBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.topPanel.SuspendLayout();
            this.likedPanel.SuspendLayout();
            this.sortingLikedAdsPnl.SuspendLayout();
            this.sortLikedAdsAscDescPnl.SuspendLayout();
            this.uploadedPanel.SuspendLayout();
            this.sortingUploadedAdsPnl.SuspendLayout();
            this.sortUploadedAdsAscDescPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // profilePicture
            // 
            this.profilePicture.AccessibleDescription = "user profile picture";
            this.profilePicture.AccessibleName = "user profile picture";
            this.profilePicture.Dock = System.Windows.Forms.DockStyle.Right;
            this.profilePicture.Image = ((System.Drawing.Image)(resources.GetObject("profilePicture.Image")));
            this.profilePicture.Location = new System.Drawing.Point(593, 0);
            this.profilePicture.Margin = new System.Windows.Forms.Padding(2);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(34, 37);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 0;
            this.profilePicture.TabStop = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AccessibleDescription = "user name";
            this.usernameLabel.AccessibleName = "user name";
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.usernameLabel.Location = new System.Drawing.Point(627, 0);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(97, 38);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Guest";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uploadedLabel
            // 
            this.uploadedLabel.AccessibleDescription = "ads uploaded by user";
            this.uploadedLabel.AccessibleName = "ads uploaded by user";
            this.uploadedLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.uploadedLabel.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadedLabel.Location = new System.Drawing.Point(0, 0);
            this.uploadedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uploadedLabel.Name = "uploadedLabel";
            this.uploadedLabel.Size = new System.Drawing.Size(724, 25);
            this.uploadedLabel.TabIndex = 1;
            this.uploadedLabel.Text = "Uploaded Ads";
            this.uploadedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // likedAdsLabel
            // 
            this.likedAdsLabel.AccessibleDescription = "favorite user ads";
            this.likedAdsLabel.AccessibleName = "favorite user ads";
            this.likedAdsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.likedAdsLabel.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.likedAdsLabel.Location = new System.Drawing.Point(0, 0);
            this.likedAdsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.likedAdsLabel.Name = "likedAdsLabel";
            this.likedAdsLabel.Size = new System.Drawing.Size(724, 25);
            this.likedAdsLabel.TabIndex = 3;
            this.likedAdsLabel.Text = "Liked Ads";
            this.likedAdsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // likedAdsPanel
            // 
            this.likedAdsPanel.AutoScroll = true;
            this.likedAdsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.likedAdsPanel.Location = new System.Drawing.Point(0, 25);
            this.likedAdsPanel.Name = "likedAdsPanel";
            this.likedAdsPanel.Size = new System.Drawing.Size(724, 248);
            this.likedAdsPanel.TabIndex = 6;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.profilePicture);
            this.topPanel.Controls.Add(this.usernameLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(724, 37);
            this.topPanel.TabIndex = 7;
            // 
            // uploadedAdsPanel
            // 
            this.uploadedAdsPanel.AutoScroll = true;
            this.uploadedAdsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadedAdsPanel.Location = new System.Drawing.Point(0, 25);
            this.uploadedAdsPanel.Name = "uploadedAdsPanel";
            this.uploadedAdsPanel.Size = new System.Drawing.Size(724, 202);
            this.uploadedAdsPanel.TabIndex = 8;
            // 
            // likedPanel
            // 
            this.likedPanel.Controls.Add(this.likedAdsPanel);
            this.likedPanel.Controls.Add(this.likedAdsLabel);
            this.likedPanel.Controls.Add(this.sortingLikedAdsPnl);
            this.likedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.likedPanel.Location = new System.Drawing.Point(0, 37);
            this.likedPanel.Name = "likedPanel";
            this.likedPanel.Size = new System.Drawing.Size(724, 326);
            this.likedPanel.TabIndex = 9;
            // 
            // sortingLikedAdsPnl
            // 
            this.sortingLikedAdsPnl.AutoScroll = true;
            this.sortingLikedAdsPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sortingLikedAdsPnl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sortingLikedAdsPnl.Controls.Add(this.sortLikedAdsBtn);
            this.sortingLikedAdsPnl.Controls.Add(this.sortLikedAdsByCombobox);
            this.sortingLikedAdsPnl.Controls.Add(this.sortLikedAdsByLbl);
            this.sortingLikedAdsPnl.Controls.Add(this.likedAdsPageNrLbl);
            this.sortingLikedAdsPnl.Controls.Add(this.likedAdsPrevPageBtn);
            this.sortingLikedAdsPnl.Controls.Add(this.likedAdsNextPageBtn);
            this.sortingLikedAdsPnl.Controls.Add(this.sortLikedAdsAscDescPnl);
            this.sortingLikedAdsPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sortingLikedAdsPnl.Location = new System.Drawing.Point(0, 273);
            this.sortingLikedAdsPnl.Margin = new System.Windows.Forms.Padding(2);
            this.sortingLikedAdsPnl.MinimumSize = new System.Drawing.Size(660, 53);
            this.sortingLikedAdsPnl.Name = "sortingLikedAdsPnl";
            this.sortingLikedAdsPnl.Size = new System.Drawing.Size(724, 53);
            this.sortingLikedAdsPnl.TabIndex = 2;
            // 
            // sortLikedAdsBtn
            // 
            this.sortLikedAdsBtn.AccessibleDescription = "sort button";
            this.sortLikedAdsBtn.AccessibleName = "sort button";
            this.sortLikedAdsBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortLikedAdsBtn.Enabled = false;
            this.sortLikedAdsBtn.Location = new System.Drawing.Point(356, 15);
            this.sortLikedAdsBtn.Name = "sortLikedAdsBtn";
            this.sortLikedAdsBtn.Size = new System.Drawing.Size(37, 23);
            this.sortLikedAdsBtn.TabIndex = 13;
            this.sortLikedAdsBtn.Text = "sort";
            this.sortLikedAdsBtn.UseVisualStyleBackColor = true;
            this.sortLikedAdsBtn.Click += new System.EventHandler(this.SortLikedAdsBtn_Click);
            // 
            // sortLikedAdsByCombobox
            // 
            this.sortLikedAdsByCombobox.AccessibleDescription = "sort by combo box";
            this.sortLikedAdsByCombobox.AccessibleName = "sort by combo box";
            this.sortLikedAdsByCombobox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortLikedAdsByCombobox.FormattingEnabled = true;
            this.sortLikedAdsByCombobox.Items.AddRange(new object[] {
            "upload date",
            "price",
            "date of purchase",
            "total kilometers driven",
            "original purchase country",
            "next vehicle inspection"});
            this.sortLikedAdsByCombobox.Location = new System.Drawing.Point(465, 15);
            this.sortLikedAdsByCombobox.Margin = new System.Windows.Forms.Padding(2);
            this.sortLikedAdsByCombobox.Name = "sortLikedAdsByCombobox";
            this.sortLikedAdsByCombobox.Size = new System.Drawing.Size(160, 23);
            this.sortLikedAdsByCombobox.TabIndex = 10;
            // 
            // sortLikedAdsByLbl
            // 
            this.sortLikedAdsByLbl.AccessibleDescription = "sort by label";
            this.sortLikedAdsByLbl.AccessibleName = "sort by label";
            this.sortLikedAdsByLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortLikedAdsByLbl.AutoSize = true;
            this.sortLikedAdsByLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sortLikedAdsByLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sortLikedAdsByLbl.Location = new System.Drawing.Point(398, 16);
            this.sortLikedAdsByLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sortLikedAdsByLbl.Name = "sortLikedAdsByLbl";
            this.sortLikedAdsByLbl.Size = new System.Drawing.Size(67, 21);
            this.sortLikedAdsByLbl.TabIndex = 3;
            this.sortLikedAdsByLbl.Text = "Sort by:";
            // 
            // likedAdsPageNrLbl
            // 
            this.likedAdsPageNrLbl.AccessibleDescription = "current page number";
            this.likedAdsPageNrLbl.AccessibleName = "current page number";
            this.likedAdsPageNrLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.likedAdsPageNrLbl.AutoSize = true;
            this.likedAdsPageNrLbl.Location = new System.Drawing.Point(216, 19);
            this.likedAdsPageNrLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.likedAdsPageNrLbl.Name = "likedAdsPageNrLbl";
            this.likedAdsPageNrLbl.Size = new System.Drawing.Size(13, 15);
            this.likedAdsPageNrLbl.TabIndex = 1;
            this.likedAdsPageNrLbl.Text = "1";
            this.likedAdsPageNrLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // likedAdsPrevPageBtn
            // 
            this.likedAdsPrevPageBtn.AccessibleDescription = "button to change page number to a previous one";
            this.likedAdsPrevPageBtn.AccessibleName = "previous page button";
            this.likedAdsPrevPageBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.likedAdsPrevPageBtn.Enabled = false;
            this.likedAdsPrevPageBtn.Location = new System.Drawing.Point(153, 15);
            this.likedAdsPrevPageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.likedAdsPrevPageBtn.Name = "likedAdsPrevPageBtn";
            this.likedAdsPrevPageBtn.Size = new System.Drawing.Size(47, 23);
            this.likedAdsPrevPageBtn.TabIndex = 0;
            this.likedAdsPrevPageBtn.Text = "<";
            this.likedAdsPrevPageBtn.UseVisualStyleBackColor = true;
            // 
            // likedAdsNextPageBtn
            // 
            this.likedAdsNextPageBtn.AccessibleDescription = "button to change page number to next one";
            this.likedAdsNextPageBtn.AccessibleName = "next page button";
            this.likedAdsNextPageBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.likedAdsNextPageBtn.Enabled = false;
            this.likedAdsNextPageBtn.Location = new System.Drawing.Point(243, 15);
            this.likedAdsNextPageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.likedAdsNextPageBtn.Name = "likedAdsNextPageBtn";
            this.likedAdsNextPageBtn.Size = new System.Drawing.Size(47, 23);
            this.likedAdsNextPageBtn.TabIndex = 0;
            this.likedAdsNextPageBtn.Text = ">";
            this.likedAdsNextPageBtn.UseVisualStyleBackColor = true;
            // 
            // sortLikedAdsAscDescPnl
            // 
            this.sortLikedAdsAscDescPnl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortLikedAdsAscDescPnl.AutoSize = true;
            this.sortLikedAdsAscDescPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sortLikedAdsAscDescPnl.BackColor = System.Drawing.Color.Transparent;
            this.sortLikedAdsAscDescPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sortLikedAdsAscDescPnl.Controls.Add(this.sortLikedAdsAscRdBtn);
            this.sortLikedAdsAscDescPnl.Controls.Add(this.sortLikedAdsDescRdBtn);
            this.sortLikedAdsAscDescPnl.Location = new System.Drawing.Point(601, 1);
            this.sortLikedAdsAscDescPnl.Name = "sortLikedAdsAscDescPnl";
            this.sortLikedAdsAscDescPnl.Size = new System.Drawing.Size(123, 52);
            this.sortLikedAdsAscDescPnl.TabIndex = 11;
            // 
            // sortLikedAdsAscRdBtn
            // 
            this.sortLikedAdsAscRdBtn.AccessibleDescription = "sortAscendingRadioButton";
            this.sortLikedAdsAscRdBtn.AccessibleName = "sortAscendingRadioButton";
            this.sortLikedAdsAscRdBtn.AutoSize = true;
            this.sortLikedAdsAscRdBtn.Location = new System.Drawing.Point(33, 14);
            this.sortLikedAdsAscRdBtn.Name = "sortLikedAdsAscRdBtn";
            this.sortLikedAdsAscRdBtn.Size = new System.Drawing.Size(81, 19);
            this.sortLikedAdsAscRdBtn.TabIndex = 1;
            this.sortLikedAdsAscRdBtn.Text = "Ascending";
            this.sortLikedAdsAscRdBtn.UseVisualStyleBackColor = true;
            // 
            // sortLikedAdsDescRdBtn
            // 
            this.sortLikedAdsDescRdBtn.AccessibleDescription = "sortDescendingRadioButton";
            this.sortLikedAdsDescRdBtn.AccessibleName = "sortDescendingRadioButton";
            this.sortLikedAdsDescRdBtn.AutoSize = true;
            this.sortLikedAdsDescRdBtn.Checked = true;
            this.sortLikedAdsDescRdBtn.Location = new System.Drawing.Point(33, 30);
            this.sortLikedAdsDescRdBtn.Name = "sortLikedAdsDescRdBtn";
            this.sortLikedAdsDescRdBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sortLikedAdsDescRdBtn.Size = new System.Drawing.Size(87, 19);
            this.sortLikedAdsDescRdBtn.TabIndex = 2;
            this.sortLikedAdsDescRdBtn.TabStop = true;
            this.sortLikedAdsDescRdBtn.Text = "Descending";
            this.sortLikedAdsDescRdBtn.UseVisualStyleBackColor = true;
            // 
            // uploadedPanel
            // 
            this.uploadedPanel.Controls.Add(this.uploadedAdsPanel);
            this.uploadedPanel.Controls.Add(this.uploadedLabel);
            this.uploadedPanel.Controls.Add(this.sortingUploadedAdsPnl);
            this.uploadedPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uploadedPanel.Location = new System.Drawing.Point(0, 363);
            this.uploadedPanel.Name = "uploadedPanel";
            this.uploadedPanel.Size = new System.Drawing.Size(724, 280);
            this.uploadedPanel.TabIndex = 10;
            // 
            // sortingUploadedAdsPnl
            // 
            this.sortingUploadedAdsPnl.AutoScroll = true;
            this.sortingUploadedAdsPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sortingUploadedAdsPnl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sortingUploadedAdsPnl.Controls.Add(this.sortUploadedAdsBtn);
            this.sortingUploadedAdsPnl.Controls.Add(this.sortUploadedAdsByCombobox);
            this.sortingUploadedAdsPnl.Controls.Add(this.refreshUploadedAdsBtn);
            this.sortingUploadedAdsPnl.Controls.Add(this.sortUploadedAdsByLbl);
            this.sortingUploadedAdsPnl.Controls.Add(this.uploadedAdsPageNrLbl);
            this.sortingUploadedAdsPnl.Controls.Add(this.uploadedAdsPrevPageBtn);
            this.sortingUploadedAdsPnl.Controls.Add(this.uploadedAdsNextPageBtn);
            this.sortingUploadedAdsPnl.Controls.Add(this.sortUploadedAdsAscDescPnl);
            this.sortingUploadedAdsPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sortingUploadedAdsPnl.Location = new System.Drawing.Point(0, 227);
            this.sortingUploadedAdsPnl.Margin = new System.Windows.Forms.Padding(2);
            this.sortingUploadedAdsPnl.MinimumSize = new System.Drawing.Size(660, 53);
            this.sortingUploadedAdsPnl.Name = "sortingUploadedAdsPnl";
            this.sortingUploadedAdsPnl.Size = new System.Drawing.Size(724, 53);
            this.sortingUploadedAdsPnl.TabIndex = 2;
            // 
            // sortUploadedAdsBtn
            // 
            this.sortUploadedAdsBtn.AccessibleDescription = "sort button";
            this.sortUploadedAdsBtn.AccessibleName = "sort button";
            this.sortUploadedAdsBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortUploadedAdsBtn.Enabled = false;
            this.sortUploadedAdsBtn.Location = new System.Drawing.Point(356, 15);
            this.sortUploadedAdsBtn.Name = "sortUploadedAdsBtn";
            this.sortUploadedAdsBtn.Size = new System.Drawing.Size(37, 23);
            this.sortUploadedAdsBtn.TabIndex = 13;
            this.sortUploadedAdsBtn.Text = "sort";
            this.sortUploadedAdsBtn.UseVisualStyleBackColor = true;
            this.sortUploadedAdsBtn.Click += new System.EventHandler(this.SortUploadedAdsBtn_Click);
            // 
            // sortUploadedAdsByCombobox
            // 
            this.sortUploadedAdsByCombobox.AccessibleDescription = "sort by combo box";
            this.sortUploadedAdsByCombobox.AccessibleName = "sort by combo box";
            this.sortUploadedAdsByCombobox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortUploadedAdsByCombobox.FormattingEnabled = true;
            this.sortUploadedAdsByCombobox.Items.AddRange(new object[] {
            "upload date",
            "price",
            "date of purchase",
            "total kilometers driven",
            "original purchase country",
            "next vehicle inspection"});
            this.sortUploadedAdsByCombobox.Location = new System.Drawing.Point(465, 15);
            this.sortUploadedAdsByCombobox.Margin = new System.Windows.Forms.Padding(2);
            this.sortUploadedAdsByCombobox.Name = "sortUploadedAdsByCombobox";
            this.sortUploadedAdsByCombobox.Size = new System.Drawing.Size(160, 23);
            this.sortUploadedAdsByCombobox.TabIndex = 10;
            // 
            // refreshUploadedAdsBtn
            // 
            this.refreshUploadedAdsBtn.AccessibleDescription = "refresh button";
            this.refreshUploadedAdsBtn.AccessibleName = "refresh button";
            this.refreshUploadedAdsBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.refreshUploadedAdsBtn.Enabled = false;
            this.refreshUploadedAdsBtn.Location = new System.Drawing.Point(38, 15);
            this.refreshUploadedAdsBtn.Name = "refreshUploadedAdsBtn";
            this.refreshUploadedAdsBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshUploadedAdsBtn.TabIndex = 12;
            this.refreshUploadedAdsBtn.Text = "refresh";
            this.refreshUploadedAdsBtn.UseVisualStyleBackColor = true;
            this.refreshUploadedAdsBtn.Click += new System.EventHandler(this.RefreshUploadedAdsBtn_Click);
            // 
            // sortUploadedAdsByLbl
            // 
            this.sortUploadedAdsByLbl.AccessibleDescription = "sort by label";
            this.sortUploadedAdsByLbl.AccessibleName = "sort by label";
            this.sortUploadedAdsByLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortUploadedAdsByLbl.AutoSize = true;
            this.sortUploadedAdsByLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sortUploadedAdsByLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sortUploadedAdsByLbl.Location = new System.Drawing.Point(398, 16);
            this.sortUploadedAdsByLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sortUploadedAdsByLbl.Name = "sortUploadedAdsByLbl";
            this.sortUploadedAdsByLbl.Size = new System.Drawing.Size(67, 21);
            this.sortUploadedAdsByLbl.TabIndex = 3;
            this.sortUploadedAdsByLbl.Text = "Sort by:";
            // 
            // uploadedAdsPageNrLbl
            // 
            this.uploadedAdsPageNrLbl.AccessibleDescription = "current page number";
            this.uploadedAdsPageNrLbl.AccessibleName = "current page number";
            this.uploadedAdsPageNrLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.uploadedAdsPageNrLbl.AutoSize = true;
            this.uploadedAdsPageNrLbl.Location = new System.Drawing.Point(216, 19);
            this.uploadedAdsPageNrLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uploadedAdsPageNrLbl.Name = "uploadedAdsPageNrLbl";
            this.uploadedAdsPageNrLbl.Size = new System.Drawing.Size(13, 15);
            this.uploadedAdsPageNrLbl.TabIndex = 1;
            this.uploadedAdsPageNrLbl.Text = "1";
            this.uploadedAdsPageNrLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uploadedAdsPrevPageBtn
            // 
            this.uploadedAdsPrevPageBtn.AccessibleDescription = "button to change page number to a previous one";
            this.uploadedAdsPrevPageBtn.AccessibleName = "previous page button";
            this.uploadedAdsPrevPageBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.uploadedAdsPrevPageBtn.Enabled = false;
            this.uploadedAdsPrevPageBtn.Location = new System.Drawing.Point(153, 15);
            this.uploadedAdsPrevPageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.uploadedAdsPrevPageBtn.Name = "uploadedAdsPrevPageBtn";
            this.uploadedAdsPrevPageBtn.Size = new System.Drawing.Size(47, 23);
            this.uploadedAdsPrevPageBtn.TabIndex = 0;
            this.uploadedAdsPrevPageBtn.Text = "<";
            this.uploadedAdsPrevPageBtn.UseVisualStyleBackColor = true;
            // 
            // uploadedAdsNextPageBtn
            // 
            this.uploadedAdsNextPageBtn.AccessibleDescription = "button to change page number to next one";
            this.uploadedAdsNextPageBtn.AccessibleName = "next page button";
            this.uploadedAdsNextPageBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.uploadedAdsNextPageBtn.Enabled = false;
            this.uploadedAdsNextPageBtn.Location = new System.Drawing.Point(243, 15);
            this.uploadedAdsNextPageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.uploadedAdsNextPageBtn.Name = "uploadedAdsNextPageBtn";
            this.uploadedAdsNextPageBtn.Size = new System.Drawing.Size(47, 23);
            this.uploadedAdsNextPageBtn.TabIndex = 0;
            this.uploadedAdsNextPageBtn.Text = ">";
            this.uploadedAdsNextPageBtn.UseVisualStyleBackColor = true;
            // 
            // sortUploadedAdsAscDescPnl
            // 
            this.sortUploadedAdsAscDescPnl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortUploadedAdsAscDescPnl.AutoSize = true;
            this.sortUploadedAdsAscDescPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sortUploadedAdsAscDescPnl.BackColor = System.Drawing.Color.Transparent;
            this.sortUploadedAdsAscDescPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sortUploadedAdsAscDescPnl.Controls.Add(this.sortUploadedAdsAscRdBtn);
            this.sortUploadedAdsAscDescPnl.Controls.Add(this.sortUploadedAdsDescRdBtn);
            this.sortUploadedAdsAscDescPnl.Location = new System.Drawing.Point(601, 1);
            this.sortUploadedAdsAscDescPnl.Name = "sortUploadedAdsAscDescPnl";
            this.sortUploadedAdsAscDescPnl.Size = new System.Drawing.Size(123, 52);
            this.sortUploadedAdsAscDescPnl.TabIndex = 11;
            // 
            // sortUploadedAdsAscRdBtn
            // 
            this.sortUploadedAdsAscRdBtn.AccessibleDescription = "sortAscendingRadioButton";
            this.sortUploadedAdsAscRdBtn.AccessibleName = "sortAscendingRadioButton";
            this.sortUploadedAdsAscRdBtn.AutoSize = true;
            this.sortUploadedAdsAscRdBtn.Location = new System.Drawing.Point(33, 14);
            this.sortUploadedAdsAscRdBtn.Name = "sortUploadedAdsAscRdBtn";
            this.sortUploadedAdsAscRdBtn.Size = new System.Drawing.Size(81, 19);
            this.sortUploadedAdsAscRdBtn.TabIndex = 1;
            this.sortUploadedAdsAscRdBtn.Text = "Ascending";
            this.sortUploadedAdsAscRdBtn.UseVisualStyleBackColor = true;
            // 
            // sortUploadedAdsDescRdBtn
            // 
            this.sortUploadedAdsDescRdBtn.AccessibleDescription = "sortDescendingRadioButton";
            this.sortUploadedAdsDescRdBtn.AccessibleName = "sortDescendingRadioButton";
            this.sortUploadedAdsDescRdBtn.AutoSize = true;
            this.sortUploadedAdsDescRdBtn.Checked = true;
            this.sortUploadedAdsDescRdBtn.Location = new System.Drawing.Point(33, 30);
            this.sortUploadedAdsDescRdBtn.Name = "sortUploadedAdsDescRdBtn";
            this.sortUploadedAdsDescRdBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sortUploadedAdsDescRdBtn.Size = new System.Drawing.Size(87, 19);
            this.sortUploadedAdsDescRdBtn.TabIndex = 2;
            this.sortUploadedAdsDescRdBtn.TabStop = true;
            this.sortUploadedAdsDescRdBtn.Text = "Descending";
            this.sortUploadedAdsDescRdBtn.UseVisualStyleBackColor = true;
            // 
            // ProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.likedPanel);
            this.Controls.Add(this.uploadedPanel);
            this.Controls.Add(this.topPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProfilePage";
            this.Size = new System.Drawing.Size(724, 643);
            this.VisibleChanged += new System.EventHandler(this.ProfilePage_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.likedPanel.ResumeLayout(false);
            this.sortingLikedAdsPnl.ResumeLayout(false);
            this.sortingLikedAdsPnl.PerformLayout();
            this.sortLikedAdsAscDescPnl.ResumeLayout(false);
            this.sortLikedAdsAscDescPnl.PerformLayout();
            this.uploadedPanel.ResumeLayout(false);
            this.sortingUploadedAdsPnl.ResumeLayout(false);
            this.sortingUploadedAdsPnl.PerformLayout();
            this.sortUploadedAdsAscDescPnl.ResumeLayout(false);
            this.sortUploadedAdsAscDescPnl.PerformLayout();
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
        private System.Windows.Forms.Panel likedPanel;
        private System.Windows.Forms.Panel uploadedPanel;
        private System.Windows.Forms.Panel sortingLikedAdsPnl;
        private System.Windows.Forms.Button sortLikedAdsBtn;
        private System.Windows.Forms.ComboBox sortLikedAdsByCombobox;
        private System.Windows.Forms.Label sortLikedAdsByLbl;
        private System.Windows.Forms.Label likedAdsPageNrLbl;
        private System.Windows.Forms.Button likedAdsPrevPageBtn;
        private System.Windows.Forms.Button likedAdsNextPageBtn;
        private System.Windows.Forms.Panel sortLikedAdsAscDescPnl;
        private System.Windows.Forms.RadioButton sortLikedAdsAscRdBtn;
        private System.Windows.Forms.RadioButton sortLikedAdsDescRdBtn;
        private System.Windows.Forms.Panel sortingUploadedAdsPnl;
        private System.Windows.Forms.Button sortUploadedAdsBtn;
        private System.Windows.Forms.ComboBox sortUploadedAdsByCombobox;
        private System.Windows.Forms.Button refreshUploadedAdsBtn;
        private System.Windows.Forms.Label sortUploadedAdsByLbl;
        private System.Windows.Forms.Label uploadedAdsPageNrLbl;
        private System.Windows.Forms.Button uploadedAdsPrevPageBtn;
        private System.Windows.Forms.Button uploadedAdsNextPageBtn;
        private System.Windows.Forms.Panel sortUploadedAdsAscDescPnl;
        private System.Windows.Forms.RadioButton sortUploadedAdsAscRdBtn;
        private System.Windows.Forms.RadioButton sortUploadedAdsDescRdBtn;
    }
}
