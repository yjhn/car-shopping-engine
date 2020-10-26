using System;
using System.Collections.Generic;

namespace DataTypes
{
    public static class Algorithms
    {
        public static void SortBy(this List<Car> carListToSort, SortingCriteria sortBy, bool sortAscending)
        {
            switch (sortBy)
            {
                case SortingCriteria.UploadDate:
                    if (sortAscending)
                    {
                        carListToSort.Sort((a, b) => a.UploadDate.CompareTo(b.UploadDate));
                    }
                    else
                    {
                        carListToSort.Sort((a, b) => b.UploadDate.CompareTo(a.UploadDate));
                    }
                    break;
                case SortingCriteria.Price:
                    if (sortAscending)
                    {
                        carListToSort.Sort((a, b) => a.Price.CompareTo(b.Price));
                    }
                    else
                    {
                        carListToSort.Sort((a, b) => b.Price.CompareTo(a.Price));
                    }
                    break;
                case SortingCriteria.DateOfPurchase:
                    if (sortAscending)
                    {
                        carListToSort.Sort((a, b) => a.DateOfPurchase.CompareTo(b.DateOfPurchase));
                    }
                    else
                    {
                        carListToSort.Sort((a, b) => b.DateOfPurchase.CompareTo(a.DateOfPurchase));
                    }
                    break;
                case SortingCriteria.TotalKilometersDriven:
                    if (sortAscending)
                    {
                        carListToSort.Sort((a, b) => a.TotalKilometersDriven.CompareTo(b.TotalKilometersDriven));
                    }
                    else
                    {
                        carListToSort.Sort((a, b) => b.TotalKilometersDriven.CompareTo(a.TotalKilometersDriven));
                    }
                    break;
                case SortingCriteria.OriginalPurchaseCountry:
                    if (sortAscending)
                    {
                        carListToSort.Sort((a, b) => a.OriginalPurchaseCountry.CompareTo(b.OriginalPurchaseCountry));
                    }
                    else
                    {
                        carListToSort.Sort((a, b) => b.OriginalPurchaseCountry.CompareTo(a.OriginalPurchaseCountry));
                    }
                    break;
                default:
                    if (sortAscending)
                    {
                        carListToSort.Sort((a, b) => a.DateOfPurchase.CompareTo(b.DateOfPurchase));
                    }
                    else
                    {
                        carListToSort.Sort((a, b) => b.DateOfPurchase.CompareTo(a.DateOfPurchase));
                    }
                    break;
            }
        }
    }

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
        public ChassisType? ChassisType { get; set; }
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
