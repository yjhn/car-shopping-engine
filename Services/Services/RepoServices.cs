using Contracts.Incoming;
using Contracts.Outgoing;
using Models;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RepoServices : IRepoServices
    {
        private readonly IVehicleRepository _repository;
        private readonly UserMapper _userMapper;
        private readonly VehicleMapper _vehicleMapper;

        public RepoServices(IVehicleRepository repository)
        {
            _repository = repository;
            _userMapper = new UserMapper(repository);
            _vehicleMapper = new VehicleMapper(repository);
        }

        public Task<string> AddUser(IncomingUserDTO user)
        {
            return _repository.AddUser(_userMapper.ToEntity(user));
        }
        public async Task<bool> AddVehicle(string username, IncomingVehicleDTO v)
        {
            return await _repository.AddVehicle(username, await _vehicleMapper.ToEntity(v));
        }
        public async Task<OutgoingUserDTO> Authenticate(string username, string password)
        {
            return _userMapper.ToOutgoingDTO(await _repository.Authenticate(username, password));
        }
        public Task<bool> DeleteUser(string username)
        {
            return _repository.DeleteUser(username);
        }
        public Task<int> DeleteUsers(IList<string> usernames)
        {
            return _repository.DeleteUsers(usernames);
        }
        public Task<bool> DeleteVehicle(int carId, string username)
        {
            return _repository.DeleteVehicle(carId, username);
        }
        public Task<int> DeleteVehicles(IList<int> ids)
        {
            return _repository.DeleteVehicles(ids);
        }
        public Task<int> DisableUsers(IList<string> usernames)
        {
            return _repository.DisableUsers(usernames);
        }
        public Task<int> EnableUsers(IList<string> usernames)
        {
            return _repository.EnableUsers(usernames);
        }
        public IEnumerable<Vehicle> GetDisabledAds()
        {
            return _repository.GetDisabledAds();
        }
        public IEnumerable<User> GetDisabledUsers()
        {
            return _repository.GetDisabledUsers();
        }
        public async Task<IEnumerable<OutgoingVehicleDTO>> GetFilteredVehicles(VehicleFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = await _repository.GetFilteredVehicles(filters, sortBy, sortAscending, startIndex, amount);
            if (v == null)
            {
                return null;
            }
            return v.Select(x => _vehicleMapper.ToOutgoingDTO(x));
        }
        public IEnumerable<OutgoingVehicleDTO> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = _repository.GetSortedVehicles(sortBy, sortAscending, startIndex, amount);
            if (v == null)
            {
                return null;
            }
            return v.Select(x => _vehicleMapper.ToOutgoingDTO(x));
        }
        public async Task<OutgoingUserDTO> GetUser(string username)
        {
            return _userMapper.ToOutgoingDTO(await _repository.GetUser(username));
        }
        public async Task<IEnumerable<OutgoingVehicleDTO>> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = await _repository.GetUserLikedAds(username, sortBy, sortAscending, startIndex, amount);
            if (v == null)
            {
                return null;
            }
            return v.Select(x => _vehicleMapper.ToOutgoingDTO(x));
        }
        public async Task<IEnumerable<OutgoingVehicleDTO>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            var v = await _repository.GetUserUploadedAds(username, sortBy, sortAscending, startIndex, amount);
            if (v == null)
            {
                return null;
            }
            return v.Select(x => _vehicleMapper.ToOutgoingDTO(x));
        }
        public Task<Vehicle> GetVehicle(int id)
        {
            return _repository.GetVehicle(id);
        }
        public IEnumerable<Vehicle> GetVehicles(IList<int> ids)
        {
            return _repository.GetVehicles(ids);
        }
        public Task<int> HideAds(IList<int> ids)
        {
            return _repository.HideAds(ids);
        }
        public Task<int> UnhideAds(IList<int> ids)
        {
            return _repository.UnhideAds(ids);
        }
        public Task<bool> UpdateUser(string username, IncomingUserDTO user)
        {
            return _repository.UpdateUser(username, _userMapper.ToEntity(user));
        }
        public async Task<bool> UpdateVehicle(string username, IncomingVehicleDTO v)
        {
            return await _repository.UpdateVehicle(username, await _vehicleMapper.ToEntity(v));
        }
        public Task<User> GetFullUser(string username)
        {
            return _repository.GetUser(username);
        }
    }
}
