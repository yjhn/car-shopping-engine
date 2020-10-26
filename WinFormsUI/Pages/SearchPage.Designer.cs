using System;
using System.Threading;
using System.Windows.Forms;

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
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.lowerPriceTextBox = new System.Windows.Forms.NumericUpDown();
            this.brandLabel = new System.Windows.Forms.Label();
            this.priceRangeLabel = new System.Windows.Forms.Label();
            this.upperPriceTextBox = new System.Windows.Forms.NumericUpDown();
            this.dashLabel1 = new System.Windows.Forms.Label();
            this.yearRangeLabel = new System.Windows.Forms.Label();
            this.dashLabel2 = new System.Windows.Forms.Label();
            this.fuelTypeLabel = new System.Windows.Forms.Label();
            this.fuelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.lowerYearRangeTextBox = new System.Windows.Forms.NumericUpDown();
            this.upperYearRangeTextBox = new System.Windows.Forms.NumericUpDown();
            this.brandTextBox = new System.Windows.Forms.TextBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.radioButtonUsed = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.usedNewRadioButtonPanel = new System.Windows.Forms.Panel();
            this.sortByLabel = new System.Windows.Forms.Label();
            this.sortByCombobox = new System.Windows.Forms.ComboBox();
            this.radioButtonAscending = new System.Windows.Forms.RadioButton();
            this.radioButtonDescending = new System.Windows.Forms.RadioButton();
            this.sortAscendingDescendingRadioButtonPanel = new System.Windows.Forms.Panel();
            this.resetSearchButton = new System.Windows.Forms.Button();
            this.typeOfVehicleLabel = new System.Windows.Forms.Label();
            this.typeOfVehicleTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPriceTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperPriceTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerYearRangeTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperYearRangeTextBox)).BeginInit();
            this.usedNewRadioButtonPanel.SuspendLayout();
            this.sortAscendingDescendingRadioButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTitleLabel
            // 
            this.mainTitleLabel.AutoSize = true;
            this.mainTitleLabel.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainTitleLabel.Location = new System.Drawing.Point(168, 0);
            this.mainTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mainTitleLabel.Name = "mainTitleLabel";
            this.mainTitleLabel.Size = new System.Drawing.Size(391, 38);
            this.mainTitleLabel.TabIndex = 0;
            this.mainTitleLabel.Text = "Search for specific vehicles";
            // 
            // modelTextBox
            // 
            this.modelTextBox.AccessibleDescription = "text box for model of the vehicle";
            this.modelTextBox.AccessibleName = "model of the vehicle";
            this.modelTextBox.Location = new System.Drawing.Point(275, 139);
            this.modelTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(246, 23);
            this.modelTextBox.TabIndex = 2;
            // 
            // lowerPriceTextBox
            // 
            this.lowerPriceTextBox.AccessibleDescription = "Lower price range text box";
            this.lowerPriceTextBox.AccessibleName = "Lower price range text box";
            this.lowerPriceTextBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.lowerPriceTextBox.Location = new System.Drawing.Point(275, 174);
            this.lowerPriceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lowerPriceTextBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.lowerPriceTextBox.Name = "lowerPriceTextBox";
            this.lowerPriceTextBox.Size = new System.Drawing.Size(82, 23);
            this.lowerPriceTextBox.TabIndex = 3;
            // 
            // brandLabel
            // 
            this.brandLabel.AccessibleDescription = "brand of the vehicle label";
            this.brandLabel.AccessibleName = "brand of the vehicle label";
            this.brandLabel.AutoSize = true;
            this.brandLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.brandLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.brandLabel.Location = new System.Drawing.Point(197, 95);
            this.brandLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(71, 25);
            this.brandLabel.TabIndex = 3;
            this.brandLabel.Text = "Brand:";
            // 
            // priceRangeLabel
            // 
            this.priceRangeLabel.AccessibleDescription = "price range:";
            this.priceRangeLabel.AccessibleName = "price range:";
            this.priceRangeLabel.AutoSize = true;
            this.priceRangeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.priceRangeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.priceRangeLabel.Location = new System.Drawing.Point(150, 171);
            this.priceRangeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.priceRangeLabel.Name = "priceRangeLabel";
            this.priceRangeLabel.Size = new System.Drawing.Size(118, 25);
            this.priceRangeLabel.TabIndex = 3;
            this.priceRangeLabel.Text = "Price range:";
            // 
            // upperPriceTextBox
            // 
            this.upperPriceTextBox.AccessibleDescription = "Upper price range text box";
            this.upperPriceTextBox.AccessibleName = "Upper price range text box";
            this.upperPriceTextBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.upperPriceTextBox.Location = new System.Drawing.Point(376, 173);
            this.upperPriceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.upperPriceTextBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.upperPriceTextBox.Name = "upperPriceTextBox";
            this.upperPriceTextBox.Size = new System.Drawing.Size(82, 23);
            this.upperPriceTextBox.TabIndex = 4;
            // 
            // dashLabel1
            // 
            this.dashLabel1.AccessibleDescription = "dash";
            this.dashLabel1.AccessibleName = "dash";
            this.dashLabel1.AutoSize = true;
            this.dashLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dashLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dashLabel1.Location = new System.Drawing.Point(358, 171);
            this.dashLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dashLabel1.Name = "dashLabel1";
            this.dashLabel1.Size = new System.Drawing.Size(16, 21);
            this.dashLabel1.TabIndex = 3;
            this.dashLabel1.Text = "-";
            // 
            // yearRangeLabel
            // 
            this.yearRangeLabel.AccessibleDescription = "year range:";
            this.yearRangeLabel.AccessibleName = "year range:";
            this.yearRangeLabel.AutoSize = true;
            this.yearRangeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yearRangeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.yearRangeLabel.Location = new System.Drawing.Point(159, 274);
            this.yearRangeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yearRangeLabel.Name = "yearRangeLabel";
            this.yearRangeLabel.Size = new System.Drawing.Size(112, 25);
            this.yearRangeLabel.TabIndex = 3;
            this.yearRangeLabel.Text = "Year range:";
            // 
            // dashLabel2
            // 
            this.dashLabel2.AccessibleDescription = "dash";
            this.dashLabel2.AutoSize = true;
            this.dashLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dashLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dashLabel2.Location = new System.Drawing.Point(359, 278);
            this.dashLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dashLabel2.Name = "dashLabel2";
            this.dashLabel2.Size = new System.Drawing.Size(16, 21);
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
            this.fuelTypeLabel.Location = new System.Drawing.Point(173, 312);
            this.fuelTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fuelTypeLabel.Name = "fuelTypeLabel";
            this.fuelTypeLabel.Size = new System.Drawing.Size(98, 25);
            this.fuelTypeLabel.TabIndex = 3;
            this.fuelTypeLabel.Text = "Fuel type:";
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
            this.fuelTypeComboBox.Location = new System.Drawing.Point(275, 317);
            this.fuelTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.fuelTypeComboBox.Name = "fuelTypeComboBox";
            this.fuelTypeComboBox.Size = new System.Drawing.Size(129, 23);
            this.fuelTypeComboBox.TabIndex = 9;
            // 
            // searchButton
            // 
            this.searchButton.AccessibleDescription = "search button";
            this.searchButton.AccessibleName = "search button";
            this.searchButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchButton.Location = new System.Drawing.Point(261, 456);
            this.searchButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(174, 34);
            this.searchButton.TabIndex = 12;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // lowerYearRangeTextBox
            // 
            this.lowerYearRangeTextBox.AccessibleDescription = "lower year range combo box";
            this.lowerYearRangeTextBox.AccessibleName = "lower year range combo box";
            this.lowerYearRangeTextBox.Location = new System.Drawing.Point(275, 280);
            this.lowerYearRangeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lowerYearRangeTextBox.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.lowerYearRangeTextBox.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.lowerYearRangeTextBox.Name = "lowerYearRangeTextBox";
            this.lowerYearRangeTextBox.Size = new System.Drawing.Size(80, 23);
            this.lowerYearRangeTextBox.TabIndex = 7;
            this.lowerYearRangeTextBox.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // upperYearRangeTextBox
            // 
            this.upperYearRangeTextBox.AccessibleDescription = "upper year range combo box";
            this.upperYearRangeTextBox.AccessibleName = "upper year range combo box";
            this.upperYearRangeTextBox.Location = new System.Drawing.Point(378, 280);
            this.upperYearRangeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.upperYearRangeTextBox.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.upperYearRangeTextBox.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.upperYearRangeTextBox.Name = "upperYearRangeTextBox";
            this.upperYearRangeTextBox.Size = new System.Drawing.Size(80, 23);
            this.upperYearRangeTextBox.TabIndex = 8;
            this.upperYearRangeTextBox.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // brandTextBox
            // 
            this.brandTextBox.AccessibleDescription = "text box for brand of the vehicle";
            this.brandTextBox.AccessibleName = "brand of the vehicle";
            this.brandTextBox.Location = new System.Drawing.Point(275, 97);
            this.brandTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.brandTextBox.Name = "brandTextBox";
            this.brandTextBox.Size = new System.Drawing.Size(246, 23);
            this.brandTextBox.TabIndex = 1;
            // 
            // modelLabel
            // 
            this.modelLabel.AccessibleDescription = "model of the vehicle";
            this.modelLabel.AccessibleName = "model of the vehicle";
            this.modelLabel.AutoSize = true;
            this.modelLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.modelLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.modelLabel.Location = new System.Drawing.Point(194, 137);
            this.modelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(74, 25);
            this.modelLabel.TabIndex = 3;
            this.modelLabel.Text = "Model:";
            // 
            // radioButtonUsed
            // 
            this.radioButtonUsed.AccessibleDescription = "radio button for used car";
            this.radioButtonUsed.AccessibleName = "used car";
            this.radioButtonUsed.AutoSize = true;
            this.radioButtonUsed.Location = new System.Drawing.Point(33, 14);
            this.radioButtonUsed.Name = "radioButtonUsed";
            this.radioButtonUsed.Size = new System.Drawing.Size(51, 19);
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
            this.radioButtonNew.Location = new System.Drawing.Point(33, 39);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(49, 19);
            this.radioButtonNew.TabIndex = 2;
            this.radioButtonNew.Text = "New";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            // 
            // usedNewRadioButtonPanel
            // 
            this.usedNewRadioButtonPanel.AutoSize = true;
            this.usedNewRadioButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usedNewRadioButtonPanel.Controls.Add(this.radioButtonUsed);
            this.usedNewRadioButtonPanel.Controls.Add(this.radioButtonNew);
            this.usedNewRadioButtonPanel.Location = new System.Drawing.Point(244, 202);
            this.usedNewRadioButtonPanel.Name = "usedNewRadioButtonPanel";
            this.usedNewRadioButtonPanel.Size = new System.Drawing.Size(87, 61);
            this.usedNewRadioButtonPanel.TabIndex = 5;
            // 
            // sortByLabel
            // 
            this.sortByLabel.AccessibleDescription = "sort by label";
            this.sortByLabel.AccessibleName = "sort by label";
            this.sortByLabel.AutoSize = true;
            this.sortByLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sortByLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sortByLabel.Location = new System.Drawing.Point(185, 352);
            this.sortByLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sortByLabel.Name = "sortByLabel";
            this.sortByLabel.Size = new System.Drawing.Size(83, 25);
            this.sortByLabel.TabIndex = 3;
            this.sortByLabel.Text = "Sort by:";
            // 
            // sortByCombobox
            // 
            this.sortByCombobox.AccessibleDescription = "sort by combo box";
            this.sortByCombobox.AccessibleName = "sort by combo box";
            this.sortByCombobox.FormattingEnabled = true;
            this.sortByCombobox.Items.AddRange(new object[] {
            "upload date",
            "price",
            "date of purchase",
            "total kilometers driven",
            "original purchase country"});
            this.sortByCombobox.Location = new System.Drawing.Point(275, 352);
            this.sortByCombobox.Margin = new System.Windows.Forms.Padding(2);
            this.sortByCombobox.Name = "sortByCombobox";
            this.sortByCombobox.Size = new System.Drawing.Size(160, 23);
            this.sortByCombobox.TabIndex = 10;
            // 
            // radioButtonAscending
            // 
            this.radioButtonAscending.AccessibleDescription = "sortAscendingRadioButton";
            this.radioButtonAscending.AccessibleName = "sortAscendingRadioButton";
            this.radioButtonAscending.AutoSize = true;
            this.radioButtonAscending.Location = new System.Drawing.Point(33, 14);
            this.radioButtonAscending.Name = "radioButtonAscending";
            this.radioButtonAscending.Size = new System.Drawing.Size(81, 19);
            this.radioButtonAscending.TabIndex = 1;
            this.radioButtonAscending.Text = "Ascending";
            this.radioButtonAscending.UseVisualStyleBackColor = true;
            // 
            // radioButtonDescending
            // 
            this.radioButtonDescending.AccessibleDescription = "sortDescendingRadioButton";
            this.radioButtonDescending.AccessibleName = "sortDescendingRadioButton";
            this.radioButtonDescending.AutoSize = true;
            this.radioButtonDescending.Checked = true;
            this.radioButtonDescending.Location = new System.Drawing.Point(33, 39);
            this.radioButtonDescending.Name = "radioButtonDescending";
            this.radioButtonDescending.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButtonDescending.Size = new System.Drawing.Size(87, 19);
            this.radioButtonDescending.TabIndex = 2;
            this.radioButtonDescending.TabStop = true;
            this.radioButtonDescending.Text = "Descending";
            this.radioButtonDescending.UseVisualStyleBackColor = true;
            // 
            // sortAscendingDescendingRadioButtonPanel
            // 
            this.sortAscendingDescendingRadioButtonPanel.AutoSize = true;
            this.sortAscendingDescendingRadioButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sortAscendingDescendingRadioButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.sortAscendingDescendingRadioButtonPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sortAscendingDescendingRadioButtonPanel.Controls.Add(this.radioButtonAscending);
            this.sortAscendingDescendingRadioButtonPanel.Controls.Add(this.radioButtonDescending);
            this.sortAscendingDescendingRadioButtonPanel.Location = new System.Drawing.Point(244, 380);
            this.sortAscendingDescendingRadioButtonPanel.Name = "sortAscendingDescendingRadioButtonPanel";
            this.sortAscendingDescendingRadioButtonPanel.Size = new System.Drawing.Size(123, 61);
            this.sortAscendingDescendingRadioButtonPanel.TabIndex = 11;
            // 
            // resetSearchButton
            // 
            this.resetSearchButton.AccessibleDescription = "reset search criteria";
            this.resetSearchButton.AccessibleName = "reset search criteria";
            this.resetSearchButton.AutoSize = true;
            this.resetSearchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetSearchButton.Location = new System.Drawing.Point(639, 464);
            this.resetSearchButton.Name = "resetSearchButton";
            this.resetSearchButton.Size = new System.Drawing.Size(42, 25);
            this.resetSearchButton.TabIndex = 13;
            this.resetSearchButton.Text = "reset";
            this.resetSearchButton.UseVisualStyleBackColor = true;
            this.resetSearchButton.Click += new System.EventHandler(this.resetSearchButton_Click);
            // 
            // typeOfVehicleLabel
            // 
            this.typeOfVehicleLabel.AccessibleDescription = "type of the vehicle label";
            this.typeOfVehicleLabel.AccessibleName = "type of the vehicle label";
            this.typeOfVehicleLabel.AutoSize = true;
            this.typeOfVehicleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.typeOfVehicleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.typeOfVehicleLabel.Location = new System.Drawing.Point(212, 53);
            this.typeOfVehicleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeOfVehicleLabel.Name = "typeOfVehicleLabel";
            this.typeOfVehicleLabel.Size = new System.Drawing.Size(59, 25);
            this.typeOfVehicleLabel.TabIndex = 3;
            this.typeOfVehicleLabel.Text = "Type:";
            // 
            // typeOfVehicleTextBox
            // 
            this.typeOfVehicleTextBox.AccessibleDescription = "text box for type of the vehicle";
            this.typeOfVehicleTextBox.AccessibleName = "type of the vehicle";
            this.typeOfVehicleTextBox.Location = new System.Drawing.Point(275, 55);
            this.typeOfVehicleTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.typeOfVehicleTextBox.Name = "typeOfVehicleTextBox";
            this.typeOfVehicleTextBox.Size = new System.Drawing.Size(246, 23);
            this.typeOfVehicleTextBox.TabIndex = 0;
            // 
            // SearchPage
            // 
            this.AccessibleDescription = "vehicle search page";
            this.AccessibleName = "search page";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.typeOfVehicleTextBox);
            this.Controls.Add(this.typeOfVehicleLabel);
            this.Controls.Add(this.resetSearchButton);
            this.Controls.Add(this.sortAscendingDescendingRadioButtonPanel);
            this.Controls.Add(this.sortByCombobox);
            this.Controls.Add(this.sortByLabel);
            this.Controls.Add(this.usedNewRadioButtonPanel);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.brandTextBox);
            this.Controls.Add(this.upperYearRangeTextBox);
            this.Controls.Add(this.lowerYearRangeTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.fuelTypeComboBox);
            this.Controls.Add(this.fuelTypeLabel);
            this.Controls.Add(this.dashLabel2);
            this.Controls.Add(this.yearRangeLabel);
            this.Controls.Add(this.dashLabel1);
            this.Controls.Add(this.upperPriceTextBox);
            this.Controls.Add(this.priceRangeLabel);
            this.Controls.Add(this.brandLabel);
            this.Controls.Add(this.lowerPriceTextBox);
            this.Controls.Add(this.modelTextBox);
            this.Controls.Add(this.mainTitleLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SearchPage";
            this.Size = new System.Drawing.Size(696, 500);
            ((System.ComponentModel.ISupportInitialize)(this.lowerPriceTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperPriceTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerYearRangeTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperYearRangeTextBox)).EndInit();
            this.usedNewRadioButtonPanel.ResumeLayout(false);
            this.usedNewRadioButtonPanel.PerformLayout();
            this.sortAscendingDescendingRadioButtonPanel.ResumeLayout(false);
            this.sortAscendingDescendingRadioButtonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainTitleLabel;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.NumericUpDown lowerPriceTextBox;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label priceRangeLabel;
        private System.Windows.Forms.NumericUpDown upperPriceTextBox;
        private System.Windows.Forms.Label dashLabel1;
        private System.Windows.Forms.Label yearRangeLabel;
        private System.Windows.Forms.Label dashLabel2;
        private System.Windows.Forms.Label fuelTypeLabel;
        private System.Windows.Forms.ComboBox fuelTypeComboBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.NumericUpDown lowerYearRangeTextBox;
        private System.Windows.Forms.NumericUpDown upperYearRangeTextBox;
        private TextBox brandTextBox;
        private Label modelLabel;
        private RadioButton radioButtonUsed;
        private RadioButton radioButtonNew;
        private Panel usedNewRadioButtonPanel;
        private Label sortByLabel;
        private ComboBox sortByCombobox;
        private RadioButton radioButtonAscending;
        private RadioButton radioButtonDescending;
        private Panel sortAscendingDescendingRadioButtonPanel;
        private Button resetSearchButton;
        private Label typeOfVehicleLabel;
        private TextBox typeOfVehicleTextBox;
    }
}
