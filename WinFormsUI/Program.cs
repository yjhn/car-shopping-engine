using DataTypes;
using System;
using System.Windows.Forms;

namespace Test1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static User user = new User("Guest", 0, "", "");
        public static string userToken = null;
        public static string username = null;
        public static MinimalUser User
        {
            get
            {
                return User;
            }
            set
            {
                username = value.Username;
                userToken = value.Token;
                User = value;
            }
        }

        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
