using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char flag = char.Parse(Console.ReadLine());

            var mat = new int[size,size];

            switch (flag)
            {
                case 'a':
                    FillMatrixA(mat, size);
                    break;
                case 'b':
                    FillMatrixB(mat, size);
                    break;
                case 'c':
                    FillMatrixC(mat, size);
                    break;
                case 'd':
                    FillMatrixD(mat, size);
                    break;
            }

            PrintMatrix(size, mat);

        }

        private static void FillMatrixD(int[,] mat, int size)
        {
            int counter = 1;
            int startRowIndex = 0;
            int endRowIndex = size - 1;
            int startColIndex = 0;
            int endColIndex = size - 1;

            while (startRowIndex <= endRowIndex && startColIndex <= endColIndex)
            {
                for (int row = startRowIndex; row <= endRowIndex; row++)
                {
                    mat[row,startColIndex] = counter;
                    counter++;
                }
                startColIndex++;

                for (int col = startColIndex; col <= endColIndex; col++)
                {
                    mat[endRowIndex,col] = counter;
                    counter++;
                }
                endRowIndex--;

                for (int row = endRowIndex; row >= startRowIndex; row--)
                {
                    mat[row,endColIndex] = counter;
                    counter++;
                }
                endColIndex--;

                for (int col = endColIndex; col >= startColIndex; col--)
                {
                    mat[startRowIndex,col] = counter;
                    counter++;
                }
                startRowIndex++;
            }
        }

        private static void FillMatrixC(int[,] mat, int size)
        {
            int counter = 1;
            for (int row = size - 1; row >= 0; row--)
            {
                for (int col = 0; col < size - row; col++)
                {
                    mat[row + col,col] = counter;
                    counter++;
                }
            }

            for (int col = 1; col < size; col++)
            {
                for (int row = 0; row < size - col; row++)
                {
                    mat[row,col + row] = counter;
                    counter++;
                }
            }
        }

        private static void FillMatrixB(int[,] mat, int size)
        {
            int counter = 1;
            for (int col = 0; col < size; col++)
            {
                for (int i = 0; i < size; i++)
                {
                    int row = col % 2 == 0 ? i : size - i - 1;
                    mat[row, col] = counter;
                    counter++;
                }
            }
        }

        private static void FillMatrixA(int[,] mat, int size)
        {
            int counter = 1;
            for (int col = 0; col < size; col++)
            {
                for (int row = 0; row < size; row++)
                {
                    mat[row, col] = counter;
                    counter++;
                }
            }
        }

        private static void PrintMatrix(int size, int[,] mat)
        {
            for (int row = 0; row < size; row++)
            {              
                for (int col = 0; col < size; col++)
                {
                    if (col != size - 1)
                        Console.Write("{0} ", mat[row, col]);
                    else
                        Console.WriteLine(mat[row, col]);
                }
            }
        }
    }
}
