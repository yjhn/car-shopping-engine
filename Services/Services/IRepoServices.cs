using Contracts.Incoming;
using Contracts.Outgoing;
using Models;
using Services.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IRepoServices
    {
        Task<string> AddUser(IncomingUserDTO user);
        Task<bool> AddVehicle(string username, IncomingVehicleDTO v);
        Task<OutgoingUserDTO> Authenticate(string username, string password);
        Task<bool> DeleteUser(string username);
        Task<int> DeleteUsers(IList<string> usernames);
        Task<bool> DeleteVehicle(int carId, string username);
        Task<int> DeleteVehicles(IList<int> ids);
        Task<int> DisableUsers(IList<string> usernames);
        Task<int> EnableUsers(IList<string> usernames);
        IEnumerable<Vehicle> GetDisabledAds();
        IEnumerable<User> GetDisabledUsers();
        Task<IEnumerable<OutgoingVehicleDTO>> GetFilteredVehicles(VehicleFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        IEnumerable<OutgoingVehicleDTO> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<OutgoingUserDTO> GetUser(string username);
        Task<User> GetFullUser(string username);
        Task<IEnumerable<OutgoingVehicleDTO>> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<IEnumerable<OutgoingVehicleDTO>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<Vehicle> GetVehicle(int id);
        IEnumerable<Vehicle> GetVehicles(IList<int> ids);
        Task<int> HideAds(IList<int> ids);
        Task<int> UnhideAds(IList<int> ids);
        Task<bool> UpdateUser(string username, IncomingUserDTO user);
        Task<bool> UpdateVehicle(string username, IncomingVehicleDTO v);
    }
}