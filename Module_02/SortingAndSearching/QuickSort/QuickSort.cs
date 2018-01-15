using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swap;

namespace QuickSort
{
    public class QuickSort
    {
        public static void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            Sort(collection, 0, collection.Count - 1);
        }

        private static void Sort<T>(IList<T> collection, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
                return;

            int pivot = Partition(collection, lo, hi);
            Sort(collection, lo, pivot - 1);
            Sort(collection, pivot + 1, hi);
        }

        private static int Partition<T>(IList<T> collection, int lo, int hi) where T : IComparable<T>
        {
            int i = lo;
            int j = hi + 1;
            var pivot = collection[lo];

            while (true)
            {
                while (collection[++i].CompareTo(pivot) < 0)
                    if (i == hi)
                        break;

                while (collection[--j].CompareTo(pivot) > 0)
                    if (j == lo)
                        break;

                if (i >= j)
                    break;

                SwapElements.Swap(collection, i, j);
            }

            SwapElements.Swap(collection, j, lo);
            return j;
        }
    }
}
