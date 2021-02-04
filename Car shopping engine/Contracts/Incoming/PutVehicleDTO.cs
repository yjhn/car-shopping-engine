using Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Incoming
{
    public class PutVehicleDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public bool Used { get; set; }
        [Required]
        public YearMonth Purchased { get; set; }
        [Required]
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        [Required]
        public ChassisType ChassisType { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int KilometersDriven { get; set; }
        [Required]
        public DriveWheels DriveWheels { get; set; }
        [Required]
        public SteeringWheelSide SteeringWheelSide { get; set; }
        [Required]
        public NumberOfDoors NumberOfDoors { get; set; }
        [Required]
        public int Seats { get; set; }
        public YearMonth NextVehicleInspection { get; set; }
        public string WheelSize { get; set; }
        public int Weight { get; set; }
        public string OriginalPurchaseCountry { get; set; }
        public string Vin { get; set; }
        public List<string> Defects { get; set; }
        public List<string> AdditionalProperties { get; set; }
        [Required]
        public List<string> Base64EncodedImages { get; set; }
        public string Comment { get; set; }
    }
}
