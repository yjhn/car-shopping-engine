namespace CarEngine.Pages
{
    partial class SearchResultsPage_old
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.sortResultsAscDescPanel = new System.Windows.Forms.Panel();
            this.sortResultsAscRadioBtn = new System.Windows.Forms.RadioButton();
            this.sortResultsDescRadioBtn = new System.Windows.Forms.RadioButton();
            this.sortResultsByCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.goBackButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.sortResultsAscDescPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topPanel.Controls.Add(this.sortResultsAscDescPanel);
            this.topPanel.Controls.Add(this.sortResultsByCombobox);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.goBackButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(898, 56);
            this.topPanel.TabIndex = 0;
            this.topPanel.TabStop = true;
            // 
            // sortResultsAscDescPanel
            // 
            this.sortResultsAscDescPanel.AutoSize = true;
            this.sortResultsAscDescPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sortResultsAscDescPanel.BackColor = System.Drawing.Color.Transparent;
            this.sortResultsAscDescPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sortResultsAscDescPanel.Controls.Add(this.sortResultsAscRadioBtn);
            this.sortResultsAscDescPanel.Controls.Add(this.sortResultsDescRadioBtn);
            this.sortResultsAscDescPanel.Location = new System.Drawing.Point(656, 0);
            this.sortResultsAscDescPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sortResultsAscDescPanel.Name = "sortResultsAscDescPanel";
            this.sortResultsAscDescPanel.Size = new System.Drawing.Size(250, 47);
            this.sortResultsAscDescPanel.TabIndex = 11;
            // 
            // sortResultsAscRadioBtn
            // 
            this.sortResultsAscRadioBtn.AccessibleDescription = "sortAscendingRadioButton";
            this.sortResultsAscRadioBtn.AccessibleName = "sortAscendingRadioButton";
            this.sortResultsAscRadioBtn.AutoSize = true;
            this.sortResultsAscRadioBtn.Location = new System.Drawing.Point(38, 19);
            this.sortResultsAscRadioBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sortResultsAscRadioBtn.Name = "sortResultsAscRadioBtn";
            this.sortResultsAscRadioBtn.Size = new System.Drawing.Size(99, 24);
            this.sortResultsAscRadioBtn.TabIndex = 1;
            this.sortResultsAscRadioBtn.Text = "Ascending";
            this.sortResultsAscRadioBtn.UseVisualStyleBackColor = true;
            // 
            // sortResultsDescRadioBtn
            // 
            this.sortResultsDescRadioBtn.AccessibleDescription = "sortDescendingRadioButton";
            this.sortResultsDescRadioBtn.AccessibleName = "sortDescendingRadioButton";
            this.sortResultsDescRadioBtn.AutoSize = true;
            this.sortResultsDescRadioBtn.Checked = true;
            this.sortResultsDescRadioBtn.Location = new System.Drawing.Point(139, 19);
            this.sortResultsDescRadioBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sortResultsDescRadioBtn.Name = "sortResultsDescRadioBtn";
            this.sortResultsDescRadioBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sortResultsDescRadioBtn.Size = new System.Drawing.Size(108, 24);
            this.sortResultsDescRadioBtn.TabIndex = 2;
            this.sortResultsDescRadioBtn.TabStop = true;
            this.sortResultsDescRadioBtn.Text = "Descending";
            this.sortResultsDescRadioBtn.UseVisualStyleBackColor = true;
            // 
            // sortResultsByCombobox
            // 
            this.sortResultsByCombobox.AccessibleDescription = "sort by combo box";
            this.sortResultsByCombobox.AccessibleName = "sort by combo box";
            this.sortResultsByCombobox.FormattingEnabled = true;
            this.sortResultsByCombobox.Items.AddRange(new object[] {
            "upload date",
            "price",
            "date of purchase",
            "total kilometers driven",
            "original purchase country"});
            this.sortResultsByCombobox.Location = new System.Drawing.Point(469, 15);
            this.sortResultsByCombobox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sortResultsByCombobox.Name = "sortResultsByCombobox";
            this.sortResultsByCombobox.Size = new System.Drawing.Size(182, 28);
            this.sortResultsByCombobox.TabIndex = 10;
            this.sortResultsByCombobox.SelectedIndexChanged += new System.EventHandler(this.sortResultsByCombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "sort by label";
            this.label1.AccessibleName = "sort by label";
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(387, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sort by:";
            // 
            // goBackButton
            // 
            this.goBackButton.AccessibleDescription = "go back button";
            this.goBackButton.AccessibleName = "go back button";
            this.goBackButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.goBackButton.Location = new System.Drawing.Point(0, 0);
            this.goBackButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(93, 56);
            this.goBackButton.TabIndex = 1;
            this.goBackButton.Text = "go back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // SearchResultsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.topPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchResultsPage";
            this.Size = new System.Drawing.Size(898, 617);
            this.VisibleChanged += new System.EventHandler(this.SearchResultsPage_VisibleChanged);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.sortResultsAscDescPanel.ResumeLayout(false);
            this.sortResultsAscDescPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.ComboBox sortResultsByCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel sortResultsAscDescPanel;
        private System.Windows.Forms.RadioButton sortResultsAscRadioBtn;
        private System.Windows.Forms.RadioButton sortResultsDescRadioBtn;
    }
}
