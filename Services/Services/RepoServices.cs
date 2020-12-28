using Contracts.Incoming;
using Contracts.Outgoing;
using Models;
using Services.Mappers;
using Services.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RepoServices : IRepoServices
    {
        private readonly IVehicleRepository _repository;

        public RepoServices(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public Task<string> AddFullUser(User user)
        {
            return _repository.AddUser(user);
        }
        public Task<string> AddUser(IncomingUserDTO user)
        {
            return _repository.AddUser(user.ToEntity());
        }
        public async Task<bool> AddVehicle(string username, PostVehicleDTO v)
        {
            return await _repository.AddVehicle(username, v.ToEntity());
        }
        public async Task<OutgoingUserDTO> Authenticate(string username, string password)
        {
            return (await _repository.Authenticate(username, password)).ToOutgoingDTO();
        }
        public Task<bool> DeleteUser(string username)
        {
            return _repository.DeleteUser(username);
        }
        public Task<int> DeleteUsers(IEnumerable<string> usernames)
        {
            return _repository.DeleteUsers(usernames);
        }
        public Task<bool> DeleteVehicle(int carId, string username)
        {
            return _repository.DeleteVehicle(carId, username);
        }
        public Task<int> DeleteVehicles(IEnumerable<int> ids)
        {
            return _repository.DeleteVehicles(ids);
        }
        public Task<int> DisableUsers(IEnumerable<string> usernames)
        {
            return _repository.DisableUsers(usernames);
        }
        public Task<int> EnableUsers(IEnumerable<string> usernames)
        {
            return _repository.EnableUsers(usernames);
        }
        public IEnumerable<OutgoingFullVehicleDTO> GetDisabledAds()
        {
            var v = _repository.GetDisabledAds();
            if(v == null)
                return null;
            return v.Select(x => x.ToOutgoingFullDTO());
        }
        public IEnumerable<OutgoingFullUserDTO> GetDisabledUsers()
        {
            var u = _repository.GetDisabledUsers();
            if(u == null)
                return null;
            return u.Select(x => x.ToOutgoingFullDTO());
        }
        public IEnumerable<OutgoingVehicleDTO> GetFilteredVehicles(VehicleFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = _repository.GetFilteredVehicles(filters, sortBy, sortAscending, startIndex, amount);
            if (v == null)
                return null;
            return v.Select(x => x.ToOutgoingDTO());
        }
        public IEnumerable<OutgoingVehicleDTO> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = _repository.GetSortedVehicles(sortBy, sortAscending, startIndex, amount);
            if (v == null)
                return null;
            return v.Select(x => x.ToOutgoingDTO());
        }
        public async Task<OutgoingUserDTO> GetUser(string username)
        {
            return (await _repository.GetUser(username)).ToOutgoingDTO();
        }
        public async Task<IEnumerable<OutgoingVehicleDTO>> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = await _repository.GetUserLikedAds(username, sortBy, sortAscending, startIndex, amount);
            if (v == null)
                return null;
            return v.Select(x => x.ToOutgoingDTO());
        }
        public async Task<IEnumerable<OutgoingVehicleDTO>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = await _repository.GetUserUploadedAds(username, sortBy, sortAscending, startIndex, amount);
            if (v == null)
                return null;
            return v.Select(x => x.ToOutgoingDTO());
        }
        public async Task<OutgoingFullVehicleDTO> GetVehicle(int id)
        {
            return (await _repository.GetVehicle(id)).ToOutgoingFullDTO();
        }
        public IEnumerable<OutgoingFullVehicleDTO> GetVehicles(IEnumerable<int> ids)
        {
            var v = _repository.GetVehicles(ids);
            if(v == null)
                return null;
            return v.Select(x => x.ToOutgoingFullDTO());
        }
        public Task<int> HideAds(IEnumerable<int> ids)
        {
            return _repository.HideAds(ids);
        }
        public Task<int> UnhideAds(IEnumerable<int> ids)
        {
            return _repository.UnhideAds(ids);
        }
        public Task<bool> UpdateUser(string username, IncomingUserDTO user)
        {
            return _repository.UpdateUser(username, user.ToEntity());
        }
        public async Task<bool> UpdateVehicle(string username, PutVehicleDTO v)
        {
            return await _repository.UpdateVehicle(username, v.ToEntity());
        }
        public async Task<OutgoingFullUserDTO> GetFullUser(string username)
        {
            return (await _repository.GetUser(username)).ToOutgoingFullDTO();
        }

        public async Task<IEnumerable<OutgoingVehicleDTO>> GetVehiclesByImage(Stream image, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = await _repository.GetVehiclesByImage(image, sortBy, sortAscending, startIndex, amount);
            if (v == null)
                return null;
            return v.Select(x => x.ToOutgoingDTO());
        }
    }
}
