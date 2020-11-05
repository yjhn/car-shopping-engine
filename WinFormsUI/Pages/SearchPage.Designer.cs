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
            this.searchAndResultsTabs = new System.Windows.Forms.TabControl();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.sortAscDescPanel = new System.Windows.Forms.Panel();
            this.sortAscRadioBtn = new System.Windows.Forms.RadioButton();
            this.sortDescRadioBtn = new System.Windows.Forms.RadioButton();
            this.usedNewPanel = new System.Windows.Forms.Panel();
            this.usedRadioBtn = new System.Windows.Forms.RadioButton();
            this.newRadioBtn = new System.Windows.Forms.RadioButton();
            this.vehicleTypeCombobox = new System.Windows.Forms.ComboBox();
            this.lowerYearTextbox = new System.Windows.Forms.NumericUpDown();
            this.vehicleTypeLabel = new System.Windows.Forms.Label();
            this.resetSearchBtn = new System.Windows.Forms.Button();
            this.sortByCombobox = new System.Windows.Forms.ComboBox();
            this.sortByLabel = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.brandTextbox = new System.Windows.Forms.TextBox();
            this.higherYearTextbox = new System.Windows.Forms.NumericUpDown();
            this.searchBtn = new System.Windows.Forms.Button();
            this.modelTextbox = new System.Windows.Forms.TextBox();
            this.fuelTypeCombobox = new System.Windows.Forms.ComboBox();
            this.fuelTypeLabel = new System.Windows.Forms.Label();
            this.yearRangeDashLabel = new System.Windows.Forms.Label();
            this.yearRangeLabel = new System.Windows.Forms.Label();
            this.priceRangeDashLabel = new System.Windows.Forms.Label();
            this.higherPriceTextbox = new System.Windows.Forms.NumericUpDown();
            this.priceRangeLabel = new System.Windows.Forms.Label();
            this.brandLabel = new System.Windows.Forms.Label();
            this.lowerPriceTextbox = new System.Windows.Forms.NumericUpDown();
            this.titleLabel = new System.Windows.Forms.Label();
            this.searchAndResultsTabs.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.sortAscDescPanel.SuspendLayout();
            this.usedNewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerYearTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.higherYearTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.higherPriceTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPriceTextbox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchAndResultsTabs
            // 
            this.searchAndResultsTabs.Controls.Add(this.searchTab);
            this.searchAndResultsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchAndResultsTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.searchAndResultsTabs.ItemSize = new System.Drawing.Size(70, 20);
            this.searchAndResultsTabs.Location = new System.Drawing.Point(0, 0);
            this.searchAndResultsTabs.Name = "searchAndResultsTabs";
            this.searchAndResultsTabs.SelectedIndex = 0;
            this.searchAndResultsTabs.Size = new System.Drawing.Size(696, 563);
            this.searchAndResultsTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.searchAndResultsTabs.TabIndex = 14;
            this.searchAndResultsTabs.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl_DrawItem);
            this.searchAndResultsTabs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabControl_MouseDown);
            // 
            // searchTab
            // 
            this.searchTab.AutoScroll = true;
            this.searchTab.Controls.Add(this.sortAscDescPanel);
            this.searchTab.Controls.Add(this.usedNewPanel);
            this.searchTab.Controls.Add(this.vehicleTypeCombobox);
            this.searchTab.Controls.Add(this.lowerYearTextbox);
            this.searchTab.Controls.Add(this.vehicleTypeLabel);
            this.searchTab.Controls.Add(this.resetSearchBtn);
            this.searchTab.Controls.Add(this.sortByCombobox);
            this.searchTab.Controls.Add(this.sortByLabel);
            this.searchTab.Controls.Add(this.modelLabel);
            this.searchTab.Controls.Add(this.brandTextbox);
            this.searchTab.Controls.Add(this.higherYearTextbox);
            this.searchTab.Controls.Add(this.searchBtn);
            this.searchTab.Controls.Add(this.modelTextbox);
            this.searchTab.Controls.Add(this.fuelTypeCombobox);
            this.searchTab.Controls.Add(this.fuelTypeLabel);
            this.searchTab.Controls.Add(this.yearRangeDashLabel);
            this.searchTab.Controls.Add(this.yearRangeLabel);
            this.searchTab.Controls.Add(this.priceRangeDashLabel);
            this.searchTab.Controls.Add(this.higherPriceTextbox);
            this.searchTab.Controls.Add(this.priceRangeLabel);
            this.searchTab.Controls.Add(this.brandLabel);
            this.searchTab.Controls.Add(this.lowerPriceTextbox);
            this.searchTab.Controls.Add(this.titleLabel);
            this.searchTab.Location = new System.Drawing.Point(4, 24);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(688, 535);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "search";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // sortAscDescPanel
            // 
            this.sortAscDescPanel.AutoSize = true;
            this.sortAscDescPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sortAscDescPanel.BackColor = System.Drawing.Color.Transparent;
            this.sortAscDescPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sortAscDescPanel.Controls.Add(this.sortAscRadioBtn);
            this.sortAscDescPanel.Controls.Add(this.sortDescRadioBtn);
            this.sortAscDescPanel.Location = new System.Drawing.Point(226, 388);
            this.sortAscDescPanel.Name = "sortAscDescPanel";
            this.sortAscDescPanel.Size = new System.Drawing.Size(155, 61);
            this.sortAscDescPanel.TabIndex = 11;
            // 
            // sortAscRadioBtn
            // 
            this.sortAscRadioBtn.AccessibleDescription = "sortAscendingRadioButton";
            this.sortAscRadioBtn.AccessibleName = "sortAscendingRadioButton";
            this.sortAscRadioBtn.AutoSize = true;
            this.sortAscRadioBtn.Location = new System.Drawing.Point(65, 14);
            this.sortAscRadioBtn.Name = "sortAscRadioBtn";
            this.sortAscRadioBtn.Size = new System.Drawing.Size(81, 19);
            this.sortAscRadioBtn.TabIndex = 1;
            this.sortAscRadioBtn.Text = "Ascending";
            this.sortAscRadioBtn.UseVisualStyleBackColor = true;
            // 
            // sortDescRadioBtn
            // 
            this.sortDescRadioBtn.AccessibleDescription = "sortDescendingRadioButton";
            this.sortDescRadioBtn.AccessibleName = "sortDescendingRadioButton";
            this.sortDescRadioBtn.AutoSize = true;
            this.sortDescRadioBtn.Checked = true;
            this.sortDescRadioBtn.Location = new System.Drawing.Point(65, 39);
            this.sortDescRadioBtn.Name = "sortDescRadioBtn";
            this.sortDescRadioBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sortDescRadioBtn.Size = new System.Drawing.Size(87, 19);
            this.sortDescRadioBtn.TabIndex = 2;
            this.sortDescRadioBtn.TabStop = true;
            this.sortDescRadioBtn.Text = "Descending";
            this.sortDescRadioBtn.UseVisualStyleBackColor = true;
            // 
            // usedNewPanel
            // 
            this.usedNewPanel.AutoSize = true;
            this.usedNewPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usedNewPanel.Controls.Add(this.usedRadioBtn);
            this.usedNewPanel.Controls.Add(this.newRadioBtn);
            this.usedNewPanel.Location = new System.Drawing.Point(226, 210);
            this.usedNewPanel.Name = "usedNewPanel";
            this.usedNewPanel.Size = new System.Drawing.Size(119, 61);
            this.usedNewPanel.TabIndex = 5;
            // 
            // usedRadioBtn
            // 
            this.usedRadioBtn.AccessibleDescription = "radio button for used car";
            this.usedRadioBtn.AccessibleName = "used car";
            this.usedRadioBtn.AutoSize = true;
            this.usedRadioBtn.Location = new System.Drawing.Point(65, 14);
            this.usedRadioBtn.Name = "usedRadioBtn";
            this.usedRadioBtn.Size = new System.Drawing.Size(51, 19);
            this.usedRadioBtn.TabIndex = 1;
            this.usedRadioBtn.TabStop = true;
            this.usedRadioBtn.Text = "Used";
            this.usedRadioBtn.UseVisualStyleBackColor = true;
            // 
            // newRadioBtn
            // 
            this.newRadioBtn.AccessibleDescription = "radio button for new car";
            this.newRadioBtn.AccessibleName = "new car";
            this.newRadioBtn.AutoSize = true;
            this.newRadioBtn.Location = new System.Drawing.Point(65, 39);
            this.newRadioBtn.Name = "newRadioBtn";
            this.newRadioBtn.Size = new System.Drawing.Size(49, 19);
            this.newRadioBtn.TabIndex = 2;
            this.newRadioBtn.Text = "New";
            this.newRadioBtn.UseVisualStyleBackColor = true;
            // 
            // vehicleTypeCombobox
            // 
            this.vehicleTypeCombobox.AccessibleDescription = "vehicle type combobox";
            this.vehicleTypeCombobox.AccessibleName = "vehicle type combobox";
            this.vehicleTypeCombobox.FormattingEnabled = true;
            this.vehicleTypeCombobox.Items.AddRange(new object[] {
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
            this.vehicleTypeCombobox.Location = new System.Drawing.Point(252, 62);
            this.vehicleTypeCombobox.Name = "vehicleTypeCombobox";
            this.vehicleTypeCombobox.Size = new System.Drawing.Size(181, 23);
            this.vehicleTypeCombobox.TabIndex = 0;
            // 
            // lowerYearTextbox
            // 
            this.lowerYearTextbox.AccessibleDescription = "lower year range combo box";
            this.lowerYearTextbox.AccessibleName = "lower year range combo box";
            this.lowerYearTextbox.Location = new System.Drawing.Point(252, 284);
            this.lowerYearTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.lowerYearTextbox.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.lowerYearTextbox.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.lowerYearTextbox.Name = "lowerYearTextbox";
            this.lowerYearTextbox.Size = new System.Drawing.Size(46, 23);
            this.lowerYearTextbox.TabIndex = 7;
            this.lowerYearTextbox.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // vehicleTypeLabel
            // 
            this.vehicleTypeLabel.AccessibleDescription = "type of the vehicle label";
            this.vehicleTypeLabel.AccessibleName = "type of the vehicle label";
            this.vehicleTypeLabel.AutoSize = true;
            this.vehicleTypeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vehicleTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vehicleTypeLabel.Location = new System.Drawing.Point(187, 61);
            this.vehicleTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vehicleTypeLabel.Name = "vehicleTypeLabel";
            this.vehicleTypeLabel.Size = new System.Drawing.Size(59, 25);
            this.vehicleTypeLabel.TabIndex = 3;
            this.vehicleTypeLabel.Text = "Type:";
            // 
            // resetSearchBtn
            // 
            this.resetSearchBtn.AccessibleDescription = "reset search criteria";
            this.resetSearchBtn.AccessibleName = "reset search criteria";
            this.resetSearchBtn.AutoSize = true;
            this.resetSearchBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetSearchBtn.Location = new System.Drawing.Point(614, 472);
            this.resetSearchBtn.Name = "resetSearchBtn";
            this.resetSearchBtn.Size = new System.Drawing.Size(42, 25);
            this.resetSearchBtn.TabIndex = 13;
            this.resetSearchBtn.Text = "reset";
            this.resetSearchBtn.UseVisualStyleBackColor = true;
            this.resetSearchBtn.Click += new System.EventHandler(this.ResetSearchButton_Click);
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
            this.sortByCombobox.Location = new System.Drawing.Point(252, 360);
            this.sortByCombobox.Margin = new System.Windows.Forms.Padding(2);
            this.sortByCombobox.Name = "sortByCombobox";
            this.sortByCombobox.Size = new System.Drawing.Size(160, 23);
            this.sortByCombobox.TabIndex = 10;
            // 
            // sortByLabel
            // 
            this.sortByLabel.AccessibleDescription = "sort by label";
            this.sortByLabel.AccessibleName = "sort by label";
            this.sortByLabel.AutoSize = true;
            this.sortByLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sortByLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sortByLabel.Location = new System.Drawing.Point(163, 360);
            this.sortByLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sortByLabel.Name = "sortByLabel";
            this.sortByLabel.Size = new System.Drawing.Size(83, 25);
            this.sortByLabel.TabIndex = 3;
            this.sortByLabel.Text = "Sort by:";
            // 
            // modelLabel
            // 
            this.modelLabel.AccessibleDescription = "model of the vehicle";
            this.modelLabel.AccessibleName = "model of the vehicle";
            this.modelLabel.AutoSize = true;
            this.modelLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.modelLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.modelLabel.Location = new System.Drawing.Point(172, 145);
            this.modelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(74, 25);
            this.modelLabel.TabIndex = 3;
            this.modelLabel.Text = "Model:";
            // 
            // brandTextbox
            // 
            this.brandTextbox.AccessibleDescription = "text box for brand of the vehicle";
            this.brandTextbox.AccessibleName = "brand of the vehicle";
            this.brandTextbox.Location = new System.Drawing.Point(252, 105);
            this.brandTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.brandTextbox.Name = "brandTextbox";
            this.brandTextbox.Size = new System.Drawing.Size(246, 23);
            this.brandTextbox.TabIndex = 1;
            // 
            // higherYearTextbox
            // 
            this.higherYearTextbox.AccessibleDescription = "upper year range combo box";
            this.higherYearTextbox.AccessibleName = "upper year range combo box";
            this.higherYearTextbox.Location = new System.Drawing.Point(322, 284);
            this.higherYearTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.higherYearTextbox.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.higherYearTextbox.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.higherYearTextbox.Name = "higherYearTextbox";
            this.higherYearTextbox.Size = new System.Drawing.Size(46, 23);
            this.higherYearTextbox.TabIndex = 8;
            this.higherYearTextbox.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // searchBtn
            // 
            this.searchBtn.AccessibleDescription = "search button";
            this.searchBtn.AccessibleName = "search button";
            this.searchBtn.Enabled = false;
            this.searchBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchBtn.Location = new System.Drawing.Point(236, 464);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(174, 34);
            this.searchBtn.TabIndex = 12;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // modelTextbox
            // 
            this.modelTextbox.AccessibleDescription = "text box for model of the vehicle";
            this.modelTextbox.AccessibleName = "model of the vehicle";
            this.modelTextbox.Location = new System.Drawing.Point(252, 147);
            this.modelTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.modelTextbox.Name = "modelTextbox";
            this.modelTextbox.Size = new System.Drawing.Size(246, 23);
            this.modelTextbox.TabIndex = 2;
            // 
            // fuelTypeCombobox
            // 
            this.fuelTypeCombobox.AccessibleDescription = "fuel type combo box";
            this.fuelTypeCombobox.AccessibleName = "fuel type combo box";
            this.fuelTypeCombobox.FormattingEnabled = true;
            this.fuelTypeCombobox.Items.AddRange(new object[] {
            "any",
            "petrol",
            "diesel",
            "electric",
            "hybrid"});
            this.fuelTypeCombobox.Location = new System.Drawing.Point(252, 325);
            this.fuelTypeCombobox.Margin = new System.Windows.Forms.Padding(2);
            this.fuelTypeCombobox.Name = "fuelTypeCombobox";
            this.fuelTypeCombobox.Size = new System.Drawing.Size(129, 23);
            this.fuelTypeCombobox.TabIndex = 9;
            // 
            // fuelTypeLabel
            // 
            this.fuelTypeLabel.AccessibleDescription = "fuel type:";
            this.fuelTypeLabel.AccessibleName = "fuel type:";
            this.fuelTypeLabel.AutoSize = true;
            this.fuelTypeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fuelTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fuelTypeLabel.Location = new System.Drawing.Point(148, 320);
            this.fuelTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fuelTypeLabel.Name = "fuelTypeLabel";
            this.fuelTypeLabel.Size = new System.Drawing.Size(98, 25);
            this.fuelTypeLabel.TabIndex = 3;
            this.fuelTypeLabel.Text = "Fuel type:";
            // 
            // yearRangeDashLabel
            // 
            this.yearRangeDashLabel.AccessibleDescription = "dash";
            this.yearRangeDashLabel.AutoSize = true;
            this.yearRangeDashLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yearRangeDashLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.yearRangeDashLabel.Location = new System.Drawing.Point(302, 284);
            this.yearRangeDashLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yearRangeDashLabel.Name = "yearRangeDashLabel";
            this.yearRangeDashLabel.Size = new System.Drawing.Size(16, 21);
            this.yearRangeDashLabel.TabIndex = 3;
            this.yearRangeDashLabel.Text = "-";
            // 
            // yearRangeLabel
            // 
            this.yearRangeLabel.AccessibleDescription = "year range:";
            this.yearRangeLabel.AccessibleName = "year range:";
            this.yearRangeLabel.AutoSize = true;
            this.yearRangeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yearRangeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.yearRangeLabel.Location = new System.Drawing.Point(134, 282);
            this.yearRangeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yearRangeLabel.Name = "yearRangeLabel";
            this.yearRangeLabel.Size = new System.Drawing.Size(112, 25);
            this.yearRangeLabel.TabIndex = 3;
            this.yearRangeLabel.Text = "Year range:";
            // 
            // priceRangeDashLabel
            // 
            this.priceRangeDashLabel.AccessibleDescription = "dash";
            this.priceRangeDashLabel.AccessibleName = "dash";
            this.priceRangeDashLabel.AutoSize = true;
            this.priceRangeDashLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.priceRangeDashLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.priceRangeDashLabel.Location = new System.Drawing.Point(345, 178);
            this.priceRangeDashLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.priceRangeDashLabel.Name = "priceRangeDashLabel";
            this.priceRangeDashLabel.Size = new System.Drawing.Size(16, 21);
            this.priceRangeDashLabel.TabIndex = 3;
            this.priceRangeDashLabel.Text = "-";
            // 
            // higherPriceTextbox
            // 
            this.higherPriceTextbox.AccessibleDescription = "Upper price range text box";
            this.higherPriceTextbox.AccessibleName = "Upper price range text box";
            this.higherPriceTextbox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.higherPriceTextbox.Location = new System.Drawing.Point(365, 181);
            this.higherPriceTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.higherPriceTextbox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.higherPriceTextbox.Name = "higherPriceTextbox";
            this.higherPriceTextbox.Size = new System.Drawing.Size(82, 23);
            this.higherPriceTextbox.TabIndex = 4;
            // 
            // priceRangeLabel
            // 
            this.priceRangeLabel.AccessibleDescription = "price range:";
            this.priceRangeLabel.AccessibleName = "price range:";
            this.priceRangeLabel.AutoSize = true;
            this.priceRangeLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.priceRangeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.priceRangeLabel.Location = new System.Drawing.Point(128, 179);
            this.priceRangeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.priceRangeLabel.Name = "priceRangeLabel";
            this.priceRangeLabel.Size = new System.Drawing.Size(118, 25);
            this.priceRangeLabel.TabIndex = 3;
            this.priceRangeLabel.Text = "Price range:";
            // 
            // brandLabel
            // 
            this.brandLabel.AccessibleDescription = "brand of the vehicle label";
            this.brandLabel.AccessibleName = "brand of the vehicle label";
            this.brandLabel.AutoSize = true;
            this.brandLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.brandLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.brandLabel.Location = new System.Drawing.Point(175, 103);
            this.brandLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(71, 25);
            this.brandLabel.TabIndex = 3;
            this.brandLabel.Text = "Brand:";
            // 
            // lowerPriceTextbox
            // 
            this.lowerPriceTextbox.AccessibleDescription = "Lower price range text box";
            this.lowerPriceTextbox.AccessibleName = "Lower price range text box";
            this.lowerPriceTextbox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.lowerPriceTextbox.Location = new System.Drawing.Point(252, 181);
            this.lowerPriceTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.lowerPriceTextbox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.lowerPriceTextbox.Name = "lowerPriceTextbox";
            this.lowerPriceTextbox.Size = new System.Drawing.Size(82, 23);
            this.lowerPriceTextbox.TabIndex = 3;
            // 
            // titleLabel
            // 
            this.titleLabel.AccessibleDescription = "title label";
            this.titleLabel.AccessibleName = "title label";
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Black", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(143, 8);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(391, 38);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Search for specific vehicles";
            // 
            // SearchPage
            // 
            this.AccessibleDescription = "vehicle search page";
            this.AccessibleName = "search page";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.searchAndResultsTabs);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SearchPage";
            this.Size = new System.Drawing.Size(696, 563);
            this.VisibleChanged += new System.EventHandler(this.SearchPage_VisibleChanged);
            this.searchAndResultsTabs.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            this.sortAscDescPanel.ResumeLayout(false);
            this.sortAscDescPanel.PerformLayout();
            this.usedNewPanel.ResumeLayout(false);
            this.usedNewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerYearTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.higherYearTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.higherPriceTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPriceTextbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl searchAndResultsTabs;
        private TabPage searchTab;
        private Panel sortAscDescPanel;
        private RadioButton sortAscRadioBtn;
        private RadioButton sortDescRadioBtn;
        private Panel usedNewPanel;
        private RadioButton usedRadioBtn;
        private RadioButton newRadioBtn;
        private ComboBox vehicleTypeCombobox;
        private NumericUpDown lowerYearTextbox;
        private Label vehicleTypeLabel;
        private Button resetSearchBtn;
        private ComboBox sortByCombobox;
        private Label sortByLabel;
        private Label modelLabel;
        private TextBox brandTextbox;
        private NumericUpDown higherYearTextbox;
        private Button searchBtn;
        private TextBox modelTextbox;
        private ComboBox fuelTypeCombobox;
        private Label fuelTypeLabel;
        private Label yearRangeDashLabel;
        private Label yearRangeLabel;
        private Label priceRangeDashLabel;
        private NumericUpDown higherPriceTextbox;
        private Label priceRangeLabel;
        private Label brandLabel;
        private NumericUpDown lowerPriceTextbox;
        private Label titleLabel;
    }
}
