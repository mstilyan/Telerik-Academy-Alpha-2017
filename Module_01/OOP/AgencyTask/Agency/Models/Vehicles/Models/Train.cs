using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles.Models
{
    class Train : Vehicle, ITrain
    {
        private int carts;

        public Train(int passengerCapacity, decimal pricePerKilometer, int carts) 
            : base(VehicleType.Land)
        {
            this.PassangerCapacity = passengerCapacity;
            this.PricePerKilometer = pricePerKilometer;
            this.Carts = carts;
        }

        public override int PassangerCapacity
        {
            get => base.PassangerCapacity;
            protected set
            {
                Validator.ArgumentIsInRangeInclusive(value, Restrictions.TrainPassangerCapacityMinValue,
                    Restrictions.TrainPassangerCapacityMaxValue, 
                    "A train cannot have less than 30 passengers or more than 150 passengers.");

                base.PassangerCapacity = value;
            }
        }

        public int Carts
        {
            get => this.carts;
            private set
            {
                Validator.ArgumentIsInRangeInclusive(value, Restrictions.TrainCartsMinValue, 
                    Restrictions.TrainCartsMaxValue, 
                    "A train cannot have less than 1 cart or more than 15 carts.");

                this.carts = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append($"Carts amount: {this.Carts}");

            return sb.ToString();
        }
    }
}
