using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles.Models
{
    abstract class Vehicle : IVehicle
    {
        private int passangerCapacity;
        private decimal pricePerKilomenter;

        protected Vehicle(VehicleType type)
        {
            this.Type = type;
        }

        public VehicleType Type { get; }

        public virtual int PassangerCapacity
        {
            get => this.passangerCapacity;
            protected set
            {
                Validator.ArgumentIsInRangeInclusive(value, Restrictions.VehiclePassangerCapacityMinValue,
                    Restrictions.VehiclePassangerCapacityMaxValue,
                    "A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");

                this.passangerCapacity = value;
            }
        }

        public decimal PricePerKilometer
        {
            get => this.pricePerKilomenter;
            protected set
            {
                Validator.ArgumentIsInRangeInclusive(value, Restrictions.VehiclePricePerKilometerMinValue,
                    Restrictions.VehiclePricePerKilometerMaxValue,
                    "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!");

                this.pricePerKilomenter = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} ----");
            sb.AppendLine($"Passenger capacity: {this.PassangerCapacity}");
            sb.AppendLine($"Price per kilometer: {this.pricePerKilomenter}");
            sb.Append($"Vehicle type: {this.Type}");

            return sb.ToString();
        }
    }
}
