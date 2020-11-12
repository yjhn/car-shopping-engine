using DataTypes;
using System;
using System.IO;
using System.Text.Json;

namespace Backend
{
    internal class FileWriter
    {
        private readonly static string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly static char _pathSeparator = Path.DirectorySeparatorChar;
        private readonly static string _defaultDatabasePath = $"{_desktopPath}{_pathSeparator}car shopping engine{_pathSeparator}db{_pathSeparator}";
        private readonly Logger _logger;
        private readonly string _userDatabasePath;
        private readonly string _carDatabasePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        internal FileWriter(Logger logger, string carDbPath = null, string userDbPath = null)
        {
            _logger = logger;

            if (carDbPath != null)
            {
                _carDatabasePath = carDbPath;
            }
            else
            {
                _carDatabasePath = $"{_defaultDatabasePath}cars{_pathSeparator}";
            }
            if (userDbPath != null)
            {
                _userDatabasePath = userDbPath;
            }
            else
            {
                _userDatabasePath = $"{_defaultDatabasePath}users{_pathSeparator}";
            }
        }

        internal bool WriteCarData(Car car)
        {
            string fileName = _carDatabasePath + car.Id + ".json";

            byte[] jsonUtf8Bytes;
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(car, _options);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    writer.Write(jsonUtf8Bytes);
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return false;
            }
        }

        internal bool DeleteCar(int Id)
        {
            string fileName = _carDatabasePath + Id + ".json";

            try
            {
                File.Delete(fileName);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return false;
            }
        }

        internal bool WriteUserData(User user)
        {
            string fileName = _userDatabasePath + user.Username + ".json";

            byte[] jsonUtf8Bytes;
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(user, _options);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    writer.Write(jsonUtf8Bytes);
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return false;
            }
        }

        internal bool DeleteUser(string username)
        {
            string fileName = _userDatabasePath + username + ".json";

            try
            {
                File.Delete(fileName);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return false;
            }
        }
    }
}
