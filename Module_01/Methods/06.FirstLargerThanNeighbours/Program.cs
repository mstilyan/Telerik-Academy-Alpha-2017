using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _06.FirstLargerThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] ints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(IndexOfFirstGreaterThanNeighbours(ints, length));
        }

        private static int IndexOfFirstGreaterThanNeighbours(int[] ints, int length)
        {
            if (length < 0)
                throw  new ArgumentException();
            if (length == 1)
                return 0;

            for (int index = 0; index < length; index++)
            {
                if (ints[index] > ints[index + 1])
                {
                    
                }
            }

            return -1;
        }
    }
}
