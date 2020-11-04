using DataTypes;
using System;
using System.IO;
using System.Text.Json;

namespace Backend
{
    internal class FileWriter
    {
        private readonly string _defaultDatabasePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\car shopping engine\db\";
        private readonly Logger _logger;
        private readonly string _userDatabasePath;
        private readonly string _carDatabasePath;

        JsonSerializerOptions options = new JsonSerializerOptions
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
                _carDatabasePath = _defaultDatabasePath + @"cars\";
            }
            if (userDbPath != null)
            {
                _userDatabasePath = userDbPath;
            }
            else
            {
                _userDatabasePath = _defaultDatabasePath + @"users\";
            }
        }

        internal bool WriteCarData(Car car)
        {
            string fileName = _carDatabasePath + car.Id + ".json";

            byte[] jsonUtf8Bytes;
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(car, options);

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
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(user, options);

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
