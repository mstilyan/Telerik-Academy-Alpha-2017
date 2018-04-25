using System.Collections.Generic;
using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;

namespace FurnitureManufacturer.Commands.Company
{
    public class RemoveFurnitureFromCompanyCommand : ICommand
    {
        private readonly IDataStore data;
        private readonly Constants constants;

        public RemoveFurnitureFromCompanyCommand(IDataStore data, Constants constants)
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
            company.Remove(furniture);

            return string.Format(this.constants.FurnitureRemovedSuccessMessage, furnitureModel, companyName);
        }
    }
}
