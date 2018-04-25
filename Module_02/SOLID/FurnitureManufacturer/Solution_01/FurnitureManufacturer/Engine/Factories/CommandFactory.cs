using Autofac;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Factories;

namespace FurnitureManufacturer.Engine.Factories
{
    class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext componenteContext;

        public CommandFactory(IComponentContext componenteContext)
        {
            this.componenteContext = componenteContext;
        }

        public ICommand CreateCommand(string commandName)
        {
            return componenteContext.ResolveNamed<ICommand>(commandName);
        }
    }
}