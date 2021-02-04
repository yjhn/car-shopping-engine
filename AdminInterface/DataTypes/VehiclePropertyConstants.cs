using System;

namespace DataTypes
{
    public static class VehiclePropertyConstants
    {
        readonly public static uint MinVehiclePrice = 0;
        readonly public static uint MaxVehiclePrice = 1000000;
        readonly public static int MinVehicleManufactureYear = 1900;
        readonly public static int MaxVehicleManufactureYear = DateTime.Now.Year;
    }
}
