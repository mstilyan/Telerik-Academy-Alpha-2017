using System;
using System.Collections.Generic;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Providers;

namespace FurnitureManufacturer.Engine.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        public string Process(ICommand command, IList<string> commandParameters)
        {
            string commandResult;
            try
            {
                commandResult = command.Execute(commandParameters);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return commandResult;
        }
    }
}