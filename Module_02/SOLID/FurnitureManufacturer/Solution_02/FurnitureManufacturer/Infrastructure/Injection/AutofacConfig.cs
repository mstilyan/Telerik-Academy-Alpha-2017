using Autofac;
using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using ImpromptuInterface;
using System;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace FurnitureManufacturer.Infrastructure.Injection
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
                    throw new InvalidOperationException("You must first build the container before accessing it!");
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
            this.RegisterDynamicFactory(builder);

            this.container = builder.Build();
            return this.container;
        }

        private void RegisterConvention(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(currentAssembly)
                   .AsImplementedInterfaces();
        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<FurnitureEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<Constants>().AsSelf().SingleInstance();
            builder.RegisterType<DataStore>().As<IDataStore>().SingleInstance();
        }
        
        private void RegisterDynamicCommands(ContainerBuilder builder)
        {
            // Get the current assembly (VS Project)
            Assembly currentAssembly = this.GetType().Assembly;

            // Get all the classes in this assembly that implement the interface ICommand
            var commandTypeInfos = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .ToList();

            foreach (var commandInfo in commandTypeInfos)
            {
                // Get the name of the class
                var commandName = commandInfo.Name.ToLowerInvariant();

                // Trim the classe's name to remove the "command" part at the end
                var commandNameTrimmed = commandName.Substring(0, commandName.Length - "command".Length);

                // Bind that class to the ICommand interface, using it's trimmed name. (As singleton)
                builder.RegisterType(commandInfo.AsType()).Named<ICommand>(commandNameTrimmed).SingleInstance();
            }
        }

        // !!!! Before reading this method, see:
        // - What's inside the ICommandFactory
        // - How ICommandFactory is used inside the Engine
        private void RegisterDynamicFactory(ContainerBuilder builder)
        {
            // ExpandoObject is a class in C# to which you can add whatever methods or properties you want
            dynamic factoryProxy = new ExpandoObject();

            // This is the body of the method I assign below. It uses the Autofac container to get a command by it's name. 
            // Those commands are bound in the RegisterDynamicCommands method.
            Func<string, ICommand> methodBody = (commandName => this.Container.ResolveNamed<ICommand>(commandName.ToLower()));

            // I create a "method" called GetCommand, using the delegate above
            factoryProxy.GetCommand = methodBody;

            // Using the impromptu-interface library, I convert this dynamic object to the interface ICommandFactory.
            ICommandsFactory factoryShell = Impromptu.ActLike<ICommandsFactory>(factoryProxy);

            // Then i say - whenever you want an implementation of ICommandsFactory (like in the Engine)
            // Use the object I created dynamically above
            builder.RegisterInstance(factoryShell).As<ICommandsFactory>();

            // Magic!
        }
    }
}
