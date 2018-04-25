using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Mathematics.Engine;
using Mathematics.Engine.Contracts;
using Mathematics.General.Models;
using Mathematics.General.Contracts;
using Mathematics.Operations.Models;
using Mathematics.Operations.Contracts;

namespace ConsoleClient
{
    public class ModuleConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExpressionParser>().As<IExpressionParser>().SingleInstance();
            builder.RegisterType<InfixToPostfixConverter>().As<IInfixToPostfixConverter>().SingleInstance();
            builder.RegisterType<PostfixCalculator>().As<IPostfixCalculator>().SingleInstance();
            builder.RegisterType<OperationTable>().As<IOperationTable>().SingleInstance();
            builder.RegisterType<OperationFactory>().As<IOperationFactory>().SingleInstance();
            builder.RegisterType<Expression>().As<IExpression>().SingleInstance();
            builder.RegisterType<Addition>().Named<IOperation>("+");
            builder.RegisterType<Substraction>().Named<IOperation>("-");
            builder.RegisterType<Multiplication>().Named<IOperation>("*");
            builder.RegisterType<Division>().Named<IOperation>("/");
            builder.RegisterType<Modulo>().Named<IOperation>("%");
            builder.RegisterType<BitwiseAND>().Named<IOperation>("&");
            builder.RegisterType<BitwiseExclusiveOR>().Named<IOperation>("^");
            builder.RegisterType<BitwiseInclusiveOR>().Named<IOperation>("|");
            builder.RegisterType<BitwiseLeftShift>().Named<IOperation>("<<");
            builder.RegisterType<BitwiseRightShift>().Named<IOperation>("<<");
        }
    }
}
