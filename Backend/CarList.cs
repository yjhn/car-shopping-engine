using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Backend
{
    public class CarList : ICarDb
    {
        public List<Car> carList;
        private FileReader carDataReader;
        private FileWriter carDataWriter;
        public uint lastCarId { get; internal set; }
        private Logger logger;

        public CarList(Logger logger, string carDbPath = null)
        {
            this.logger = logger;
            carDataReader = new FileReader(logger, carDbPath);
            carDataWriter = new FileWriter(logger, carDbPath);
            carList = carDataReader.GetAllCarData();
            lastCarId = carDataReader.lastCarId;
        }

        // returns List<Car> serialized to JSON
        public byte[] GetCarList(int startIndex, int amount)
        {
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carList.Skip(startIndex).Take(amount).ToList<Car>());
        }

        public byte[] SortBy(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount, List<Car> carListToSort = null)
        {
            if (carListToSort == null)
            {
                carListToSort = carList;
            }
            carListToSort.SortBy(sortBy, sortAscending);
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carListToSort.Skip(startIndex).Take(amount).ToList<Car>());
        }

        public byte[] Filter(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            List<Car> filteredCarList = carList;

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
                c.Id = lastCarId + 1;
                lastCarId++;
                carList.Add(c);
                carDataWriter.WriteCarData(c);
                return true;
            }
            catch (JsonException e)
            {
                logger.LogException(new Exception("Failed to write car data due to bad serialization", e));
                return false;
            }
            catch (Exception e)
            {
                logger.LogException(e);
                return false;
            }
        }

        public byte[] GetCar(int id)
        {
            Car car = carList.Find(car => car.Id == id);
            return car != null ? JsonSerializer.SerializeToUtf8Bytes<Car>(car) : null;
        }

        public bool DeleteCar(int id)
        {
            foreach (Car car in carList)
            {
                if (car.Id == id)
                {
                    carList.Remove(car);
                    carDataWriter.DeleteCar(id);
                    return true;
                }
            }
            return false;
        }

        public List<uint> GetUserAdIds(string username)
        {
            List<uint> ids = new List<uint>();
            foreach (Car car in carList)
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
