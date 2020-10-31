using DataTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend
{
    public static class VehicleSearch
    {
        public static async Task<List<Car>> SearchVehicles(string brand,
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
                PriceFrom = (lowerPriceRange == VehiclePropertyConstants.MinVehiclePrice) ? default(int?) : lowerPriceRange,
                PriceTo = (upperPriceRange == VehiclePropertyConstants.MaxVehiclePrice) ? default(int?) : upperPriceRange,
                Used = isUsed ? true : (isNew ? false : default(bool?)),
                YearFrom = (lowerYearRange == VehiclePropertyConstants.MinVehicleManufactureYear) ? default(int?) : lowerYearRange,
                YearTo = (upperYearRange == VehiclePropertyConstants.MaxVehicleManufactureYear) ? default(int?) : upperYearRange,
                FuelType = fuelType
            };

            // can be used for testing: adds random cars to DB
            //Generator.Post();
            return await Api.SearchVehicles(filters, sorting, sortAscending, 0, 15);
        }
    }
}
