using FurnitureManufacturer.Commands.Contracts;
using System;

namespace FurnitureManufacturer.Engine.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}
