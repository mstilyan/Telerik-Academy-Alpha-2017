using System.Collections.Generic;
using Mathematics.Operations.Enums;

namespace Mathematics.General.Contracts
{
    public interface IOperationTable
    {
        (OperationAssociativity Associativity, int Priority) this[string operation] { get; }
        ICollection<string> Operations { get; }
        bool Contains(string operation);
    }
}