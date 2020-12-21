using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Services;

namespace Services.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IDatabaseContext _dbContext;
        private readonly DbSet<Vehicle> _vehicles;
        private readonly DbSet<User> _users;
        private readonly DbSet<VehicleModel> _vehicleModels;

        public VehicleRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _vehicles = dbContext.Vehicles;
            _users = dbContext.Users;
            _vehicleModels = dbContext.VehicleModels;
        }

        public async Task<IEnumerable<Vehicle>> GetFilteredVehicles(VehicleFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            IQueryable<Vehicle> filteredVehicleList = _vehicles;

            if (!string.IsNullOrEmpty(filters.Brand))
                filteredVehicleList = (from v in filteredVehicleList where v.VehicleModel.Brand.ToLower().Contains(filters.Brand) select v);
            if (!string.IsNullOrEmpty(filters.Model))
                filteredVehicleList = (from v in filteredVehicleList where v.VehicleModel.Model.ToLower().Contains(filters.Model) select v);
            if (filters.Used.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Used == filters.Used select v);
            if (filters.PriceFrom.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Price >= filters.PriceFrom select v);
            if (filters.PriceTo.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Price <= filters.PriceTo select v);
            if (filters.YearFrom.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Purchased.Year >= filters.YearFrom select v);
            if (filters.YearTo.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Purchased.Year <= filters.YearTo select v);
            if (filters.FuelType.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Engine.FuelType == filters.FuelType select v);

            // this is currently not used
            //if (!string.IsNullOrEmpty(filters.Username))
            //    filteredVehicleList = (from v in filteredVehicleList where v.UploaderUsername.ToLower() == filters.Username select v).ToList();

            return GetSortedVehiclesList(sortBy, sortAscending, startIndex, amount, await filteredVehicleList.ToListAsync());
        }

        public IEnumerable<Vehicle> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            return GetSortedVehiclesList(sortBy, sortAscending, startIndex, amount);
        }

        public IEnumerable<Vehicle> GetVehicles(IList<int> ids)
        {
            return _vehicles.Where(c => ids.Contains(c.Id));
        }

        private IEnumerable<Vehicle> GetSortedVehiclesList(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount, IEnumerable<Vehicle> listToSort = null)
        {
            if (listToSort == null)
            {
                listToSort = _vehicles;
            }
            listToSort.SortBy(sortBy, sortAscending);
            return listToSort.Skip(startIndex).Take(amount);
        }

        public async Task<bool> DeleteVehicle(int carId, string username)
        {
            // find car to delete
            Vehicle v = _vehicles.Find(carId);
            // only procedd if user exists and is uploader of the vehicle
            if (GetUser(username) != null && v != null && v.Uploader.Username == username)
            {
                // remove this car from all users liked cars lists
                await _users.ForEachAsync(u => u.LikedAds.Remove(v));
                _vehicles.Remove(v);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> AddUser(User user)
        {
            // do not allow null fields
            if (user.Username == null || user.HashedPassword == null || user.LikedAds == null || user.Email == null)
            {
                return null;
            }

            var u = await _users.FindAsync(user.Username);
            if (u == null)
            {
                // only admin can set the roles
                if (user.Role == null)
                {
                    user.Role = UserRole.User;
                }
                else
                {
                    await _users.AddAsync(user);
                }
                await _dbContext.SaveChangesAsync();
                return user.Username;
            }
            else
            {
                // null => user already exists
                return null;
            }
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var u = await _users.FindAsync(username);
            if (u != null)
            {
                return u;
                return u.HashedPassword == Utilities.EncryptPassword(password, username) ? u : null;
            }
            return null;
        }

        public async Task<User> GetUser(string username)
        {
            return await _users.FindAsync(username);
        }

        public async Task<IEnumerable<Vehicle>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            User user = await GetUser(username);
            if (user == null)
            {
                return null;
            }
            else
            {
                return GetSortedVehiclesList(sortBy, sortAscending, startIndex, amount, _vehicles.Where(car => car.UploaderUsername == user.Username));
            }
        }

        public async Task<IEnumerable<Vehicle>> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            User user = await GetUser(username);
            if (user == null)
            {
                return null;
            }
            else
            {
                return GetSortedVehiclesList(sortBy, sortAscending, startIndex, amount, _vehicles.Where(car => user.LikedAds.Contains(car)));
            }
        }

        public async Task<bool> DeleteUser(string username)
        {
            User user = await GetUser(username);
            if (user == null)
            {
                return false;
            }
            else
            {
                _users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateUser(string username, User user)
        {
            User userToUpdate = await GetUser(username);
            if (userToUpdate == null)
            {
                return false;
            }
            else
            {
                _users.Update(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> AddVehicle(string username, Vehicle car)
        {
            User user = await GetUser(username);
            if (user == null)
            {
                return false;
            }
            else
            {
                await _vehicles.AddAsync(car);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateVehicle(string username, Vehicle car)
        {
            User user = await GetUser(username);
            if (user == null)
            {
                return false;
            }
            else
            {
                var v = await _vehicles.FindAsync(car.Id);
                if (v == null)
                {
                    return false;
                }
                else
                {
                    _vehicles.Update(car);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await _vehicles.FindAsync(id);
        }

        public async Task<int> DeleteVehicles(IList<int> ids)
        {
            _vehicles.RemoveRange(_vehicles.Where(v => ids.Contains(v.Id)));
            return await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Vehicle> GetDisabledAds()
        {
            return _vehicles.Where(c => c.Hidden);
        }

        public async Task<int> DeleteUsers(IList<string> usernames)
        {
            _users.RemoveRange(_users.Where(u => usernames.Contains(u.Username)));
            return await _dbContext.SaveChangesAsync();
        }
        public IEnumerable<User> GetDisabledUsers()
        {
            return _users.Where(u => u.Disabled);
        }

        public async Task<int> UnhideAds(IList<int> ids)
        {
            var ads = _vehicles.Where(v => ids.Contains(v.Id));
            foreach (Vehicle v in ads)
            {
                _vehicles.Update(v);
                v.Hidden = false;
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> HideAds(IList<int> ids)
        {
            var ads = _vehicles.Where(v => ids.Contains(v.Id));
            foreach (Vehicle v in ads)
            {
                _vehicles.Update(v);
                v.Hidden = true;
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DisableUsers(IList<string> usernames)
        {
            var users = _users.Where(u => usernames.Contains(u.Username));
            foreach (User u in users)
            {
                _users.Update(u);
                u.Disabled = true;
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> EnableUsers(IList<string> usernames)
        {
            var users = _users.Where(u => usernames.Contains(u.Username));
            foreach (User u in users)
            {
                _users.Update(u);
                u.Disabled = false;
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<VehicleModel> GetVehicleModel(string brand, string model)
        {
            return await _vehicleModels.FindAsync(brand, model);
        }

        public async Task<VehicleModel> GetOrCreateVehicleModel(string brand, string model)
        {
            var m = await _vehicleModels.FindAsync(brand, model);
            if(m == null)
            {
                m = new VehicleModel()
                {
                    Brand = brand,
                    Model = model
                };
                _vehicleModels.Add(m);
            }
            return m;
        }
    }
}
