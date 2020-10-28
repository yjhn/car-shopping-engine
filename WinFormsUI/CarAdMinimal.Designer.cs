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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.carModel = new System.Windows.Forms.Label();
            this.carImage = new System.Windows.Forms.PictureBox();
            this.price = new System.Windows.Forms.Label();
            this.additionInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carImage)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.carModel);
            this.flowLayoutPanel1.Controls.Add(this.carImage);
            this.flowLayoutPanel1.Controls.Add(this.price);
            this.flowLayoutPanel1.Controls.Add(this.additionInfo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 352);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // carModel
            // 
            this.carModel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.carModel.Location = new System.Drawing.Point(3, 0);
            this.carModel.Name = "carModel";
            this.carModel.Size = new System.Drawing.Size(235, 55);
            this.carModel.TabIndex = 0;
            this.carModel.Text = "Volvo V60";
            this.carModel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // carImage
            // 
            this.carImage.Image = ((System.Drawing.Image)(resources.GetObject("carImage.Image")));
            this.carImage.Location = new System.Drawing.Point(3, 59);
            this.carImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.carImage.Name = "carImage";
            this.carImage.Size = new System.Drawing.Size(235, 187);
            this.carImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carImage.TabIndex = 1;
            this.carImage.TabStop = false;
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.SystemColors.Control;
            this.price.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.price.Location = new System.Drawing.Point(3, 250);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(235, 44);
            this.price.TabIndex = 2;
            this.price.Text = "13 500€";
            this.price.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // additionInfo
            // 
            this.additionInfo.BackColor = System.Drawing.SystemColors.Control;
            this.additionInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.additionInfo.Location = new System.Drawing.Point(3, 294);
            this.additionInfo.Name = "additionInfo";
            this.additionInfo.Size = new System.Drawing.Size(235, 59);
            this.additionInfo.TabIndex = 2;
            this.additionInfo.Text = "2.2l V8 \"Vairavo kunigas\"";
            // 
            // CarAdMinimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CarAdMinimal";
            this.Size = new System.Drawing.Size(239, 352);
            this.Click += new System.EventHandler(this.CarAdMinimal_Click);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label carModel;
        private System.Windows.Forms.PictureBox carImage;
        private System.Windows.Forms.Label additionInfo;
        private System.Windows.Forms.Label price;
    }
}
