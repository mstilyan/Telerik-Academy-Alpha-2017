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
    public class CreateAirplaneCommand : CreateVehicleCommand
    {
        public CreateAirplaneCommand(ITravellerFactory travellerFactory, IDataStore dataStore, CommandConstants commandConstants) : 
            base(travellerFactory, dataStore, commandConstants)
        {
        }

        protected override IVehicle CreateVehicle(IList<string> parameters)
        {
            bool hasFreeFood;
            try
            {
                hasFreeFood = bool.Parse(parameters[0]);
            }
            catch (Exception)
            {
                var commandName = this.GetType().Name.Replace("Command", string.Empty);
                throw new ArgumentException(string.Format(CommandConstants.InvalidCommandParametersErrorMessage, commandName));
            }

            return this.TravellerFactory.CreateAirplane(this.PassengerCapacity, this.PricePerKilometer, hasFreeFood);
        }
    }
}
