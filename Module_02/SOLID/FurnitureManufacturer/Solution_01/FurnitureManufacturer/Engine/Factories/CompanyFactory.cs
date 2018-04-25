using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Factories;
using FurnitureManufacturer.Models;

namespace FurnitureManufacturer.Engine.Factories
{
    public class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            return new Company(name, registrationNumber);
        }
    }
}
