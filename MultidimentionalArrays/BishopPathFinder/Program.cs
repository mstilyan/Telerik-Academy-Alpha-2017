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
            InitializeComponents();

            int currRow = gameBoardRows - 1;
            int currCol = 0;

            for (int i = 0; i < movesCount; i++)
            {
                var token = Console.ReadLine().Split();
                string direction = token[0];
                int steps = int.Parse(token[1]);

                MoveBishop(ref currRow, ref currCol, steps, direction);
            }

            Console.WriteLine(score);
        }

        private static void ReadInput()
        {
            var boardDimentions = Console.ReadLine().Split();
            var movesCountInputString = Console.ReadLine();

            gameBoardRows = int.Parse(boardDimentions[0]);
            gameBoardCols = int.Parse(boardDimentions[1]);
            movesCount = int.Parse(movesCountInputString);
        }

        private static void InitializeComponents()
        {
            gameBoard = new int[gameBoardRows, gameBoardCols];
            used = new bool[gameBoardRows, gameBoardCols];
            
            for (int row = 0; row < gameBoardRows; row++)
            {
                for (int col = 0; col < gameBoardCols; col++)
                {
                    gameBoard[gameBoardRows - 1 - row, col] = (row + col) * 3;
                }
            }
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
