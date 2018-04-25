using System;
using System.Collections.Generic;
using Mathematics.General.Exception;
using Mathematics.Operands.Contracts;
using Mathematics.Operations.Contracts;

namespace Mathematics.Operations.Models
{
    public abstract class BinaryOperation : IOperation
    {
        protected BinaryOperation()
        {
            this.Operands = new List<IOperand>();
        }

        protected IList<IOperand> Operands { get; }

        public IOperand Result
        {
            get
            {
                if (!this.IsComplete)
                {
                    throw new InvalidOperationException(string.
                        Format(ErrorMessages.IncompleteResult, GetType().Name));
                }

                return ApplyOperation(this.Operands[1], this.Operands[0]);
            }
        }

        protected abstract IOperand ApplyOperation(IOperand o1, IOperand o2);

        public void AddOperand(IOperand operand)
        {
            if (this.IsComplete)
            {
                throw new InvalidOperationException();
            }

            if (operand == null)
            {
                throw new ArgumentNullException();
            }

            this.Operands.Add(operand);
        }

        public bool IsComplete => this.Operands.Count == 2;
    }
}
