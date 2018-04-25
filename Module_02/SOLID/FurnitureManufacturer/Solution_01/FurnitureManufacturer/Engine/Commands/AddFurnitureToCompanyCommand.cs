using FurnitureManufacturer.Engine.Commands.Abstract;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands
{
    public class AddFurnitureToCompanyCommand : FurnitureCompanyBaseCommand
    {
        public AddFurnitureToCompanyCommand(IFurnitureRepository furnitureRepository, ICompanyRepository companyRepository) :
            base(furnitureRepository, companyRepository)
        {
        }

        protected override string Execute(ICompany company, IFurniture furniture)
        {
            company.Add(furniture);
            return string.Format(Messages.FurnitureAddedSuccessMessage, furniture.Model, company.Name);
        }
    }
}