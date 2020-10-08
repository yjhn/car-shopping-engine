namespace CarEngine.Pages
{
    partial class UploadPage
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
            this.mainTitleLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.vehicleNameTextBox = new System.Windows.Forms.TextBox();
            this.vehiclePriceTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.uploadLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uploadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTitleLabel
            // 
            this.mainTitleLabel.AutoSize = true;
            this.mainTitleLabel.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainTitleLabel.Location = new System.Drawing.Point(211, 53);
            this.mainTitleLabel.Name = "mainTitleLabel";
            this.mainTitleLabel.Size = new System.Drawing.Size(602, 57);
            this.mainTitleLabel.TabIndex = 0;
            this.mainTitleLabel.Text = "Upload your own vehicle ad";
            this.mainTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(80, 180);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(327, 45);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name of the vehicle:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.priceLabel.Location = new System.Drawing.Point(304, 239);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(103, 45);
            this.priceLabel.TabIndex = 1;
            this.priceLabel.Text = "Price:";
            // 
            // vehicleNameTextBox
            // 
            this.vehicleNameTextBox.Location = new System.Drawing.Point(450, 193);
            this.vehicleNameTextBox.Name = "vehicleNameTextBox";
            this.vehicleNameTextBox.Size = new System.Drawing.Size(400, 31);
            this.vehicleNameTextBox.TabIndex = 2;
            // 
            // vehiclePriceTextBox
            // 
            this.vehiclePriceTextBox.Location = new System.Drawing.Point(450, 252);
            this.vehiclePriceTextBox.Name = "vehiclePriceTextBox";
            this.vehiclePriceTextBox.Size = new System.Drawing.Size(175, 31);
            this.vehiclePriceTextBox.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(282, 354);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(112, 34);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // uploadLabel
            // 
            this.uploadLabel.AutoSize = true;
            this.uploadLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadLabel.Location = new System.Drawing.Point(129, 293);
            this.uploadLabel.Name = "uploadLabel";
            this.uploadLabel.Size = new System.Drawing.Size(278, 45);
            this.uploadLabel.TabIndex = 1;
            this.uploadLabel.Text = "Upload a picture:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(450, 312);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // uploadButton
            // 
            this.uploadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadButton.Location = new System.Drawing.Point(380, 518);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(248, 57);
            this.uploadButton.TabIndex = 5;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            // 
            // UploadPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uploadLabel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.vehiclePriceTextBox);
            this.Controls.Add(this.vehicleNameTextBox);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.mainTitleLabel);
            this.Name = "UploadPage";
            this.Size = new System.Drawing.Size(1026, 663);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainTitleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox vehicleNameTextBox;
        private System.Windows.Forms.TextBox vehiclePriceTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label uploadLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button uploadButton;
    }
}
