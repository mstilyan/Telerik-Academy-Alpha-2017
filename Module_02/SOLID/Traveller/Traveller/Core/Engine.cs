using System;
using System.Collections.Generic;
using System.Text;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;
using Traveller.Models;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser commandParser;
        private readonly IRenderer renderer;
        private readonly ICommandProcessor commandProcessor;
        private readonly CommandConstants commandConstants;

        public Engine(ICommandParser commandParser, IRenderer renderer, ICommandProcessor commandProcessor, CommandConstants commandConstants)
        {
            this.commandParser = commandParser;
            this.renderer = renderer;
            this.commandProcessor = commandProcessor;
            this.commandConstants = commandConstants;
        }

        public void Start()
        {
            var commandResults = new List<string>();
            string commandLine;

            while ((commandLine = this.renderer.InputLine()) != this.commandConstants.TerminationCommand)
            {
                string executionResult;

                try
                {
                    var commandParameters = this.commandParser.ParseParameters(commandLine);
                    var command = this.commandParser.ParseCommand(commandLine);
                    executionResult = this.commandProcessor.Process(command, commandParameters);
                }
                catch (Exception exception)
                {
                    executionResult = exception.Message;
                }

                commandResults.Add(executionResult);
            }

            this.renderer.OutputLine(commandResults);
        }
    }
}
