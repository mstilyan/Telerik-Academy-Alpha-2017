using Autofac;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Infrastructure.Injection;

namespace FurnitureManufacturer
{
    public sealed class Startup
    {
        public static void Main()
        {
            var containerConfig = new AutofacConfig();
            var container = containerConfig.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
