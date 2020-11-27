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