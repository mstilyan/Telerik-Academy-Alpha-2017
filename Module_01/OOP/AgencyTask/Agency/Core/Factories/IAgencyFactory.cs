using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core.Contracts
{
    public interface IAgencyFactory
    {
        IBus CreateBus(int passengerCapacity, decimal pricePerKilometer);
        
        ITrain CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts);

        IAirplane CreateAirplane(int passengerCapacity, decimal pricePerKilomenter, bool hasFreeFood);
        
        IJourney CreateJourney(string startingLocation, string destination, int distance, IVehicle vehicle);

        ITicket CreateTicket(IJourney journey, decimal administrativeCosts);
    }
}
