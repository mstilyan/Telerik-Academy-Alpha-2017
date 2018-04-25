using Bytes2you.Validation;
using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Interfaces;
using System.Collections.Generic;

namespace FurnitureManufacturer.Engine
{
    public class DataStore : IDataStore
    {
        private readonly IDictionary<string, ICompany> companies;
        private readonly IDictionary<string, IFurniture> furniture;

        public DataStore()
        {
            this.companies = new Dictionary<string, ICompany>();
            this.furniture = new Dictionary<string, IFurniture>();
        }

        /// <summary>
        /// Immutable collection, holding ICompany objects and their Name as key.
        /// </summary>
        public IDictionary<string, ICompany> Companies => new Dictionary<string, ICompany>(this.companies);

        /// <summary>
        /// Immutable collection, holding IFurniture objects and their Model as key.
        /// </summary>
        public IDictionary<string, IFurniture> Furniture => new Dictionary<string, IFurniture>(this.furniture);

        public void AddCompany(ICompany company)
        {
            Guard.WhenArgument(company, company.GetType().Name).IsNull().Throw();
            this.companies.Add(company.Name, company);
        }

        public void AddFurniture(IFurniture furniture)
        {
            Guard.WhenArgument(furniture, furniture.GetType().Name).IsNull().Throw();
            this.furniture.Add(furniture.Model, furniture);
        }
    }
}
