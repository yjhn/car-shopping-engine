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

        public FileWriter(string DbPath, Logger logger)
        {
            this.databasePath = DbPath;
            this.logger = logger;
            carDatabasePath = databasePath + @"cars\";
            userDatabasePath = databasePath + @"users\";
        }

        public FileWriter(Logger logger)
        {
            this.logger = logger;
            carDatabasePath = databasePath + @"cars\";
            userDatabasePath = databasePath + @"users\";
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
                logger.Log(DateTime.Now.ToShortTimeString() + "\n" + e.ToString());
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
                logger.Log(DateTime.Now.ToShortTimeString() + "\n" + e.ToString());
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
                logger.Log(DateTime.Now.ToShortTimeString() + "\n" + e.ToString());
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
                logger.Log(DateTime.Now.ToShortTimeString() + "\n" + e.ToString());
            }
        }
    }
}
