using Contracts.Incoming;
using Contracts.Outgoing;
using Models;

namespace Services.Mappers
{
    public static class VehicleMapper
    {
        public static Vehicle ToEntity(this PutVehicleDTO vehicle)
        {
            if (vehicle == null)
                return null;

            // create temporary vehicle model
            VehicleModel m = new()
            {
                Brand = vehicle.Manufacturer,
                Model = vehicle.Model
            };

            Vehicle v = new()
            {
                Id = vehicle.Id,
                Price = vehicle.Price,
                Used = vehicle.Used,
                Purchased = vehicle.Purchased,
                Engine = vehicle.Engine,
                Gearbox = vehicle.Gearbox,
                ChassisType = vehicle.ChassisType,
                Color = vehicle.Color,
                KilometersDriven = vehicle.KilometersDriven,
                DriveWheels = vehicle.DriveWheels,
                SteeringWheelSide = vehicle.SteeringWheelSide,
                NumberOfDoors = vehicle.NumberOfDoors,
                Seats = vehicle.Seats,
                NextVehicleInspection = vehicle.NextVehicleInspection,
                WheelSize = vehicle.WheelSize,
                Weight = vehicle.Weight,
                OriginalPurchaseCountry = vehicle.OriginalPurchaseCountry,
                Vin = vehicle.Vin,
                Defects = vehicle.Defects,
                AdditionalProperties = vehicle.AdditionalProperties,
                Images = vehicle.Base64EncodedImages,
                Comment = vehicle.Comment,
                VehicleModel = m
            };
            return v;
        }

        public static Vehicle ToEntity(this PostVehicleDTO vehicle)
        {
            if (vehicle == null)
                return null;

            // create temporary vehicle model
            VehicleModel m = new()
            {
                Brand = vehicle.Manufacturer,
                Model = vehicle.Model
            };

            Vehicle v = new()
            {
                Price = vehicle.Price,
                Used = vehicle.Used,
                Purchased = vehicle.Purchased,
                Engine = vehicle.Engine,
                Gearbox = vehicle.Gearbox,
                ChassisType = vehicle.ChassisType,
                Color = vehicle.Color,
                KilometersDriven = vehicle.KilometersDriven,
                DriveWheels = vehicle.DriveWheels,
                SteeringWheelSide = vehicle.SteeringWheelSide,
                NumberOfDoors = vehicle.NumberOfDoors,
                Seats = vehicle.Seats,
                NextVehicleInspection = vehicle.NextVehicleInspection,
                WheelSize = vehicle.WheelSize,
                Weight = vehicle.Weight,
                OriginalPurchaseCountry = vehicle.OriginalPurchaseCountry,
                Vin = vehicle.Vin,
                Defects = vehicle.Defects,
                AdditionalProperties = vehicle.AdditionalProperties,
                Images = vehicle.Base64EncodedImages,
                Comment = vehicle.Comment,
                VehicleModel = m
            };

            return v;
        }

        public static OutgoingVehicleDTO ToOutgoingDTO(this Vehicle vehicle)
        {
            if (vehicle == null)
                return null;

            OutgoingVehicleDTO v = new()
            {
                Id = vehicle.Id,
                UploaderUsername = vehicle.UploaderUsername,
                Brand = vehicle.VehicleModel.Brand,
                Model = vehicle.VehicleModel.Model,
                Price = vehicle.Price,
                Used = vehicle.Used,
                Purchased = vehicle.Purchased,
                Engine = vehicle.Engine,
                Gearbox = vehicle.Gearbox,
                ChassisType = vehicle.ChassisType,
                Color = vehicle.Color,
                KilometersDriven = vehicle.KilometersDriven,
                DriveWheels = vehicle.DriveWheels,
                SteeringWheelSide = vehicle.SteeringWheelSide,
                NumberOfDoors = vehicle.NumberOfDoors,
                Seats = vehicle.Seats,
                NextVehicleInspection = vehicle.NextVehicleInspection,
                WheelSize = vehicle.WheelSize,
                Weight = vehicle.Weight,
                OriginalPurchaseCountry = vehicle.OriginalPurchaseCountry,
                Vin = vehicle.Vin,
                Defects = vehicle.Defects,
                AdditionalProperties = vehicle.AdditionalProperties,
                Base64EncodedImages = vehicle.Images,
                Comment = vehicle.Comment,
                Created = vehicle.Created,
                Modified = vehicle.Modified
            };
            return v;
        }

        public static OutgoingFullVehicleDTO ToOutgoingFullDTO(this Vehicle vehicle)
        {
            if (vehicle == null)
                return null;

            OutgoingFullVehicleDTO v = new()
            {
                Id = vehicle.Id,
                UploaderUsername = vehicle.UploaderUsername,
                ModelId = vehicle.VehicleModel.Id,
                Brand = vehicle.VehicleModel.Brand,
                Model = vehicle.VehicleModel.Model,
                Price = vehicle.Price,
                Used = vehicle.Used,
                Purchased = vehicle.Purchased,
                Engine = vehicle.Engine,
                Gearbox = vehicle.Gearbox,
                ChassisType = vehicle.ChassisType,
                Color = vehicle.Color,
                KilometersDriven = vehicle.KilometersDriven,
                DriveWheels = vehicle.DriveWheels,
                SteeringWheelSide = vehicle.SteeringWheelSide,
                NumberOfDoors = vehicle.NumberOfDoors,
                Seats = vehicle.Seats,
                NextVehicleInspection = vehicle.NextVehicleInspection,
                WheelSize = vehicle.WheelSize,
                Weight = vehicle.Weight,
                OriginalPurchaseCountry = vehicle.OriginalPurchaseCountry,
                Vin = vehicle.Vin,
                Defects = vehicle.Defects,
                AdditionalProperties = vehicle.AdditionalProperties,
                Images = vehicle.Images,
                Comment = vehicle.Comment,
                Hidden = vehicle.Hidden,
                Created = vehicle.Created,
                Modified = vehicle.Modified
            };
            return v;
        }
    }
}
