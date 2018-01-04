using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceInMatrix
{
    class Program
    {
        private static int rows;
        private static int cols;
        private static long longestLength = 1;
        private static bool[,] used;

        static void Main(string[] args)
        {
            var token = Console.ReadLine().Split().Select(int.Parse);
            rows = token.First();
            cols = token.Last();

            used = new bool[rows, cols];
            var matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    CalculateSequenceLength(matrix, row, col, matrix[row][col]);
                }
            }

            Console.WriteLine(longestLength);

        }

        private static void CalculateSequenceLength(int[][] matrix, int row, int col, int value, int currLength = 1)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || matrix[row][col] != value || used[row, col])
                return;

            used[row, col] = true;
            longestLength = longestLength < currLength ? currLength : longestLength;

            CalculateSequenceLength(matrix, row, col + 1, value, currLength + 1);
            CalculateSequenceLength(matrix, row, col - 1, value, currLength + 1);
            CalculateSequenceLength(matrix, row + 1, col, value, currLength + 1);
            CalculateSequenceLength(matrix, row + 1, col + 1, value, currLength + 1);
            CalculateSequenceLength(matrix, row + 1, col - 1, value, currLength + 1);
            CalculateSequenceLength(matrix, row - 1, col, value, currLength + 1);
            CalculateSequenceLength(matrix, row - 1, col + 1, value, currLength + 1);
            CalculateSequenceLength(matrix, row - 1, col - 1, value, currLength + 1);

            used[row, col] = false;
        }
    }
}
