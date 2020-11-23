using DataTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend
{
    public interface IApiWrapper
    {
        /*
         * int response codes:
         *      0 => Ok
         *     -1 => Failed (bad response code)
         *     -2 => Cannot connect to server
        */


        public event Action NoServerResponse;
        Task<int> DeleteUser(string username, string password);
        Task<int> DeleteVehicle(int id, string username, string password);
        Task<Car> GetCar(int id);
        Task<List<Car>> GetFilteredVehicles(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<List<Car>> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<User> GetUser(string username, string password);
        Task<List<Car>> GetUserLikedAds(string username, string password, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<List<Car>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<int> PostCar(Car car, string username, string password);
        Task<int> PostUser(User user);
        Task<int> UpdateUser(string username, string password, User user);
        Task<int> UpdateVehicle(Car car, string username, string password);
    }
}