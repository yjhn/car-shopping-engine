using System;
using DataTypes;
namespace Frontend
{
    public class Generator
    {
        public static void post()
        {
            Random r = new Random();
            string[] colors = { "raudona", "zalia", "melyna", "geltona", "balta", "belekokia spalva", "purpurine", "alyvine", "tamsiai violetine" };
            for (int i = 0; i < 2; i++)
            {
                Car c = new Car();
                c.UploaderUsername = "user" + r.Next(0, 100);
                c.UploadDate = DateTime.Now;
                c.Price = r.Next(1000, 600000);
                c.Brand = "brand" + r.Next(0, 50);
                c.Model = "model" + r.Next(0, 100);
                c.Used = true;
                c.DateOfPurchase = new Month();
                c.Engine = new Engine();
                c.FuelType = FuelType.petrol;
                c.ChassisType = ChassisType.sedan;
                c.Color = colors[r.Next(0, 7)];
                c.GearboxType = GearboxType.automatic;
                c.TotalKilometersDriven = r.Next(2000, 800000);
                c.DriveWheels = DriveWheels.front;
                c.Defects = new string[]{"luzusi dureliu rankena", "isdauzti trys langai"};
                c.SteeringWheelPosition = SteeringWheelPosition.left;
                Api.AddCar(c);
            }
        }
    }
}