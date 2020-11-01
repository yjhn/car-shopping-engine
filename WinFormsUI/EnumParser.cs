using DataTypes;
using System;

namespace CarEngine
{
    internal class EnumParser
    {
        // this method is ONLY for sorting based on sorting criteria that are available in SearhPage sortByCombobox -- they should be moved to a central location to be reusable
        internal SortingCriteria GetSortingCriteria(string name)
        {
            // need to move those strings to a centrally stored list

            // we could do this -- although it is a bit hacky
            string parsableCriteria = name.Replace(" ", null);
            // not sure if this is going to work
            return (SortingCriteria)Enum.Parse(typeof(SortingCriteria), parsableCriteria, true);

            //SortingCriteria criteria;
            //switch (name)
            //{
            //    case "upload date":
            //        criteria = SortingCriteria.UploadDate;
            //        break;
            //    case "price":
            //        criteria = SortingCriteria.Price;
            //        break;
            //    case "date of purchase":
            //        criteria = SortingCriteria.DateOfPurchase;
            //        break;
            //    case "total kilometers driven":
            //        criteria = SortingCriteria.TotalKilometersDriven;
            //        break;
            //    case "original purchase country":
            //        criteria = SortingCriteria.OriginalPurchaseCountry;
            //        break;
            //    case "next vehicle inspection":
            //        criteria = SortingCriteria.NextVehicleInspection;
            //        break;
            //    default:
            //        criteria = SortingCriteria.UploadDate;
            //        break;
            //}
            //return criteria;
        }

        //internal object GetSortObj(SortingCriteria sorting)
        //{
        //    string sortObj;
        //    switch (sorting)
        //    {
        //        case SortingCriteria.UploadDate:
        //            sortObj = "upload date";
        //            break;
        //        case SortingCriteria.Price:
        //            sortObj = "price";
        //            break;
        //        case SortingCriteria.DateOfPurchase:
        //            sortObj = "date of purchase";
        //            break;
        //        case SortingCriteria.TotalKilometersDriven:
        //            sortObj = "total kilometers driven";
        //            break;
        //        case SortingCriteria.OriginalPurchaseCountry:
        //            sortObj = "original purchase country";
        //            break;
        //        case SortingCriteria.NextVehicleInspection:
        //            sortObj = "next vehicle inspection";
        //            break;
        //        default:
        //            sortObj = "upload date";
        //            break;
        //    }
        //    return sortObj;
        //}

        internal FuelType? GetFuelType(string fuelName)
        {
            if (fuelName != "any")
            {
                string parsableFuelName = fuelName.Replace(' ', '_');
                return (FuelType?)Enum.Parse(typeof(FuelType), parsableFuelName, true);
            }
            else
            {
                return null;
            }
            //FuelType? fuelType;
            //switch (fuelTypeCombobox.SelectedItem)
            //{
            //    case "any":
            //        fuelType = default;
            //        break;
            //    case "petrol":
            //        fuelType = FuelType.Petrol;
            //        break;
            //    case "diesel":
            //        fuelType = FuelType.Diesel;
            //        break;
            //    case "electric":
            //        fuelType = FuelType.Electricity;
            //        break;
            //    case "hybrid":
            //        fuelType = FuelType.Hybrid;
            //        break;
            //    default:
            //        fuelType = default;
            //        break;
            //}
            //return fuelType;
        }

        internal ChassisType? GetChassisType(string chassisName)
        {
            if (chassisName != "any")
            {
                // this might not work
                string parsableChassisType = chassisName.Replace(' ', '_');

                return (ChassisType?)Enum.Parse(typeof(ChassisType), parsableChassisType, true);
            }
            else
            {
                return null;
            }

            //switch (vehicleTypeCombobox.SelectedItem)
            //{
            //    case "any":
            //        vehicleType = default;
            //        break;
            //    case "station wagon":
            //        vehicleType = ChassisType.Station_wagon;
            //        break;
            //    case "hatchback":
            //        vehicleType = ChassisType.Hatchback;
            //        break;
            //    case "sedan":
            //        vehicleType = ChassisType.Sedan;
            //        break;
            //    case "suv":
            //        vehicleType = ChassisType.Suv;
            //        break;
            //    case "minivan":
            //        vehicleType = ChassisType.Minivan;
            //        break;
            //    case "coupe":
            //        vehicleType = ChassisType.Coupe;
            //        break;
            //    case "convertible":
            //        vehicleType = ChassisType.Convertible;
            //        break;
            //    case "passenger minibus":
            //        vehicleType = ChassisType.Passenger_minibus;
            //        break;
            //    case "combi minibus":
            //        vehicleType = ChassisType.Combi_minibus;
            //        break;
            //    case "freight minibus":
            //        vehicleType = ChassisType.Freight_minibus;
            //        break;
            //    case "commercial":
            //        vehicleType = ChassisType.Commercial;
            //        break;
            //    default:
            //        vehicleType = default;
            //        break;
            //}
        }
    }
}
