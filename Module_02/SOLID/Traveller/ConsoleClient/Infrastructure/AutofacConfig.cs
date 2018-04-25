using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace ConsoleClient.Infrastructure
{
    internal sealed class AutofacConfig
    {
        private IContainer container;

        private IContainer Container
        {
            get
            {
                if (this.container == null)
                {
                    throw new InvalidOperationException("Container must be build before accessed!");
                }

                return this.container;
            }
        }

        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            this.RegisterConvention(builder);
            this.RegisterCoreComponents(builder);
            this.RegisterDynamicCommands(builder);

            return this.container = builder.Build();
        }

        private void RegisterConvention(ContainerBuilder builder)
        {
            var assembly = Assembly.GetAssembly(typeof(IEngine));
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces();
        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<TimingEngine>().AsSelf().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<DataStore>().As<IDataStore>().SingleInstance();

            builder.RegisterType<CommandConstants>().AsSelf().SingleInstance();
            builder.RegisterType<ConsoleRenderer>().As<IRenderer>();
        }

        private void RegisterDynamicCommands(ContainerBuilder builder)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(IEngine));

            var commandTypeInfos = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)) && !type.IsAbstract)
                .ToList();

            foreach (var commandInfo in commandTypeInfos)
            {
                var commandName = commandInfo.Name.ToLowerInvariant().Replace("command", String.Empty);
                builder.RegisterType(commandInfo.AsType()).Named<ICommand>(commandName).SingleInstance();
            }
        }
    }
}