using System.Collections.Generic;

namespace FurnitureManufacturer.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
