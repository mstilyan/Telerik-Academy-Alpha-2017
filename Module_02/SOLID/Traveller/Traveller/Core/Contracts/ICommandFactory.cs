using Traveller.Commands.Contracts;

namespace Traveller.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}