using Autofac;
using ConsoleClient.Infrastructure;
using Traveller.Core;

namespace ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new AutofacConfig();
            var container = config.Build();

            var engine = container.Resolve<TimingEngine>();
            engine.Start();
        }
    }
}