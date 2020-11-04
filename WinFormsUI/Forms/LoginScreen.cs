using DataTypes;
using Frontend;
using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public partial class LoginScreen : Form
    {
        private IApi _frontendApi;
        private MinimalUser _userInfo;

        public LoginScreen(IApi api)
        {
            _frontendApi = api;
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
            phoneTextbox.Controls.RemoveAt(0);
            phoneTextbox.ResetText();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            //Here we should retrieve userToken from backend, if userToken is null it means, user is not logged in, for this button will just make the user token not null and set UserName. This Button will close the Form

            //Program.user.Username = usernameTextBox.Text;
            //Program.userToken = "";


            _userInfo = await _frontendApi.GetUser(usernameTextBox.Text, EncryptPassword(passwordTextBox.Text, usernameTextBox.Text));
            Close();
        }

        private async void SigUpButton_Click(object sender, EventArgs e)
        {
            bool? successfullyCreated = false;
            if (!loginButton.Visible)
            {
                // need to check for bad input
                User user = new User(usernameTextBox.Text, Convert.ToInt64(phoneTextbox.Text), EncryptPassword(passwordTextBox.Text, usernameTextBox.Text), emailTextbox.Text);
                successfullyCreated =  await _frontendApi.AddUser(user);
                if (successfullyCreated != null && (bool)successfullyCreated)
                {
                    // show that user creation is successful
                    Close();
                }
            }
            else
            {
                emailLabel.Visible = true;
                emailTextbox.Visible = true;
                phoneLabel.Visible = true;
                phoneTextbox.Visible = true;
                loginButton.Visible = false;
                usernameTextBox.Focus();
            }
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }


        // method to encrypt password
        public string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }
    }
}
