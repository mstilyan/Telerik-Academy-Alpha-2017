using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using FurnitureManufacturer.Engine.Commands;
using FurnitureManufacturer.Interfaces.Engine;

namespace ConsoleClient
{
    public sealed class AutofacConfic
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            this.RegisterCoreComponents(builder);
            this.RegisterCommandTypes(builder);

            return builder.Build();
        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            var assembly = Assembly.GetAssembly(typeof(IFurnitureManufacturerEngine));

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .SingleInstance();
        }

        private void RegisterCommandTypes(ContainerBuilder builder)
        {
            builder.RegisterType<CreateTableCommand>().Named<ICommand>("CreateTable");
            builder.RegisterType<CreateChairCommand>().Named<ICommand>("CreateChair");
            builder.RegisterType<CreateCompany>().Named<ICommand>("CreateCompany");
            builder.RegisterType<AddFurnitureToCompanyCommand>().Named<ICommand>("AddFurnitureToCompany");
            builder.RegisterType<RemoveFurnitureFromCompanyCommand>().Named<ICommand>("RemoveFurnitureFromCompany");
            builder.RegisterType<FindFurnitureFromCompanyCommand>().Named<ICommand>("FindFurnitureFromCompany");
            builder.RegisterType<ShowCompanyCatalogCommand>().Named<ICommand>("ShowCompanyCatalog");
        }
    }
}