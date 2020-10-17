using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using DataTypes;

namespace Backend
{
    public class CarList
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

        private List<Car> GetCarList(int resultAmount = 50)
        {
            return carList.Take(resultAmount).ToList<Car>();
        }


        // returns List<Car> serialized to JSON
        public byte[] JsonGetCarList(int resultAmount = 50)
        {
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(GetCarList(resultAmount));
        }

        private List<Car> SortBy(SortingCriteria sortBy, int resultAmount = 50)
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
                    break; ;
                default:
                    throw new ArgumentException("Bad compare criteria");
            }
            return carList.Take(resultAmount).ToList<Car>();
        }

        public byte[] JsonFilter(CarFilters filters)
        {
            List<Car> filteredCarList = carList;

            if(filters.PriceFrom.HasValue && filters.PriceTo.HasValue)
                filteredCarList = (from car in carList where (car.Price >= filters.PriceFrom && car.Price <= filters.PriceTo) select car).ToList();
            if(!string.IsNullOrEmpty(filters.Username))
                filteredCarList = (from car in carList where car.UploaderUsername.Equals(filters.Username) select car).ToList();
            if(filters.YearFrom.HasValue && filters.YearTo.HasValue)
                filteredCarList = (from car in carList where (car.DateOfPurchase.year >= filters.YearFrom && car.DateOfPurchase.year <= filters.YearTo) select car).ToList();
            if(filters.FuelType.HasValue)
                filteredCarList = (from car in carList where car.FuelType == filters.FuelType select car).ToList();

            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(filteredCarList);
        }

        // returns List<Car> serialized to JSON
        public byte[] JsonSortBy(SortingCriteria sortBy, int resultAmount = 50)
        {
            return JsonSerializer.SerializeToUtf8Bytes<List<Car>>(SortBy(sortBy, resultAmount));
        }

        // doesn't add car to the user's ad list
        private void AddCar(Car car)
        {
            car.Id = lastCarId + 1;
            lastCarId++;
            carList.Add(car);
            carDataWriter.WriteCarData(car);
        }

        // params: Car serialized to JSON
        public void JsonAddCar(byte[] car)
        {
            try
            {
                AddCar(JsonSerializer.Deserialize<Car>(car));
            }
            catch (Exception e)
            {
                logger.LogException(new BackendException("Failed to write car due to bad serialization", e));
            }
        }



        // returns null if not found
        private Car GetCar(int id)
        {
            return carList.Find(car => car.Id == id);
        }

        public byte[] JsonGetCar(int id)
        {
            return JsonSerializer.SerializeToUtf8Bytes<Car>(GetCar(id));
        }

        public void DeleteCar(int id)
        {
            foreach (Car car in carList)
            {
                if (car.Id == id)
                {
                    carList.Remove(car);
                    carDataWriter.DeleteCar(id);
                }
            }
        }

        public List<int> GetUserAdIds(string username)
        {
            List<int> ids = new List<int>();
            foreach(Car car in carList)
            {
                if (car.UploaderUsername.Equals(username))
                {
                    ids.Add(car.Id);
                }
            }
            return ids;
        }
    }

    public enum SortingCriteria
    {
        UploadDateOrId,
        Price,
        DateOfPurchase,
        TotalKilometersDriven,
        NextVehicleInspection,
        OriginalPurchaseCountry,
        Unknown
    };

    public class CarFilters
    {
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public string Username { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public FuelType? FuelType { get; set; }
    }
}
