using DataTypes;
using Frontend;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public partial class LoginScreen : Form
    {
        private readonly IApi _frontendApi;
        private readonly UserInfo _userInfo;

        public LoginScreen(IApi api, UserInfo userInfo)
        {
            _userInfo = userInfo;
            _frontendApi = api;
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
            phoneTextbox.Controls[0].Visible = false;
            phoneTextbox.ResetText();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (Validate(username, password))
            {
                MinimalUser user = await _frontendApi.GetUser(username, EncryptPassword(passwordTextBox.Text, username));
                if (user == null)
                {
                    MessageBox.Show("Bad username or password", "Bad credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passwordTextBox.Clear();
                }
                else
                {
                    _userInfo.User = user;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Username and password cannot be empty and cannot contain spaces ", "Bad input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Clear();
            }
        }

        private async void SigUpButton_Click(object sender, EventArgs e)
        {
            bool? successfullyCreated;
            if (!loginButton.Visible)
            {
                // need to check for bad input
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string email = emailTextbox.Text;
                long phone = 1000000;
                if (!string.IsNullOrEmpty(phoneTextbox.Text))
                    phone = Convert.ToInt64(phoneTextbox.Text);
                if (Validate(username, password) && email != "" && !email.Contains(' ') && phone != 1000000)
                {
                    User user = new User(username, phone, EncryptPassword(password, username), email);
                    successfullyCreated = await _frontendApi.AddUser(user);

                    if (successfullyCreated != null)
                    {
                        if ((bool)successfullyCreated)
                        {
                            // show that user creation is successful
                            MessageBox.Show("Successfully created user " + username, "User created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // show login controls
                            emailLabel.Visible = false;
                            emailTextbox.Visible = false;
                            phoneLabel.Visible = false;
                            phoneTextbox.Visible = false;
                            loginButton.Visible = true;
                            usernameTextBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show("This username is already taken", "Bad username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // if Api returns null, then there is no connection to server
                        MessageBox.Show("No connection to server", "No connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Fields cannot be empty and cannot contain spaces", "Bad form data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool Validate(string username, string password)
        {
            return !(username == "" || username.Contains(' ') || password == "" || password.Contains(' '));
        }

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
