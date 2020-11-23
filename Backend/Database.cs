using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Backend
{
    public class Database : IDatabase
    {
        private readonly List<Car> _carList;
        private readonly List<User> _userList;
        //private readonly List<MinimalUser> _currentlyLoggedInUsers = new List<MinimalUser>();
        private readonly FileReader _fileReader;
        private readonly FileWriter _fileWriter;
        private int _lastCarId;
        //private int _lastUserId;
        private readonly Logger _logger;

        public Database(Logger logger, string carDbPath = null, string userDbPath = null)
        {
            _logger = logger;
            _fileReader = new FileReader(logger, carDbPath, userDbPath);
            _fileWriter = new FileWriter(logger, carDbPath, userDbPath);
            _carList = _fileReader.GetAllCarData();
            _userList = _fileReader.GetAllUserData();
            _lastCarId = _fileReader.LastCarId;
        }

        public IEnumerable<Car> GetFilteredCars(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            List<Car> filteredCarList = _carList;

            if (!string.IsNullOrEmpty(filters.Brand))
                filteredCarList = (from car in filteredCarList where car.Brand.ToLower().Contains(filters.Brand) select car).ToList();
            if (!string.IsNullOrEmpty(filters.Model))
                filteredCarList = (from car in filteredCarList where car.Model.ToLower().Contains(filters.Model) select car).ToList();
            if (filters.Used.HasValue)
                filteredCarList = (from car in filteredCarList where car.Used == filters.Used select car).ToList();
            if (filters.PriceFrom.HasValue)
                filteredCarList = (from car in filteredCarList where car.Price >= filters.PriceFrom select car).ToList();
            if (filters.PriceTo.HasValue)
                filteredCarList = (from car in filteredCarList where car.Price <= filters.PriceTo select car).ToList();
            if (filters.YearFrom.HasValue)
                filteredCarList = (from car in filteredCarList where car.DateOfPurchase.Year >= filters.YearFrom select car).ToList();
            if (filters.YearTo.HasValue)
                filteredCarList = (from car in filteredCarList where car.DateOfPurchase.Year <= filters.YearTo select car).ToList();
            if (filters.FuelType.HasValue)
                filteredCarList = (from car in filteredCarList where car.FuelType == filters.FuelType select car).ToList();

            // this is currently not used
            //if (!string.IsNullOrEmpty(filters.Username))
            //    filteredCarList = (from car in filteredCarList where car.UploaderUsername.ToLower() == filters.Username select car).ToList();


            return GetSortedCarsListJson(sortBy, sortAscending, startIndex, amount, filteredCarList);
        }

        public IEnumerable<Car> GetSortedCars(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            return GetSortedCarsListJson(sortBy, sortAscending, startIndex, amount);
        }


        private IEnumerable<Car> GetSortedCarsListJson(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount, List<Car> carListToSort = null)
        {
            if (carListToSort == null)
            {
                carListToSort = _carList;
            }
            carListToSort.SortBy(sortBy, sortAscending);
            return /*JsonSerializer.SerializeToUtf8Bytes<List<Car>>(*/carListToSort.Skip(startIndex).Take(amount);
        }

        public bool DeleteCar(int carId, string username, string password)
        {
            // find car to delete
            Car car = _carList.Find(c => c.UploaderUsername == username && c.Id == carId);
            // only procedd if user exists and is uploader of the vehicle
            if (GetUser(username, password) != null && car != null)
            {
                // remove this car from all users liked cars lists
                _userList.ForEach(user =>
                {
                    if (user.LikedAds.Remove(carId))
                    {
                        // if user info is changed, it needs to be saved
                        _fileWriter.WriteUserData(user);
                    }
                });
                // remove this car from currently logged in users liked lists
                //_currentlyLoggedInUsers.ForEach(user => user.LikedAds.Remove(id));
                //foreach (User user in _userList)
                //{
                //    user.LikedAds.Remove(id);
                //}
                return _carList.Remove(car) && _fileWriter.DeleteCar(carId);
            }
            else
            {
                return false;
            }
        }

        public string AddUser(User user)
        {
            // do not allow null fields
            if (user.Username == null || user.HashedPassword == null || user.LikedAds == null || user.Email == null)
            {
                return null;
            }

            if (!_userList.Exists(u => u.Username == user.Username))
            {
                if (!_fileWriter.WriteUserData(user))
                {
                    throw new Exception("Failed to add user");
                }
                else
                {
                    _userList.Add(user);
                    _logger.Log("Added new user. Username = " + user.Username);
                }
                return user.Username;
            }
            else
            {
                // null => user already exists
                return null;
            }
        }

        public User GetUser(string username, string password)
        {
            return _userList.Find(u => u.Username == username && u.HashedPassword == EncryptPassword(password, username));
        }

        public IEnumerable<Car> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            User user = _userList.Find(u => u.Username == username);
            if (user == null)
            {
                return null;
            }
            else
            {
                return GetSortedCarsListJson(sortBy, sortAscending, startIndex, amount, _carList.FindAll(car => car.UploaderUsername == user.Username));
            }
        }

        public IEnumerable<Car> GetUserLikedAds(string username, string password, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            User user = GetUser(username, password);
            if (user == null)
            {
                return null;
            }
            else
            {
                return GetSortedCarsListJson(sortBy, sortAscending, startIndex, amount, _carList.FindAll(car => user.LikedAds.Contains(car.Id)));
            }
        }

        public bool DeleteUser(string username, string password)
        {
            User user = GetUser(username, password);
            if (user == null)
            {
                return false;
            }
            else
            {
                _fileWriter.DeleteUser(username);
                return true;
            }
        }

        public bool UpdateUser(string username, string password, User user)
        {
            // this should return only one user, but if user updates his username to a clashing one, we check for it
            User userToUpdate = _userList.Find(u => u.Username == username && u.HashedPassword == EncryptPassword(password, username));
            if (userToUpdate == null)
            {
                return false;
            }
            else
            {
                _userList.Remove(userToUpdate);
                _fileWriter.DeleteUser(userToUpdate.Username);
                _userList.Add(user);
                _fileWriter.WriteUserData(user);
                return true;
            }
        }

        public bool AddCar(string username, string password, Car car)
        {
            User user = GetUser(username, password);
            if (user == null)
            {
                return false;
            }
            else
            {
                car.UploaderUsername = username;
                car.Id = _lastCarId++;
                _carList.Add(car);
                _fileWriter.WriteCarData(car);
                return true;
            }
        }

        private static string EncryptPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = string.Format("{0}{1}", salt, password);
            byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
            return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
        }

        public bool UpdateCar(string username, string password, Car car)
        {
            User user = GetUser(username, password);
            if (user == null)
            {
                return false;
            }
            else
            {
                Car c = _carList.Find(car1 => car1.UploaderUsername == username && car1.Id == car.Id);
                if (c != null)
                {
                    _carList.Remove(c);
                    car.UploaderUsername = username;
                    _carList.Add(car);
                    _fileWriter.DeleteCar(car.Id);
                    _fileWriter.WriteCarData(car);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Car GetCar(int id)
        {
            return _carList.Find(car => car.Id == id);
        }
    }
}
