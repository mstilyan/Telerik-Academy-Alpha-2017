using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    class Program
    {
        private static char[][] lab;
        private static int rows;
        private static int cols;

        private static long maxScore;
        private static long currScore;

        static void Main(string[] args)
        {
            int startRow, startCol;
            ReadInput(out startRow, out startCol);

            DFS(startRow, startCol);
            Console.WriteLine(maxScore);
        }

        private static void ReadInput(out int startRow, out int startCol)
        {
            var rowColPair = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();

            startRow = rowColPair[0];
            startCol = rowColPair[1];
            rowColPair = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            rows = rowColPair[0];
            cols = rowColPair[1];

            lab = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                lab[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }
        }

        private static void DFS(int row, int col, int usedPortalPower = 0)
        {
            if (!(row >= 0 && row < rows && col >= 0 && col < cols) || lab[row][col] == '#')
            {
                return;
            }
            if (lab[row][col] == '0')
            {
                maxScore = Math.Max(maxScore, currScore + usedPortalPower);
                return;
            }

            currScore += usedPortalPower;
            maxScore = Math.Max(currScore, maxScore);

            int currPortalPower = lab[row][col] - '0';
            lab[row][col] = '0';
            
            DFS(row + currPortalPower, col,  currPortalPower);
            DFS(row, col + currPortalPower, currPortalPower);
            DFS(row - currPortalPower, col, currPortalPower);
            DFS(row, col - currPortalPower, currPortalPower);

            lab[row][col] = (char)(currPortalPower + '0');
            currScore -= usedPortalPower;

        }
    }
}
