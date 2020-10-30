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
            this.browseButton = new System.Windows.Forms.Button();
            this.uploadLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uploadButton = new System.Windows.Forms.Button();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.brandTextBox = new System.Windows.Forms.TextBox();
            this.brandLabel = new System.Windows.Forms.Label();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.priceRangeLabel = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButtonUsed = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.yearRangeLabel = new System.Windows.Forms.Label();
            this.yearBox = new System.Windows.Forms.NumericUpDown();
            this.fuelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.fuelTypeLabel = new System.Windows.Forms.Label();
            this.additionalImagesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.priceBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).BeginInit();
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
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(304, 141);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(87, 38);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Type:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(766, 486);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(111, 33);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // uploadLabel
            // 
            this.uploadLabel.AccessibleDescription = "upload a picture:";
            this.uploadLabel.AccessibleName = "upload a picture:";
            this.uploadLabel.AutoSize = true;
            this.uploadLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadLabel.Location = new System.Drawing.Point(149, 486);
            this.uploadLabel.Name = "uploadLabel";
            this.uploadLabel.Size = new System.Drawing.Size(242, 38);
            this.uploadLabel.TabIndex = 1;
            this.uploadLabel.Text = "Upload a picture:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(447, 486);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // uploadButton
            // 
            this.uploadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.uploadButton.Location = new System.Drawing.Point(350, 734);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(249, 57);
            this.uploadButton.TabIndex = 5;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // typeComboBox
            // 
            this.typeComboBox.AccessibleDescription = "vehicle type combobox";
            this.typeComboBox.AccessibleName = "vehicle type combobox";
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "any",
            "station wagon",
            "hatchback",
            "sedan",
            "suv",
            "minivan",
            "coupe",
            "convertible",
            "passenger minibus",
            "combi minibus",
            "freight minibus",
            "commercial"});
            this.typeComboBox.Location = new System.Drawing.Point(449, 149);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(257, 33);
            this.typeComboBox.TabIndex = 0;
            // 
            // brandTextBox
            // 
            this.brandTextBox.AccessibleDescription = "text box for brand of the vehicle";
            this.brandTextBox.AccessibleName = "brand of the vehicle";
            this.brandTextBox.Location = new System.Drawing.Point(448, 188);
            this.brandTextBox.Name = "brandTextBox";
            this.brandTextBox.Size = new System.Drawing.Size(350, 31);
            this.brandTextBox.TabIndex = 1;
            // 
            // brandLabel
            // 
            this.brandLabel.AccessibleDescription = "brand of the vehicle label";
            this.brandLabel.AccessibleName = "brand of the vehicle label";
            this.brandLabel.AutoSize = true;
            this.brandLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.brandLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.brandLabel.Location = new System.Drawing.Point(288, 180);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(103, 38);
            this.brandLabel.TabIndex = 3;
            this.brandLabel.Text = "Brand:";
            // 
            // modelTextBox
            // 
            this.modelTextBox.AccessibleDescription = "text box for model of the vehicle";
            this.modelTextBox.AccessibleName = "model of the vehicle";
            this.modelTextBox.Location = new System.Drawing.Point(448, 226);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(350, 31);
            this.modelTextBox.TabIndex = 2;
            // 
            // modelLabel
            // 
            this.modelLabel.AccessibleDescription = "model of the vehicle";
            this.modelLabel.AccessibleName = "model of the vehicle";
            this.modelLabel.AutoSize = true;
            this.modelLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.modelLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.modelLabel.Location = new System.Drawing.Point(282, 218);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(109, 38);
            this.modelLabel.TabIndex = 3;
            this.modelLabel.Text = "Model:";
            // 
            // priceRangeLabel
            // 
            this.priceRangeLabel.AccessibleDescription = "price range:";
            this.priceRangeLabel.AccessibleName = "price range:";
            this.priceRangeLabel.AutoSize = true;
            this.priceRangeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.priceRangeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.priceRangeLabel.Location = new System.Drawing.Point(219, 256);
            this.priceRangeLabel.Name = "priceRangeLabel";
            this.priceRangeLabel.Size = new System.Drawing.Size(172, 38);
            this.priceRangeLabel.TabIndex = 3;
            this.priceRangeLabel.Text = "Price range:";
            // 
            // radioButton1
            // 
            this.radioButton1.AccessibleDescription = "radio button for new car";
            this.radioButton1.AccessibleName = "new car";
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(47, 65);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 29);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "New";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AccessibleDescription = "radio button for used car";
            this.radioButton2.AccessibleName = "used car";
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(47, 23);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 29);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Used";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Location = new System.Drawing.Point(359, 337);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 99);
            this.panel1.TabIndex = 5;
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(0, 0);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 24);
            this.radioButton3.TabIndex = 0;
            // 
            // radioButton4
            // 
            this.radioButton4.AccessibleDescription = "radio button for new car";
            this.radioButton4.AccessibleName = "new car";
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(47, 65);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(72, 29);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Text = "New";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AccessibleDescription = "radio button for used car";
            this.radioButton5.AccessibleName = "used car";
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(47, 23);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(77, 29);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Used";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Location = new System.Drawing.Point(359, 337);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 99);
            this.panel2.TabIndex = 5;
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(0, 0);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(104, 24);
            this.radioButton6.TabIndex = 0;
            // 
            // radioButton7
            // 
            this.radioButton7.AccessibleDescription = "radio button for new car";
            this.radioButton7.AccessibleName = "new car";
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(47, 65);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(72, 29);
            this.radioButton7.TabIndex = 2;
            this.radioButton7.Text = "New";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AccessibleDescription = "radio button for used car";
            this.radioButton8.AccessibleName = "used car";
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(47, 23);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(77, 29);
            this.radioButton8.TabIndex = 1;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Used";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Location = new System.Drawing.Point(359, 337);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 99);
            this.panel3.TabIndex = 5;
            // 
            // radioButton9
            // 
            this.radioButton9.Location = new System.Drawing.Point(0, 0);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(104, 24);
            this.radioButton9.TabIndex = 0;
            // 
            // radioButtonUsed
            // 
            this.radioButtonUsed.AccessibleDescription = "radio button for used car";
            this.radioButtonUsed.AccessibleName = "used car";
            this.radioButtonUsed.AutoSize = true;
            this.radioButtonUsed.Location = new System.Drawing.Point(47, 23);
            this.radioButtonUsed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonUsed.Name = "radioButtonUsed";
            this.radioButtonUsed.Size = new System.Drawing.Size(77, 29);
            this.radioButtonUsed.TabIndex = 1;
            this.radioButtonUsed.TabStop = true;
            this.radioButtonUsed.Text = "Used";
            this.radioButtonUsed.UseVisualStyleBackColor = true;
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AccessibleDescription = "radio button for new car";
            this.radioButtonNew.AccessibleName = "new car";
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Location = new System.Drawing.Point(47, 65);
            this.radioButtonNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(72, 29);
            this.radioButtonNew.TabIndex = 2;
            this.radioButtonNew.Text = "New";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.radioButtonUsed);
            this.panel4.Controls.Add(this.radioButtonNew);
            this.panel4.Location = new System.Drawing.Point(400, 304);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 99);
            this.panel4.TabIndex = 5;
            // 
            // yearRangeLabel
            // 
            this.yearRangeLabel.AccessibleDescription = "year range:";
            this.yearRangeLabel.AccessibleName = "year range:";
            this.yearRangeLabel.AutoSize = true;
            this.yearRangeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yearRangeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.yearRangeLabel.Location = new System.Drawing.Point(228, 400);
            this.yearRangeLabel.Name = "yearRangeLabel";
            this.yearRangeLabel.Size = new System.Drawing.Size(163, 38);
            this.yearRangeLabel.TabIndex = 3;
            this.yearRangeLabel.Text = "Year range:";
            // 
            // yearBox
            // 
            this.yearBox.AccessibleDescription = "lower year range combo box";
            this.yearBox.AccessibleName = "lower year range combo box";
            this.yearBox.Location = new System.Drawing.Point(447, 409);
            this.yearBox.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.yearBox.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(66, 31);
            this.yearBox.TabIndex = 7;
            this.yearBox.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // fuelTypeComboBox
            // 
            this.fuelTypeComboBox.AccessibleDescription = "fuel type combo box";
            this.fuelTypeComboBox.AccessibleName = "fuel type combo box";
            this.fuelTypeComboBox.FormattingEnabled = true;
            this.fuelTypeComboBox.Items.AddRange(new object[] {
            "any",
            "petrol",
            "diesel",
            "electric",
            "hybrid"});
            this.fuelTypeComboBox.Location = new System.Drawing.Point(447, 446);
            this.fuelTypeComboBox.Name = "fuelTypeComboBox";
            this.fuelTypeComboBox.Size = new System.Drawing.Size(183, 33);
            this.fuelTypeComboBox.TabIndex = 9;
            // 
            // fuelTypeLabel
            // 
            this.fuelTypeLabel.AccessibleDescription = "fuel type:";
            this.fuelTypeLabel.AccessibleName = "fuel type:";
            this.fuelTypeLabel.AutoSize = true;
            this.fuelTypeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fuelTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fuelTypeLabel.Location = new System.Drawing.Point(245, 438);
            this.fuelTypeLabel.Name = "fuelTypeLabel";
            this.fuelTypeLabel.Size = new System.Drawing.Size(146, 38);
            this.fuelTypeLabel.TabIndex = 3;
            this.fuelTypeLabel.Text = "Fuel type:";
            // 
            // additionalImagesPanel
            // 
            this.additionalImagesPanel.AutoScroll = true;
            this.additionalImagesPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.additionalImagesPanel.Location = new System.Drawing.Point(28, 527);
            this.additionalImagesPanel.Name = "additionalImagesPanel";
            this.additionalImagesPanel.Size = new System.Drawing.Size(413, 119);
            this.additionalImagesPanel.TabIndex = 10;
            // 
            // priceBox
            // 
            this.priceBox.AccessibleDescription = "price text box";
            this.priceBox.AccessibleName = "price text box";
            this.priceBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.priceBox.Location = new System.Drawing.Point(447, 265);
            this.priceBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(117, 31);
            this.priceBox.TabIndex = 3;
            // 
            // UploadPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.additionalImagesPanel);
            this.Controls.Add(this.fuelTypeLabel);
            this.Controls.Add(this.fuelTypeComboBox);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.yearRangeLabel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.priceRangeLabel);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.modelTextBox);
            this.Controls.Add(this.brandLabel);
            this.Controls.Add(this.brandTextBox);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uploadLabel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.mainTitleLabel);
            this.Name = "UploadPage";
            this.Size = new System.Drawing.Size(994, 833);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainTitleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label uploadLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label priceRangeLabel;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButtonUsed;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label yearRangeLabel;
        private System.Windows.Forms.NumericUpDown yearBox;
        private System.Windows.Forms.ComboBox fuelTypeComboBox;
        private System.Windows.Forms.Label fuelTypeLabel;
        private System.Windows.Forms.FlowLayoutPanel additionalImagePanel;
        private System.Windows.Forms.FlowLayoutPanel additionalImagesPanel;
        private System.Windows.Forms.TextBox brandTextBox;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown priceBox;
    }
}
