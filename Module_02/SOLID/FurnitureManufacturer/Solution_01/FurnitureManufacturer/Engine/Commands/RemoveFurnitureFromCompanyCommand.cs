using FurnitureManufacturer.Engine.Commands.Abstract;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands
{
    public class RemoveFurnitureFromCompanyCommand : FurnitureCompanyBaseCommand
    {
        public RemoveFurnitureFromCompanyCommand(IFurnitureRepository furnitureRepository, ICompanyRepository companyRepository) : 
            base(furnitureRepository, companyRepository)
        {
        }

        protected override string Execute(ICompany company, IFurniture furniture)
        {
            company.Remove(furniture);
            return string.Format(Messages.FurnitureRemovedSuccessMessage, furniture.Model, company.Name);
        }
    }
}