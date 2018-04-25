using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GirlsGoneWild
{
    class Program
    {
        private static int shirtsCount;
        private static IList<char> skirts;
        private static int girlsCount;
        private static string[] combination;
        private static HashSet<string> combinations;
        private static bool[] used;
        
        static void Main(string[] args)
        {
            combinations = new HashSet<string>();
            // ReSharper disable once AssignNullToNotNullAttribute
            shirtsCount = int.Parse(Console.ReadLine());
            // ReSharper disable once AssignNullToNotNullAttribute
            skirts = Console.ReadLine()
                .OrderBy(x => x)
                .ToList();

            used = new bool[skirts.Count];

            // ReSharper disable once AssignNullToNotNullAttribute
            girlsCount = int.Parse(Console.ReadLine());

            combination = new string[girlsCount];

            GenCombinations();

            Console.WriteLine(combinations.Count);
            Console.WriteLine(string.Join(Environment.NewLine, combinations));
        }

        private static void GenCombinations(int currGirl = 0, int shirtBound = 0)
        {
            if (currGirl >= combination.Length)
            {
                combinations.Add(string.Join("-", combination));
                return;
            }

            for (int i = shirtBound; i < shirtsCount; i++)
            {
                for (int skritIndex = 0; skritIndex < skirts.Count; skritIndex++)
                {
                    if (!used[skritIndex])
                    {
                        used[skritIndex] = true;
                        combination[currGirl] = $"{i}{skirts[skritIndex]}";
                        GenCombinations(currGirl + 1, i + 1);
                        used[skritIndex] = false;
                    }
                }
            }
        }
    }
}
