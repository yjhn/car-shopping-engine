using System;
using System.IO;
using System.Text;

namespace Backend
{
    class Logger
    {
        private string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\test\logs\" + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToLongTimeString().Replace(":", "-") + ".txt";
        private FileStream LogFile;

        public Logger()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogPath));
                LogFile = File.OpenWrite(LogPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create log file\n" + e.ToString());
            }
        }

        public Logger(string LogPath)
        {
            this.LogPath = LogPath;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogPath));
                LogFile = File.OpenWrite(LogPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create log file\n" + e.ToString());
            }
        }

        public void Log(string text)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            try
            {
                LogFile.Write(info, 0, info.Length);
                LogFile.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot write to log file\n" + e.ToString());
            }
        }
    }
}
