using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating.Abstract;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : CreateCommand
    {

        public CreateTicketCommand(ITravellerFactory travellerFactory, IDataStore dataStore, CommandConstants commandConstants) :
            base(travellerFactory, dataStore, commandConstants)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                int journeyId = int.Parse(parameters[0]);
                journey = this.DataStore.Journeys[journeyId];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                var commandName = this.GetType().Name.Replace("Command", string.Empty);

                var errorMessage = string.Format(this.CommandConstants.InvalidCommandParametersErrorMessage,
                    commandName);

                throw new ArgumentException(errorMessage);
            }

            var ticket = this.TravellerFactory.CreateTicket(journey, administrativeCosts);
            var ticketId = this.DataStore.AddTicket(ticket);

            return string.Format(CommandConstants.TicketCreatedSuccessMessage, ticketId);
        }
    }
}
