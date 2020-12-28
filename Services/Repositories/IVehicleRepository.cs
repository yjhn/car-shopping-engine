using Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IVehicleRepository
    {
        Task<string> AddUser(User user);
        Task<bool> AddVehicle(string username, Vehicle car);
        Task<User> Authenticate(string username, string password);
        Task<bool> DeleteUser(string username);
        Task<int> DeleteUsers(IEnumerable<string> usernames);
        Task<bool> DeleteVehicle(int carId, string username);
        Task<int> DeleteVehicles(IEnumerable<int> ids);
        Task<int> DisableUsers(IEnumerable<string> usernames);
        Task<int> EnableUsers(IEnumerable<string> usernames);
        IEnumerable<Vehicle> GetDisabledAds();
        IEnumerable<User> GetDisabledUsers();
        IEnumerable<Vehicle> GetFilteredVehicles(VehicleFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        IEnumerable<Vehicle> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<User> GetUser(string username);
        Task<IEnumerable<Vehicle>> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<IEnumerable<Vehicle>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<Vehicle> GetVehicle(int id);
        IEnumerable<Vehicle> GetVehicles(IEnumerable<int> ids);
        Task<int> HideAds(IEnumerable<int> ids);
        Task<int> UnhideAds(IEnumerable<int> ids);
        Task<bool> UpdateUser(string username, User user);
        Task<bool> UpdateVehicle(string username, Vehicle car);
        Task<VehicleModel> GetVehicleModel(string brand, string model);
        Task<IEnumerable<Vehicle>> GetVehiclesByImage(Stream image, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
    }
}