using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AddingPolynomials
{
    class Program
    {
        /*
         * 3
         * 5 0 1
         * 7 4 -3
         */
        static void Main(string[] args)
        {
            int deg = int.Parse(Console.ReadLine());

            int[] fst = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] sec = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(" ", ArraySum(fst, sec, deg)));
        }

        private static int[] ArraySum(int[] fst, int[] sec, int deg)
        {
            int[] result = new int[deg];

            for (int i = 0; i < deg; i++)
            {
                result[i] = fst[i] + sec[i];
            }

            return result;
        }
    }
}
