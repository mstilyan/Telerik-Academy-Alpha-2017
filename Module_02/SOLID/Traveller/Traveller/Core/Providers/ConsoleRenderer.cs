using System;
using System.Collections.Generic;
using System.Text;

namespace Traveller.Core.Providers
{
    public class ConsoleRenderer : IRenderer
    {
        public string InputLine()
        {
            return Console.ReadLine();
        }

        public void OutputLine(IEnumerable<string> output)
        {
            var resultBuilder = new StringBuilder();
            foreach (var line in output)
            {
                resultBuilder.AppendLine(line);
            }

            Console.Write(resultBuilder.ToString());
        }

        public void OutputLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}