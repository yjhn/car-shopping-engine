﻿using DataTypes;
using System.Collections.Generic;

namespace Frontend
{
    public static class VehicleSearch
    {
        public static List<Car> searchVehicles(string brand,
                                               string model,
                                               FuelType? fuelType,
                                               ChassisType? vehicleType,
                                               SortingCriteria sorting,
                                               bool sortAscending,
                                               bool isUsed,
                                               bool isNew,
                                               int lowerPriceRange,
                                               int upperPriceRange,
                                               int lowerYearRange,
                                               int upperYearRange)
        {
            CarFilters filters = new CarFilters()
            {
                ChassisType = vehicleType,
                Brand = (brand == string.Empty) ? null : brand,
                Model = (model == string.Empty) ? null : model,
                PriceFrom = (lowerPriceRange == VehiclePropertyConstants.minVehiclePrice) ? default(int?) : lowerPriceRange,
                PriceTo = (upperPriceRange == VehiclePropertyConstants.maxVehiclePrice) ? default(int?) : upperPriceRange,
                Used = isUsed ? true : (isNew ? false : default(bool?)),
                YearFrom = (lowerYearRange == VehiclePropertyConstants.minVehicleManufactureYear) ? default(int?) : lowerYearRange,
                YearTo = (upperYearRange == VehiclePropertyConstants.maxVehicleManufactureYear) ? default(int?) : upperYearRange,
                FuelType = fuelType
            };

            // for now
            return null;
            //return Api.SearchVehicles(filters, sorting, sortAscending);
        }
    }
}