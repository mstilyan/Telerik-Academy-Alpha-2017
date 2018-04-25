using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles.Models
{
    class Airplane : Vehicle, IAirplane
    {
        public Airplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood) 
            : base(VehicleType.Air)
        {
            this.PassangerCapacity = passengerCapacity;
            this.PricePerKilometer = pricePerKilometer;
            this.HasFreeFood = hasFreeFood;
        }

        public bool HasFreeFood { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append($"Has free food: {this.HasFreeFood}");

            return sb.ToString();
        }
    }
}
