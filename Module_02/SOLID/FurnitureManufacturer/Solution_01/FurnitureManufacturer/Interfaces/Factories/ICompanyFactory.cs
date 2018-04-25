namespace FurnitureManufacturer.Interfaces.Factories
{
    public interface ICompanyFactory
    {
        ICompany CreateCompany(string name, string registrationNumber);
    }
}
