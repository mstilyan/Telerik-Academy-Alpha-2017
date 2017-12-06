using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var reversedStr = string.Join("", str.Reverse());
            Console.WriteLine(reversedStr);
        }
    }
}
