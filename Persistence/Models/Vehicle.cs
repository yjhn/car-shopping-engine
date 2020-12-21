using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Vehicle : IEquatable<Vehicle>
    {
        public int Id { get; set; }
        public int Price { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UploaderUsername { get; set; }

        [Required]
        public User Uploader { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Modified { get; set; }

        [ForeignKey(nameof(VehicleModel))]
        public int ModelId { get; set; }

        [Required]
        public VehicleModel VehicleModel { get; set; }
        public bool Used { get; set; }
        public YearMonth Purchased { get; set; }

        [Required]
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        public ChassisType ChassisType { get; set; }

        [Required]
        [Column(TypeName = "char(20)")]
        public string Color { get; set; }
        public int KilometersDriven { get; set; }
        public DriveWheels DriveWheels { get; set; }
        public SteeringWheelSide SteeringWheelSide { get; set; }
        public NumberOfDoors NumberOfDoors { get; set; }
        public int Seats { get; set; }
        public YearMonth NextVehicleInspection { get; set; }
        
        [Required]
        [Column(TypeName = "char(20)")]
        public string WheelSize { get; set; }
        public int Weight { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string OriginalPurchaseCountry { get; set; }

        [Column(TypeName = "char(17)")] // https://en.wikipedia.org/wiki/Vehicle_identification_number#Components
        public string Vin { get; set; }

        [Column(TypeName = "varchar(200)")]
        public ICollection<string> Defects { get; set; }

        [Column(TypeName = "varchar(200)")]
        public ICollection<string> AdditionalProperties { get; set; }

        [Required]
        public ICollection<string> Images { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Comment { get; set; }
        public bool Hidden { get; set; }
        public ICollection<User> LikedBy { get; set; }

        public Vehicle()
        {
            Defects = new List<string>();
            Hidden = false;
            Used = true;
            AdditionalProperties = new List<string>();
        }


        // not sure if these are needed

        public bool Equals(Vehicle other)
        {
            if(other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vehicle);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    [Owned]
    public class YearMonth : IComparable<YearMonth>
    {
        public YearMonth() { }
        public int Year { get; set; }
        public int Month { get; set; }

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

    [Owned]
    public class Gearbox
    {
        public GearboxType GearboxType { get; set; }
        public int NumberOfGears { get; set; }
    }

    [Owned]
    public class Engine
    {
        public int Hp { get; set; }
        public int Kw { get; set; }
        public float? Volume { get; set; }
        public EngineType Type { get; set; }
        public FuelType FuelType { get; set; }
        public EuroStandard? EuroEmissionsStandard { get; set; }
        public int? NumberOfCylinders { get; set; }
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

    public enum SteeringWheelSide
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

    public enum EngineType
    {
        I4,
        V6,
        V8,
        W3,
        W8,
        W12,
        W16,
        Electric,
        Other
    };

    public enum FuelType
    {
        Petrol,
        Diesel,
        Electricity,
        Hybrid
    };

    public enum ChassisType
    {
        Station_wagon,
        Hatchback,
        Sedan,
        Suv,
        Minivan,
        Coupe,
        Convertible,
        Passenger_minibus,
        Combi_minibus,
        Freight_minibus,
        Commercial
    };
}
