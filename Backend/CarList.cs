using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Backend
{
    class CarList
    {
        public List<Car> carList;
        private FileReader carDataReader;
        private FileWriter carDataWriter;
        public int lastCarId { get; internal set; }

        public CarList(Logger logger, FileReader reader, FileWriter writer)
        {
            carDataReader = reader;
            carDataWriter = writer;
            carList = carDataReader.GetAllCarData();
            lastCarId = carDataReader.lastCarId;
        }

        public ReadOnlyCollection<Car> GetCarList(int resultAmount)
        {
            return new ReadOnlyCollection<Car>((IList<Car>)carList.Take(resultAmount));
        }

        public ReadOnlyCollection<Car> SortBy(SortingCriteria sortBy, int resultAmount)
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
            return new ReadOnlyCollection<Car>((List<Car>)carList.Take(resultAmount));
        }

        // doesn't add car to the user's ad list
        public void AddCar(Car car)
        {
            carList.Add(car);
            carDataWriter.WriteCarData(car);
            if (car.Id > lastCarId)
            {
                lastCarId = car.Id;
            }
        }

        // returns null if not found
        public Car GetCar(int id)
        {
            return carList.Find(car => car.Id == id);
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
    }

    enum SortingCriteria
    {
        UploadDateOrId,
        Price,
        DateOfPurchase,
        TotalKilometersDriven,
        NextVehicleInspection,
        Weight,
        OriginalPurchaseCountry,
    };
}
