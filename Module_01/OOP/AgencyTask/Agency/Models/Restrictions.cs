using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models
{
    public static class Restrictions
    {
        public const int TrainPassangerCapacityMinValue = 30;
        public const int TrainPassangerCapacityMaxValue = 150;
        public const int TrainCartsMinValue = 1;
        public const int TrainCartsMaxValue = 15;
        public const int BusPassangerCapacityMinValue = 10;
        public const int BusPassangerCapacityMaxValue = 50;
        public const int JourneyStartingLocationMinLength = 5;
        public const int JourneyStartingLocationMaxLength = 25;
        public const int JourneyDestinationMinLength = 5;
        public const int JourneyDestionationMaxLenght = 25;
        public const int JourneyDistanceMinLength = 5;
        public const int JourneyDistanceMaxLength = 5000;
        public const decimal VehiclePricePerKilometerMinValue = 0.10m;
        public const decimal VehiclePricePerKilometerMaxValue = 2.50m;
        public const int VehiclePassangerCapacityMinValue = 1;
        public const int VehiclePassangerCapacityMaxValue = 800;

    }
}
