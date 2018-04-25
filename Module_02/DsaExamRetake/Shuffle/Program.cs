using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = Console.ReadLine().Split().ToArray();

            int count = int.Parse(token[0]);

            var toShuffle = Console.ReadLine().Split().Select(int.Parse).ToArray();

            LinkedList<int> order = new LinkedList<int>();
            LinkedListNode<int>[] nodes = new LinkedListNode<int>[count + 1];

            for (int i = 1; i < count + 1; i++)
            {
                nodes[i] = order.AddLast(i);
            }

            for (var index = 0; index < toShuffle.Length; index++)
            {
                var number = toShuffle[index];
                int prevNumber;
                if (number % 2 == 0)
                {
                    prevNumber = number / 2;
                }
                else
                {
                    prevNumber = Math.Min(number * 2, count);
                }

                if (number == prevNumber) continue;


                var node = nodes[number];
                var prevNode = nodes[prevNumber];

                if (node.Previous == prevNode) continue;

                order.Remove(node);
                nodes[number] = order.AddAfter(prevNode, number);
            }

            Console.WriteLine(string.Join(" ", order));
        }
    }
}