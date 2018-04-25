using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating.Abstract;
using Traveller.Commands.Listing.Abstract;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Listing
{
    public class ListJourneysCommand : ListCommand
    {
        public ListJourneysCommand(IDataStore dataStore, CommandConstants commandConstants) : 
            base(dataStore, commandConstants)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var journeys = this.DataStore.Journeys;

            Guard.WhenArgument(journeys.Count, this.CommandConstants.NoRegisteredJourneysErrorMessage)
                .IsEqual(0)
                .Throw();

            return string.Join(this.CommandConstants.ListingDelimiter, journeys);
        }
    }
}
