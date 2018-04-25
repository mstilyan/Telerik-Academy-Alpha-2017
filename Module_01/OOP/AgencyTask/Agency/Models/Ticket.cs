using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Contracts;

namespace Agency.Models
{
    class Ticket : ITicket
    {
        private readonly IJourney journey;
        private decimal administrativeCosts;

        public Ticket(IJourney journey, decimal administrativeCosts)
        {
            this.journey = journey;
            AdministrativeCosts = administrativeCosts;
        }

        public decimal AdministrativeCosts
        {
            get => this.administrativeCosts;
            private set
            {
                Validator.ArgumentIsGreaterThan(value, 0, "Administrative consts connot be negative");
                this.administrativeCosts = value;
            }
        }

        public IJourney Journey => new Journey(this.journey.StartLocation, this.journey.Destination,
            this.journey.Distance, this.journey.Vehicle);

        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts + this.journey.CalculateTravelCosts();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} ----");
            sb.AppendLine($"Destination: {this.journey.Destination}");
            sb.Append($"Price: {CalculatePrice()}");

            return sb.ToString();
        }
    }
}
