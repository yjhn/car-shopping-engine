using Contracts.Incoming;
using Contracts.Outgoing;
using Models;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VehicleMapper
    {
        private readonly IVehicleRepository _repository;

        public VehicleMapper(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Vehicle> ToEntity(IncomingVehicleDTO vehicle)
        {
            if (vehicle == null) return null;

            var m = _repository.GetOrCreateVehicleModel(vehicle.Manufacturer, vehicle.Model);

            Vehicle v = new()
            {
                Id = vehicle.Id == null? 0 : (int)vehicle.Id,
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
                VehicleModel = await m
            };
            return v;
        }

        public OutgoingVehicleDTO ToOutgoingDTO(Vehicle vehicle)
        {
            if (vehicle == null) return null;

            OutgoingVehicleDTO v = new()
            {
                Id = vehicle.Id,
                Manufacturer = vehicle.VehicleModel.Brand,
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
                Defects = (List<string>)vehicle.Defects,
                AdditionalProperties = (List<string>)vehicle.AdditionalProperties,
                Base64EncodedImages = (List<string>)vehicle.Images,
                Comment = vehicle.Comment,
                Created = vehicle.Created,
                Modified = vehicle.Modified
            };
            return v;
        }
    }
}
