using System.Collections.Generic;

namespace Mathematics.Engine.Contracts
{
    using Operands.Contracts;

    public interface IPostfixCalculator
    {
        IOperand EvaluateExpression(IEnumerable<string> tokens);
    }
}
