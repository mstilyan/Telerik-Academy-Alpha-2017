using System;

namespace Traveller.Core
{
    public class CommandConstants
    {
        //error messages
        public virtual string InvalidCommandErrorMessage => "Invalid command name: {0}";
        public virtual string InvalidCommandParametersErrorMessage => "Failed to parse {0} command parameters.";
        public virtual string NoRegisteredJourneysErrorMessage => "There are no registered journeys.";
        public virtual string NoRegisteredTicketsErrorMessage => "There are no registered tickets.";
        public virtual string NoRegisteredVehiclesErrorMessage => "There are no registered vehicles.";

        //success messages
        public virtual string VehicleCreatedSuccessMessage => "Vehicle with ID {0} was created.";
        public virtual string TicketCreatedSuccessMessage => "Ticket with ID {0} was created.";
        public virtual string JourneyCreatedSuccessMessage => "Journey with ID {0} was created.";

        //other
        public virtual string TerminationCommand => "exit";
        public virtual string ListingDelimiter => $"{Environment.NewLine}####################{Environment.NewLine}";
    }
}