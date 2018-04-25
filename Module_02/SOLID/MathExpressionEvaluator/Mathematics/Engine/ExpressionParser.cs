using Mathematics.General.Contracts;

namespace Mathematics.Engine
{
    using System;
    using Contracts;

    public class ExpressionParser : IExpressionParser
    {
        private const char WhiteSpace = ' ';
        private readonly IOperationTable operationTable;

        public ExpressionParser(IOperationTable operationTable)
        {
            this.operationTable = operationTable;
        }

        public string[] Parse(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentException("Value cannot be null");
            }
            return CleanExpressionInput(expression)
                .Split(new[] {WhiteSpace}, StringSplitOptions.RemoveEmptyEntries);
        }

        private string CleanExpressionInput(string expression)
        {
            foreach (var operation in operationTable.Operations)
            {
                expression = expression.Replace(operation, $" {operation} ");
            }

            expression = expression
                .Replace("(", " ( ")
                .Replace(")", " ) ");

            return expression;
        }
    }
}