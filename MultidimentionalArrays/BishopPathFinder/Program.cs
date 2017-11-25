using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BishopPathFinder
{
    class Program
    {
        private static int[,] gameBoard;
        private static bool[,] used;
        private static long score;
        private static int gameBoardRows;
        private static int gameBoardCols;
        private static int movesCount;

        static void Main(string[] args)
        {
            ReadInput();

            gameBoard = InitGameBoard();
            used = new bool[gameBoardRows, gameBoardCols];

            int currRow = gameBoardRows - 1;
            int currCol = 0;

            for (int i = 0; i < movesCount; i++)
            {
                var moveInfoToken = Console.ReadLine().Split();

                string direction = moveInfoToken[0];
                int steps = int.Parse(moveInfoToken[1]);

                MoveBishop(ref currRow, ref currCol, steps, direction);
            }

            Console.WriteLine(score);
        }

        private static void ReadInput()
        {
            var token = Console.ReadLine().Split().Select(int.Parse);

            gameBoardRows = token.First();
            gameBoardCols = token.Last();

            movesCount = int.Parse(Console.ReadLine());
        }

        private static int[,] InitGameBoard()
        {
            int[,] result = new int[gameBoardRows, gameBoardCols];
            int[,] table =
            {
                {15, 18, 21, 24, 27, 30, 33, 36, 39},
                {12, 15, 18, 21, 24, 27, 30, 33, 36},
                {9, 12, 15, 18, 21, 24, 27, 30, 33},
                {6, 9, 12, 15, 18, 21, 24, 27, 30},
                {3, 6, 9, 12, 15, 18, 21, 24, 27},
                {0, 3, 6, 9, 12, 15, 18, 21, 24}
            };

            int startRowInTable = table.GetLength(0) - gameBoardRows;
            for (int rowIndex = 0; rowIndex < gameBoardRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < gameBoardCols; colIndex++)
                {
                    result[rowIndex, colIndex] = table[startRowInTable + rowIndex, colIndex];
                }
            }
            
            return result;
        }

        private static void MoveBishop(ref int currRow, ref int currCol, int steps, string direction)
        {
            steps--;
            if (!used[currRow, currCol])
            {
                score += gameBoard[currRow, currCol];
                used[currRow, currCol] = true;
            }
            
            switch (direction)
            {
                case "RD":
                case "DR":
                    if (currRow + 1 < gameBoardRows && currCol + 1 < gameBoardCols && steps > 0)
                    {
                        currRow++;
                        currCol++;
                        MoveBishop(ref currRow, ref currCol, steps, direction);
                    }
                    break;
                case "LD":
                case "DL":
                    if (currRow + 1 < gameBoardRows && currCol - 1 >= 0 && steps > 0)
                    {
                        currRow++;
                        currCol--;
                        MoveBishop(ref currRow, ref currCol, steps, direction);
                    }
                    break;
                case "RU":
                case "UR":
                    if (currRow - 1 >= 0 && currCol + 1 < gameBoardCols && steps > 0)
                    {
                        currRow--;
                        currCol++;
                        MoveBishop(ref currRow, ref currCol, steps, direction);
                    }
                    break;
                case "LU":
                case "UL":
                    if (currRow - 1 >= 0 && currCol - 1 >= 0 && steps > 0)
                    {
                        currRow--;
                        currCol--;
                        MoveBishop(ref currRow, ref currCol, steps, direction);
                    }
                    break;
            }
        }
    }
}
