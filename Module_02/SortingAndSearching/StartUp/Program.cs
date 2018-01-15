using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuffle;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            const int size = 10;
            var list = Enumerable.Range(1, size).Select(x => random.Next(Int16.MinValue, Int16.MaxValue)).ToList();

            Console.WriteLine(string.Join(" ", list));
            Console.WriteLine(TimeOfSortingAlgorithm(list, InsertionSort.InsertionSort.Sort, 500_000));
            Console.WriteLine(string.Join(" ", list));
        }

        public static long TimeOfSortingAlgorithm<T>(IList<T> collection, Action<IList<T>> sorting, int executionCounter) where T : IComparable<T>
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < executionCounter; i++)
            {
                watch.Stop();
                FisherYates.Shuffle(collection);
                watch.Start();

                sorting(collection);
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
