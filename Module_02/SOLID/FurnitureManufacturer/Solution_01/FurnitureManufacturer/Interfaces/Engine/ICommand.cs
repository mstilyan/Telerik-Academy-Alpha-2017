using System.Collections.Generic;

namespace FurnitureManufacturer.Interfaces.Engine
{
    public interface ICommand
    {
        string Execute(IList<string> commandParameters);
    }
}
