using DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Backend
{
    internal class FileReader
    {
        private string databasePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\test\db\";
        private string userDatabasePath;
        private string carDatabasePath;
        private Logger logger;
        internal int lastCarId { get; private set; } = 0;

        internal FileReader(Logger logger, string carDbPath = null, string userDbPath = null)
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

        internal Car GetCarData(int Id)
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

        internal User GetUserData(string username)
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

        internal List<Car> GetAllCarData()
        {
            List<Car> cars = new List<Car>();
            if (Directory.Exists(carDatabasePath))
            {
                foreach (string file in Directory.EnumerateFiles(carDatabasePath, "*.json"))
                {
                    try
                    {
                        byte[] jsonBytes = File.ReadAllBytes(file);
                        var utf8Reader = new Utf8JsonReader(jsonBytes);
                        Car car = JsonSerializer.Deserialize<Car>(ref utf8Reader);
                        if (car.Id > lastCarId)
                        {
                            lastCarId = car.Id;
                        }
                        cars.Add(car);
                    }
                    catch (Exception e)
                    {
                        // ignore files that do not hold cars
                        logger.LogException(new Exception("Garbage file in car database directory", e));
                    }
                }
                return cars;
            }
            return cars;
        }

        internal List<User> GetAllUserData()
        {
            List<User> users = new List<User>();
            if (Directory.Exists(userDatabasePath))
            {
                foreach (string file in Directory.EnumerateFiles(userDatabasePath, "*.json"))
                {
                    try
                    {
                        string username = Path.GetFileNameWithoutExtension(file);
                        byte[] jsonBytes = File.ReadAllBytes(file);
                        var utf8Reader = new Utf8JsonReader(jsonBytes);
                        User user = JsonSerializer.Deserialize<User>(ref utf8Reader);
                        users.Add(user);
                    }
                    catch (Exception e)
                    {
                        // ignore files that do not hold users
                        logger.LogException(new Exception("Garbage file in user database directory", e));
                    }
                }
            }
            return users;
        }
    }
}
