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
        public int lastCarId { get; internal set; }
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
        public byte[] GetCarList(int resultAmount = 50)
        {
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carList.Take(resultAmount).ToList<Car>());
        }

        public byte[] SortBy(SortingCriteria sortBy, int resultAmount = 50)
        {
            switch (sortBy)
            {
                case (SortingCriteria.UploadDateOrId):
                    carList.Sort((x, y) => x.Id.CompareTo(y.Id));
                    break;
                case (SortingCriteria.Price):
                    carList.Sort((x, y) => x.Price.CompareTo(y.Price));
                    break;
                case (SortingCriteria.DateOfPurchase):
                    carList.Sort((x, y) => x.DateOfPurchase.CompareTo(y.DateOfPurchase));
                    break;
                case (SortingCriteria.TotalKilometersDriven):
                    carList.Sort((x, y) => x.TotalKilometersDriven.CompareTo(y.TotalKilometersDriven));
                    break;
                case (SortingCriteria.NextVehicleInspection):
                    carList.Sort((x, y) => x.NextVehicleInspection.CompareTo(y.NextVehicleInspection));
                    break;
                case (SortingCriteria.OriginalPurchaseCountry):
                    carList.Sort((x, y) => x.OriginalPurchaseCountry.CompareTo(y.OriginalPurchaseCountry));
                    break;
                default:
                    throw new ArgumentException("Bad compare criteria");
            }
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carList.Take(resultAmount).ToList<Car>());
        }

        public byte[] Filter(CarFilters filters)
        {
            List<Car> filteredCarList = carList;

            if (filters.PriceFrom.HasValue && filters.PriceTo.HasValue)
                filteredCarList = (from car in carList where (car.Price >= filters.PriceFrom && car.Price <= filters.PriceTo) select car).ToList();
            if (!string.IsNullOrEmpty(filters.Username))
                filteredCarList = (from car in carList where car.UploaderUsername.Equals(filters.Username) select car).ToList();
            if (filters.YearFrom.HasValue && filters.YearTo.HasValue)
                filteredCarList = (from car in carList where (car.DateOfPurchase.year >= filters.YearFrom && car.DateOfPurchase.year <= filters.YearTo) select car).ToList();
            if (filters.FuelType.HasValue)
                filteredCarList = (from car in carList where car.FuelType == filters.FuelType select car).ToList();

            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(filteredCarList);
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

        public List<int> GetUserAdIds(string username)
        {
            List<int> ids = new List<int>();
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
