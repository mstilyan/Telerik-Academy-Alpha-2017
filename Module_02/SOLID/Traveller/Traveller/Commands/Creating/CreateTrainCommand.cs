using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating.Abstract;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : CreateVehicleCommand
    {
        public CreateTrainCommand(ITravellerFactory travellerFactory, IDataStore dataStore, CommandConstants commandConstants) : 
            base(travellerFactory, dataStore, commandConstants)
        {
        }

        protected override IVehicle CreateVehicle(IList<string> parameters)
        {
            int carts;
            try
            {
                carts = int.Parse(parameters[0]);
            }
            catch (Exception)
            {
                var commandName = this.GetType().Name.Replace("Command", string.Empty);
                throw new ArgumentException(string.Format(CommandConstants.InvalidCommandParametersErrorMessage, commandName));
            }

            return this.TravellerFactory.CreateTrain(this.PassengerCapacity, this.PricePerKilometer, carts);
        }
    }
}
