using DataTypes;

namespace CarEngine
{
    static internal class Sorting
    {
        // this method is ONLY for sorting based on sorting crteria that are available in SearhPage sortByCombobox
        static internal SortingCriteria getSortingCriteria(string name)
        {
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
                default:
                    criteria = SortingCriteria.UploadDate;
                    break;
            }
            return criteria;
        }
    }
}
