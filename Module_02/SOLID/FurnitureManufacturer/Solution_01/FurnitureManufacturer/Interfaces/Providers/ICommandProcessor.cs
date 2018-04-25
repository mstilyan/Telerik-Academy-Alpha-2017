using System.Collections.Generic;
using FurnitureManufacturer.Interfaces.Engine;

namespace FurnitureManufacturer.Interfaces.Providers
{
    public interface ICommandProcessor
    {
        string Process(ICommand command, IList<string> commandParameters);
    }
}