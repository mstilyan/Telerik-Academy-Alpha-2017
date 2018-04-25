using System.Diagnostics;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace Traveller.Core
{
    public class TimingEngine : IEngine
    {
        private const string EngineStartedMessage = "The Engine is starting...";
        private const string EnginedStoppedMessage = "The Engine worked for {0} milliseconds.";

        private readonly IEngine engine;
        private readonly IRenderer renderer;

        public TimingEngine(IEngine engine, IRenderer renderer)
        {
            this.engine = engine;
            this.renderer = renderer;
        }

        public void Start()
        {
            this.renderer.OutputLine(EngineStartedMessage);

            var clock = Stopwatch.StartNew();
            this.engine.Start();
            clock.Stop();

            this.renderer.OutputLine(string.Format(EnginedStoppedMessage, clock.ElapsedMilliseconds));
        }
    }
}