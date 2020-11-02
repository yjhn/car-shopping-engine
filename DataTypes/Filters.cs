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
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public string Username { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public FuelType? FuelType { get; set; }
        public ChassisType? ChassisType { get; set; }
    }

    public enum SortingCriteria
    {
        UploadDate,
        Price,
        DateOfPurchase,
        TotalKilometersDriven,
        NextVehicleInspection,
        OriginalPurchaseCountry
    }

    public enum EngineType
    {
        I4,
        V6,
        V8,
        W3,
        W8,
        W12,
        W16,
        Electric,
        Other
    };

    public enum FuelType
    {
        Petrol,
        Diesel,
        Electricity,
        Hybrid
    };

    public enum ChassisType
    {
        Station_wagon,
        Hatchback,
        Sedan,
        Suv,
        Minivan,
        Coupe,
        Convertible,
        Passenger_minibus,
        Combi_minibus,
        Freight_minibus,
        Commercial
    };
}
