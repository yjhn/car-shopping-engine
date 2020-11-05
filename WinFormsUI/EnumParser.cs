using DataTypes;
using System;

namespace CarEngine
{
    internal class EnumParser
    {
        internal SortingCriteria GetSortingCriteria(string name)
        {
            string parsableCriteria = name.Replace(" ", null);
            return (SortingCriteria)Enum.Parse(typeof(SortingCriteria), parsableCriteria, true);
        }

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
        }

        internal GearboxType? GetGearboxType(string gearboxName)
        {
            if (gearboxName != "any")
            {
                string parsableGearboxName = gearboxName.Replace(' ', '_');
                return (GearboxType?)Enum.Parse(typeof(GearboxType), parsableGearboxName, true);
            }
            else
            {
                return null;
            }
        }

        internal DriveWheels? GetDriveWheels(string driveWheelsName)
        {
            if (driveWheelsName != "any")
            {
                string parsabledriveWheelsName = driveWheelsName.Replace(' ', '_');
                return (DriveWheels?)Enum.Parse(typeof(DriveWheels), parsabledriveWheelsName, true);
            }
            else
            {
                return null;
            }
        }

        internal ChassisType? GetChassisType(string chassisName)
        {
            if (chassisName != "any")
            {
                string parsableChassisType = chassisName.Replace(' ', '_');

                return (ChassisType?)Enum.Parse(typeof(ChassisType), parsableChassisType, true);
            }
            else
            {
                return null;
            }
        }
    }
}


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