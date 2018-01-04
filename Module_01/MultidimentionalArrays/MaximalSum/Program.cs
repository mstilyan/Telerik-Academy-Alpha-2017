using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = Console.ReadLine().Split().Select(int.Parse);
            int rows = token.First();
            int cols = token.Last();

            var matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            long maxSum = long.MinValue;
            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    long currSum = matrix[row][col] + matrix[row + 1][col] + matrix[row - 1][col]
                                   + matrix[row][col + 1] + matrix[row + 1][col + 1] + matrix[row - 1][col + 1]
                                   + matrix[row][col - 1] + matrix[row + 1][col - 1] + matrix[row - 1][col - 1];

                    maxSum = currSum > maxSum ? currSum : maxSum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
