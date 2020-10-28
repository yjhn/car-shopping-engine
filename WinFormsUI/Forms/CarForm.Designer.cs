namespace CarEngine.Forms
{
    partial class CarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.vin = new System.Windows.Forms.Label();
            this.eurostandard = new System.Windows.Forms.Label();
            this.weight = new System.Windows.Forms.Label();
            this.gearBoxType = new System.Windows.Forms.Label();
            this.fuelType = new System.Windows.Forms.Label();
            this.color = new System.Windows.Forms.Label();
            this.chassisType = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.engine = new System.Windows.Forms.Label();
            this.model = new System.Windows.Forms.Label();
            this.brand = new System.Windows.Forms.Label();
            this.comment = new System.Windows.Forms.Label();
            this.carMainImage = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carMainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.brand);
            this.flowLayoutPanel1.Controls.Add(this.model);
            this.flowLayoutPanel1.Controls.Add(this.engine);
            this.flowLayoutPanel1.Controls.Add(this.age);
            this.flowLayoutPanel1.Controls.Add(this.price);
            this.flowLayoutPanel1.Controls.Add(this.chassisType);
            this.flowLayoutPanel1.Controls.Add(this.color);
            this.flowLayoutPanel1.Controls.Add(this.fuelType);
            this.flowLayoutPanel1.Controls.Add(this.gearBoxType);
            this.flowLayoutPanel1.Controls.Add(this.weight);
            this.flowLayoutPanel1.Controls.Add(this.eurostandard);
            this.flowLayoutPanel1.Controls.Add(this.vin);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(444, 410);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // vin
            // 
            this.vin.AutoSize = true;
            this.vin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vin.Location = new System.Drawing.Point(3, 374);
            this.vin.Name = "vin";
            this.vin.Size = new System.Drawing.Size(78, 32);
            this.vin.TabIndex = 0;
            this.vin.Text = "label5";
            // 
            // eurostandard
            // 
            this.eurostandard.AutoSize = true;
            this.eurostandard.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eurostandard.Location = new System.Drawing.Point(3, 342);
            this.eurostandard.Name = "eurostandard";
            this.eurostandard.Size = new System.Drawing.Size(78, 32);
            this.eurostandard.TabIndex = 0;
            this.eurostandard.Text = "label6";
            // 
            // weight
            // 
            this.weight.AutoSize = true;
            this.weight.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.weight.Location = new System.Drawing.Point(3, 310);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(78, 32);
            this.weight.TabIndex = 0;
            this.weight.Text = "label7";
            // 
            // gearBoxType
            // 
            this.gearBoxType.AutoSize = true;
            this.gearBoxType.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gearBoxType.Location = new System.Drawing.Point(3, 278);
            this.gearBoxType.Name = "gearBoxType";
            this.gearBoxType.Size = new System.Drawing.Size(78, 32);
            this.gearBoxType.TabIndex = 0;
            this.gearBoxType.Text = "label8";
            // 
            // fuelType
            // 
            this.fuelType.AutoSize = true;
            this.fuelType.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fuelType.Location = new System.Drawing.Point(3, 246);
            this.fuelType.Name = "fuelType";
            this.fuelType.Size = new System.Drawing.Size(78, 32);
            this.fuelType.TabIndex = 0;
            this.fuelType.Text = "label9";
            // 
            // color
            // 
            this.color.AutoSize = true;
            this.color.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.color.Location = new System.Drawing.Point(3, 214);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(91, 32);
            this.color.TabIndex = 0;
            this.color.Text = "label10";
            // 
            // chassisType
            // 
            this.chassisType.AutoSize = true;
            this.chassisType.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chassisType.Location = new System.Drawing.Point(3, 182);
            this.chassisType.Name = "chassisType";
            this.chassisType.Size = new System.Drawing.Size(91, 32);
            this.chassisType.TabIndex = 0;
            this.chassisType.Text = "label11";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.price.Location = new System.Drawing.Point(3, 140);
            this.price.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(91, 32);
            this.price.TabIndex = 0;
            this.price.Text = "label12";
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.age.Location = new System.Drawing.Point(3, 112);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(76, 28);
            this.age.TabIndex = 0;
            this.age.Text = "label13";
            // 
            // engine
            // 
            this.engine.AutoSize = true;
            this.engine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.engine.Location = new System.Drawing.Point(3, 69);
            this.engine.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.engine.Name = "engine";
            this.engine.Size = new System.Drawing.Size(76, 28);
            this.engine.TabIndex = 0;
            this.engine.Text = "label14";
            // 
            // model
            // 
            this.model.AutoSize = true;
            this.model.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.model.Location = new System.Drawing.Point(3, 37);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(91, 32);
            this.model.TabIndex = 0;
            this.model.Text = "label15";
            // 
            // brand
            // 
            this.brand.AutoSize = true;
            this.brand.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.brand.Location = new System.Drawing.Point(3, 0);
            this.brand.Name = "brand";
            this.brand.Size = new System.Drawing.Size(105, 37);
            this.brand.TabIndex = 0;
            this.brand.Text = "label16";
            // 
            // comment
            // 
            this.comment.AutoSize = true;
            this.comment.Location = new System.Drawing.Point(12, 436);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(50, 20);
            this.comment.TabIndex = 1;
            this.comment.Text = "label1";
            // 
            // carMainImage
            // 
            this.carMainImage.Image = ((System.Drawing.Image)(resources.GetObject("carMainImage.Image")));
            this.carMainImage.Location = new System.Drawing.Point(483, 15);
            this.carMainImage.Name = "carMainImage";
            this.carMainImage.Size = new System.Drawing.Size(447, 407);
            this.carMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.carMainImage.TabIndex = 2;
            this.carMainImage.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(483, 428);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(447, 125);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // CarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 560);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.carMainImage);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CarForm";
            this.Text = "CarForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carMainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label brand;
        private System.Windows.Forms.Label model;
        private System.Windows.Forms.Label engine;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label chassisType;
        private System.Windows.Forms.Label color;
        private System.Windows.Forms.Label fuelType;
        private System.Windows.Forms.Label gearBoxType;
        private System.Windows.Forms.Label weight;
        private System.Windows.Forms.Label eurostandard;
        private System.Windows.Forms.Label vin;
        private System.Windows.Forms.Label comment;
        private System.Windows.Forms.PictureBox carMainImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}