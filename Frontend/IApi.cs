using DataTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend
{
    public interface IApi
    {
        event Action NoServerResponse;

        Task<int?> AddCar(Car car);
        Task<bool?> AddUser(User user);
        Task<bool?> DeleteCar(int id);
        Task<bool?> DeleteUser(string username);
        Task<Car> GetCar(int id);
        Task<List<Car>> GetCars(int startIndex, int amount);
        Task<MinimalUser?> GetUser(string username, string hashedPassword);
        Task<List<Car>> SearchVehicles(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<List<Car>> SortBy(SortingCriteria sortBy, int startIndex, int amount, bool sortAscending);
    }
}