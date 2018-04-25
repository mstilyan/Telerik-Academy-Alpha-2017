using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureManufacturer.Engine
{
    public sealed class FurnitureEngine : IEngine
    {
        private readonly IRenderer renderer;
        private readonly ICommandsFactory factory;

        public FurnitureEngine(IRenderer consoleRenderer, ICommandsFactory factory)
        {
            this.renderer = consoleRenderer;
            this.factory = factory;
        }

        public void Start()
        {
            var commandResults = new List<string>();

            try
            {
                foreach (var currentLine in this.renderer.Input())
                {
                    commandResults.Add(this.ProcessCommand(currentLine));
                }
            }
            catch (Exception ex)
            {
                commandResults.Add(ex.Message);
            }

            this.renderer.Output(commandResults);

        }

        private string ProcessCommand(string commandLine)
        {
            var commandParts = commandLine.Split(' ').ToList();

            var commandName = commandParts[0];
            var commandParameters = commandParts.Skip(1).ToList();

            var command = this.factory.GetCommand(commandName);
            return command.Execute(commandParameters);
        }
    }
}
