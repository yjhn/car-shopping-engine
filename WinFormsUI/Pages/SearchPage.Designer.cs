namespace CarEngine
{
    partial class SearchPage
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.lowerPriceTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.priceRangeLabel = new System.Windows.Forms.Label();
            this.UpperPriceTextBox = new System.Windows.Forms.TextBox();
            this.dashLabel1 = new System.Windows.Forms.Label();
            this.usedCheckBox = new System.Windows.Forms.CheckBox();
            this.newCheckBox = new System.Windows.Forms.CheckBox();
            this.yearRangeLabel = new System.Windows.Forms.Label();
            this.dashLabel2 = new System.Windows.Forms.Label();
            this.fuelTypeLabel = new System.Windows.Forms.Label();
            this.fuelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.lowerYearRangeComboBox = new System.Windows.Forms.ComboBox();
            this.upperYearRangeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // mainTitleLabel
            // 
            this.mainTitleLabel.AutoSize = true;
            this.mainTitleLabel.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainTitleLabel.Location = new System.Drawing.Point(213, 53);
            this.mainTitleLabel.Name = "mainTitleLabel";
            this.mainTitleLabel.Size = new System.Drawing.Size(584, 57);
            this.mainTitleLabel.TabIndex = 0;
            this.mainTitleLabel.Text = "Search for specific vehicles";
            // 
            // nameTextBox
            // 
            this.nameTextBox.AccessibleDescription = "text box for the name";
            this.nameTextBox.AccessibleName = "text box for the name";
            this.nameTextBox.Location = new System.Drawing.Point(447, 190);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(350, 31);
            this.nameTextBox.TabIndex = 1;
            // 
            // lowerPriceTextBox
            // 
            this.lowerPriceTextBox.AccessibleDescription = "Lower price range text box";
            this.lowerPriceTextBox.AccessibleName = "Lower price range text box";
            this.lowerPriceTextBox.Location = new System.Drawing.Point(447, 251);
            this.lowerPriceTextBox.Name = "lowerPriceTextBox";
            this.lowerPriceTextBox.Size = new System.Drawing.Size(116, 31);
            this.lowerPriceTextBox.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.AccessibleDescription = "name of the vehicle";
            this.nameLabel.AccessibleName = "name of the vehicle";
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameLabel.Location = new System.Drawing.Point(114, 183);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(289, 38);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name of the vehicle:";
            // 
            // priceRangeLabel
            // 
            this.priceRangeLabel.AccessibleDescription = "price range:";
            this.priceRangeLabel.AccessibleName = "price range:";
            this.priceRangeLabel.AutoSize = true;
            this.priceRangeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.priceRangeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.priceRangeLabel.Location = new System.Drawing.Point(231, 244);
            this.priceRangeLabel.Name = "priceRangeLabel";
            this.priceRangeLabel.Size = new System.Drawing.Size(172, 38);
            this.priceRangeLabel.TabIndex = 3;
            this.priceRangeLabel.Text = "Price range:";
            // 
            // UpperPriceTextBox
            // 
            this.UpperPriceTextBox.AccessibleDescription = "Upper price range text box";
            this.UpperPriceTextBox.AccessibleName = "Upper price range text box";
            this.UpperPriceTextBox.Location = new System.Drawing.Point(592, 250);
            this.UpperPriceTextBox.Name = "UpperPriceTextBox";
            this.UpperPriceTextBox.Size = new System.Drawing.Size(116, 31);
            this.UpperPriceTextBox.TabIndex = 2;
            // 
            // dashLabel1
            // 
            this.dashLabel1.AccessibleDescription = "dash";
            this.dashLabel1.AccessibleName = "dash";
            this.dashLabel1.AutoSize = true;
            this.dashLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dashLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dashLabel1.Location = new System.Drawing.Point(566, 246);
            this.dashLabel1.Name = "dashLabel1";
            this.dashLabel1.Size = new System.Drawing.Size(24, 32);
            this.dashLabel1.TabIndex = 3;
            this.dashLabel1.Text = "-";
            // 
            // usedCheckBox
            // 
            this.usedCheckBox.AccessibleDescription = "check box for used vehicles";
            this.usedCheckBox.AccessibleName = "check box for used vehicles";
            this.usedCheckBox.AutoSize = true;
            this.usedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usedCheckBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usedCheckBox.Location = new System.Drawing.Point(294, 298);
            this.usedCheckBox.Name = "usedCheckBox";
            this.usedCheckBox.Size = new System.Drawing.Size(107, 42);
            this.usedCheckBox.TabIndex = 4;
            this.usedCheckBox.Text = "Used";
            this.usedCheckBox.UseVisualStyleBackColor = true;
            this.usedCheckBox.CheckedChanged += new System.EventHandler(this.usedCheckBox_CheckedChanged);
            // 
            // newCheckBox
            // 
            this.newCheckBox.AccessibleDescription = "check box for new vehicles";
            this.newCheckBox.AccessibleName = "check box for new vehicles";
            this.newCheckBox.AutoSize = true;
            this.newCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newCheckBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newCheckBox.Location = new System.Drawing.Point(447, 298);
            this.newCheckBox.Name = "newCheckBox";
            this.newCheckBox.Size = new System.Drawing.Size(102, 42);
            this.newCheckBox.TabIndex = 4;
            this.newCheckBox.Text = "New";
            this.newCheckBox.UseVisualStyleBackColor = true;
            this.newCheckBox.CheckedChanged += new System.EventHandler(this.newCheckBox_CheckedChanged);
            // 
            // yearRangeLabel
            // 
            this.yearRangeLabel.AccessibleDescription = "year range:";
            this.yearRangeLabel.AccessibleName = "year range:";
            this.yearRangeLabel.AutoSize = true;
            this.yearRangeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yearRangeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.yearRangeLabel.Location = new System.Drawing.Point(240, 352);
            this.yearRangeLabel.Name = "yearRangeLabel";
            this.yearRangeLabel.Size = new System.Drawing.Size(163, 38);
            this.yearRangeLabel.TabIndex = 3;
            this.yearRangeLabel.Text = "Year range:";
            // 
            // dashLabel2
            // 
            this.dashLabel2.AccessibleDescription = "dash";
            this.dashLabel2.AutoSize = true;
            this.dashLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dashLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dashLabel2.Location = new System.Drawing.Point(566, 354);
            this.dashLabel2.Name = "dashLabel2";
            this.dashLabel2.Size = new System.Drawing.Size(24, 32);
            this.dashLabel2.TabIndex = 3;
            this.dashLabel2.Text = "-";
            // 
            // fuelTypeLabel
            // 
            this.fuelTypeLabel.AccessibleDescription = "fuel type:";
            this.fuelTypeLabel.AccessibleName = "fuel type:";
            this.fuelTypeLabel.AutoSize = true;
            this.fuelTypeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fuelTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fuelTypeLabel.Location = new System.Drawing.Point(257, 416);
            this.fuelTypeLabel.Name = "fuelTypeLabel";
            this.fuelTypeLabel.Size = new System.Drawing.Size(146, 38);
            this.fuelTypeLabel.TabIndex = 3;
            this.fuelTypeLabel.Text = "Fuel type:";
            // 
            // fuelTypeComboBox
            // 
            this.fuelTypeComboBox.AccessibleDescription = "fuel type combo box";
            this.fuelTypeComboBox.AccessibleName = "fuel type combo box";
            this.fuelTypeComboBox.FormattingEnabled = true;
            this.fuelTypeComboBox.Items.AddRange(new object[] {
            "Petrol",
            "Diesel",
            "Electric",
            "Hybrid"});
            this.fuelTypeComboBox.Location = new System.Drawing.Point(447, 421);
            this.fuelTypeComboBox.Name = "fuelTypeComboBox";
            this.fuelTypeComboBox.Size = new System.Drawing.Size(182, 33);
            this.fuelTypeComboBox.TabIndex = 5;
            this.fuelTypeComboBox.Text = "-select fuel type-";
            // 
            // searchButton
            // 
            this.searchButton.AccessibleDescription = "search button";
            this.searchButton.AccessibleName = "search button";
            this.searchButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchButton.Location = new System.Drawing.Point(380, 518);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(248, 57);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // lowerYearRangeComboBox
            // 
            this.lowerYearRangeComboBox.AccessibleDescription = "lower year range combo box";
            this.lowerYearRangeComboBox.AccessibleName = "lower year range combo box";
            this.lowerYearRangeComboBox.FormattingEnabled = true;
            this.lowerYearRangeComboBox.Items.AddRange(new object[] {
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002",
            "2001",
            "2000",
            "1999",
            "1998",
            "1997",
            "1996",
            "1995",
            "1994",
            "1993",
            "1992",
            "1991",
            "1990",
            "1989",
            "1988",
            "1987",
            "1986",
            "1985",
            "1980",
            "1970",
            "1950",
            "1900"});
            this.lowerYearRangeComboBox.Location = new System.Drawing.Point(447, 357);
            this.lowerYearRangeComboBox.Name = "lowerYearRangeComboBox";
            this.lowerYearRangeComboBox.Size = new System.Drawing.Size(113, 33);
            this.lowerYearRangeComboBox.TabIndex = 5;
            // 
            // upperYearRangeComboBox
            // 
            this.upperYearRangeComboBox.AccessibleDescription = "upper year range combo box";
            this.upperYearRangeComboBox.AccessibleName = "upper year range combo box";
            this.upperYearRangeComboBox.FormattingEnabled = true;
            this.upperYearRangeComboBox.Items.AddRange(new object[] {
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002",
            "2001",
            "2000",
            "1999",
            "1998",
            "1997",
            "1996",
            "1995",
            "1994",
            "1993",
            "1992",
            "1991",
            "1990",
            "1989",
            "1988",
            "1987",
            "1986",
            "1985",
            "1980",
            "1970",
            "1950",
            "1900"});
            this.upperYearRangeComboBox.Location = new System.Drawing.Point(596, 357);
            this.upperYearRangeComboBox.Name = "upperYearRangeComboBox";
            this.upperYearRangeComboBox.Size = new System.Drawing.Size(113, 33);
            this.upperYearRangeComboBox.TabIndex = 5;
            // 
            // SearchPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upperYearRangeComboBox);
            this.Controls.Add(this.lowerYearRangeComboBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.fuelTypeComboBox);
            this.Controls.Add(this.fuelTypeLabel);
            this.Controls.Add(this.dashLabel2);
            this.Controls.Add(this.yearRangeLabel);
            this.Controls.Add(this.newCheckBox);
            this.Controls.Add(this.usedCheckBox);
            this.Controls.Add(this.dashLabel1);
            this.Controls.Add(this.UpperPriceTextBox);
            this.Controls.Add(this.priceRangeLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.lowerPriceTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.mainTitleLabel);
            this.Name = "SearchPage";
            this.Size = new System.Drawing.Size(1026, 663);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainTitleLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox lowerPriceTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label priceRangeLabel;
        private System.Windows.Forms.TextBox UpperPriceTextBox;
        private System.Windows.Forms.Label dashLabel1;
        private System.Windows.Forms.CheckBox usedCheckBox;
        private System.Windows.Forms.CheckBox newCheckBox;
        private System.Windows.Forms.Label yearRangeLabel;
        private System.Windows.Forms.Label dashLabel2;
        private System.Windows.Forms.Label fuelTypeLabel;
        private System.Windows.Forms.ComboBox fuelTypeComboBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox lowerYearRangeComboBox;
        private System.Windows.Forms.ComboBox upperYearRangeComboBox;
    }
}
