using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services.Repositories
{
    public static class ExtensionMethods
    {
        public static void SortBy(this IEnumerable<Vehicle> carListToSort, SortingCriteria sortBy, bool sortAscending)
        {
            switch (sortBy)
            {
                case SortingCriteria.UploadDate:
                    if (sortAscending) carListToSort = carListToSort.OrderBy(a => a.Created);
                    else carListToSort = carListToSort.OrderByDescending(a => a.Created);
                    break;
                case SortingCriteria.Price:
                    if (sortAscending) carListToSort = carListToSort.OrderBy(a => a.Price);
                    else carListToSort = carListToSort.OrderByDescending(a => a.Price);
                    break;
                case SortingCriteria.Purchased:
                    if (sortAscending) carListToSort = carListToSort.OrderBy(a => a.Purchased);
                    else carListToSort = carListToSort.OrderByDescending(a => a.Purchased);
                    break;
                case SortingCriteria.KilometersDriven:
                    if (sortAscending) carListToSort = carListToSort.OrderBy(a => a.KilometersDriven);
                    else carListToSort = carListToSort.OrderByDescending(a => a.KilometersDriven);
                    break;
                case SortingCriteria.OriginalPurchaseCountry:
                    if (sortAscending) carListToSort = carListToSort.OrderBy(a => a.OriginalPurchaseCountry);
                    else carListToSort = carListToSort.OrderByDescending(a => a.OriginalPurchaseCountry);
                    break;
                default:
                    if (sortAscending) carListToSort = carListToSort.OrderBy(a => a.Created);
                    else carListToSort = carListToSort.OrderByDescending(a => a.Created);
                    break;
            }
        }
    }

    public class VehicleFilters
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
        Purchased,
        KilometersDriven,
        NextVehicleInspection,
        OriginalPurchaseCountry
    }
}
