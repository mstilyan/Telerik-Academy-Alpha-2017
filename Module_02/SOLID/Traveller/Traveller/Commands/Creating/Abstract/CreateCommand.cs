using System.Collections.Generic;
using Traveller.Core;
using Traveller.Core.Contracts;
using ICommand = Traveller.Commands.Contracts.ICommand;

namespace Traveller.Commands.Creating.Abstract
{
    public abstract class CreateCommand : ICommand
    {
        protected CreateCommand(ITravellerFactory travellerFactory, IDataStore dataStore, CommandConstants commandConstants)
        {
            this.TravellerFactory = travellerFactory;
            this.DataStore = dataStore;
            this.CommandConstants = commandConstants;
        }

        protected ITravellerFactory TravellerFactory { get; }
        protected IDataStore DataStore { get; }

        protected CommandConstants CommandConstants { get; }

        public abstract string Execute(IList<string> parameters);
    }
}