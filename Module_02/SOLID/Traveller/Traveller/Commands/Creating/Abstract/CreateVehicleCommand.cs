using System;
using System.Collections.Generic;
using System.Linq;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating.Abstract
{
    public abstract class CreateVehicleCommand : CreateCommand
    {
        protected CreateVehicleCommand(ITravellerFactory travellerFactory, IDataStore dataStore, CommandConstants commandConstants) : 
            base(travellerFactory, dataStore, commandConstants)
        {
        }

        protected int PassengerCapacity { get; private set; }
        protected decimal PricePerKilometer { get; private set; }

        public override string Execute(IList<string> parameters)
        {
            try
            {
                this.PassengerCapacity = int.Parse(parameters[0]);
                this.PricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch (Exception)
            {
                var commandName = this.GetType().Name.Replace("Command", string.Empty);

                var errorMessage = string.Format(this.CommandConstants.InvalidCommandParametersErrorMessage,
                    commandName);

                throw new ArgumentException(errorMessage);
            }

            IVehicle vehicle = CreateVehicle(parameters.Skip(2).ToList());
            int vehicleId = this.DataStore.AddVehicle(vehicle);

            return string.Format(CommandConstants.VehicleCreatedSuccessMessage, vehicleId);
        }

        protected abstract IVehicle CreateVehicle(IList<string> parameters);
    }
}