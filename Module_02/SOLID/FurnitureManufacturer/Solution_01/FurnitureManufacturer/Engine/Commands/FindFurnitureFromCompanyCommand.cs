using System;
using FurnitureManufacturer.Engine.Commands.Abstract;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands
{
    public class FindFurnitureFromCompanyCommand : FurnitureCompanyBaseCommand
    {
        public FindFurnitureFromCompanyCommand(IFurnitureRepository furnitureRepository, ICompanyRepository companyRepository) : 
            base(furnitureRepository, companyRepository)
        {
        }

        protected override string Execute(ICompany company, IFurniture furniture)
        {
            var resultFurniture = company.Find(furniture.Model);
            if (resultFurniture == null)
            {
                throw new ArgumentException(string.Format(Messages.FurnitureNotFoundErrorMessage, furniture.Model));
            }

            return resultFurniture.ToString();
        }
    }
}