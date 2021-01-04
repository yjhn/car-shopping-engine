using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Services;
using System.IO;
using Services.Dependencies;

namespace Services.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly CarNetApiClient _carNetClient;
        private readonly DbSet<Vehicle> _vehicles;
        private readonly DbSet<User> _users;
        private readonly DbSet<VehicleModel> _vehicleModels;

        public VehicleRepository(DatabaseContext dbContext, CarNetApiClient carNetClient)
        {
            _carNetClient = carNetClient;
            _dbContext = dbContext;
            _vehicles = dbContext.Vehicles;
            _users = dbContext.Users;
            _vehicleModels = dbContext.VehicleModels;
        }

        public IEnumerable<Vehicle> GetFilteredVehicles(VehicleFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            IEnumerable<Vehicle> filteredVehicleList = _vehicles.Include(v => v.VehicleModel);

            if (!string.IsNullOrEmpty(filters.Brand))
                filteredVehicleList = (from v in filteredVehicleList where v.VehicleModel.Brand.Contains(filters.Brand) select v);
            if (!string.IsNullOrEmpty(filters.Model))
                filteredVehicleList = (from v in filteredVehicleList where v.VehicleModel.Model.Contains(filters.Model) select v);
            if (filters.Used.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Used == filters.Used select v);
            if (filters.PriceFrom.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Price >= filters.PriceFrom select v);
            if (filters.PriceTo.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Price <= filters.PriceTo select v);
            if (filters.FuelType.HasValue)
                filteredVehicleList = (from v in filteredVehicleList where v.Engine.FuelType == filters.FuelType select v);
            filteredVehicleList = FilterByYear(filters.YearFrom, filters.YearTo, filteredVehicleList);

            // this is currently not used
            //if (!string.IsNullOrEmpty(filters.Username))
            //    filteredVehicleList = (from v in filteredVehicleList where v.UploaderUsername.ToLower() == filters.Username select v).ToList();

            return GetSortedVehiclesList(sortBy, sortAscending, startIndex, amount, (IQueryable<Vehicle>)filteredVehicleList);
        }

        private IEnumerable<Vehicle>FilterByYear(int? start, int? end, IEnumerable<Vehicle> list = null)
        {
            if(list == null)
                list = _vehicles;
            if (start.HasValue)
                list = (from v in list where v.Purchased.Year >= start select v);
            if (end.HasValue)
                list = (from v in list where v.Purchased.Year <= end select v);

            return list;
        }

        public IEnumerable<Vehicle> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            return GetSortedVehiclesList(sortBy, sortAscending, startIndex, amount);
        }

        public IEnumerable<Vehicle> GetVehicles(IEnumerable<int> ids)
        {
            return _vehicles.Include(v => v.VehicleModel).Where(c => ids.Contains(c.Id));
        }

        private IEnumerable<Vehicle> GetSortedVehiclesList(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount, IQueryable<Vehicle> listToSort = null)
        {
            if (listToSort == null)
                listToSort = _vehicles;
            listToSort = listToSort.Include(v => v.VehicleModel);
            listToSort.SortBy(sortBy, sortAscending);
            return listToSort.Skip(startIndex).Take(amount);
        }

        public async Task<bool> DeleteVehicle(int carId, string username)
        {
            // find vehicle to delete
            Vehicle v = _vehicles.Find(carId);

            // only procedd if user exists and is uploader of the vehicle
            var user = await GetUser(username);
            if (v != null && user != null && (v.Uploader == user || user.Role == UserRole.Admin))
            {
                // remove this vehicle from all users liked vehicles lists
                _vehicles.Remove(v);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<string> AddUser(User user)
        {
            // do not allow null fields
            if (user.Username == null || user.HashedPassword == null || user.Email == null)
                return null;

            var u = await _users.FindAsync(user.Username);
            if (u == null)
            {
                int[] ids = user.LikedAds.Select(v => v.Id).ToArray();
                user.LikedAds = _vehicles.Where(v => ids.Contains(v.Id)).ToList();
                _users.Add(user);
                await _dbContext.SaveChangesAsync();
                return user.Username;
            }
            else
                return null;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var u = await _users.FindAsync(username);
            if (u != null)
            {
                var encryptedPassword = Utilities.EncryptPassword(password, username);
                return u.HashedPassword.SequenceEqual(encryptedPassword) ? u : null;
            }
            return null;
        }

        public async Task<User> GetUser(string username)
        {
            var u = await _users.FindAsync(username);
            if (u == null)
                return null;
            await _dbContext.Entry(u).Collection(user => user.UploadedAds).LoadAsync();
            await _dbContext.Entry(u).Collection(user => user.LikedAds).LoadAsync();
            return u;
        }

        public async Task<IEnumerable<Vehicle>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            User user = await GetUser(username);
            return user == null ? null : GetSortedVehiclesList(sortBy, sortAscending, startIndex, amount, _vehicles.Where(v => v.UploaderUsername == user.Username));
        }

        public async Task<IEnumerable<Vehicle>> GetUserLikedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            User user = await GetUser(username);
            return user == null ? null : GetSortedVehiclesList(sortBy, sortAscending, startIndex, amount, _vehicles.Where(v => user.LikedAds.Contains(v)));
        }

        public async Task<bool> DeleteUser(string username)
        {
            User user = await GetUser(username);
            if (user == null)
                return false;
            else
            {
                // remove user uploaded vehicles
                // this has to be done manually as it is not done by the database
                _vehicles.RemoveRange(_vehicles.Where(v => v.UploaderUsername == username));
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
                // the user does not exist
                return false;
            }
            else
            {
                // add uploaded vehicles
                userToUpdate.Phone = user.Phone;
                userToUpdate.Email = user.Email;
                userToUpdate.Disabled = user.Disabled;
                userToUpdate.HashedPassword = user.HashedPassword;
                int[] ids = user.LikedAds.Select(v => v.Id).ToArray();
                userToUpdate.LikedAds = _vehicles.Where(v => ids.Contains(v.Id)).ToList();

                _users.Update(userToUpdate);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> AddVehicle(string username, Vehicle v)
        {
            User user = await GetUser(username);
            if (user == null)
                return false;
            else
            {
                v.Uploader = user;
                v.VehicleModel = await GetOrCreateVehicleModel(v.VehicleModel.Brand, v.VehicleModel.Model);
                _vehicles.Add(v);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateVehicle(string username, Vehicle vehicle)
        {
            User user = await GetUser(username);
            if (user == null)
                return false;
            else
            {
                var v = await _vehicles.FindAsync(vehicle.Id);
                if (v == null || (v.Uploader != user && user.Role != UserRole.Admin))
                    return false;
                else
                {
                    // transfer properties to the vehicle being updated
                    v.AdditionalProperties = vehicle.AdditionalProperties;
                    v.ChassisType = vehicle.ChassisType;
                    v.Color = vehicle.Color;
                    v.Comment = vehicle.Comment;
                    v.Defects = vehicle.Defects;
                    v.DriveWheels = vehicle.DriveWheels;
                    v.Engine = vehicle.Engine;
                    v.Gearbox = vehicle.Gearbox;
                    v.Hidden = vehicle.Hidden;
                    v.Id = vehicle.Id;
                    v.Images = vehicle.Images;
                    v.KilometersDriven = vehicle.KilometersDriven;
                    v.NextVehicleInspection = vehicle.NextVehicleInspection;
                    v.NumberOfDoors = vehicle.NumberOfDoors;
                    v.OriginalPurchaseCountry = vehicle.OriginalPurchaseCountry;
                    v.Price = vehicle.Price;
                    v.Purchased = vehicle.Purchased;
                    v.Seats = vehicle.Seats;
                    v.SteeringWheelSide = vehicle.SteeringWheelSide;
                    v.Used = vehicle.Used;
                    v.Vin = vehicle.Vin;
                    v.Weight = vehicle.Weight;
                    v.WheelSize = vehicle.WheelSize;
                    v.VehicleModel = await GetOrCreateVehicleModel(vehicle.VehicleModel.Brand, vehicle.VehicleModel.Model);

                    _vehicles.Update(v);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            var v = await _vehicles.FindAsync(id);
            if (v == null)
                return null;
            await _dbContext.Entry(v).Reference(v => v.VehicleModel).LoadAsync();
            return v;
        }

        public async Task<int> DeleteVehicles(IEnumerable<int> ids)
        {
            _vehicles.RemoveRange(_vehicles.Where(v => ids.Contains(v.Id)));
            return await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Vehicle> GetDisabledAds()
        {
            return _vehicles.Include(v => v.VehicleModel).Where(c => c.Hidden);
        }

        public async Task<int> DeleteUsers(IEnumerable<string> usernames)
        {
            foreach (string u in usernames)
            {
                // remove user uploaded vehicles
                // this has to be done manually as it is not done by the database
                _vehicles.RemoveRange(_vehicles.Where(v => v.UploaderUsername == u));
            }
            _users.RemoveRange(_users.Where(u => usernames.Contains(u.Username)));
            return await _dbContext.SaveChangesAsync();
        }
        public IEnumerable<User> GetDisabledUsers()
        {
            return _users.Where(u => u.Disabled);
        }

        public async Task<int> UnhideAds(IEnumerable<int> ids)
        {
            var ads = _vehicles.Where(v => ids.Contains(v.Id));
            if (ads == null)
                return 0;
            foreach (Vehicle v in ads)
            {
                v.Hidden = false;
                _vehicles.Update(v);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> HideAds(IEnumerable<int> ids)
        {
            var ads = _vehicles.Where(v => ids.Contains(v.Id));
            if (ads == null)
                return 0;
            foreach (Vehicle v in ads)
            {
                v.Hidden = true;
                _vehicles.Update(v);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DisableUsers(IEnumerable<string> usernames)
        {
            // we may need to hide ads of the disabled users

            var users = _users.Where(u => usernames.Contains(u.Username));
            if (users == null)
                return 0;
            foreach (User u in users)
            {
                u.Disabled = true;
                _users.Update(u);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> EnableUsers(IEnumerable<string> usernames)
        {
            var users = _users.Where(u => usernames.Contains(u.Username));
            if (users == null)
                return 0;
            foreach (User u in users)
            {
                u.Disabled = false;
                _users.Update(u);
            }
            return await _dbContext.SaveChangesAsync();
        }

        // this will probably crash due to the fact that vehicle models are not loaded by default
        public async Task<IEnumerable<Vehicle>> GetVehiclesByImage(Stream image, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            Response carNetResponse = await _carNetClient.DetectVehicle(image);
            if (carNetResponse.Is_success)
            {
                // we only care about the first detection, as it will
                // hopefully contain the main vehicle in the image
                var detection = carNetResponse.Detections.First();

                // we only care about the highest probability vehicle
                var vehicle = detection.Mmg.First();
                var make = vehicle.Make_name;
                var model = vehicle.Model_name;

                // years format: <begin>-<end>
                var years = vehicle.Years.Split('-');
                int yearStart = Convert.ToInt32(years[0]);
                int yearEnd = Convert.ToInt32(years[1]);

                List<VehicleModel> brandCandidates = new();
                List<VehicleModel> modelCandidates = new();

                // find similar vehicle models
                foreach (VehicleModel m in _vehicleModels.Include(m => m.Vehicles))
                {
                    if (m.Brand.Contains(make) || make.Contains(m.Brand))
                    {
                        brandCandidates.Add(m);
                        if (m.Model.Contains(model) || model.Contains(m.Model))
                            modelCandidates.Add(m);
                    }
                }

                List<Vehicle> vehicles = new();
                if (modelCandidates.Count > 0)
                {
                    vehicles.AddRange(modelCandidates.SelectMany(m => m.Vehicles));

                    // if there are too many results, filter by year
                    if (vehicles.Count > amount)
                    {
                        var v = FilterByYear(yearStart, yearEnd,vehicles);
                        if (v.Count() > amount)
                            return v.Take(amount);
                        return v;
                    }
                }

                if (vehicles.Count < amount)
                {
                    vehicles.AddRange(brandCandidates.SelectMany(m => m.Vehicles));

                    // if there are too many results, filter by year
                    if (vehicles.Count > amount)
                    {
                        var v = FilterByYear(yearStart, yearEnd, vehicles);
                        if (v.Count() > amount)
                            return v.Take(amount);
                        return v;
                    }
                }

                if (vehicles.Count > 0)
                    return vehicles;
            }
            return null;
        }

        public Task<VehicleModel> GetVehicleModel(string brand, string model)
        {
            // Because SQL Server by default is case insensitive, we don't need
            // to explicitly specify case insensitivity
            return _vehicleModels.FirstOrDefaultAsync(m =>
                (m.Brand.Contains(brand) || brand.Contains(m.Brand)) &&
                (m.Model.Contains(model) || model.Contains(m.Model)));
        }

        private async Task<VehicleModel> GetOrCreateVehicleModel(string brand, string model)
        {
            var m = await GetVehicleModel(brand, model);
            if (m == null)
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
