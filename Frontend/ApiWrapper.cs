using DataTypes;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend
{
    public class ApiWrapper : IApiWrapper
    {
        // all methods in this class may throw various exceptions related to server response codes

        private readonly IServerV2 _api;
        public event Action NoServerResponse = delegate { };

        public ApiWrapper(IServerV2 api)
        {
            _api = api;
        }

        public async Task<Response> PostUser(User user)
        {
            try
            {
                var result = await _api.PostUserAsync(ConvertToFrontendUser(user));
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<User> GetUser(string username, string password)
        {
            try
            {
                var user = await _api.GetUserAsync(username, username, password);
                return ConvertToUser(user);
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return null;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return null;
            }
        }

        public async Task<Response> DeleteUser(string username, string password)
        {
            try
            {
                await _api.DeleteUserAsync(username, username, password);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> UpdateUser(string username, string password, User user)
        {
            try
            {
                await _api.PutUserAsync(username, ConvertToFrontendUser(user), username, password);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Car> GetCar(int id)
        {
            try
            {
                var car = await _api.GetVehicleAsync(id);
                return ConvertToCar(car);
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return null;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return null;
            }
        }

        public async Task<Response> PostCar(Car car, string username, string password)
        {
            try
            {
                var result = await _api.PostVehicleAsync(ConvertToFrontendCar(car), username, password);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> UpdateVehicle(Car car, string username, string password)
        {
            try
            {
                await _api.PutVehicleAsync(ConvertToFrontendCar(car), username, password);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> DeleteVehicle(int id, string username, string password)
        {
            try
            {
                await _api.DeleteVehicleAsync(id, username, password);
                return Response.Ok;
            }
            catch (HttpOperationException) { return Response.InvalidResponse; }
            catch (HttpRequestException) { NoServerResponse.Invoke(); return Response.NoResponse; }
        }

        public async Task<List<Car>> GetSortedVehicles(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            try
            {
                var result = await _api.GetSortedVehiclesAsync((int)sortBy, sortAscending, startIndex, amount);
                return GetCarList(result);
            }
            catch (HttpRequestException)
            {
                // this happens when there is no connection
                NoServerResponse.Invoke();
                return null;
            }
        }

        public async Task<List<Car>> GetFilteredVehicles(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            try
            {
                var result = await _api.GetFiteredVehiclesAsync((int)sortBy, sortAscending, startIndex, amount, filters.Brand, filters.Model, filters.Used, filters.PriceFrom,
                    filters.PriceTo, filters.Username, filters.YearFrom, filters.YearTo, (int?)filters.FuelType, (int?)filters.ChassisType);
                return GetCarList(result);
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return null;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return null;
            }
        }

        public async Task<List<Car>> GetUserLikedAds(string username, string password, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            try
            {
                var result = await _api.GetUserLikedAdsAsync(username, username, password, (int)sortBy, sortAscending, startIndex, amount);
                return GetCarList(result);
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return null;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return null;
            }
        }

        public async Task<List<Car>> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            try
            {
                var result = await _api.GetUserUploadedAdsAsync(username, (int)sortBy, sortAscending, startIndex, amount);
                return GetCarList(result);
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return null;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return null;
            }
        }




        // Converter methods //

        private static List<Car> GetCarList(IList<Models.Car> list)
        {
            List<Car> vehicles = new List<Car>();
            foreach (Models.Car c in list)
            {
                vehicles.Add(ConvertToCar(c));
            }
            return vehicles;
        }

        private static Models.Car ConvertToFrontendCar(Car c)
        {
            var car = new Models.Car()
            {
                Id = c.Id,
                UploaderUsername = c.UploaderUsername,
                Price = c.Price,
                UploadDate = c.UploadDate,
                Brand = c.Brand,
                Model = c.Model,
                Used = c.Used,
                DateOfPurchase = ConvertToFrontendYearMonth(c.DateOfPurchase),
                Engine = ConvertToFrontendEngine(c.Engine),
                FuelType = (int)c.FuelType,
                ChassisType = (int)c.ChassisType,
                Color = c.Color,
                GearboxType = (int)c.GearboxType,
                TotalKilometersDriven = c.TotalKilometersDriven,
                DriveWheels = (int)c.DriveWheels,
                Defects = c.Defects,
                SteeringWheelPosition = (int)c.SteeringWheelPosition,
                NumberOfDoors = (int)c.NumberOfDoors,
                NumberOfCylinders = c.NumberOfCylinders,
                NumberOfGears = c.NumberOfGears,
                Seats = c.Seats,
                NextVehicleInspection = ConvertToFrontendYearMonth(c.NextVehicleInspection),
                WheelSize = c.WheelSize,
                Weight = c.Weight,
                EuroStandard = (int)c.EuroStandard,
                OriginalPurchaseCountry = c.OriginalPurchaseCountry,
                Vin = c.Vin,
                AdditionalProperties = c.AdditionalProperties,
                Images = c.Images,
                Comment = c.Comment
            };

            return car;
        }

        private static Models.Engine ConvertToFrontendEngine(Engine engine)
        {
            if (engine == null)
            {
                return null;
            }
            Models.Engine e = new Models.Engine()
            {
                Hp = engine.Hp,
                Kw = engine.Kw,
                Volume = engine.Volume,
                Type = (int)engine.Type
            };
            return e;
        }

        private static Models.YearMonth ConvertToFrontendYearMonth(YearMonth dateOfPurchase)
        {
            if (dateOfPurchase == null)
            {
                return null;
            }
            Models.YearMonth y = new Models.YearMonth()
            {
                Year = dateOfPurchase.Year,
                Month = dateOfPurchase.Month
            };
            return y;
        }

        private static Car ConvertToCar(Frontend.Models.Car c)
        {
            var car = new Car()
            {
                Id = (int)c.Id,
                UploaderUsername = c.UploaderUsername,
                Price = (int)c.Price,
                UploadDate = (DateTime)c.UploadDate,
                Brand = c.Brand,
                Model = c.Model,
                Used = (bool)c.Used,
                DateOfPurchase = ConvertToYearMonth(c.DateOfPurchase),
                Engine = ConvertToEngine(c.Engine),
                FuelType = (FuelType)c.FuelType,
                ChassisType = (ChassisType)c.ChassisType,
                Color = c.Color,
                GearboxType = (GearboxType)c.GearboxType,
                TotalKilometersDriven = (int)c.TotalKilometersDriven,
                DriveWheels = (DriveWheels)c.DriveWheels,
                Defects = (List<string>)c.Defects,
                SteeringWheelPosition = (SteeringWheelPosition)c.SteeringWheelPosition,
                NumberOfDoors = (NumberOfDoors)c.NumberOfDoors,
                NumberOfCylinders = (int)c.NumberOfCylinders,
                NumberOfGears = (int)c.NumberOfGears,
                Seats = (int)c.Seats,
                NextVehicleInspection = ConvertToYearMonth(c.NextVehicleInspection),
                WheelSize = c.WheelSize,
                Weight = (int)c.Weight,
                EuroStandard = (EuroStandard)c.EuroStandard,
                OriginalPurchaseCountry = c.OriginalPurchaseCountry,
                Vin = c.Vin,
                AdditionalProperties = (List<string>)c.AdditionalProperties,
                Images = (List<string>)c.Images,
                Comment = c.Comment
            };

            return car;
        }

        private static Engine ConvertToEngine(Frontend.Models.Engine engine)
        {
            if (engine == null)
            {
                return null;
            }
            Engine e = new Engine()
            {
                Hp = (int)engine.Hp,
                Kw = (int)engine.Kw,
                Volume = (float?)engine.Volume,
                Type = (EngineType)engine.Type
            };
            return e;
        }

        private static YearMonth ConvertToYearMonth(Frontend.Models.YearMonth dateOfPurchase)
        {
            if (dateOfPurchase == null)
            {
                return null;
            }
            YearMonth y = new YearMonth()
            {
                Year = (int)dateOfPurchase.Year,
                Month = (int)dateOfPurchase.Month
            };
            return y;
        }

        private static User ConvertToUser(Frontend.Models.User u)
        {
            // get liked ads manually, because auto cast does not work
            var ads = new List<int>(0);
            foreach (int adId in u.LikedAds)
            {
                ads.Add(adId);
            }

            var user = new User()
            {
                Username = u.Username,
                HashedPassword = u.HashedPassword,
                LikedAds = ads,
                Phone = (long)u.Phone,
                Email = u.Email
            };
            return user;
        }

        private static Frontend.Models.User ConvertToFrontendUser(User u)
        {
            // get liked ads manually, because auto cast does not work
            var ads = new List<int?>(0);
            u.LikedAds.ForEach(id => ads.Add(id));

            var user = new Frontend.Models.User()
            {
                Username = u.Username,
                HashedPassword = u.HashedPassword,
                LikedAds = ads,
                Phone = u.Phone,
                Email = u.Email
            };
            return user;
        }
    }
}
