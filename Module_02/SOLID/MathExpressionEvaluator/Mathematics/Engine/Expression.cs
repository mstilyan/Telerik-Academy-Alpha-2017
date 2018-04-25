using System;
using Mathematics.Engine.Contracts;
using Mathematics.Operands.Contracts;

namespace Mathematics.Engine
{
    public class Expression : IExpression
    {
        private readonly IExpressionParser parser;
        private readonly IInfixToPostfixConverter postfixConverter;
        private readonly IPostfixCalculator postfixCalculator;

        public Expression(IExpressionParser parser, IInfixToPostfixConverter postfixConverter, IPostfixCalculator postfixCalculator)
        {
            this.parser = parser;
            this.postfixConverter = postfixConverter;
            this.postfixCalculator = postfixCalculator;
        }      
        
        public string Evaluate(string expression)
        {
            IOperand result;

            try
            {
                var infixExpression = parser.Parse(expression);
                var postfixExpression = postfixConverter.ConvertInfixToPostfix(infixExpression);
                result = postfixCalculator.EvaluateExpression(postfixExpression);
            }
            catch (Exception ex)
            {
                return ex.Message;
                //throw new ArgumentNullException();
            }

            return result.Value.ToString();
        }
    }
}