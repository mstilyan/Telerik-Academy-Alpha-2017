using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commnadFactory;

        public CommandParser(ICommandFactory commnadFactory)
        {
            this.commnadFactory = commnadFactory;
        }

        public ICommand ParseCommand(string commandLine)
        {
            Guard.WhenArgument(commandLine, "CommandLine cannot be null").IsNullOrEmpty().Throw();

            var commandName = string.Empty;
            try
            {
                commandName = this.SplitCommandLine(commandLine).First();
                var command = this.commnadFactory.CreateCommand(commandName);

                return command;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Invalid command {commandName}");
            }
        }

        public IList<string> ParseParameters(string commandLine)
        {
            Guard.WhenArgument(commandLine, "CommandLine cannot be null").IsNullOrEmpty().Throw();

            return SplitCommandLine(commandLine).Skip(1).ToList();
        }

        private IList<string> SplitCommandLine(string commandLine)
        {
            return commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}
