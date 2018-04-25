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
    public class CreateJourneyCommand : CreateCommand
    {

        public CreateJourneyCommand(ITravellerFactory travellerFactory, IDataStore dataStore, CommandConstants commandConstants) : 
            base(travellerFactory, dataStore, commandConstants)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                var vehicleId = int.Parse(parameters[3]);
                vehicle = this.DataStore.Vehicles[vehicleId];
            }
            catch
            {
                var commandName = this.GetType().Name.Replace("Command", string.Empty);

                var errorMessage = string.Format(this.CommandConstants.InvalidCommandParametersErrorMessage,
                    commandName);

                throw new ArgumentException(errorMessage);
            }

            var journey = this.TravellerFactory.CreateJourney(startLocation, destination, distance, vehicle);
            var journeyId = this.DataStore.AddJourney(journey);

            return string.Format(CommandConstants.JourneyCreatedSuccessMessage, journeyId);
        }
    }
}
