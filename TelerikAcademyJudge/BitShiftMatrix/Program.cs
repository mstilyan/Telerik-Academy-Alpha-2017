using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitShiftMatrix
{
    class Program
    {
        private static int rows;
        private static int cols;
        private static int coef;
        private static int movesCount;
        private static BigInteger sum;
        private static BigInteger[,] matrix;
        private static int[] codes;

        static void Main(string[] args)
        {
            ReadInput();

            coef = Math.Max(rows, cols);
            matrix = new BigInteger[rows,cols];
            FillMatrix();

            int currRow = rows - 1;
            int currCol = 0;

            for (int i = 0; i < movesCount; i++)
            {
                int code = codes[i];
                int targetCol = code % coef;
                int targetRow = code / coef;

                MakeHorizontalMove(currRow, currCol, targetCol);
                currCol = targetCol;

                MakeVerticalMove(currRow, currCol, targetRow);
                currRow = targetRow;
            }

            Console.WriteLine(sum);
        }

        private static void ReadInput()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            movesCount = int.Parse(Console.ReadLine());

            codes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        private static void MakeVerticalMove(int currRow, int currCol, int targetRow)
        {
            int from = Math.Min(currRow, targetRow);
            int to = Math.Max(currRow, targetRow);

            for (int row = from; row <= to; row++)
            {
                sum += matrix[row, currCol];
                matrix[row, currCol] = 0;
            }
        }

        private static void MakeHorizontalMove(int currRow, int currCol, int targetCol)
        {
            int from = Math.Min(currCol, targetCol);
            int to = Math.Max(currCol, targetCol);

            for (int col = from; col <= to; col++)
            {
                sum += matrix[currRow, col];
                matrix[currRow, col] = 0;
            }
        }

        private static void FillMatrix()
        {
            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = (BigInteger)Math.Pow( 2, rows - row - 1 + col);
                }
            }
        }
    }
}
