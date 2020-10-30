using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Backend
{
    public class CarList : ICarDb
    {
        private readonly List<Car> _carList;
        private readonly FileReader _carDataReader;
        private readonly FileWriter _carDataWriter;
        public int LastCarId { get; private set; }
        private readonly Logger _logger;

        public CarList(Logger logger, string carDbPath = null)
        {
            _logger = logger;
            _carDataReader = new FileReader(logger, carDbPath);
            _carDataWriter = new FileWriter(logger, carDbPath);
            _carList = _carDataReader.GetAllCarData();
            LastCarId = _carDataReader.LastCarId;
        }

        // returns List<Car> serialized to JSON
        public byte[] GetCarList(int startIndex, int amount)
        {
            // convert this to string
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(_carList.Skip(startIndex).Take(amount).ToList<Car>());
        }

        public byte[] SortBy(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            return SortBy(sortBy, sortAscending, startIndex, amount, null);
        }

        private byte[] SortBy(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount, List<Car> carListToSort = null)
        {
            if (carListToSort == null)
            {
                carListToSort = _carList;
            }
            carListToSort.SortBy(sortBy, sortAscending);
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carListToSort.Skip(startIndex).Take(amount).ToList<Car>());
        }

        public byte[] Filter(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            List<Car> filteredCarList = _carList;

            if (filters.PriceFrom.HasValue && filters.PriceTo.HasValue)
                filteredCarList = (from car in filteredCarList where (car.Price >= filters.PriceFrom && car.Price <= filters.PriceTo) select car).ToList();
            if (!string.IsNullOrEmpty(filters.Username))
                filteredCarList = (from car in filteredCarList where car.UploaderUsername.Equals(filters.Username) select car).ToList();
            if (filters.YearFrom.HasValue && filters.YearTo.HasValue)
                filteredCarList = (from car in filteredCarList where (car.DateOfPurchase.year >= filters.YearFrom && car.DateOfPurchase.year <= filters.YearTo) select car).ToList();
            if (filters.FuelType.HasValue)
                filteredCarList = (from car in filteredCarList where car.FuelType == filters.FuelType select car).ToList();

            return SortBy(sortBy, sortAscending, startIndex, amount, filteredCarList);
        }

        // params: Car serialized to JSON
        public bool AddCar(byte[] car)
        {
            try
            {
                Car c = JsonSerializer.Deserialize<Car>(car);
                c.Id = LastCarId + 1;
                LastCarId++;
                _carList.Add(c);
                _carDataWriter.WriteCarData(c);
                return true;
            }
            catch (JsonException e)
            {
                _logger.LogException(new Exception("Failed to write car data due to bad serialization", e));
                return false;
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return false;
            }
        }

        public byte[] GetCar(int id)
        {
            Car car = _carList.Find(car => car.Id == id);
            return car != null ? JsonSerializer.SerializeToUtf8Bytes<Car>(car) : null;
        }

        public bool DeleteCar(int id)
        {
            foreach (Car car in _carList)
            {
                if (car.Id == id)
                {
                    _carList.Remove(car);
                    _carDataWriter.DeleteCar(id);
                    return true;
                }
            }
            return false;
        }

        public List<int> GetUserAdIds(string username)
        {
            List<int> ids = new List<int>();
            foreach (Car car in _carList)
            {
                if (car.UploaderUsername.Equals(username))
                {
                    ids.Add(car.Id);
                }
            }
            return ids;
        }
    }
}
