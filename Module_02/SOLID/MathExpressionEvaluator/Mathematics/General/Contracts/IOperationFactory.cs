using Autofac;

namespace Mathematics.General.Contracts
{
    using Operations.Contracts;

    public interface IOperationFactory
    {
        IOperation CreateOperation(string operation);
    }
}
