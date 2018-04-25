using System;
using System.Collections.Generic;
using FurnitureManufacturer.Engine.Commands.Abstract;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Factories;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands
{
    public class CreateTableCommand : CreateFurnitureCommand
    {
        public CreateTableCommand(IFurnitureFactory furnitureFactory, IFurnitureRepository furnitureRepository) : 
            base(furnitureFactory, furnitureRepository)
        {
        }

        protected override IFurniture CreateFurniture(IList<string> commandParameters)
        {
            decimal length, width;
            try
            {
                length = decimal.Parse(commandParameters[0]);
                width = decimal.Parse(commandParameters[1]);
            }
            catch (Exception)
            {
                throw new ArgumentException(Messages.InvalidCommandParametersErrorMessage);
            }

            return this.FurnitureFactory.CreateTable(this.Model, this.Material, this.Price, this.Height, length, width);
        }
    }
}