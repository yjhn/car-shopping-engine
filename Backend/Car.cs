﻿using System;

namespace Backend
{
    public class Car
    {
        public int UploaderId { get; set; }
        public DateTime UploadDate { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Month DateOfPurchase { get; set; }
        public Engine Engine { get; set; }
        public FuelType FuelType { get; set; }
        public ChassisType ChassisType { get; set; }
        public string Color { get; set; }
        public GearboxType Gearbox { get; set; }
        public int Mileage { get; set; }
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
        public string[] images { get; set; }
    }

    public class Month : IComparable
    {
        public int year { get; set; }
        public int month { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Month)
            {
                Month m = (Month)obj;
                if (m.year > this.year)
                {
                    return -1;
                }
                else if (m.year < this.year)
                {
                    return 1;
                }
                else
                {
                    if (m.month > this.month)
                    {
                        return -1;
                    }
                    else if (m.month < this.month)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Cannot compare objects of different types");
            }
        }
    }

    public class Engine
    {
        public int hp { get; set; }
        public int kw { get; set; }
        public float volume { get; set; }
    }

    public enum FuelType
    {
        benzinas,
        dyzelis,
        elektra
    };

    public enum ChassisType
    {
        universalas,
        hečbekas,
        sedanas,
        visureigis,
        vienatūris,
        coupe,
        kabrioletas,
        keleivinis_mikroautobusas,
        kombi_mikroautobusas,
        krovininis_mikroautobusas,
        komercinis
    };

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