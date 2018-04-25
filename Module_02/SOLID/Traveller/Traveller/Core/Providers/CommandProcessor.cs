using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using Traveller.Commands.Contracts;

namespace Traveller.Core
{
    class CommandProcessor : ICommandProcessor
    {
        public string Process(ICommand command, IList<string> parameters)
        {
            Guard.WhenArgument(command, "Command cannot be null").IsNull().Throw();
            Guard.WhenArgument(command, "Command parameters cannot be null").IsNull().Throw();

            try
            {
                var result = command.Execute(parameters);
                return result;
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }
        }
    }
}