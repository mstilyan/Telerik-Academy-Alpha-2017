using FurnitureManufacturer.Interfaces.Engine;

namespace FurnitureManufacturer.Interfaces.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}