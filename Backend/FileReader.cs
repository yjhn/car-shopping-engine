using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Backend
{
    class FileReader
    {
        private string databasePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\test\db\";
        private string userDatabasePath;
        private string carDatabasePath;
        private Logger logger;
        internal int lastCarId { get; private set; } = 0;
        internal int lastUserId { get; private set; } = 0;

        public FileReader(string dbPath, Logger logger)
        {
            this.databasePath = dbPath;
            this.logger = logger;
            carDatabasePath = databasePath + @"cars\";
            userDatabasePath = databasePath + @"users\";
        }

        public FileReader(Logger logger)
        {
            this.logger = logger;
            carDatabasePath = databasePath + @"cars\";
            userDatabasePath = databasePath + @"users\";
        }

        public Car GetCarData(int Id)
        {
            if (Directory.Exists(carDatabasePath))
            {
                string fileName = databasePath + Id + ".json";
                try
                {
                    byte[] jsonBytes = File.ReadAllBytes(fileName);
                    var utf8Reader = new Utf8JsonReader(jsonBytes);
                    Car car = JsonSerializer.Deserialize<Car>(ref utf8Reader);
                    return car;
                }
                catch (Exception e)
                {
                    logger.Log(DateTime.Now.ToShortTimeString() + "\n" + e.ToString());
                }
            }
            return null;
        }

        public User GetUserData(int UserId)
        {
            if (Directory.Exists(userDatabasePath))
            {
                string fileName = databasePath + @"users\" + UserId + ".json";

                try
                {
                    byte[] jsonBytes = File.ReadAllBytes(fileName);
                    var utf8Reader = new Utf8JsonReader(jsonBytes);
                    User user = JsonSerializer.Deserialize<User>(ref utf8Reader);
                    return user;
                }
                catch (Exception e)
                {
                    logger.Log(DateTime.Now.ToShortTimeString() + "\n" + e.ToString());
                }
            }
            return null;
        }

        public List<Car> GetAllCarData()
        {
            List<Car> cars = new List<Car>();
            if (Directory.Exists(carDatabasePath))
            {
                try
                {
                    foreach (string file in Directory.EnumerateFiles(databasePath + @"cars\", "*.json"))
                    {
                        int carId = int.Parse(file.Substring(file.IndexOf(@"cars\"), file.Length - 5));
                        if (carId > lastCarId)
                        {
                            lastCarId = carId;
                        }
                        byte[] jsonBytes = File.ReadAllBytes(file);
                        var utf8Reader = new Utf8JsonReader(jsonBytes);
                        Car car = JsonSerializer.Deserialize<Car>(ref utf8Reader);
                        cars.Add(car);
                    }
                    return cars;
                }
                catch (Exception e)
                {
                    logger.Log(DateTime.Now.ToShortTimeString() + "\n" + e.ToString());
                }
            }
            return cars;
        }

        public List<User> GetAllUserData()
        {
            List<User> users = new List<User>();
            if (Directory.Exists(userDatabasePath))
            {
                try
                {
                    foreach (string file in Directory.EnumerateFiles(databasePath + @"users\", "*.json"))
                    {
                        int userId = int.Parse(file.Substring(file.IndexOf(@"users\"), file.Length - 5));
                        if (userId > lastUserId)
                        {
                            lastUserId = userId;
                        }
                        byte[] jsonBytes = File.ReadAllBytes(file);
                        var utf8Reader = new Utf8JsonReader(jsonBytes);
                        User user = JsonSerializer.Deserialize<User>(ref utf8Reader);
                        users.Add(user);
                    }
                    return users;
                }
                catch (Exception e)
                {
                    logger.Log(DateTime.Now.ToShortTimeString() + "\n" + e.ToString());
                }
            }
            return users;
        }
    }
}
