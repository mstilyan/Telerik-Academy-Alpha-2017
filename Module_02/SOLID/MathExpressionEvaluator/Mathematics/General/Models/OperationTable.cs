using System;
using System.Collections;
using Mathematics.General.Contracts;
using Mathematics.General.Exception;
using Mathematics.Operations.Enums;

namespace Mathematics.General.Models
{
    using System.Collections.Generic;

    public class OperationTable : IOperationTable
    {
        private readonly Dictionary<string, (OperationAssociativity Associativity, int Priority)> operations;

        public OperationTable()
        {
            operations = new Dictionary<string, (OperationAssociativity Associativity, int Priority)>
            {
                { "*", (OperationAssociativity.LeftToRight, 6)},
                { "/", (OperationAssociativity.LeftToRight, 6)},
                { "%", (OperationAssociativity.LeftToRight, 6)},
                { "+", (OperationAssociativity.LeftToRight, 5)},
                { "-", (OperationAssociativity.LeftToRight, 5)},
                { "<<", (OperationAssociativity.LeftToRight, 4)},
                { ">>", (OperationAssociativity.LeftToRight, 4)},
                { "&", (OperationAssociativity.LeftToRight, 3)},
                { "^", (OperationAssociativity.LeftToRight, 2)},
                { "|", (OperationAssociativity.LeftToRight, 1)}
            };
        }

        public (OperationAssociativity Associativity, int Priority) this[string operation]
        {
            get
            {
                if (!operations.ContainsKey(operation))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.UnsupportedOperation, operation));
                }

                return operations[operation];
            }
        }

        public ICollection<string> Operations => new List<string>(operations.Keys);

        public bool Contains(string operation)
        {
            return operations.ContainsKey(operation);
        }
    }
}
