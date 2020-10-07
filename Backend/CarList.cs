using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    class CarList
    {
        private List<Car> carList;
        private FileReader carDataReader;
        private FileWriter carDataWriter;
        private int lastCarId;

        public CarList(Logger logger, FileReader reader, FileWriter writer)
        {
            carDataReader = reader;
            carDataWriter = writer;
            carList = carDataReader.GetAllCarData();
        }

        public Car[] SortBy(SortingCriteria sortBy)
        {
            switch (sortBy)
            {
                case (SortingCriteria.UploadDateOrId):
                    carList.Sort((x, y) => x.Id.CompareTo(y.Id));
                    return carList.ToArray();
                case (SortingCriteria.Price):
                    carList.Sort((x, y) => x.Price.CompareTo(y.Price));
                    return carList.ToArray();
                case (SortingCriteria.DateOfPurchase):
                    carList.Sort((x, y) => x.DateOfPurchase.CompareTo(y.DateOfPurchase));
                    return carList.ToArray();
                case (SortingCriteria.Mileage):
                    carList.Sort((x, y) => x.Mileage.CompareTo(y.Mileage));
                    return carList.ToArray();
                case (SortingCriteria.NextVehicleInspection):
                    carList.Sort((x, y) => x.NextVehicleInspection.CompareTo(y.NextVehicleInspection));
                    return carList.ToArray();
                case (SortingCriteria.OriginalPurchaseCountry):
                    carList.Sort((x, y) => x.OriginalPurchaseCountry.CompareTo(y.OriginalPurchaseCountry));
                    return carList.ToArray();
                default:
                    throw new ArgumentException("Bad compare criterion");
            }
        }

        // doesn't add car to the user's ad list
        public void AddCar(Car car)
        {
            carList.Add(car);
            carDataWriter.WriteCarData(car);
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
        Mileage,
        NextVehicleInspection,
        Weight,
        OriginalPurchaseCountry,
    };
}
