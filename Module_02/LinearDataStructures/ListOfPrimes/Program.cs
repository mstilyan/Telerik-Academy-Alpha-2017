using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfPrimes
{
    class Program
    {
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            var primes = new LinkedList<int>(Enumerable.Range(200, 100).Where(IsPrime));
            Console.WriteLine(string.Join(" ", primes));
        }
    }
}
