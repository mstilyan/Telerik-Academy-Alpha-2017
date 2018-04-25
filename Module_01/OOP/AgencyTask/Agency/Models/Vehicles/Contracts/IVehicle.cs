using Agency.Models.Enums;

namespace Agency.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        VehicleType Type { get; }

        int PassangerCapacity { get; }

        decimal PricePerKilometer { get; }
    }
}