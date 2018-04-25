using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Models;

namespace Agency.Models
{
    class Journey : IJourney
    {
        private string startLocation;
        private string destination;
        private int distance;
        private readonly IVehicle vehicle;

        public Journey(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            this.Destination = destination;
            this.Distance = distance;
            this.StartLocation = startLocation;
            this.vehicle = vehicle;
        }

        public string Destination
        {
            get => this.destination;
            private set
            {
                Validator.ArgumentStringNotNull(value);
                Validator.ArgumentIsInRangeInclusive(value.Length, Restrictions.JourneyDestinationMinLength, 
                    Restrictions.JourneyDestionationMaxLenght,
                    "The Destination's length cannot be less than 5 or more than 25 symbols long.");

                this.destination = value;
            }
        }

        public int Distance
        {
            get => this.distance;
            private set
            {
                Validator.ArgumentIsInRangeInclusive(value, Restrictions.JourneyDistanceMinLength, 
                    Restrictions.JourneyDistanceMaxLength,
                    "The Distance cannot be less than 5 or more than 5000 kilometers.");

                this.distance = value;
            }
        }
        public string StartLocation
        {
            get => this.startLocation;
            private set
            {
                Validator.ArgumentStringNotNull(value);
                Validator.ArgumentIsInRangeInclusive(value.Length, Restrictions.JourneyStartingLocationMinLength, 
                    Restrictions.JourneyStartingLocationMaxLength,
                    "The StartingLocation's length cannot be less than 5 or more than 25 symbols long.");

                this.startLocation = value;
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                switch (this.vehicle)
                {
                    case IBus bus:
                        return new Bus(bus.PassangerCapacity, bus.PricePerKilometer);
                    case IAirplane airplane:
                        return new Airplane(airplane.PassangerCapacity, airplane.PricePerKilometer, airplane.HasFreeFood);
                    case ITrain train:
                        return new Train(train.PassangerCapacity, train.PricePerKilometer, train.Carts);
                }

                throw new ArgumentException();
            }
        }

        public decimal CalculateTravelCosts()
        {
            return this.Distance * this.vehicle.PricePerKilometer;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} ----");
            sb.AppendLine($"Start location: {this.StartLocation}");
            sb.AppendLine($"Destination: {this.Destination}");
            sb.AppendLine($"Distance: {this.Distance}");
            sb.AppendLine($"Vehicle type: {this.vehicle.Type}");
            sb.Append($"Travel costs: {this.CalculateTravelCosts()}");

            return sb.ToString();
        }
    }
}
