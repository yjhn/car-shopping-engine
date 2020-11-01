using DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;

namespace Backend
{
    public class CarList : ICarDb
    {
        private List<Car> _carList;
        private readonly FileReader _carDataReader;
        private readonly FileWriter _carDataWriter;
        public int LastCarId { get; private set; }
        private readonly Logger _logger;

        public CarList(Logger logger, string carDbPath = null)
        {
            _logger = logger;
            _carDataReader = new FileReader(logger, carDbPath);
            _carDataWriter = new FileWriter(logger, carDbPath);
            LoadAllCarData();
        }

        private async void LoadAllCarData()
        {
            _carList = await _carDataReader.GetAllCarData();
            LastCarId = _carDataReader.LastCarId;
        }

        // returns List<Car> serialized to JSON
        public byte[] GetCarListJson(int startIndex, int amount)
        {
            // convert this to string -- not sure about this as it would mean double conversion a the other end
            // we could pass all information as strings, but it would have some overhead (JsonSerializer can do this)
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(_carList.Skip(startIndex).Take(amount).ToList<Car>());
        }

        public byte[] GetSortedCarsJson(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            return GetSortedCarsJson(sortBy, sortAscending, startIndex, amount, null);
        }

        private byte[] GetSortedCarsJson(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount, List<Car> carListToSort = null)
        {
            if (carListToSort == null)
            {
                carListToSort = _carList;
            }
            carListToSort.SortBy(sortBy, sortAscending);
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carListToSort.Skip(startIndex).Take(amount).ToList<Car>());
        }

        public byte[] GetFilteredCarsJson(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            List<Car> filteredCarList = _carList;

            if (!string.IsNullOrEmpty(filters.Brand))
                filteredCarList = (from car in filteredCarList where car.Brand.ToLower().Contains(filters.Brand) select car).ToList();
            if (!string.IsNullOrEmpty(filters.Model))
                filteredCarList = (from car in filteredCarList where car.Model.ToLower().Contains(filters.Model) select car).ToList();
            if (filters.Used.HasValue)
                filteredCarList = (from car in filteredCarList where car.Used == filters.Used select car).ToList();
            if (filters.PriceFrom.HasValue)
                filteredCarList = (from car in filteredCarList where car.Price >= filters.PriceFrom select car).ToList();
            if (filters.PriceTo.HasValue)
                filteredCarList = (from car in filteredCarList where car.Price <= filters.PriceTo select car).ToList();
            //if (!string.IsNullOrEmpty(filters.Username))
            //    filteredCarList = (from car in filteredCarList where car.UploaderUsername.ToLower() == filters.Username select car).ToList();
            //if (filters.YearFrom.HasValue)
            //    filteredCarList = (from car in filteredCarList where car.DateOfPurchase.Year >= filters.YearFrom select car).ToList();
            //if (filters.YearTo.HasValue)
            //    filteredCarList = (from car in filteredCarList where car.DateOfPurchase.Year <= filters.YearTo select car).ToList();
            //if (filters.FuelType.HasValue)
            //    filteredCarList = (from car in filteredCarList where car.FuelType == filters.FuelType select car).ToList();


            return GetSortedCarsJson(sortBy, sortAscending, startIndex, amount, filteredCarList);
        }

        // params: Car serialized to JSON
        public bool AddCarJson(byte[] car)
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

        public byte[] GetCarJson(int id)
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
