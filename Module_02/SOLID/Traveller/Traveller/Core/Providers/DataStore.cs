using System.Collections;
using System.Collections.Generic;
using Bytes2you.Validation;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Providers
{
    public class DataStore : IDataStore
    {
        private readonly List<IJourney> journeys;
        private readonly List<ITicket> tickets;
        private readonly List<IVehicle> vehicles;

        public DataStore()
        {
            this.vehicles = new List<IVehicle>();
            this.journeys = new List<IJourney>();
            this.tickets = new List<ITicket>();
        }

        public List<IVehicle> Vehicles => new List<IVehicle>(this.vehicles);

        public List<IJourney> Journeys => new List<IJourney>(this.journeys);

        public List<ITicket> Tickets => new List<ITicket>(this.tickets);

        public int AddTicket(ITicket ticket)
        {
            Guard.WhenArgument(ticket, ticket.GetType().Name).IsNull().Throw();
            this.tickets.Add(ticket);

            return this.tickets.Count - 1;
        }

        public int AddJourney(IJourney journey)
        {
            Guard.WhenArgument(journey, journey.GetType().Name).IsNull().Throw();
            this.journeys.Add(journey);

            return this.journeys.Count - 1;
        }

        public int AddVehicle(IVehicle vehicle)
        {
            Guard.WhenArgument(vehicle, vehicle.GetType().Name).IsNull().Throw();
            this.vehicles.Add(vehicle);

            return this.vehicles.Count - 1;
        }
    }
}