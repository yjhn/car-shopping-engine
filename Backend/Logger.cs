using System;
using System.IO;
using System.Text;

namespace Backend
{
    public class Logger
    {
        private readonly string _logPath;
        private readonly FileStream _logFile;

        public Logger(string logPath = null)
        {
            if (logPath != null)
            {
                _logPath = logPath;
            }
            else
            {
                _logPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\car shopping engine\logs\Exceptions\{DateTime.Now.ToShortDateString()}-{DateTime.Now.ToLongTimeString().Replace(":", "-")}.txt";
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_logPath));
                _logFile = File.OpenWrite(_logPath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to create log file {_logPath}\n{e}");
            }
        }

        public async void LogException(Exception e)
        {
            byte[] info = new UTF8Encoding(true).GetBytes($"[{DateTime.Now:T}] {e}\n\n");
            try
            {
                await _logFile.WriteAsync(info, 0, info.Length);
                await _logFile.FlushAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Cannot write to log file\n{exc}");
            }
        }
    }
}
