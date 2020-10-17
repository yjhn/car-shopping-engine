using System;
using System.Text.Json;
using DataTypes;

namespace Backend
{
    class Program
    {
        static void Main()
        {
            Logger logger = new Logger();

            //FileReader reader = new FileReader(logger);
            //FileWriter writer = new FileWriter(logger);

            CarList carList = new CarList(logger);
            UserList userList = new UserList(logger);

            User user1 = new User(username: "Andrius", phone1: 1234567890, phone2: 0987654321, email: "aaaaa", hashedPassword: "2q345ethgbfvr56rervtb67j8k7j6h5g454we");

            Car car1 = new Car(uploaderUsername: "Andrius", uploadDate: DateTime.Now, price : 123,
                brand: "alfa", model : "beta", dateOfPurchase: new Month { year = 2000, month = 10 }, engine: new Engine { hp = 100, kw = 60, volume = 1.2f },
                fuelType: FuelType.gasoline, chassisType: ChassisType.station_wagon, color: "juoda", gearboxType: GearboxType.automatic, totalKilometersDriven: 100000,
                driveWheels: DriveWheels.rear, defects: new string[] { "dauzta mazda" }, steeringWheelPosition: SteeringWheelPosition.left,
                numberOfDoors: NumberOfDoors.fourFive, numberOfCylinders: 4, numberOfGears: 6, seats: 5, nextVehicleInspection: new Month { year = 2022, month = 5 },
                wheelSize: "R16", weight: 1300, euroStandard: EuroStandard.Euro3, originalPurchaseCountry: "Vokietija", vin : "cgfb13uj5b4gri53",
                additionalProperties: new string[] { "a", "b" }, images : new string[] { "0" });

            Car car2 = new Car(uploaderUsername: "Andrius", uploadDate: DateTime.Now, price: 25,
    brand: "alfa", model: "beta", dateOfPurchase: new Month { year = 2000, month = 10 }, engine: new Engine { hp = 100, kw = 60, volume = 1.2f },
    fuelType: FuelType.gasoline, chassisType: ChassisType.station_wagon, color: "juoda", gearboxType: GearboxType.automatic, totalKilometersDriven: 100000,
    driveWheels: DriveWheels.rear, defects: new string[] { "dauzta mazda" }, steeringWheelPosition: SteeringWheelPosition.left,
    numberOfDoors: NumberOfDoors.fourFive, numberOfCylinders: 4, numberOfGears: 6, seats: 5, nextVehicleInspection: new Month { year = 2022, month = 5 },
    wheelSize: "R16", weight: 1300, euroStandard: EuroStandard.Euro3, originalPurchaseCountry: "Vokietija", vin: "cgfb13uj5b4gri53",
    additionalProperties: new string[] { "a", "b" }, images: new string[] { "0" });

            carList.JsonAddCar(JsonSerializer.SerializeToUtf8Bytes<Car>(car1));
            carList.JsonAddCar(JsonSerializer.SerializeToUtf8Bytes<Car>(car2));
            userList.JsonAddUser(JsonSerializer.SerializeToUtf8Bytes<User>(user1));

            carList.JsonFilterByPrice(10, 100);
        }
    }
}