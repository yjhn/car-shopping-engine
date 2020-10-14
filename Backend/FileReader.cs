using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DataTypes;

namespace Backend
{
    class FileReader
    {
        private string databasePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\test\db\";
        private string userDatabasePath;
        private string carDatabasePath;
        private Logger logger;
        internal int lastCarId { get; private set; } = 0;

        public FileReader(Logger logger, string carDbPath = null, string userDbPath = null)
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
                    logger.LogException(e);
                }
            }
            return null;
        }

        public User GetUserData(string username)
        {
            if (Directory.Exists(userDatabasePath))
            {
                string fileName = userDatabasePath + username + ".json";
                try
                {
                    byte[] jsonBytes = File.ReadAllBytes(fileName);
                    var utf8Reader = new Utf8JsonReader(jsonBytes);
                    User user = JsonSerializer.Deserialize<User>(ref utf8Reader);
                    return user;
                }
                catch (Exception e)
                {
                    logger.LogException(e);
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
                    foreach (string file in Directory.EnumerateFiles(carDatabasePath, "*.json"))
                    {
                        int carId = GetId(file);
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
                    logger.LogException(e);
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
                    foreach (string file in Directory.EnumerateFiles(userDatabasePath, "*.json"))
                    {
                        string username = GetUsername(file);
                        byte[] jsonBytes = File.ReadAllBytes(file);
                        var utf8Reader = new Utf8JsonReader(jsonBytes);
                        User user = JsonSerializer.Deserialize<User>(ref utf8Reader);
                        users.Add(user);
                    }
                    return users;
                }
                catch (Exception e)
                {
                    logger.LogException(e);
                }
            }
            return users;
        }

        private string GetUsername(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        private int GetId(string filePath)
        {
            return int.Parse(Path.GetFileNameWithoutExtension(filePath));
        }
    }
}
