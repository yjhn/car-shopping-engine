namespace Test1
{
    partial class LoginScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.usernameText = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.BackColor = System.Drawing.Color.Transparent;
            this.usernameText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameText.ForeColor = System.Drawing.Color.Yellow;
            this.usernameText.Location = new System.Drawing.Point(70, 19);
            this.usernameText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(106, 25);
            this.usernameText.TabIndex = 0;
            this.usernameText.Text = "Username:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(70, 99);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(138, 23);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBox_KeyDown);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(70, 46);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(138, 23);
            this.usernameTextBox.TabIndex = 1;
            this.usernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameTextBox_KeyDown);
            // 
            // passwordText
            // 
            this.passwordText.AutoSize = true;
            this.passwordText.BackColor = System.Drawing.Color.Transparent;
            this.passwordText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passwordText.ForeColor = System.Drawing.Color.Yellow;
            this.passwordText.Location = new System.Drawing.Point(70, 71);
            this.passwordText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(102, 25);
            this.passwordText.TabIndex = 0;
            this.passwordText.Text = "Password:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(11, 137);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(289, 209);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameText);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginScreen";
            this.Text = "3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordText;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox usernameTextBox;
    }
}

