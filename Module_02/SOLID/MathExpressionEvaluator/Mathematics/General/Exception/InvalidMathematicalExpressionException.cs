namespace Mathematics.General.Exception
{
    internal class InvalidMathematicalExpressionException : System.Exception
    {
        private const string ErrorMessage = ErrorMessages.InvalidMathExpression;

        public InvalidMathematicalExpressionException()
            : this(ErrorMessage)
        {
            
        }

        public InvalidMathematicalExpressionException(string message) 
            : base(message)
        {

        }
    }
}
