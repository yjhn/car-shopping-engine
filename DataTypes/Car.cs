using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class Car : IEquatable<Car>
    {
        // unique db key = Id

        public Car(string uploaderUsername, DateTime uploadDate, int price, string brand, string model, bool used, Month dateOfPurchase, Engine engine, FuelType fuelType,
            ChassisType chassisType, string color, GearboxType gearboxType, int totalKilometersDriven, DriveWheels driveWheels, string[] defects,
            SteeringWheelPosition steeringWheelPosition, NumberOfDoors numberOfDoors, int numberOfCylinders, int numberOfGears, int seats, Month nextVehicleInspection,
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

        public Car(){ }

        public int Id { get; set; }
        public int Price { get; set; }
        public string UploaderUsername { get; set; }
        public DateTime UploadDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool Used { get; set; }
        public Month DateOfPurchase { get; set; }
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
        public Month NextVehicleInspection { get; set; }
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
            return this.Id == other.Id;
        }
    }

    public class Month : IComparable<Month>
    {
        public int year { get; set; }
        public int month { get; set; }

        public int CompareTo(Month other)
        {
            if (other.year > this.year)
            {
                return -1;
            }
            else if (other.year < this.year)
            {
                return 1;
            }
            else
            {
                if (other.month > this.month)
                {
                    return -1;
                }
                else if (other.month < this.month)
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
        public int hp { get; set; }
        public int kw { get; set; }
        public float volume { get; set; }
        public Enginetype engineType { get; set; }

    }

    public enum GearboxType
    {
        mechanic,
        automatic
    };

    public enum DriveWheels
    {
        front,
        rear,
        all
    };

    public enum SteeringWheelPosition
    {
        left,
        right
    }

    public enum NumberOfDoors
    {
        twoThree = 23,
        fourFive = 45,
        sixSeven = 67
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
