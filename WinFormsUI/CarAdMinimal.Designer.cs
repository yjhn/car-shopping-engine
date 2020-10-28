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
            this.vehicleAdPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.carModel = new System.Windows.Forms.Label();
            this.carImage = new System.Windows.Forms.PictureBox();
            this.price = new System.Windows.Forms.Label();
            this.additionInfo = new System.Windows.Forms.Label();
            this.vehicleAdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carImage)).BeginInit();
            this.SuspendLayout();
            // 
            // vehicleAdPanel
            // 
            this.vehicleAdPanel.Controls.Add(this.carModel);
            this.vehicleAdPanel.Controls.Add(this.carImage);
            this.vehicleAdPanel.Controls.Add(this.price);
            this.vehicleAdPanel.Controls.Add(this.additionInfo);
            this.vehicleAdPanel.Location = new System.Drawing.Point(0, 0);
            this.vehicleAdPanel.Name = "vehicleAdPanel";
            this.vehicleAdPanel.Size = new System.Drawing.Size(209, 264);
            this.vehicleAdPanel.TabIndex = 0;
            // 
            // carModel
            // 
            this.carModel.BackColor = System.Drawing.Color.Transparent;
            this.carModel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.carModel.Location = new System.Drawing.Point(3, 0);
            this.carModel.Name = "carModel";
            this.carModel.Size = new System.Drawing.Size(206, 41);
            this.carModel.TabIndex = 0;
            this.carModel.Text = "Volvo V60";
            this.carModel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.carModel.Click += new System.EventHandler(this.carModel_Click);
            // 
            // carImage
            // 
            this.carImage.BackColor = System.Drawing.Color.Transparent;
            this.carImage.Image = ((System.Drawing.Image)(resources.GetObject("carImage.Image")));
            this.carImage.Location = new System.Drawing.Point(3, 44);
            this.carImage.Name = "carImage";
            this.carImage.Size = new System.Drawing.Size(206, 140);
            this.carImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carImage.TabIndex = 1;
            this.carImage.TabStop = false;
            this.carImage.Click += new System.EventHandler(this.carImage_Click);
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.price.Location = new System.Drawing.Point(3, 187);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(206, 33);
            this.price.TabIndex = 2;
            this.price.Text = "13 500€";
            this.price.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.price.Click += new System.EventHandler(this.price_Click);
            // 
            // additionInfo
            // 
            this.additionInfo.BackColor = System.Drawing.Color.Transparent;
            this.additionInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.additionInfo.Location = new System.Drawing.Point(3, 220);
            this.additionInfo.Name = "additionInfo";
            this.additionInfo.Size = new System.Drawing.Size(206, 44);
            this.additionInfo.TabIndex = 2;
            this.additionInfo.Text = "2.2l V8 \"Vairavo kunigas\"";
            this.additionInfo.Click += new System.EventHandler(this.additionInfo_Click);
            // 
            // CarAdMinimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vehicleAdPanel);
            this.Name = "CarAdMinimal";
            this.Size = new System.Drawing.Size(209, 264);
            this.vehicleAdPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel vehicleAdPanel;
        private System.Windows.Forms.Label carModel;
        private System.Windows.Forms.PictureBox carImage;
        private System.Windows.Forms.Label additionInfo;
        private System.Windows.Forms.Label price;
    }
}
