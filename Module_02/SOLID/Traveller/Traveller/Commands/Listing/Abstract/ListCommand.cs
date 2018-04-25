using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Listing.Abstract
{
    public abstract class ListCommand : ICommand
    {
        protected ListCommand(IDataStore dataStore, CommandConstants commandConstants)
        {
            this.DataStore = dataStore;
            CommandConstants = commandConstants;
        }

        protected IDataStore DataStore { get; }
        protected CommandConstants CommandConstants { get; }

        public abstract string Execute(IList<string> parameters);
    }
}