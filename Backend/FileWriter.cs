using System;
using System.IO;
using System.Text.Json;

namespace Backend
{
    class FileWriter
    {
        private string databasePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\test\db\";
        private Logger logger;
        private string userDatabasePath;
        private string carDatabasePath;

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public FileWriter(Logger logger, string carDbPath = null, string userDbPath = null)
        {
            this.logger = logger;

            if (carDbPath != null)
            {
                this.carDatabasePath = carDbPath;
            }
            else
            {
                carDatabasePath = databasePath + @"cars\";
            }
            if (userDbPath != null)
            {
                this.userDatabasePath = userDbPath;
            }
            else
            {
                userDatabasePath = databasePath + @"users\";
            }
        }

        public void WriteCarData(Car car)
        {
            string fileName = carDatabasePath + car.Id + ".json";

            byte[] jsonUtf8Bytes;
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(car, options);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    writer.Write(jsonUtf8Bytes);
                }
            }
            catch (Exception e)
            {
                logger.LogException(e);
            }
        }

        public void DeleteCar(int Id)
        {
            string fileName = carDatabasePath + Id + ".json";

            try
            {
                File.Delete(fileName);
            }
            catch (Exception e)
            {
                logger.LogException(e);
            }
        }

        public void WriteUserData(User user)
        {
            string fileName = userDatabasePath + user.Id + ".json";

            byte[] jsonUtf8Bytes;
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(user, options);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    writer.Write(jsonUtf8Bytes);
                }
            }
            catch (Exception e)
            {
                logger.LogException(e);
            }
        }

        public void DeleteUser(int Id)
        {
            string fileName = userDatabasePath + Id + ".json";

            try
            {
                File.Delete(fileName);
            }
            catch (Exception e)
            {
                logger.LogException(e);
            }
        }
    }
}
