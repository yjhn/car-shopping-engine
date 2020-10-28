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
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(700, 555);
            this.mainPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pageNumberLabel);
            this.panel1.Controls.Add(this.previousPageButton);
            this.panel1.Controls.Add(this.nextPageButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 35);
            this.panel1.TabIndex = 2;
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.AccessibleDescription = "current page number";
            this.pageNumberLabel.AccessibleName = "current page number";
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Location = new System.Drawing.Point(323, 10);
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
            this.previousPageButton.Enabled = false;
            this.previousPageButton.Location = new System.Drawing.Point(260, 7);
            this.previousPageButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.nextPageButton.Location = new System.Drawing.Point(357, 7);
            this.nextPageButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BrowsePage";
            this.Size = new System.Drawing.Size(700, 555);
            this.Load += new System.EventHandler(this.BrowsePage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Label pageNumberLabel;
        private System.Windows.Forms.Button previousPageButton;
    }
}
