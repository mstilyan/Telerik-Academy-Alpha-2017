using System;
using System.Collections.Generic;
using System.Linq;

class Cell
{
    public int Row { get; set; }
    public int Col { get; set; }
}

class Program
{
    static int rows;
    static int cols;
    static bool[,] used;
    static int greatestArea;
    static int currentArea;
    static int[][] matrix;

    static void Main(string[] args)
    {
        var token = Console.ReadLine().Split().Select(int.Parse).ToArray();
        rows = token[0];
        cols = token[1];

        var matrix = new int[rows][];
        used = new bool[rows, cols];

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
                if (!used[row, col])
                {
                    currentArea = 0;
                    int targetValue = matrix[row][col];

                    DFS(matrix, row, col, targetValue);
                }
            }

        }

        Console.WriteLine(greatestArea);
    }

    private static void DFS(int[][] matrix, int row, int col, int targetValue)
    {
        Stack<Cell> stack = new Stack<Cell>();
        stack.Push(new Cell { Row = row, Col = col });

        while (stack.Count > 0)
        {
            var top = stack.Pop();

            if (!IsValid(matrix, top.Row, top.Col, targetValue))
            {
                continue;
            }

            currentArea++;
            used[top.Row, top.Col] = true;
            greatestArea = Math.Max(currentArea, greatestArea);

            stack.Push(new Cell { Row = top.Row + 1, Col = top.Col });
            stack.Push(new Cell { Row = top.Row - 1, Col = top.Col });
            stack.Push(new Cell { Row = top.Row, Col = top.Col + 1 });
            stack.Push(new Cell { Row = top.Row, Col = top.Col - 1 });
        }
    }

    private static bool IsValid(int[][] matrix, int r, int c, int targetValue)
    {
        return r >= 0 && r < rows && c >= 0
            && c < cols && matrix[r][c] == targetValue
            && !used[r, c];
    }
}