using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Interfaces.Engine;
using System.Collections.Generic;

namespace FurnitureManufacturer.Commands
{
    public class CreateTableCommand : ICommand
    {
        private readonly IDataStore data;
        private readonly IFurnitureFactory factory;
        private readonly Constants constants;

        public CreateTableCommand(IDataStore data, IFurnitureFactory factory, Constants constants)
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
            var length = decimal.Parse(parameters[4]);
            var width = decimal.Parse(parameters[5]);

            if (this.data.Furniture.ContainsKey(model))
            {
                return string.Format(this.constants.FurnitureExistsErrorMessage, model);
            }

            var table = this.factory.CreateTable(model, material, price, height, length, width);
            this.data.AddFurniture(table);

            return string.Format(this.constants.TableCreatedSuccessMessage, model);
        }
    }
}
