using Models;
using System;
using System.Collections.Generic;

namespace Contracts.Outgoing
{
    public class OutgoingVehicleDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Model { get; set; }
        public string UploaderUsername { get; set; }
        public string Brand { get; set; }
        public bool Used { get; set; }
        public YearMonth Purchased { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        public ChassisType ChassisType { get; set; }
        public string Color { get; set; }
        public int KilometersDriven { get; set; }
        public DriveWheels DriveWheels { get; set; }
        public SteeringWheelSide SteeringWheelSide { get; set; }
        public NumberOfDoors NumberOfDoors { get; set; }
        public int Seats { get; set; }
        public YearMonth NextVehicleInspection { get; set; }
        public string WheelSize { get; set; }
        public int Weight { get; set; }
        public string OriginalPurchaseCountry { get; set; }
        public string Vin { get; set; }
        public IEnumerable<string> Defects { get; set; }
        public IEnumerable<string> AdditionalProperties { get; set; }
        public IEnumerable<string> Base64EncodedImages { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
