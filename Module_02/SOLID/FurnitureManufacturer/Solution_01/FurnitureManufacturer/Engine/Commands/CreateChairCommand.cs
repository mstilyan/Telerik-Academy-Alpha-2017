using System;
using System.Collections.Generic;
using FurnitureManufacturer.Engine.Commands.Abstract;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Factories;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands
{
    public class CreateChairCommand : CreateFurnitureCommand
    {
        public CreateChairCommand(IFurnitureFactory furnitureFactory, IFurnitureRepository furnitureRepository) : 
            base(furnitureFactory, furnitureRepository)
        {
        }

        protected override IFurniture CreateFurniture(IList<string> commandParameters)
        {
            int numberOfLegs;

            try
            {
                numberOfLegs = int.Parse(commandParameters[0]);
            }
            catch (Exception)
            {
                throw new ArgumentException(Messages.InvalidCommandParametersErrorMessage);
            }

            return this.FurnitureFactory.CreateChair(this.Model, this.Material, this.Price, this.Height, numberOfLegs);
        }
    }
}