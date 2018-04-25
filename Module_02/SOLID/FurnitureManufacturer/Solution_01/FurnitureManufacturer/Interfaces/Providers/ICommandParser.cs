using System.Collections.Generic;
using FurnitureManufacturer.Interfaces.Engine;

namespace FurnitureManufacturer.Interfaces.Providers
{
    public interface ICommandParser
    {
        IList<string> Parse(string commandLine, out ICommand command);
    }
}