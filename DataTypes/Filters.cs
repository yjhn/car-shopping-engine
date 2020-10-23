using System;

namespace DataTypes
{
    public class CarFilters
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool? Used { get; set; }
        public uint? PriceFrom { get; set; }
        public uint? PriceTo { get; set; }
        public string Username { get; set; }
        public uint? YearFrom { get; set; }
        public uint? YearTo { get; set; }
        public FuelType? FuelType { get; set; }
    }

    [Flags]
    public enum SortingCriteria
    {
        UploadDate = 1,
        Price = 2,
        DateOfPurchase = 4,
        TotalKilometersDriven = 8,
        NextVehicleInspection = 16,
        OriginalPurchaseCountry = 32,
        SortAscending = 64,
        SortDescending = 128
    }

    public enum Enginetype
    {
        I4,
        V6,
        V8,
        W3,
        W8,
        W12,
        W16,
        Other
    };

    public enum FuelType
    {
        any,
        petrol,
        diesel,
        electricity,
        hybrid
    };

    public enum ChassisType
    {
        station_wagon,
        hatchback,
        sedan,
        suv,
        minivan,
        coupe,
        convertible,
        passenger_minibus,
        combi_minibus,
        freight_minibus,
        commercial
    };
}
