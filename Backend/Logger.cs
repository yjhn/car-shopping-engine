using System;
using System.IO;
using System.Text;

namespace Backend
{
    public class Logger
    {
        private string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\test\logs\" + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToLongTimeString().Replace(":", "-") + ".txt";
        private FileStream LogFile;

        public Logger(string logPath = null)
        {
            if (logPath != null)
            {
                this.LogPath = logPath;
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(this.LogPath));
                LogFile = File.OpenWrite(this.LogPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create log file\n" + e.ToString());
            }
        }

        public void LogException(Exception e)
        {
            byte[] info = new UTF8Encoding(true).GetBytes($"[{DateTime.Now:T}] {e}\n\n");
            try
            {
                LogFile.Write(info, 0, info.Length);
                LogFile.Flush();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Cannot write to log file\n{exc}");
            }
        }
    }
}
