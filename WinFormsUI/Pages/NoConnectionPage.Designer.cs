namespace CarEngine
{
    partial class NoConnectionPage
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
            this.networkErrorMessage = new System.Windows.Forms.Label();
            this.retryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // networkErrorMessage
            // 
            this.networkErrorMessage.AccessibleDescription = "network error message";
            this.networkErrorMessage.AccessibleName = "network error message";
            this.networkErrorMessage.AutoSize = true;
            this.networkErrorMessage.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.networkErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.networkErrorMessage.Location = new System.Drawing.Point(108, 230);
            this.networkErrorMessage.Name = "networkErrorMessage";
            this.networkErrorMessage.Size = new System.Drawing.Size(571, 65);
            this.networkErrorMessage.TabIndex = 4;
            this.networkErrorMessage.Text = "No connection to server";
            this.networkErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // retryButton
            // 
            this.retryButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.retryButton.Location = new System.Drawing.Point(320, 308);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(117, 60);
            this.retryButton.TabIndex = 5;
            this.retryButton.Text = "retry";
            this.retryButton.UseVisualStyleBackColor = true;
            this.retryButton.Click += new System.EventHandler(this.RetryButton_Click);
            // 
            // NoConnectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.retryButton);
            this.Controls.Add(this.networkErrorMessage);
            this.Name = "NoConnectionPage";
            this.Size = new System.Drawing.Size(769, 596);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label networkErrorMessage;
        private System.Windows.Forms.Button retryButton;
    }
}
