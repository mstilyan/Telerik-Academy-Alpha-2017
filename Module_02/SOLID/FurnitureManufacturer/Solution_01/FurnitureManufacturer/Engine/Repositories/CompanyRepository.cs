using System.Collections.Generic;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDictionary<string, ICompany> companies;

        public CompanyRepository()
        {
            this.companies = new Dictionary<string, ICompany>();
        }

        public bool Commit(ICompany company)
        {
            if (this.companies.ContainsKey(company.Name))
            {
                return false;
            }

            this.companies.Add(company.Name, company);
            return true;
        }

        public bool Delete(ICompany company)
        {
            if (!this.companies.ContainsKey(company.Name))
            {
                return false;
            }

            this.companies.Remove(company.Name);
            return true;
        }

        public ICompany Return(string name)
        {
            if (this.companies.ContainsKey(name))
            {
                return companies[name];
            }

            return null;
        }
    }
}