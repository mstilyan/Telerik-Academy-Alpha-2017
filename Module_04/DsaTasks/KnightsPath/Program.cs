using System;
using System.Collections.Generic;

namespace KnightsPath
{
    class Program
    {
        private static int rows;
        private static int cols;
        private static int startRow;
        private static int startCol;
        private static int[] middleColumn;

        private const int TotalMoves = 8;
        private static readonly int[] rowMoves = { 1, 1, -1, -1, 2, 2, -2, -2 };
        private static readonly int[] colMoves = { 2, -2, 2, -2, 1, -1, 1, -1 };
        private static int[,] board;

        static void Main(string[] args)
        {
            ReadInput();

            middleColumn = new int[rows];
            board = new int[rows,cols];

            Bfs();

            Console.WriteLine(string.Join(Environment.NewLine, middleColumn));
        }

        private static void Bfs()
        {
            var queue = new Queue<Cell>();
            queue.Enqueue(new Cell { Row = startRow, Col = startCol});

            board[startRow, startCol] = 1;
            int middleColFilledCellsCount = 0;

            while (queue.Count != 0 && middleColFilledCellsCount < rows)
            {
                var cell = queue.Dequeue();

                if (cell.Col == cols / 2)
                {
                    middleColFilledCellsCount++;
                    middleColumn[cell.Row] = board[cell.Row, cell.Col];
                }

                for (int i = 0; i < TotalMoves; i++)
                {
                    var newRow = cell.Row + rowMoves[i];
                    var newCol = cell.Col + colMoves[i];

                    if (IsValid(newRow, newCol) && board[newRow, newCol] == 0)
                    {
                        board[newRow, newCol] = board[cell.Row, cell.Col] + 1;
                        queue.Enqueue(new Cell { Row = newRow, Col = newCol});
                    }
                }
            }
        }

        private static void ReadInput()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            rows = int.Parse(Console.ReadLine());
            // ReSharper disable once AssignNullToNotNullAttribute
            cols = int.Parse(Console.ReadLine());
            // ReSharper disable once AssignNullToNotNullAttribute
            startRow = int.Parse(Console.ReadLine());
            // ReSharper disable once AssignNullToNotNullAttribute
            startCol = int.Parse(Console.ReadLine());
        }

        public static bool IsValid(int r, int c) => r >= 0 && c >= 0 && r < rows && c < cols;
    }

    class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
