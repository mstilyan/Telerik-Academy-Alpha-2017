using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;
using System.Collections.Generic;

namespace FurnitureManufacturer.Commands
{
    public class CreateChairCommand : ICommand
    {
        private readonly IDataStore data;
        private readonly IFurnitureFactory factory;
        private readonly Constants constants;

        public CreateChairCommand(IDataStore data, IFurnitureFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants;
        }

        public string Execute(IList<string> parameters)
        {
            var model = parameters[0];
            var material = parameters[1];
            var price = decimal.Parse(parameters[2]);
            var height = decimal.Parse(parameters[3]);
            var legs = int.Parse(parameters[4]);

            if (this.data.Furniture.ContainsKey(model))
            {
                return string.Format(this.constants.FurnitureExistsErrorMessage, model);
            }

            IFurniture chair = this.factory.CreateChair(model, material, price, height, legs);

            this.data.AddFurniture(chair);

            return string.Format(this.constants.ChairCreatedSuccessMessage, model);
        }
    }
}
