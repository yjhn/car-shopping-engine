using DataTypes;
using System;

namespace CarEngine
{
    static internal class Sorting
    {
        // this method is ONLY for sorting based on sorting crteria that are available in SearhPage sortByCombobox
        static internal SortingCriteria getSortingCriteria(string name)
        {
            // need to move those strings to a centrally stored list
            SortingCriteria criteria;
            switch (name)
            {
                case "upload date":
                    criteria = SortingCriteria.UploadDate;
                    break;
                case "price":
                    criteria = SortingCriteria.Price;
                    break;
                case "date of purchase":
                    criteria = SortingCriteria.DateOfPurchase;
                    break;
                case "total kilometers driven":
                    criteria = SortingCriteria.TotalKilometersDriven;
                    break;
                case "original purchase country":
                    criteria = SortingCriteria.OriginalPurchaseCountry;
                    break;
                case "next vehicle inspection":
                    criteria = SortingCriteria.NextVehicleInspection;
                    break;
                default:
                    criteria = SortingCriteria.UploadDate;
                    break;
            }
            return criteria;
        }

        static internal object getSortObj(SortingCriteria sorting)
        {
            string sortObj;
            switch (sorting)
            {
                case SortingCriteria.UploadDate:
                    sortObj = "upload date";
                    break;
                case SortingCriteria.Price:
                    sortObj = "price";
                    break;
                case SortingCriteria.DateOfPurchase:
                    sortObj = "date of purchase";
                    break;
                case SortingCriteria.TotalKilometersDriven:
                    sortObj = "total kilometers driven";
                    break;
                case SortingCriteria.OriginalPurchaseCountry:
                    sortObj = "original purchase country";
                    break;
                case SortingCriteria.NextVehicleInspection:
                    sortObj = "next vehicle inspection";
                    break;
                default:
                    sortObj = "upload date";
                    break;
            }
            return sortObj;
        }
    }
}
