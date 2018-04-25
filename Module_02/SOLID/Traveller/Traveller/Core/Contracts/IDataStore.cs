using System.Collections.Generic;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Contracts
{
    public interface IDataStore
    {
        List<IJourney> Journeys { get; }
        List<ITicket> Tickets { get; }
        List<IVehicle> Vehicles { get; }

        int AddJourney(IJourney journey);
        int AddTicket(ITicket ticket);
        int AddVehicle(IVehicle vehicle);
    }
}