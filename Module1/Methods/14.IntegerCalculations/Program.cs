using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.IntegerCalculations
{
    class Program
    {
        private static int min = int.MaxValue;
        private static int max = int.MinValue;
        private static long prod = 1;
        private static double avg;
        private static long sum;

        static void Main(string[] args)
        {
            var ints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            CalculateStats(ints);
            Console.WriteLine("{0}\n{1}\n{2:F2}\n{3}\n{4}", min, max, avg, sum, prod);
        }

        private static void CalculateStats(int[] ints)
        {          
            foreach (var el in ints)
            {
                sum += el;
                prod *= el;
                max = Math.Max(max, el);
                min = Math.Min(min, el);
            }
            avg = sum / (double)ints.Length;
        }
    }
}
