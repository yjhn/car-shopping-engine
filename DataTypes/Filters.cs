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
        OriginalPurchaseCountry,
        Unknown
    };

    public class CarFilters
    {
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public string Username { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public FuelType? FuelType { get; set; }
    }
}
