using System;
using System.Collections.Generic;
using System.Linq;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Factories;
using FurnitureManufacturer.Interfaces.Providers;

namespace FurnitureManufacturer.Engine.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public IList<string> Parse(string commandLine, out ICommand command)
        {
            string commandName = string.Empty;

            try
            {
                var commandParameters = commandLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

                commandName = commandParameters[0];
                command = this.commandFactory.CreateCommand(commandName);

                return commandParameters.Skip(1).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArgumentException(string.Format(Messages.InvalidCommandErrorMessage, commandName));
            }
        }
    }
}