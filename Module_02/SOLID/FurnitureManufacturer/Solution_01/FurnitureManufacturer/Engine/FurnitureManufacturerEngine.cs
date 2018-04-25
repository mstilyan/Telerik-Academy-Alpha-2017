using FurnitureManufacturer.Interfaces.Engine;
using System;
using System.Collections.Generic;
using FurnitureManufacturer.Interfaces.Providers;

namespace FurnitureManufacturer.Engine
{
    public sealed class FurnitureManufacturerEngine : IFurnitureManufacturerEngine
    {
        private readonly ICommandParser commandParser;
        private readonly ICommandProcessor commandProcessor;
        private readonly IRenderer renderer;

        public FurnitureManufacturerEngine(ICommandParser commandParser, ICommandProcessor commandProcessor, IRenderer renderer)
        {
            this.commandParser = commandParser;
            this.commandProcessor = commandProcessor;
            this.renderer = renderer;
        }

        public void Start()
        {
            var commandsInput = this.renderer.Input();
            var commandsOutput = new List<string>();

            foreach (var commandLine in commandsInput)
            {
                string commandResult;
                try
                {
                    ICommand command;
                    var commandParameters = this.commandParser.Parse(commandLine, out command);
                    commandResult = this.commandProcessor.Process(command, commandParameters);
                }
                catch (Exception exception)
                {
                    commandResult = exception.Message;
                }

                commandsOutput.Add(commandResult);
            }

            renderer.Output(commandsOutput);
        }
    }
}
