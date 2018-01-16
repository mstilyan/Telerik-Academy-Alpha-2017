using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation
{
    class Program
    {
        private static Queue<string> Ms = new Queue<string>();
        private static Queue<string> Ks = new Queue<string>();
        private static Queue<string> Ps = new Queue<string>();

        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var units = Console.ReadLine().Split();

            foreach (var unit in units)
            {
                if (unit[0] == 'M') Ms.Enqueue(unit);
                if (unit[0] == 'P') Ps.Enqueue(unit);
                if (unit[0] == 'K') Ks.Enqueue(unit);
            }

            var result = new List<string>();

            result.Add(string.Join(" ", Ms));
            result.Add(string.Join(" ", Ks));
            result.Add(string.Join(" ", Ps));

            Console.WriteLine(string.Join(" ", result).Trim());
        }
    }
}
