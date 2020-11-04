namespace CarEngine
{
    partial class CarAdMinimal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarAdMinimal));
            this.carImage = new System.Windows.Forms.PictureBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.additionalInfo = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.carBrandModelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.carImage)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // carImage
            // 
            this.carImage.BackColor = System.Drawing.Color.Transparent;
            this.carImage.Image = ((System.Drawing.Image)(resources.GetObject("carImage.Image")));
            this.carImage.Location = new System.Drawing.Point(0, 41);
            this.carImage.Name = "carImage";
            this.carImage.Size = new System.Drawing.Size(208, 140);
            this.carImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carImage.TabIndex = 1;
            this.carImage.TabStop = false;
            this.carImage.Click += new System.EventHandler(this.CarImage_Click);
            // 
            // priceLabel
            // 
            this.priceLabel.BackColor = System.Drawing.Color.Transparent;
            this.priceLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.priceLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priceLabel.Location = new System.Drawing.Point(0, 187);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(208, 33);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "13 500€";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.priceLabel.Click += new System.EventHandler(this.Price_Click);
            // 
            // additionalInfo
            // 
            this.additionalInfo.BackColor = System.Drawing.Color.Transparent;
            this.additionalInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.additionalInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.additionalInfo.Location = new System.Drawing.Point(0, 220);
            this.additionalInfo.Name = "additionalInfo";
            this.additionalInfo.Size = new System.Drawing.Size(208, 44);
            this.additionalInfo.TabIndex = 2;
            this.additionalInfo.Text = "2.2l V8 \"Vairavo kunigas\"";
            this.additionalInfo.Click += new System.EventHandler(this.AdditionInfo_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Controls.Add(this.carBrandModelBtn);
            this.mainPanel.Controls.Add(this.priceLabel);
            this.mainPanel.Controls.Add(this.carImage);
            this.mainPanel.Controls.Add(this.additionalInfo);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(208, 264);
            this.mainPanel.TabIndex = 1;
            // 
            // carBrandModelBtn
            // 
            this.carBrandModelBtn.AutoEllipsis = true;
            this.carBrandModelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.carBrandModelBtn.FlatAppearance.BorderSize = 0;
            this.carBrandModelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.carBrandModelBtn.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.carBrandModelBtn.Location = new System.Drawing.Point(0, 0);
            this.carBrandModelBtn.Name = "carBrandModelBtn";
            this.carBrandModelBtn.Size = new System.Drawing.Size(208, 40);
            this.carBrandModelBtn.TabIndex = 3;
            this.carBrandModelBtn.Text = "Volvo V60";
            this.carBrandModelBtn.UseVisualStyleBackColor = true;
            this.carBrandModelBtn.Click += new System.EventHandler(this.CarModel_Click);
            // 
            // CarAdMinimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "CarAdMinimal";
            this.Size = new System.Drawing.Size(208, 264);
            ((System.ComponentModel.ISupportInitialize)(this.carImage)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox carImage;
        private System.Windows.Forms.Label additionalInfo;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button carBrandModelBtn;
    }
}
