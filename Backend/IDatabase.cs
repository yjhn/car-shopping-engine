using DataTypes;
using System.Collections.Generic;
namespace Backend
{
    public interface IDatabase
    {
        public int GetLastCarId();

        // returns: <amount> of vehicles from beginning of the sorted list serialized to UTF-8 JSON
        public byte[] GetSortedCarsJson(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);

        // returns: <amount> of vehicles from beginning of the filtered and sorted list serialized to UTF-8 JSON
        public byte[] GetFilteredCarsJson(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);


        // args: car serialized to UTF-8 JSON
        public bool AddCarJson(byte[] car);

        // returns: true, if removal is successful, false if not
        public bool DeleteCar(int id);


        // args: user serialized to UTF-8 JSON
        public bool AddUserJson(byte[] user);

        // returns: user info serialized to UTF-8 JSON
        public byte[] GetUserInfoJson(string username);

        public byte[] GetUserUploadedAds(string username, int startIndex, int amount);

        public byte[] GetUserLikedAds(string username, int startIndex, int amount);

        // returns: true, if such a user exists, false otherwise
        public byte[] Authenticate(string username, string hashedPassword);

        // returns: true, if removal is successful, false if not
        public bool DeleteUser(string username);
        public bool UpdateLikedAds(string token, List<int> newAds);
    }
}