using System;
using System.Windows.Forms;

namespace Test1
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text == "vienas" && passwordTextBox.Text == "du")
            {
                new MainWindow().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The username or password you entered is incorrect.\nTry again.");
                passwordTextBox.Clear();
                passwordTextBox.Focus();
            }
        }

        private void usernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
