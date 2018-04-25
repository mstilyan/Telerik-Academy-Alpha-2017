using Autofac;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Core.Factories
{
    class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext componentContext;

        public CommandFactory(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public ICommand CreateCommand(string commandName)
        {
            return componentContext.ResolveNamed<ICommand>(commandName);
        }
    }
}