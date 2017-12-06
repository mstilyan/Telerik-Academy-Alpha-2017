using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _10.NFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(num));
        }

        private static BigInteger Factorial(int num)
        {
            return num <= 1 ? 1 : num * Factorial(num - 1);
        }
    }
}
