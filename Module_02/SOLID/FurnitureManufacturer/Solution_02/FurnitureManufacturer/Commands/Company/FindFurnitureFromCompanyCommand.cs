using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Interfaces.Engine;
using System.Collections.Generic;

namespace FurnitureManufacturer.Commands
{
    public class FindFurnitureFromCompanyCommand : ICommand
    {
        private readonly IDataStore data;
        private readonly Constants constants;

        public FindFurnitureFromCompanyCommand(IDataStore data, Constants constants)
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

            var company = this.data.Companies[companyName];
            var furniture = company.Find(furnitureModel);

            if (furniture == null)
            {
                return string.Format(this.constants.FurnitureNotFoundErrorMessage, furnitureModel);
            }

            return furniture.ToString();
        }
    }
}
