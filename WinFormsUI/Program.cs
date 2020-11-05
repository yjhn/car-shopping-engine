using Frontend;
using System;
using System.Windows.Forms;

namespace Test1
{
    static class Program
    {
        // this is the only instance of Api that exists
        private static readonly IApi _api = new Api();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(_api, new UserInfo(_api)));
        }
    }
}
