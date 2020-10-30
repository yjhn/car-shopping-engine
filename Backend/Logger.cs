using System;
using System.IO;
using System.Text;

namespace Backend
{
    public class Logger
    {
        private readonly string _logPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\test\logs\" + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToLongTimeString().Replace(":", "-") + ".txt";
        private readonly FileStream _logFile;

        public Logger(string logPath = null)
        {
            if (logPath != null)
            {
                _logPath = logPath;
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(this._logPath));
                _logFile = File.OpenWrite(this._logPath);
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
                _logFile.Write(info, 0, info.Length);
                _logFile.Flush();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Cannot write to log file\n{exc}");
            }
        }
    }
}
