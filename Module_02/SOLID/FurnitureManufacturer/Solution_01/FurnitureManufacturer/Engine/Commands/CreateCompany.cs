using System;
using System.Collections.Generic;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Factories;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands
{
    public class CreateCompany : ICommand
    {
        private readonly ICompanyFactory companyFactory;
        private readonly ICompanyRepository companyRepository;

        public CreateCompany(ICompanyFactory companyFactory, ICompanyRepository companyRepository)
        {
            this.companyFactory = companyFactory;
            this.companyRepository = companyRepository;
        }

        public string Execute(IList<string> commandParameters)
        {
            if (commandParameters == null)
            {
                throw new ArgumentNullException(Messages.InvalidCommandParametersErrorMessage);
            }

            string name, registrationNumber;
            try
            {
                name = commandParameters[0];
                registrationNumber = commandParameters[1];
            }
            catch (Exception )
            {
                throw new ArgumentException(Messages.InvalidCommandParametersErrorMessage);
            }

            var company = companyFactory.CreateCompany(name, registrationNumber);
            bool companyIsSaved = companyRepository.Commit(company);

            if (companyIsSaved)
            {
                return string.Format(Messages.CompanyCreatedSuccessMessage, name);
            }

            throw new InvalidOperationException(string.Format(Messages.CompanyExistsErrorMessage, name));
        }
    }
}