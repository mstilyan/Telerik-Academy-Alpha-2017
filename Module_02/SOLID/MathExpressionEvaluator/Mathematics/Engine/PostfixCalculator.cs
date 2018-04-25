using System;
using System.Collections.Generic;
using Mathematics.Engine.Contracts;
using Mathematics.General.Contracts;
using Mathematics.General.Exception;
using Mathematics.General.Models;
using Mathematics.Operands.Contracts;
using Mathematics.Operands.Models;
namespace Mathematics.Engine
{
    using Operations.Contracts;

    public sealed class PostfixCalculator : IPostfixCalculator
    {
        private readonly Stack<IOperand> machineStack;
        private readonly IOperationTable operationTable;
        private readonly IOperationFactory operationFactory;

        public PostfixCalculator(IOperationTable operationTable, IOperationFactory operationFactory)
        {
            this.machineStack = new Stack<IOperand>();
            this.operationTable = operationTable;
            this.operationFactory = operationFactory;
        }

        public IOperand EvaluateExpression(IEnumerable<string> tokens)
        {
            this.machineStack.Clear();

            if (tokens == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var token in tokens)
            {
                if (operationTable.Contains(token))
                {
                    var operation = operationFactory.CreateOperation(token);
                    EvaluateOperation(operation);
                    continue;
                }

                try
                {
                    var operand = IntType.Parse(token);
                    this.machineStack.Push(operand);
                }
                catch (ArgumentException)
                {
                    throw new InvalidMathematicalExpressionException(
                        string.Format(ErrorMessages.UnrecognizedElement, token));
                }
            }

            if (this.machineStack.Count != 1)
            {
                throw new InvalidMathematicalExpressionException();
            }

            return this.machineStack.Pop();
        }

        private void EvaluateOperation(IOperation operation)
        {
            while (!operation.IsComplete)
            {
                if (this.machineStack.Count == 0)
                {
                    throw new InvalidOperationException(string
                        .Format(ErrorMessages.IncompleteResult, operation.GetType().Name));
                }

                operation.AddOperand(this.machineStack.Pop());
            }

            this.machineStack.Push(operation.Result);
        }
    }
}
