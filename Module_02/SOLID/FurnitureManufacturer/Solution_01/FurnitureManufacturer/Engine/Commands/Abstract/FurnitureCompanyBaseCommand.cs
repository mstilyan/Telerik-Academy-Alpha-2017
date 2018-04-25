using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands.Abstract
{
    public abstract class FurnitureCompanyBaseCommand : ICommand
    {
        protected FurnitureCompanyBaseCommand(IFurnitureRepository furnitureRepository, ICompanyRepository companyRepository)
        {
            this.FurnitureRepository = furnitureRepository;
            this.CompanyRepository = companyRepository;
        }

        protected IFurnitureRepository FurnitureRepository { get; }

        protected ICompanyRepository CompanyRepository { get; }

        public string Execute(IList<string> commandParameters)
        {
            if (commandParameters == null)
            {
                throw new ArgumentNullException(Messages.InvalidCommandParametersErrorMessage);
            }

            string companyName, furnitureModel;
            try
            {
                companyName = commandParameters[0];
                furnitureModel = commandParameters[1];
            }
            catch (Exception)
            {
                throw new ArgumentException(Messages.InvalidCommandParametersErrorMessage);
            }

            ICompany company = this.CompanyRepository.Return(companyName);
            IFurniture furniture = this.FurnitureRepository.Return(furnitureModel);

            if (company == null)
            {
                throw new InvalidOperationException(string.Format(Messages.CompanyNotFoundErrorMessage, companyName));
            }

            if (furniture == null)
            {
                throw new InvalidOleVariantTypeException(string.Format(Messages.FurnitureNotFoundErrorMessage, furnitureModel));
            }

            return Execute(company, furniture);
        }

        protected abstract string Execute(ICompany company, IFurniture furniture);
    }
}
