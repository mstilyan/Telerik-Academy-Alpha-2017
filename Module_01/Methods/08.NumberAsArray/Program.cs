using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.NumberAsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = Console.ReadLine().Split();
            int fstLength = int.Parse(token[0]);
            int secLength = int.Parse(token[1]);

            int[] fstArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = ArraysReversedSum(fstArray, secArray, fstLength, secLength);
            Console.WriteLine(string.Join(" ", result));
        }

        private static IEnumerable<int> ArraysReversedSum(int[] fst, int[] sec, int fstLength, int secLength)
        {
            var result = new List<int>();

            int index = 0;
            int carry = 0;

            while (index < fstLength || index < secLength || carry != 0)
            {
                int fstElem = index < fstLength ? fst[index] : 0;
                int secElem = index < secLength ? sec[index] : 0;

                result.Add((fstElem + secElem + carry) % 10);
                carry = (fstElem + secElem + carry) / 10;

                index++;
            }

            return result;
        }
    }
}
