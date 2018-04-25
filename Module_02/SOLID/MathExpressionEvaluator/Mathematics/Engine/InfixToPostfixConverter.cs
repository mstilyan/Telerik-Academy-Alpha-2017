using System;
using System.Drawing;
using Mathematics.General.Contracts;
using Mathematics.General.Exception;
using Mathematics.Operands.Models;
using Mathematics.Operations.Enums;

namespace Mathematics.Engine
{
    using Contracts;
    using Mathematics.General.Models;
    using System.Collections.Generic;

    public class InfixToPostfixConverter : IInfixToPostfixConverter
    {
        private const string LeftParenthesis = "(";
        private const string RightParenthesis = ")";

        private readonly IOperationTable operationTable;

        public InfixToPostfixConverter(IOperationTable operationTable)
        {
            this.operationTable = operationTable;
        }


        public IEnumerable<string> ConvertInfixToPostfix(string[] tokens)
        {
            Stack<string> operationsStack = new Stack<string>();
            Queue<string> postfixExpression = new Queue<string>();
            int leftParenthesisCounter = 0; // Count of left parenthesis on the operationsStack

            foreach (var token in tokens)
            {
                if (this.operationTable.Contains(token))
                {
                    // Move all the operations from operationsStack to postfixExpression queue that
                    // have higher priority than current operation or
                    // have equal priority to current operation and left to right associativity 
                    while (operationsStack.Count != 0 && operationsStack.Peek() != LeftParenthesis
                        && (this.operationTable[operationsStack.Peek()].Priority > this.operationTable[token].Priority
                        || this.operationTable[operationsStack.Peek()].Priority == this.operationTable[token].Priority
                        && this.operationTable[operationsStack.Peek()].Associativity == OperationAssociativity.LeftToRight))
                    {
                        postfixExpression.Enqueue(operationsStack.Pop());
                    }

                    operationsStack.Push(token);
                }
                else if (token == LeftParenthesis)
                {
                    operationsStack.Push(token);
                    leftParenthesisCounter++;
                }
                else if (token == RightParenthesis)
                {
                    if (leftParenthesisCounter == 0) // No left parenthesis on the operationsStack
                    {
                        throw new InvalidMathematicalExpressionException(ErrorMessages.ParenthesesMissing);
                    }

                    // Moving all operations until left parenthesis to posfixExpression queue
                    while (operationsStack.Peek() != LeftParenthesis)
                    {
                        postfixExpression.Enqueue(operationsStack.Pop());
                    }

                    operationsStack.Pop(); // Removint opening parenthesis from the operationsStack
                    leftParenthesisCounter--;
                }
                else
                {
                    int value;
                    if (int.TryParse(token, out value))
                    {
                        postfixExpression.Enqueue(token);
                    }
                    else
                    {
                        throw new InvalidMathematicalExpressionException(
                            string.Format(ErrorMessages.UnrecognizedElement, token));
                    }
                }
            }

            foreach (var operation in operationsStack)
            {
                if (operation == LeftParenthesis)
                {
                    throw new InvalidMathematicalExpressionException(ErrorMessages.ParenthesesMissing);
                }

                postfixExpression.Enqueue(operation);
            }

            return postfixExpression;
        }
    }
}

