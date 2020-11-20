using DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Backend
{
    internal class FileReader
    {
        private readonly static string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly static char _pathSeparator = Path.DirectorySeparatorChar;
        private readonly static string _defaultDatabasePath = $"{_desktopPath}{_pathSeparator}car shopping engine{_pathSeparator}db{_pathSeparator}";
        private readonly string _userDatabasePath;
        private readonly string _carDatabasePath;
        private readonly Logger _logger;
        internal int LastCarId { get; private set; } = 0;
        internal int LastUserId { get; private set; } = 0;

        internal FileReader(Logger logger, string carDbPath = null, string userDbPath = null)
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

        internal Car GetCarData(int Id)
        {
            if (Directory.Exists(_carDatabasePath))
            {
                string fileName = _defaultDatabasePath + Id + ".json";
                try
                {
                    byte[] jsonBytes = File.ReadAllBytes(fileName);
                    var utf8Reader = new Utf8JsonReader(jsonBytes);
                    Car car = JsonSerializer.Deserialize<Car>(ref utf8Reader);
                    return car;
                }
                catch (Exception e)
                {
                    _logger.LogException(e);
                }
            }
            return null;
        }

        internal User GetUserData(string username)
        {
            if (Directory.Exists(_userDatabasePath))
            {
                string fileName = _userDatabasePath + username + ".json";
                try
                {
                    byte[] jsonBytes = File.ReadAllBytes(fileName);
                    var utf8Reader = new Utf8JsonReader(jsonBytes);
                    User user = JsonSerializer.Deserialize<User>(ref utf8Reader);
                    return user;
                }
                catch (Exception e)
                {
                    _logger.LogException(e);
                }
            }
            return null;
        }

        //internal Task<List<Car>> GetAllCarData()
        //{
        //    return Task.Run(() =>
        //    {
        //        List<Car> cars = new List<Car>();
        //        if (Directory.Exists(_carDatabasePath))
        //        {
        //            foreach (string file in Directory.EnumerateFiles(_carDatabasePath, "*.json"))
        //            {
        //                try
        //                {
        //                    byte[] jsonBytes = File.ReadAllBytes(file);
        //                    var utf8Reader = new Utf8JsonReader(jsonBytes);
        //                    Car car = JsonSerializer.Deserialize<Car>(ref utf8Reader);
        //                    if (car.Id > LastCarId)
        //                    {
        //                        LastCarId = car.Id;
        //                    }
        //                    cars.Add(car);
        //                }
        //                catch (Exception e)
        //                {
        //                    // ignore files that do not hold cars
        //                    _logger.LogException(new Exception("Garbage file in car database directory", e));
        //                }
        //            }
        //            return cars;
        //        }
        //        return cars;
        //    });
        //}

        //internal Task<List<User>> GetAllUserData()
        //{
        //    return Task.Run(() =>
        //    {
        //        List<User> users = new List<User>();
        //        if (Directory.Exists(_userDatabasePath))
        //        {
        //            foreach (string file in Directory.EnumerateFiles(_userDatabasePath, "*.json"))
        //            {
        //                try
        //                {
        //                    string username = Path.GetFileNameWithoutExtension(file);
        //                    byte[] jsonBytes = File.ReadAllBytes(file);
        //                    var utf8Reader = new Utf8JsonReader(jsonBytes);
        //                    User user = JsonSerializer.Deserialize<User>(ref utf8Reader);
        //                    if (user.Id > LastUserId)
        //                    {
        //                        LastUserId = user.Id;
        //                    }
        //                    users.Add(user);
        //                }
        //                catch (Exception e)
        //                {
        //                    // ignore files that do not hold users
        //                    _logger.LogException(new Exception("Garbage file in user database directory", e));
        //                }
        //            }
        //        }
        //        return users;
        //    });
        //}

        internal List<Car> GetAllCarData()
        {
            List<Car> cars = new List<Car>();
            if (Directory.Exists(_carDatabasePath))
            {
                foreach (string file in Directory.EnumerateFiles(_carDatabasePath, "*.json"))
                {
                    try
                    {
                        byte[] jsonBytes = File.ReadAllBytes(file);
                        var utf8Reader = new Utf8JsonReader(jsonBytes);
                        Car car = JsonSerializer.Deserialize<Car>(ref utf8Reader);
                        if (car.Id > LastCarId)
                        {
                            LastCarId = car.Id;
                        }
                        cars.Add(car);
                    }
                    catch (Exception e)
                    {
                        // ignore files that do not hold cars
                        _logger.LogException(new Exception("Garbage file in car database directory", e));
                    }
                }
                return cars;
            }
            return cars;
        }

        internal List<User> GetAllUserData()
        {
            List<User> users = new List<User>();
            if (Directory.Exists(_userDatabasePath))
            {
                foreach (string file in Directory.EnumerateFiles(_userDatabasePath, "*.json"))
                {
                    try
                    {
                        string username = Path.GetFileNameWithoutExtension(file);
                        byte[] jsonBytes = File.ReadAllBytes(file);
                        var utf8Reader = new Utf8JsonReader(jsonBytes);
                        User user = JsonSerializer.Deserialize<User>(ref utf8Reader);
                        //if (user.Id > LastUserId)
                        //{
                        //    LastUserId = user.Id;
                        //}
                        users.Add(user);
                    }
                    catch (Exception e)
                    {
                        // ignore files that do not hold users
                        _logger.LogException(new Exception("Garbage file in user database directory", e));
                    }
                }
            }
            return users;
        }
    }
}
