using System.Collections.Generic;

namespace Traveller.Core.Providers
{
    public interface IRenderer
    {
        string InputLine();
        void OutputLine(object obj);
        void OutputLine(IEnumerable<string> output);
    }
}