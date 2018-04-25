using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Interfaces.Engine;
using System;
using System.Collections.Generic;

namespace FurnitureManufacturer.Commands
{
    public class CreateCompanyCommand : ICommand
    {
        private readonly IDataStore data;
        private readonly ICompanyFactory factory;
        private readonly Constants constants;

        public CreateCompanyCommand(IDataStore data, ICompanyFactory factory, Constants constants)
        {
            this.data = data;
            this.factory = factory;
            this.constants = constants;
        }

        public string Execute(IList<string> parameters)
        {
            var name = parameters[0];
            var registrationNumber = parameters[1];

            if (this.data.Companies.ContainsKey(name))
            {
                return string.Format(this.constants.CompanyExistsErrorMessage, name);
            }

            var company = this.factory.CreateCompany(name, registrationNumber);
            this.data.AddCompany(company);

            return string.Format(this.constants.CompanyCreatedSuccessMessage, name);
        }
    }
}
