using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace LinkedListRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            var node8 = new Node<int> { Value = 8 };
            var node7 = new Node<int> { Value = 7, Next = node8 };
            var node6 = new Node<int> { Value = 6, Next = node7 };
            var node5 = new Node<int> { Value = 5, Next = node6 };
            var node4 = new Node<int> { Value = 4, Next = node5 };
            var node3 = new Node<int> { Value = 3, Next = node4 };
            var node2 = new Node<int> { Value = 2, Next = node3 };
            var node1 = new Node<int> { Value = 1, Next = node2 };

            Remove(node5);
            PrintLinkedList(node1);
        }

        private static void PrintLinkedList<T>(Node<T> first)
        {
            var curr = first;
            while (curr != null)
            {
                Console.WriteLine(curr.Value);
                curr = curr.Next;
            }
        }

        private static void Remove<T>(Node<T> node)
        {
            if (node?.Next == null)
            {
                throw new ArgumentException();
            }

            var next = node.Next;
            node.Value = next.Value;
            node.Next = next.Next;
        }
    }

    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
