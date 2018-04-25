using System.Collections.Generic;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Repositories
{
    public class FurnitureRepository : IFurnitureRepository
    {
        private readonly IDictionary<string, IFurniture> furnitures;

        public FurnitureRepository()
        {
            this.furnitures = new Dictionary<string, IFurniture>();
        }

        public bool Commit(IFurniture furniture)
        {
            if (this.furnitures.ContainsKey(furniture.Model))
            {
                return false;
            }

            this.furnitures.Add(furniture.Model, furniture);
            return true;
        }

        public bool Delete(IFurniture furniture)
        {
            if (this.furnitures.ContainsKey(furniture.Model))
            {
                return false;
            }

            this.furnitures.Remove(furniture.Model);
            return true;
        }

        public IFurniture Return(string model)
        {
            if (this.furnitures.ContainsKey(model))
            {
                return this.furnitures[model];
            }

            return null;
        }
    }
}