using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitty
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Console.ReadLine().ToCharArray();
            int[] directions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int souls = 0;
            int deadlocks = 0;
            int food = 0;
            int currentPosition = 0;
            bool catIsDead = false;

            /*
            @ - symbol for coder soul
            * - symbol for food
            x - symbol for deadlock
             */

            EvaluatePathValue(path, ref souls, ref deadlocks, ref food, ref catIsDead, currentPosition);

            if (catIsDead)
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: 0");
                return;
            }

            for (int i = 0; i < directions.Length; i++)
            {
                currentPosition = (currentPosition + directions[i]) % path.Length;
                currentPosition = currentPosition < 0 ? path.Length + currentPosition : currentPosition;

                EvaluatePathValue(path, ref souls, ref deadlocks, ref food, ref catIsDead, currentPosition);

                if (catIsDead)
                {
                    Console.WriteLine("You are deadlocked, you greedy kitty!");
                    Console.WriteLine("Jumps before deadlock: {0}", i + 1);
                    return;
                }
            }

            Console.WriteLine("Coder souls collected: {0}", souls);
            Console.WriteLine("Food collected: {0}", food);
            Console.WriteLine("Deadlocks: {0}", deadlocks);
        }

        private static void EvaluatePathValue(char[] path, ref int souls, ref int deadlocks, ref int food, ref bool catIsDead, int currentPosition)
        {
            switch (path[currentPosition])
            {
                case '@':
                    souls++;
                    path[currentPosition] = ' ';
                    break;
                case '*':
                    food++;
                    path[currentPosition] = ' ';
                    break;
                case 'x':
                    deadlocks++;
                    if (currentPosition % 2 == 0 && souls > 0)
                    {
                        souls--;
                        path[currentPosition] = '@';
                    }
                    else if (currentPosition % 2 == 1 && food > 0)
                    {
                        food--;
                        path[currentPosition] = '*';
                    }
                    else
                    {
                        catIsDead = true;
                    }
                    break;
            }
        }
    }
}
