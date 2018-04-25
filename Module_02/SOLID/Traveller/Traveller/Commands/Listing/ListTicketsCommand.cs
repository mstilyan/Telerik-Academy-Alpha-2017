using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using Traveller.Commands.Contracts;
using Traveller.Commands.Listing.Abstract;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Listing
{
    public class ListTicketsCommand : ListCommand
    {
        public ListTicketsCommand(IDataStore dataStore, CommandConstants commandConstants) : 
            base(dataStore, commandConstants)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var tickets = this.DataStore.Tickets;

            Guard.WhenArgument(tickets.Count, this.CommandConstants.NoRegisteredTicketsErrorMessage)
                .IsEqual(0)
                .Throw();

            return string.Join(this.CommandConstants.ListingDelimiter, tickets);
        }
    }
}
