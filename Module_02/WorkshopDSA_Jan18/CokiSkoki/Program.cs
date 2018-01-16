using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokiSkoki
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] buildingHeights = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] jumps = new int[size];

            int longestSeqOfJumps = EvaluateJumps(jumps, buildingHeights);

            Console.WriteLine(longestSeqOfJumps);
            Console.WriteLine(string.Join(" ", jumps));

        }

        private static int EvaluateJumps(int[] jumps, int[] buildingHeights)
        {
            int longestSeqOfJumps = 0;
            for (int i = jumps.Length - 1; i >= 0; i--)
            {
                jumps[i] = 1 + JumpOnNextBuilding(i, jumps, buildingHeights);
                longestSeqOfJumps = Math.Max(longestSeqOfJumps, jumps[i]);
            }

            return longestSeqOfJumps;
        }

        private static int JumpOnNextBuilding(int currBuilding, int[] jumps, int[] heights)
        {
            for (int i = currBuilding + 1; i < heights.Length; i++)
            {
                if (heights[i] > heights[currBuilding])
                {
                    return jumps[i];
                }
            }

            return -1;
        }
    }
}
