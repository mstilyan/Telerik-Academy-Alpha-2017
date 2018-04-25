using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using Traveller.Commands.Contracts;
using Traveller.Commands.Listing.Abstract;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Listing
{
    public class ListVehiclesCommand : ListCommand
    {
        public ListVehiclesCommand(IDataStore dataStore, CommandConstants commandConstants) :
            base(dataStore, commandConstants)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var vehicles = this.DataStore.Vehicles;

            Guard.WhenArgument(vehicles.Count, this.CommandConstants.NoRegisteredVehiclesErrorMessage)
                .IsEqual(0)
                .Throw();

            return string.Join(this.CommandConstants.ListingDelimiter, vehicles);
        }
    }
}
