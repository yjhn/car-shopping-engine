using DataTypes;
using System.Collections.Generic;
namespace Backend
{
    public interface IDatabase
    {
        // returns: <amount> of vehicles from beginning of the sorted list serialized to UTF-8 JSON
        public IEnumerable<Car> GetSortedCars(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        // returns: <amount> of vehicles from beginning of the filtered and sorted list serialized to UTF-8 JSON
        public IEnumerable<Car> GetFilteredCars(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        public Car GetCar(int id);
        // args: car serialized to UTF-8 JSON
        public bool AddCar(string username, Car car);

        public int DeleteCars(params int[] ids);

        public bool UpdateCar(string username, Car car);
        // returns: true, if removal is successful, false if not
        public bool DeleteCar(int carId, string username);

        // args: user serialized to UTF-8 JSON
        public string AddUser(User user);
        public IEnumerable<Car> GetCars(int[] ids);
        public User Authenticate(string username, string password);
        // returns: user info serialized to UTF-8 JSON
        public User GetUser(string username);

        public IEnumerable<Car> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        public IEnumerable<Car> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        // returns: true, if removal is successful, false if not
        public bool DeleteUser(string username);

        public bool UpdateUser(string username, User user);
        public IEnumerable<Car> GetDisabledAds();
        public int DeleteUsers(string[] usernames);
        public IEnumerable<User> GetDisabledUsers();
    }
}