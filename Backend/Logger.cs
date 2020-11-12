using System;
using System.IO;
using System.Text;

namespace Backend
{
    public class Logger
    {
        private readonly static string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly static char _pathSeparator = Path.DirectorySeparatorChar;
        private readonly static string _defaultLogPath = $"{_desktopPath}{_pathSeparator}car shopping engine{_pathSeparator}logs{_pathSeparator}";
        private readonly static string _newline = Environment.NewLine;
        private readonly string _exceptionsLogPath;
        private readonly string _messagesLogPath;
        private readonly FileStream _exceptionsLogFile;
        private readonly FileStream _messagesLogFile;

        public Logger(string exceptionsLogPath = null, string messagesLogPath = null)
        {
            _exceptionsLogPath = exceptionsLogPath ?? $"{_defaultLogPath}Exceptions{_pathSeparator}{DateTime.Now.ToShortDateString()}-{DateTime.Now.ToLongTimeString().Replace(":", "-")}.txt";
            _messagesLogPath = messagesLogPath ?? $"{_defaultLogPath}Messages{_pathSeparator}{DateTime.Now.ToShortDateString()}-{DateTime.Now.ToLongTimeString().Replace(":", "-")}.txt";


            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_exceptionsLogPath));
                _exceptionsLogFile = File.OpenWrite(_exceptionsLogPath);
                Directory.CreateDirectory(Path.GetDirectoryName(_messagesLogPath));
                _messagesLogFile = File.OpenWrite(_messagesLogPath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to create log file(s) {_exceptionsLogPath}{_newline}{e}");
            }
        }

        public async void LogException(Exception e)
        {
            byte[] info = new UTF8Encoding(true).GetBytes($"[{DateTime.Now:T}] {e}{_newline}{_newline}");
            try
            {
                await _exceptionsLogFile.WriteAsync(info.AsMemory(0, info.Length));
                await _exceptionsLogFile.FlushAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Cannot write to exceptions log file{_newline}{exc}");
            }
        }

        public async void Log(string s)
        {
            byte[] info = new UTF8Encoding(true).GetBytes($"{s}{_newline}");
            try
            {
                await _messagesLogFile.WriteAsync(info.AsMemory(0, info.Length));
                await _messagesLogFile.FlushAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Cannot write to messages log file{_newline}{exc}");
            }
        }
    }
}
