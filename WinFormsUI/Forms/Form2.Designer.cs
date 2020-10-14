namespace Test1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.favoritesButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.favoritePage1 = new CarEngine.Pages.FavoritePage();
            this.uploadPage1 = new CarEngine.Pages.UploadPage();
            this.searchPage1 = new CarEngine.SearchPage();
            this.browsePage1 = new CarEngine.BrowsePage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.favoritesButton);
            this.panel1.Controls.Add(this.uploadButton);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.browseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 520);
            this.panel1.TabIndex = 0;
            // 
            // favoritesButton
            // 
            this.favoritesButton.BackColor = System.Drawing.Color.Transparent;
            this.favoritesButton.FlatAppearance.BorderSize = 0;
            this.favoritesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.favoritesButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.favoritesButton.ForeColor = System.Drawing.Color.Transparent;
            this.favoritesButton.Location = new System.Drawing.Point(0, 413);
            this.favoritesButton.Margin = new System.Windows.Forms.Padding(2);
            this.favoritesButton.Name = "favoritesButton";
            this.favoritesButton.Size = new System.Drawing.Size(144, 107);
            this.favoritesButton.TabIndex = 0;
            this.favoritesButton.Text = "favorites";
            this.favoritesButton.UseVisualStyleBackColor = false;
            this.favoritesButton.Click += new System.EventHandler(this.favoritesButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.Transparent;
            this.uploadButton.FlatAppearance.BorderSize = 0;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadButton.ForeColor = System.Drawing.Color.Transparent;
            this.uploadButton.Location = new System.Drawing.Point(0, 301);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(2);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(144, 107);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "upload";
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Transparent;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchButton.ForeColor = System.Drawing.Color.Transparent;
            this.searchButton.Location = new System.Drawing.Point(0, 189);
            this.searchButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(144, 107);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.Transparent;
            this.browseButton.FlatAppearance.BorderSize = 0;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.browseButton.ForeColor = System.Drawing.Color.Transparent;
            this.browseButton.Location = new System.Drawing.Point(0, 77);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(144, 107);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "browse";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(144, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 35);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.favoritePage1);
            this.panel3.Controls.Add(this.uploadPage1);
            this.panel3.Controls.Add(this.searchPage1);
            this.panel3.Controls.Add(this.browsePage1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(144, 35);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(821, 485);
            this.panel3.TabIndex = 2;
            // 
            // favoritePage1
            // 
            this.favoritePage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favoritePage1.Location = new System.Drawing.Point(0, 0);
            this.favoritePage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.favoritePage1.Name = "favoritePage1";
            this.favoritePage1.Size = new System.Drawing.Size(821, 485);
            this.favoritePage1.TabIndex = 3;
            // 
            // uploadPage1
            // 
            this.uploadPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadPage1.Location = new System.Drawing.Point(0, 0);
            this.uploadPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uploadPage1.Name = "uploadPage1";
            this.uploadPage1.Size = new System.Drawing.Size(821, 485);
            this.uploadPage1.TabIndex = 2;
            // 
            // searchPage1
            // 
            this.searchPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPage1.Location = new System.Drawing.Point(0, 0);
            this.searchPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchPage1.Name = "searchPage1";
            this.searchPage1.Size = new System.Drawing.Size(821, 485);
            this.searchPage1.TabIndex = 1;
            // 
            // browsePage1
            // 
            this.browsePage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browsePage1.Location = new System.Drawing.Point(0, 0);
            this.browsePage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.browsePage1.Name = "browsePage1";
            this.browsePage1.Size = new System.Drawing.Size(821, 485);
            this.browsePage1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(965, 520);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button favoritesButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private CarEngine.SearchPage searchPage1;
        private CarEngine.BrowsePage browsePage1;
        private CarEngine.Pages.FavoritePage favoritePage1;
        private CarEngine.Pages.UploadPage uploadPage1;
    }
}