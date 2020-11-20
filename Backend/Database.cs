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
            //_lastUserId = _fileReader.LastUserId;

            //LoadAllData();
        }

        //private async void LoadAllData()
        //{
        //    _carList = await _fileReader.GetAllCarData();
        //    _userList = await _fileReader.GetAllUserData();
        //    _lastCarId = _fileReader.LastCarId;
        //}

        //public int GetLastCarId()
        //{
        //    return _lastCarId;
        //}

        //// params: Car serialized to JSON
        //public bool AddCarJson(byte[] car)
        //{
        //    try
        //    {
        //        Car c = JsonSerializer.Deserialize<Car>(car);
        //        _lastCarId++;
        //        c.Id = _lastCarId;
        //        _carList.Add(c);
        //        if (_fileWriter.WriteCarData(c))
        //        {
        //            _logger.Log("Added new car. ID = " + c.Id);
        //            return true;
        //        }
        //        else return false;
        //    }
        //    catch (JsonException e)
        //    {
        //        _logger.LogException(new Exception("Failed to write car data due to bad serialization", e));
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogException(e);
        //        return false;
        //    }
        //}

        //public bool AddUserJson(byte[] user)
        //{
        //    try
        //    {
        //        User u = JsonSerializer.Deserialize<User>(user);
        //        if (!_userList.Exists(user => user.Username == u.Username))
        //        {
        //            _userList.Add(u);
        //            // should probably return a status code, not bool
        //            _logger.Log("Added new user. Username = " + u.Username);
        //            return _fileWriter.WriteUserData(u);
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (JsonException e)
        //    {
        //        _logger.LogException(new Exception("Cannot add user due to bad serialization", e));
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogException(e);
        //        return false;
        //    }
        //}

        //// returns: MinimalUser serialized to UTF-8 JSON
        //public byte[] Authenticate(string username, string hashedPassword)
        //{
        //    try
        //    {
        //        User user = _userList.Find(user => user.Username == username && user.HashedPassword == hashedPassword);
        //        if (user == null)
        //        {
        //            _logger.Log($"Failed login attempt. User [ {username} ] not found or bad user password");
        //            return null;
        //        }
        //        // remove all current minimalUser instances from _currentlyLoggedInUsers
        //        // if user signs in at a few locations, this will "sign him out" from all but the last one
        //        _currentlyLoggedInUsers.RemoveAll(user => user.Username == username);

        //        // create new minimalUser with new session Id
        //        MinimalUser authenticatedUser = new MinimalUser
        //        {
        //            Username = user.Username,
        //            Token = Guid.NewGuid().ToString(),
        //            Phone = user.Phone,
        //            Email = user.Email,
        //            LikedAds = user.LikedAds
        //        };
        //        // this is the only place that can add users to currently logged in user list
        //        _currentlyLoggedInUsers.Add(authenticatedUser);
        //        _logger.Log($"User [ {username} ] logged in.");
        //        return JsonSerializer.SerializeToUtf8Bytes<MinimalUser>(authenticatedUser);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogException(e);
        //        return null;
        //    }
        //}

        //public bool UpdateLikedAds(string token, byte[] newAdsJson)
        //{
        //    try
        //    {
        //        List<int> newAds = JsonSerializer.Deserialize<List<int>>(newAdsJson);

        //        // remove deleted cars from liked ads list
        //        newAds.RemoveAll(id => !_carList.Exists(car => car.Id == id));

        //        MinimalUser minimal = _currentlyLoggedInUsers.Find((minimalUser) => minimalUser.Token == token);
        //        if (minimal == null)
        //            return false;
        //        minimal.LikedAds = newAds;
        //        User original = _userList.Find((User user) => minimal.Username == user.Username);
        //        original.LikedAds = newAds;

        //        // write updated user data to file
        //        _fileWriter.WriteUserData(original);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogException(e);
        //        return false;
        //    }
        //}

        //public bool DeleteCar(int id)
        //{
        //    // remove this car from all users liked cars lists
        //    _userList.ForEach(user =>
        //    {
        //        if (user.LikedAds.Remove(id))
        //        {
        //            // if user info is changed, it needs to be saved
        //            _fileWriter.WriteUserData(user);
        //        }
        //    });
        //    // remove this car from currently logged in users liked lists
        //    _currentlyLoggedInUsers.ForEach(user => user.LikedAds.Remove(id));
        //    //foreach (User user in _userList)
        //    //{
        //    //    user.LikedAds.Remove(id);
        //    //}
        //    return _carList.RemoveAll(car => car.Id == id) == 1 && _fileWriter.DeleteCar(id);
        //}

        //public bool DeleteUser(string username)
        //{
        //    // remove ads posted by this user
        //    _carList.RemoveAll(car => car.UploaderUsername == username);
        //    // delete user from currently logged in users
        //    //_currentlyLoggedInUsers.RemoveAll(user => user.Username == username);
        //    return _userList.RemoveAll(user => user.Username == username) == 1 && _fileWriter.DeleteUser(username);
        //}

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

        // returns null if not found
        // this is not used
        //public byte[] GetUserInfoJson(string username)
        //{
        //    User user = _userList.Find(user => user.Username == username);
        //    return user != null ? JsonSerializer.SerializeToUtf8Bytes<User>(user) : null;
        //}

        //public IEnumerable<Car> GetUserLikedAdsJson(string token, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        //{
        //    // check if this user is currently logged in, otherwise his liked ads cannot be given
        //    MinimalUser user = _currentlyLoggedInUsers.Find(user => user.Token == token);
        //    if (user == null)
        //    {
        //        // if user is not logged in
        //        return null;
        //    }
        //    List<Car> likedCars = _carList.Where(car => user.LikedAds.Contains(car.Id)).ToList();
        //    //foreach (int id in user.LikedAds)
        //    //{
        //    //    // if Find returns null (although it should never happen), this will cause problems
        //    //    likedCars.Add(_carList.Find(car => car.Id == id));
        //    //}
        //    //List<Car> carsToReturn = likedCars.Skip(startIndex).Take(amount).ToList();
        //    return GetSortedCarsListJson(sortBy, sortAscending, startIndex, amount, likedCars);
        //}

        //public IEnumerable<Car> GetUserUploadedAdsJson(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        //{
        //    //List<Car> uploadedCars = new List<Car>();
        //    User user = _userList.Find(user => user.Username == username);
        //    // if this user does not exist
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    List<Car> uploadedCars = _carList.Where(car => car.UploaderUsername == username).ToList();
        //    //foreach (Car car in _carList)
        //    //{
        //    //    if (car.UploaderUsername == username)
        //    //    {
        //    //        uploadedCars.Add(car);
        //    //    }
        //    //}
        //    return GetSortedCarsListJson(sortBy, sortAscending, startIndex, amount, uploadedCars);

        //    //List<Car> carsToReturn = uploadedCars.Skip(startIndex).Take(amount).ToList();
        //    //return JsonSerializer.SerializeToUtf8Bytes(carsToReturn);
        //}

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
            //int id = _lastUserId++;
            //user.Id = id;

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
                    return user.Username;
                }
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

        public int UpdateUser(string username, string password, User user)
        {
            // this should return only one user, but if user updates his username to a clashing one, we check for it
            List<User> userToUpdate = _userList.FindAll(u => u.Username == username && u.HashedPassword == EncryptPassword(password, username));
            if (userToUpdate.Count == 0)
            {
                return -1;
            }
            else
            {
                if (userToUpdate.Count == 1)
                {
                    _userList.Remove(userToUpdate[0]);
                    _fileWriter.DeleteUser(userToUpdate[0].Username);
                    _userList.Add(user);
                    return 0;
                }
                else
                {
                    return -2;
                }
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
