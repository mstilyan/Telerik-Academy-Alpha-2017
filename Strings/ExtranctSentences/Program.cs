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
            string input = Console.ReadLine();
            string[] sentences = Regex.Split(input, @"(?<=[\.!\?])\s+");

            foreach (var sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}
