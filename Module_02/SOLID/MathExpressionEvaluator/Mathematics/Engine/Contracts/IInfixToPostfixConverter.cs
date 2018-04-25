using System.Collections.Generic;

namespace Mathematics.Engine.Contracts
{
    public interface IInfixToPostfixConverter
    {
        IEnumerable<string> ConvertInfixToPostfix(string[] tokens);
    }
}
