using System;
using System.IO;
using System.Text;

namespace Backend
{
    public class Logger
    {
        private readonly string _exceptionsLogPath;
        private readonly string _messagesLogPath;
        private readonly FileStream _exceptionsLogFile;
        private readonly FileStream _messagesLogFile;

        public Logger(string exceptionsLogPath = null, string messagesLogPath = null)
        {
            _exceptionsLogPath = exceptionsLogPath ?? $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\car shopping engine\logs\Exceptions\{DateTime.Now.ToShortDateString()}-{DateTime.Now.ToLongTimeString().Replace(":", "-")}.txt";
            _messagesLogPath = messagesLogPath ?? $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\car shopping engine\logs\Messages\{DateTime.Now.ToShortDateString()}-{DateTime.Now.ToLongTimeString().Replace(":", "-")}.txt";


            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_exceptionsLogPath));
                _exceptionsLogFile = File.OpenWrite(_exceptionsLogPath);
                Directory.CreateDirectory(Path.GetDirectoryName(_messagesLogPath));
                _exceptionsLogFile = File.OpenWrite(_messagesLogPath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to create log file(s) {_exceptionsLogPath}\n{e}");
            }
        }

        public async void LogException(Exception e)
        {
            byte[] info = new UTF8Encoding(true).GetBytes($"[{DateTime.Now:T}] {e}\n\n");
            try
            {
                await _exceptionsLogFile.WriteAsync(info, 0, info.Length);
                await _exceptionsLogFile.FlushAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Cannot write to exceptions log file\n{exc}");
            }
        }

        public async void Log(string s)
        {
            byte[] info = new UTF8Encoding(true).GetBytes($"{s}\n");
            try
            {
                await _exceptionsLogFile.WriteAsync(info, 0, info.Length);
                await _exceptionsLogFile.FlushAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Cannot write to messages log file\n{exc}");
            }
        }
    }
}
