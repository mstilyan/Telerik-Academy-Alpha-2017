using Autofac;

namespace Mathematics.General.Models
{
    using Contracts;
    using Operations.Contracts;

    public class OperationFactory : IOperationFactory
    {
        private readonly IComponentContext componentContext;

        public OperationFactory(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public IOperation CreateOperation(string operation)
        {
            return componentContext.ResolveNamed<IOperation>(operation);
        }
    }
}
