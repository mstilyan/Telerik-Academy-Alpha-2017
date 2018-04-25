using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class Chair : Furniture, IFurniture, IChair
    {
        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs) 
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; }

        protected override string AdditionalInfo()
        {
            return $", Legs: {this.NumberOfLegs}";
        }
    }
}
