using Contracts.Incoming;
using Contracts.Outgoing;
using Models;
using Services.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IRepoServices
    {
        Task<string> AddFullUser(User user);
        Task<string> AddUser(IncomingUserDTO user);
        Task<bool> AddVehicle(string username, PostVehicleDTO v);
        Task<OutgoingUserDTO> Authenticate(string username, string password);
        Task<bool> DeleteUser(string username);
        Task<int> DeleteUsers(IEnumerable<string> usernames);
        Task<bool> DeleteVehicle(int carId, string username);
        Task<int> DeleteVehicles(IEnumerable<int> ids);
        Task<int> DisableUsers(IEnumerable<string> usernames);
        Task<int> EnableUsers(IEnumerable<string> usernames);
        IEnumerable<OutgoingFullVehicleDTO> GetDisabledAds();
        IEnumerable<OutgoingFullUserDTO> GetDisabledUsers();
        IEnumerable<OutgoingVehicleDTO> GetFilteredVehicles(VehicleFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        IEnumerable<OutgoingVehicleDTO> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<OutgoingUserDTO> GetUser(string username);
        Task<OutgoingFullUserDTO> GetFullUser(string username);
        Task<IEnumerable<OutgoingVehicleDTO>> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<IEnumerable<OutgoingVehicleDTO>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<OutgoingFullVehicleDTO> GetVehicle(int id);
        IEnumerable<OutgoingFullVehicleDTO> GetVehicles(IEnumerable<int> ids);
        Task<int> HideAds(IEnumerable<int> ids);
        Task<int> UnhideAds(IEnumerable<int> ids);
        Task<bool> UpdateUser(string username, IncomingUserDTO user);
        Task<bool> UpdateVehicle(string username, PutVehicleDTO v);
        Task<IEnumerable<OutgoingVehicleDTO>> GetVehiclesByImage(Stream image, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
    }
}