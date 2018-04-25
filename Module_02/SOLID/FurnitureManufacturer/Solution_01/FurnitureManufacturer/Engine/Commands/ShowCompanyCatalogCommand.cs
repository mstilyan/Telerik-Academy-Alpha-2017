using System;
using System.Collections.Generic;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands
{
    public class ShowCompanyCatalogCommand : ICommand
    {
        private readonly ICompanyRepository companyRepository;

        public ShowCompanyCatalogCommand(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public string Execute(IList<string> commandParameters)
        {
            if (commandParameters == null || commandParameters.Count == 0)
            {
                throw new NullReferenceException(Messages.InvalidCommandParametersErrorMessage);
            }

            var companyName = commandParameters[0];
            var company = this.companyRepository.Return(companyName);

            if (company == null)
            {
                throw new InvalidOperationException(string.Format(Messages.CompanyNotFoundErrorMessage, companyName));
            }

            return company.Catalog();
        }
    }
}