using System;
using System.Collections.Generic;
using System.Linq;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Factories;
using FurnitureManufacturer.Interfaces.Repository;

namespace FurnitureManufacturer.Engine.Commands.Abstract
{
    public abstract class CreateFurnitureCommand : ICommand
    {
        private const string NullCollectionOfParameters = "Collection of parameteres cannot be null";

        protected CreateFurnitureCommand(IFurnitureFactory furnitureFactory, IFurnitureRepository furnitureRepository)
        {
            FurnitureFactory = furnitureFactory;
            FurnitureRepository = furnitureRepository;
        }

        protected IFurnitureFactory FurnitureFactory { get; }
        protected IFurnitureRepository FurnitureRepository { get; }

        protected string Model { get; private set; }

        protected string Material { get; private set; }

        protected decimal Price { get; private set; }

        protected decimal Height { get; private set; }

        public string Execute(IList<string> commandParameters)
        {
            if (commandParameters == null)
            {
                throw new ArgumentNullException(NullCollectionOfParameters);
            }

            try
            {
                this.Model = commandParameters[0];
                this.Material = commandParameters[1];
                this.Price = decimal.Parse(commandParameters[2]);
                this.Height = decimal.Parse(commandParameters[3]);
            }
            catch (Exception)
            {
                return Messages.InvalidCommandParametersErrorMessage;
            }

            var furniture = CreateFurniture(commandParameters.Skip(4).ToList());
            bool furnitureIsSaved = FurnitureRepository.Commit(furniture);

            if (furnitureIsSaved)
            {
                return string.Format(Messages.FurnitureCreatedSuccessMessage, furniture.GetType().Name,
                    this.Model);
            }

            throw new ArgumentException(string.Format(Messages.FurnitureExistsErrorMessage, this.Model));
        }

        protected abstract IFurniture CreateFurniture(IList<string> commandParameters);
    }
}
