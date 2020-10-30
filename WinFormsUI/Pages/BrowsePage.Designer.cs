namespace CarEngine
{
    partial class BrowsePage
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
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sortResultsByCombobox = new System.Windows.Forms.ComboBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.sortAscDescPanel = new System.Windows.Forms.Panel();
            this.sortAscRadioButton = new System.Windows.Forms.RadioButton();
            this.sortDescRadioButton = new System.Windows.Forms.RadioButton();
            this.sortByLabel = new System.Windows.Forms.Label();
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.sortAscDescPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(700, 496);
            this.mainPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.sortResultsByCombobox);
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.sortAscDescPanel);
            this.panel1.Controls.Add(this.sortByLabel);
            this.panel1.Controls.Add(this.pageNumberLabel);
            this.panel1.Controls.Add(this.previousPageButton);
            this.panel1.Controls.Add(this.nextPageButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.MinimumSize = new System.Drawing.Size(660, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 55);
            this.panel1.TabIndex = 2;
            // 
            // sortResultsByCombobox
            // 
            this.sortResultsByCombobox.AccessibleDescription = "sort by combo box";
            this.sortResultsByCombobox.AccessibleName = "sort by combo box";
            this.sortResultsByCombobox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortResultsByCombobox.FormattingEnabled = true;
            this.sortResultsByCombobox.Items.AddRange(new object[] {
            "upload date",
            "price",
            "date of purchase",
            "total kilometers driven",
            "original purchase country"});
            this.sortResultsByCombobox.Location = new System.Drawing.Point(445, 17);
            this.sortResultsByCombobox.Margin = new System.Windows.Forms.Padding(2);
            this.sortResultsByCombobox.Name = "sortResultsByCombobox";
            this.sortResultsByCombobox.Size = new System.Drawing.Size(160, 23);
            this.sortResultsByCombobox.TabIndex = 10;
            this.sortResultsByCombobox.SelectedIndexChanged += new System.EventHandler(this.sortingChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.AccessibleDescription = "refresh button";
            this.refreshButton.AccessibleName = "refresh button";
            this.refreshButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.refreshButton.Location = new System.Drawing.Point(18, 14);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 12;
            this.refreshButton.Text = "refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // sortAscDescPanel
            // 
            this.sortAscDescPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortAscDescPanel.AutoSize = true;
            this.sortAscDescPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sortAscDescPanel.BackColor = System.Drawing.Color.Transparent;
            this.sortAscDescPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sortAscDescPanel.Controls.Add(this.sortAscRadioButton);
            this.sortAscDescPanel.Controls.Add(this.sortDescRadioButton);
            this.sortAscDescPanel.Location = new System.Drawing.Point(577, 0);
            this.sortAscDescPanel.Name = "sortAscDescPanel";
            this.sortAscDescPanel.Size = new System.Drawing.Size(123, 52);
            this.sortAscDescPanel.TabIndex = 11;
            this.sortAscDescPanel.Click += new System.EventHandler(this.sortingChanged);
            // 
            // sortAscRadioButton
            // 
            this.sortAscRadioButton.AccessibleDescription = "sortAscendingRadioButton";
            this.sortAscRadioButton.AccessibleName = "sortAscendingRadioButton";
            this.sortAscRadioButton.AutoSize = true;
            this.sortAscRadioButton.Location = new System.Drawing.Point(33, 14);
            this.sortAscRadioButton.Name = "sortAscRadioButton";
            this.sortAscRadioButton.Size = new System.Drawing.Size(81, 19);
            this.sortAscRadioButton.TabIndex = 1;
            this.sortAscRadioButton.Text = "Ascending";
            this.sortAscRadioButton.UseVisualStyleBackColor = true;
            this.sortAscRadioButton.CheckedChanged += new System.EventHandler(this.sortingChanged);
            // 
            // sortDescRadioButton
            // 
            this.sortDescRadioButton.AccessibleDescription = "sortDescendingRadioButton";
            this.sortDescRadioButton.AccessibleName = "sortDescendingRadioButton";
            this.sortDescRadioButton.AutoSize = true;
            this.sortDescRadioButton.Checked = true;
            this.sortDescRadioButton.Location = new System.Drawing.Point(33, 30);
            this.sortDescRadioButton.Name = "sortDescRadioButton";
            this.sortDescRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sortDescRadioButton.Size = new System.Drawing.Size(87, 19);
            this.sortDescRadioButton.TabIndex = 2;
            this.sortDescRadioButton.TabStop = true;
            this.sortDescRadioButton.Text = "Descending";
            this.sortDescRadioButton.UseVisualStyleBackColor = true;
            // 
            // sortByLabel
            // 
            this.sortByLabel.AccessibleDescription = "sort by label";
            this.sortByLabel.AccessibleName = "sort by label";
            this.sortByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sortByLabel.AutoSize = true;
            this.sortByLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sortByLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sortByLabel.Location = new System.Drawing.Point(374, 17);
            this.sortByLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sortByLabel.Name = "sortByLabel";
            this.sortByLabel.Size = new System.Drawing.Size(67, 21);
            this.sortByLabel.TabIndex = 3;
            this.sortByLabel.Text = "Sort by:";
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.AccessibleDescription = "current page number";
            this.pageNumberLabel.AccessibleName = "current page number";
            this.pageNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Location = new System.Drawing.Point(234, 17);
            this.pageNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(13, 15);
            this.pageNumberLabel.TabIndex = 1;
            this.pageNumberLabel.Text = "1";
            this.pageNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previousPageButton
            // 
            this.previousPageButton.AccessibleDescription = "button to change page number to a previous one";
            this.previousPageButton.AccessibleName = "previous page button";
            this.previousPageButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.previousPageButton.Enabled = false;
            this.previousPageButton.Location = new System.Drawing.Point(171, 14);
            this.previousPageButton.Margin = new System.Windows.Forms.Padding(2);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(47, 20);
            this.previousPageButton.TabIndex = 0;
            this.previousPageButton.Text = "<";
            this.previousPageButton.UseVisualStyleBackColor = true;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.AccessibleDescription = "button to change page number to next one";
            this.nextPageButton.AccessibleName = "next page button";
            this.nextPageButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nextPageButton.Location = new System.Drawing.Point(261, 14);
            this.nextPageButton.Margin = new System.Windows.Forms.Padding(2);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(47, 20);
            this.nextPageButton.TabIndex = 0;
            this.nextPageButton.Text = ">";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // BrowsePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(660, 555);
            this.Name = "BrowsePage";
            this.Size = new System.Drawing.Size(700, 555);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sortAscDescPanel.ResumeLayout(false);
            this.sortAscDescPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Label pageNumberLabel;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Panel sortAscDescPanel;
        private System.Windows.Forms.RadioButton sortAscRadioButton;
        private System.Windows.Forms.RadioButton sortDescRadioButton;
        private System.Windows.Forms.ComboBox sortResultsByCombobox;
        private System.Windows.Forms.Label sortByLabel;
        private System.Windows.Forms.Button refreshButton;
    }
}
