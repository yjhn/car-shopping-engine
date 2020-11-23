using DataTypes;
using System.Collections.Generic;
namespace Backend
{
    public interface IDatabase
    {
        //public int GetLastCarId();

        // returns: <amount> of vehicles from beginning of the sorted list serialized to UTF-8 JSON
        public IEnumerable<Car> GetSortedCars(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        // returns: <amount> of vehicles from beginning of the filtered and sorted list serialized to UTF-8 JSON
        public IEnumerable<Car> GetFilteredCars(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        public Car GetCar(int id);
        // args: car serialized to UTF-8 JSON
        public bool AddCar(string username, string password, Car car);

        public bool UpdateCar(string username, string password, Car car);
        // returns: true, if removal is successful, false if not
        public bool DeleteCar(int carId, string username, string password);

        // args: user serialized to UTF-8 JSON
        public string AddUser(User user);

        // returns: user info serialized to UTF-8 JSON
        public User GetUser(string username, string password);

        public IEnumerable<Car> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        public IEnumerable<Car> GetUserLikedAds(string username, string password, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        // returns: true, if such a user exists, false otherwise
        // this will not be needed
        //public byte[] Authenticate(string username, string hashedPassword);

        // returns: true, if removal is successful, false if not
        public bool DeleteUser(string username, string password);
        //public bool UpdateLikedAds(string token, byte[] newAdsJson);

        ///**
        // * Status codes:
        // *  0  -> updated
        // *  -1 -> not found
        // *  -2 -> username clash (user tried to change username to already existing one)
        //**/
        public bool UpdateUser(string username, string password, User user);
    }
}