using System.Collections;
using System.Collections.Generic;
using Traveller.Commands.Contracts;

namespace Traveller.Core
{
    public interface ICommandProcessor
    {
        string Process(ICommand command, IList<string> parameters);
    }
}