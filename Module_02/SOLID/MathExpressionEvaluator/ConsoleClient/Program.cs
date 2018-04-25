using Autofac;
using Mathematics.Engine.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Engine;
using Mathematics.General.Contracts;
using Mathematics.General.Models;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var expression = container.Resolve<IExpression>();
            Console.WriteLine(expression.Evaluate("(2+2)*5-1*11"));
        }
    }
}
