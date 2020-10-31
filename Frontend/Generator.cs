using System;
using DataTypes;
namespace Frontend
{
    public class Generator
    {
        public Api FrontendApi
        { get; private set; }
        public Generator(Api frontendApi)
        {
            FrontendApi = frontendApi;
        }

        public void post()
        {
            Random r = new Random();
            string[] colors = { "raudona", "zalia", "melyna", "geltona", "balta", "belekokia spalva", "purpurine", "alyvine", "tamsiai violetine" };
            for (int i = 0; i < 5; i++)
            {
                Car c = new Car
                {
                    UploaderUsername = "user" + r.Next(0, 100),
                    UploadDate = DateTime.Now,
                    Price = r.Next(1000, 600000),
                    Brand = "brand" + r.Next(0, 50),
                    Model = "model" + r.Next(0, 100),
                    Used = true,
                    DateOfPurchase = new YearMonth(),
                    Engine = new Engine(),
                    FuelType = FuelType.Petrol,
                    ChassisType = ChassisType.Sedan,
                    Color = colors[r.Next(0, 7)],
                    GearboxType = GearboxType.Automatic,
                    TotalKilometersDriven = r.Next(2000, 800000),
                    DriveWheels = DriveWheels.Front,
                    Defects = new string[] { "luzusi dureliu rankena", "isdauzti trys langai" },
                    SteeringWheelPosition = SteeringWheelPosition.Left
                };
                FrontendApi.AddCar(c);
            }
        }
    }
}