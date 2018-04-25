using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Interfaces.Engine;
using System.Collections.Generic;

namespace FurnitureManufacturer.Commands
{
    public class AddFurnitureToCompanyCommand : ICommand
    {
        private readonly IDataStore data;
        private readonly Constants constants;

        public AddFurnitureToCompanyCommand(IDataStore data, Constants constants)
        {
            this.data = data;
            this.constants = constants;
        }

        public string Execute(IList<string> parameters)
        {
            var companyName = parameters[0];
            var furnitureModel = parameters[1];

            if (!this.data.Companies.ContainsKey(companyName))
            {
                return string.Format(this.constants.CompanyNotFoundErrorMessage, companyName);
            }

            if (!this.data.Furniture.ContainsKey(furnitureModel))
            {
                return string.Format(this.constants.FurnitureNotFoundErrorMessage, furnitureModel);
            }

            var company = this.data.Companies[companyName];
            var furniture = this.data.Furniture[furnitureModel];
            company.Add(furniture);

            return string.Format(this.constants.FurnitureAddedSuccessMessage, furnitureModel, companyName);
        }
    }
}
