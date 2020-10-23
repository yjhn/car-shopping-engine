using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes
{
    public enum SortingCriteria
    {
        UploadDateOrId,
        Price,
        DateOfPurchase,
        TotalKilometersDriven,
        NextVehicleInspection,
        OriginalPurchaseCountry
    };

    public class CarFilters
    {
        public uint? PriceFrom { get; set; }
        public uint? PriceTo { get; set; }
        public string Username { get; set; }
        public uint? YearFrom { get; set; }
        public uint? YearTo { get; set; }
        public FuelType? FuelType { get; set; }
    }
}
