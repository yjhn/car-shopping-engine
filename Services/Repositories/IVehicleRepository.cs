using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IVehicleRepository
    {
        Task<string> AddUser(User user);
        Task<bool> AddVehicle(string username, Vehicle car);
        Task<User> Authenticate(string username, string password);
        Task<bool> DeleteUser(string username);
        Task<int> DeleteUsers(IList<string> usernames);
        Task<bool> DeleteVehicle(int carId, string username);
        Task<int> DeleteVehicles(IList<int> ids);
        Task<int> DisableUsers(IList<string> usernames);
        Task<int> EnableUsers(IList<string> usernames);
        IEnumerable<Vehicle> GetDisabledAds();
        IEnumerable<User> GetDisabledUsers();
        Task<IEnumerable<Vehicle>> GetFilteredVehicles(VehicleFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        IEnumerable<Vehicle> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<User> GetUser(string username);
        Task<IEnumerable<Vehicle>> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<IEnumerable<Vehicle>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<Vehicle> GetVehicle(int id);
        IEnumerable<Vehicle> GetVehicles(IList<int> ids);
        Task<int> HideAds(IList<int> ids);
        Task<int> UnhideAds(IList<int> ids);
        Task<bool> UpdateUser(string username, User user);
        Task<bool> UpdateVehicle(string username, Vehicle car);
        Task<VehicleModel> GetVehicleModel(string brand, string model);
        Task<VehicleModel> GetOrCreateVehicleModel(string brand, string model);
    }
}