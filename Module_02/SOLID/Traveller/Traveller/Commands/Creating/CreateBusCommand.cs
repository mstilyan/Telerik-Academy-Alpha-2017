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
    public class CreateBusCommand : CreateVehicleCommand
    {

        public CreateBusCommand(ITravellerFactory travellerFactory, IDataStore dataStore, CommandConstants commandConstants) : 
            base(travellerFactory, dataStore, commandConstants)
        {
        }

        protected override IVehicle CreateVehicle(IList<string> parameters)
        {
            return this.TravellerFactory.CreateBus(this.PassengerCapacity, this.PricePerKilometer);
        }
    }
}
