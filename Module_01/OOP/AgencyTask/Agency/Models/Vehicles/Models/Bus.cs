using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles.Models
{
    class Bus : Vehicle, IBus
    {
        public Bus(int passengerCapacity, decimal pricePerKilometer) 
            : base(VehicleType.Land)
        {
            this.PassangerCapacity = passengerCapacity;
            this.PricePerKilometer = pricePerKilometer;
        }

        public override int PassangerCapacity
        {
            get => base.PassangerCapacity;
            protected set
            {
                Validator.ArgumentIsInRangeInclusive(value, Restrictions.BusPassangerCapacityMinValue, 
                    Restrictions.BusPassangerCapacityMaxValue, 
                    "A bus cannot have less than 10 passengers or more than 50 passengers.");

                base.PassangerCapacity = value;
            }
        }     
    }
}
