namespace Mathematics.General.Exception
{
    internal static class ErrorMessages
    {
        public const string IncompleteResult = "OperationTable {0} is incomplete!";
        public const string UnsupportedOperation = "Cannot parse {0} to IOperation!";
        public const string OperandsNotEnought = "Too few operads to execute operation of type {0}!";
        public const string CannotParseToOperand = "Cannot parse {0} to {1} Operand!";
        public const string InvalidMathExpression = "Invalid mathematical expression!";
        public const string UnrecognizedElement = "Element {0} is unrecognized!";
        public const string ParenthesesMissing = "Parentheses missing!";
        public const string ParenthesesMismatch = "Parentheses mismatch!";
    }
}