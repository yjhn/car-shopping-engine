using System;

namespace Backend
{
    class Program
    {
        static void Main()
        {
            Logger logger = new Logger();

            FileReader reader = new FileReader(logger);
            FileWriter writer = new FileWriter(logger);

            CarList carList = new CarList(logger, reader, writer);
            UserList userList = new UserList(logger, reader, writer);

            User user1 = new User
            {
                Id = 0,
                Username = "Andrius",
                Phone1 = 1234567890,
                Phone2 = 0987654321,
                Email = "aaaaa",
                HashedPassword = "2q345ethgbfvr56rervtb67j8k7j6h5g454we",
                AdIds = new int[] { 0 }
            };

            Car car1 = new Car
            {
                UploaderId = 0,
                UploadDate = DateTime.Now,
                Price = 123,
                AdditionalProperties = new string[] { "a", "b" },
                Id = 0,
                Brand = "alfa",
                Model = "beta",
                DateOfPurchase = new Month { year = 2000, month = 10 },
                Engine = new Engine { hp = 100, kw = 60, volume = 1.2f },
                FuelType = FuelType.benzinas,
                ChassisType = ChassisType.universalas,
                Color = "juoda",
                Gearbox = GearboxType.automatic,
                Mileage = 100000,
                DriveWheels = DriveWheels.rear,
                Defects = new string[] { "dauzta mazda" },
                SteeringWheelPosition = SteeringWheelPosition.left,
                NumberOfDoors = NumberOfDoors.fourFive,
                NumberOfCylinders = 4,
                NumberOfGears = 6,
                Seats = 5,
                NextVehicleInspection = new Month { year = 2022, month = 5 },
                WheelSize = "R16",
                Weight = 1300,
                EuroStandard = EuroStandard.Euro3,
                OriginalPurchaseCountry = "Vokietija",
                Vin = "cgfb13uj5b4gri53"
                //images = new string[] { base64ImageRepresentation }
            };

            carList.AddCar(car1);
            userList.AddUser(user1);
        }
    }
}