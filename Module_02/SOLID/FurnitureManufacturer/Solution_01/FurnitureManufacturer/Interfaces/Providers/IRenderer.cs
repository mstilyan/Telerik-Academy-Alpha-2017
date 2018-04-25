using System.Collections.Generic;

namespace FurnitureManufacturer.Interfaces.Providers
{
    public interface IRenderer
    {
        IEnumerable<string> Input();

        void Output(IEnumerable<string> output);
    }
}
