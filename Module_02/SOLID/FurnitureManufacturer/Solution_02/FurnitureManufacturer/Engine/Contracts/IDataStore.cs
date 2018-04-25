using FurnitureManufacturer.Interfaces;
using System.Collections.Generic;

namespace FurnitureManufacturer.Engine.Contracts
{
    public interface IDataStore
    {
        IDictionary<string, ICompany> Companies { get; }

        IDictionary<string, IFurniture> Furniture { get; }

        void AddCompany(ICompany company);

        void AddFurniture(IFurniture furniture);
    }
}
