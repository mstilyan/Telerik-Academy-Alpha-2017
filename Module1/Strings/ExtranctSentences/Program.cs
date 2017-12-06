using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtranctSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchString = Console.ReadLine();
            var text = Console.ReadLine();
            var pattern = @"\b(" + searchString + @")\b";

            var sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");

            List<string> sb = new List<string>();
            foreach (var sentence in sentences)
            {
                if (Regex.Match(sentence, "\b(" + searchString + "\b").Groups.Count > 1)
                {
                    sb.Add(sentence);
                }
            }

            Console.WriteLine(string.Join(" ", sentences));
        }
    }
}
