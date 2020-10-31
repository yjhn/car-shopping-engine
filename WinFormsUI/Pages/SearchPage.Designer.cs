﻿using System;
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
            this.label10 = new System.Windows.Forms.Label();
            this.resetSearchBtn = new System.Windows.Forms.Button();
            this.sortByCombobox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.brandTextbox = new System.Windows.Forms.TextBox();
            this.upperYearTextbox = new System.Windows.Forms.NumericUpDown();
            this.searchBtn = new System.Windows.Forms.Button();
            this.modelTextbox = new System.Windows.Forms.TextBox();
            this.fuelTypeCombobox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.upperPriceTextbox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lowerPriceTextbox = new System.Windows.Forms.NumericUpDown();
            this.titleLabel = new System.Windows.Forms.Label();
            this.searchAndResultsTabs.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.sortAscDescPanel.SuspendLayout();
            this.usedNewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerYearTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperYearTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperPriceTextbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPriceTextbox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchAndResultsTabs
            // 
            this.searchAndResultsTabs.Controls.Add(this.searchTab);
            this.searchAndResultsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchAndResultsTabs.Location = new System.Drawing.Point(0, 0);
            this.searchAndResultsTabs.Name = "searchAndResultsTabs";
            this.searchAndResultsTabs.SelectedIndex = 0;
            this.searchAndResultsTabs.Size = new System.Drawing.Size(696, 563);
            this.searchAndResultsTabs.TabIndex = 14;
            // 
            // searchTab
            // 
            this.searchTab.AutoScroll = true;
            this.searchTab.Controls.Add(this.sortAscDescPanel);
            this.searchTab.Controls.Add(this.usedNewPanel);
            this.searchTab.Controls.Add(this.vehicleTypeCombobox);
            this.searchTab.Controls.Add(this.lowerYearTextbox);
            this.searchTab.Controls.Add(this.label10);
            this.searchTab.Controls.Add(this.resetSearchBtn);
            this.searchTab.Controls.Add(this.sortByCombobox);
            this.searchTab.Controls.Add(this.label9);
            this.searchTab.Controls.Add(this.label8);
            this.searchTab.Controls.Add(this.brandTextbox);
            this.searchTab.Controls.Add(this.upperYearTextbox);
            this.searchTab.Controls.Add(this.searchBtn);
            this.searchTab.Controls.Add(this.modelTextbox);
            this.searchTab.Controls.Add(this.fuelTypeCombobox);
            this.searchTab.Controls.Add(this.label7);
            this.searchTab.Controls.Add(this.label6);
            this.searchTab.Controls.Add(this.label5);
            this.searchTab.Controls.Add(this.label4);
            this.searchTab.Controls.Add(this.upperPriceTextbox);
            this.searchTab.Controls.Add(this.label3);
            this.searchTab.Controls.Add(this.label2);
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
            // label10
            // 
            this.label10.AccessibleDescription = "type of the vehicle label";
            this.label10.AccessibleName = "type of the vehicle label";
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(187, 61);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 25);
            this.label10.TabIndex = 3;
            this.label10.Text = "Type:";
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
            // label9
            // 
            this.label9.AccessibleDescription = "sort by label";
            this.label9.AccessibleName = "sort by label";
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(163, 360);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 25);
            this.label9.TabIndex = 3;
            this.label9.Text = "Sort by:";
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "model of the vehicle";
            this.label8.AccessibleName = "model of the vehicle";
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(172, 145);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 25);
            this.label8.TabIndex = 3;
            this.label8.Text = "Model:";
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
            // upperYearTextbox
            // 
            this.upperYearTextbox.AccessibleDescription = "upper year range combo box";
            this.upperYearTextbox.AccessibleName = "upper year range combo box";
            this.upperYearTextbox.Location = new System.Drawing.Point(322, 284);
            this.upperYearTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.upperYearTextbox.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.upperYearTextbox.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.upperYearTextbox.Name = "upperYearTextbox";
            this.upperYearTextbox.Size = new System.Drawing.Size(46, 23);
            this.upperYearTextbox.TabIndex = 8;
            this.upperYearTextbox.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // searchBtn
            // 
            this.searchBtn.AccessibleDescription = "search button";
            this.searchBtn.AccessibleName = "search button";
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
            // label7
            // 
            this.label7.AccessibleDescription = "fuel type:";
            this.label7.AccessibleName = "fuel type:";
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(148, 320);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Fuel type:";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "dash";
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(302, 284);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "year range:";
            this.label5.AccessibleName = "year range:";
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(134, 282);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Year range:";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "dash";
            this.label4.AccessibleName = "dash";
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(345, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "-";
            // 
            // upperPriceTextbox
            // 
            this.upperPriceTextbox.AccessibleDescription = "Upper price range text box";
            this.upperPriceTextbox.AccessibleName = "Upper price range text box";
            this.upperPriceTextbox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.upperPriceTextbox.Location = new System.Drawing.Point(365, 181);
            this.upperPriceTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.upperPriceTextbox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.upperPriceTextbox.Name = "upperPriceTextbox";
            this.upperPriceTextbox.Size = new System.Drawing.Size(82, 23);
            this.upperPriceTextbox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "price range:";
            this.label3.AccessibleName = "price range:";
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(128, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Price range:";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "brand of the vehicle label";
            this.label2.AccessibleName = "brand of the vehicle label";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(175, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Brand:";
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
            ((System.ComponentModel.ISupportInitialize)(this.upperYearTextbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperPriceTextbox)).EndInit();
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
        private Label label10;
        private Button resetSearchBtn;
        private ComboBox sortByCombobox;
        private Label label9;
        private Label label8;
        private TextBox brandTextbox;
        private NumericUpDown upperYearTextbox;
        private Button searchBtn;
        private TextBox modelTextbox;
        private ComboBox fuelTypeCombobox;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private NumericUpDown upperPriceTextbox;
        private Label label3;
        private Label label2;
        private NumericUpDown lowerPriceTextbox;
        private Label titleLabel;
    }
}
