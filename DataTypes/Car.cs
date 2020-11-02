using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class Car : IEquatable<Car>
    {
        // unique db key = Id

        public Car(string uploaderUsername, DateTime uploadDate, int price, string brand, string model, bool used, YearMonth dateOfPurchase, Engine engine, FuelType fuelType,
            ChassisType chassisType, string color, GearboxType gearboxType, int totalKilometersDriven, DriveWheels driveWheels, string[] defects,
            SteeringWheelPosition steeringWheelPosition, NumberOfDoors numberOfDoors, int numberOfCylinders, int numberOfGears, int seats, YearMonth nextVehicleInspection,
            string wheelSize, int weight, EuroStandard euroStandard, string originalPurchaseCountry, string vin, string[] additionalProperties, string[] images, string comment)
        {
            Price = price;
            UploaderUsername = uploaderUsername;
            UploadDate = uploadDate;
            Brand = brand;
            Model = model;
            Used = used;
            DateOfPurchase = dateOfPurchase;
            Engine = engine;
            FuelType = fuelType;
            ChassisType = chassisType;
            Color = color;
            GearboxType = gearboxType;
            TotalKilometersDriven = totalKilometersDriven;
            DriveWheels = driveWheels;
            Defects = defects;
            SteeringWheelPosition = steeringWheelPosition;
            NumberOfDoors = numberOfDoors;
            NumberOfCylinders = numberOfCylinders;
            NumberOfGears = numberOfGears;
            Seats = seats;
            NextVehicleInspection = nextVehicleInspection;
            WheelSize = wheelSize;
            Weight = weight;
            EuroStandard = euroStandard;
            OriginalPurchaseCountry = originalPurchaseCountry;
            Vin = vin;
            AdditionalProperties = additionalProperties;
            Images = images;
            Comment = comment;
        }

        public int Id { get; set; } = -1;
        public int Price { get; set; }
        public string UploaderUsername { get; set; }
        public DateTime UploadDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool Used { get; set; }
        public YearMonth DateOfPurchase { get; set; }
        public Engine Engine { get; set; }
        public FuelType FuelType { get; set; }
        public ChassisType ChassisType { get; set; }
        public string Color { get; set; }
        public GearboxType GearboxType { get; set; }
        public int TotalKilometersDriven { get; set; }
        public DriveWheels DriveWheels { get; set; }
        public string[] Defects { get; set; }
        public SteeringWheelPosition SteeringWheelPosition { get; set; }
        public NumberOfDoors NumberOfDoors { get; set; }
        public int NumberOfCylinders { get; set; }
        public int NumberOfGears { get; set; }
        public int Seats { get; set; }
        public YearMonth NextVehicleInspection { get; set; }
        public string WheelSize { get; set; }
        public int Weight { get; set; }
        public EuroStandard EuroStandard { get; set; }
        public string OriginalPurchaseCountry { get; set; }
        public string Vin { get; set; }
        public string[] AdditionalProperties { get; set; }
        public string[] Images { get; set; }
        public string Comment { get; set; }

        public bool Equals(Car other)
        {
            if (Id == -1 || other.Id == -1)
            {
                throw new Exception("Cannot compare cars that have unassigned Ids");
            }
            else
            {
                return Id == other.Id;
            }
        }

        // required for serialization to work
        public Car() { }
    }

    public class YearMonth : IComparable<YearMonth>
    {
        public YearMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }

        // required for serialization to work
        public YearMonth() { }
        public int Year { get; private set; }
        public int Month { get; private set; }

        public int CompareTo(YearMonth other)
        {
            if (other.Year > this.Year)
            {
                return -1;
            }
            else if (other.Year < this.Year)
            {
                return 1;
            }
            else
            {
                if (other.Month > this.Month)
                {
                    return -1;
                }
                else if (other.Month < this.Month)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    public class Engine
    {
        public Engine(int hp, int kw, float volume, EngineType type):this(hp, kw, type)
        {
            Volume = volume;
        }

        public Engine(int hp, int kw, EngineType type)
        {
            Hp = hp;
            Kw = kw;
            Type = type;
        }

        // required for serialization to work
        public Engine() { }
        public int Hp { get; set; }
        public int Kw { get; set; }
        public float Volume { get; set; }
        public EngineType Type { get; set; }

    }

    public enum GearboxType
    {
        Mechanic,
        Automatic
    };

    public enum DriveWheels
    {
        Front,
        Rear,
        All
    };

    public enum SteeringWheelPosition
    {
        Left,
        Right
    }

    public enum NumberOfDoors
    {
        TwoThree = 23,
        FourFive = 45,
        SixSeven = 67
    }

    public enum EuroStandard
    {
        Euro1 = 1,
        Euro2,
        Euro3,
        Euro4,
        Euro5,
        Euro6
    }
}
