using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInMatrix
{
    class Program
    {
        private static int rows;
        private static int cols;
        private static bool[,] used;
        private static int currArea;
        private static int largestArea;

        static void Main(string[] args)
        {
            var token = Console.ReadLine().Split().Select(int.Parse);
            rows = token.First();
            cols = token.Last();

            used = new bool[rows, cols];
            var matrix = new int[rows][];
            ReadMatrix(matrix);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!used[row, col])
                    {
                        currArea = 0;
                        DFS(matrix, row, col, matrix[row][col]);
                    }
                }
            }

            Console.WriteLine(largestArea);
        }

        private static void ReadMatrix(int[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        private static void DFS(int[][] matrix, int row, int col, int value)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || matrix[row][col] != value || used[row, col])
                return;

            currArea++;
            used[row, col] = true;
            largestArea = largestArea < currArea ? currArea : largestArea;
            //Console.WriteLine($"{currArea} ({row}, {col})");

            DFS(matrix, row, col + 1, value);
            DFS(matrix, row, col - 1, value);
            DFS(matrix, row + 1, col, value);
            DFS(matrix, row - 1, col, value);
        }
    }
}
