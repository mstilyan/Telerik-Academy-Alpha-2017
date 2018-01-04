using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(GetReversed(input));
        }

        private static string GetReversed(string str)
        {
            return string.Join("", str.Reverse());
        }
    }
}
