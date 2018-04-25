using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public class MergeSort<T> where T : IComparable<T>
    {
        private static T[] aux;

        public static void Sort(IList<T> collection)
        {
            aux = new T[collection.Count];
            Sort(collection, 0, collection.Count - 1);
        }

        public static void Sort(IList<T> collection, int lo, int hi)
        {
            if (lo == hi)
                return;

            int mid = (lo + hi) / 2;

            Sort(collection, lo, mid);
            Sort(collection, mid + 1, hi);
            Merge(collection, lo, mid, hi);
        }

        private static void Merge(IList<T> collection, int lo, int mid, int hi)
        {
            if (collection[mid].CompareTo(collection[mid + 1]) <= 0)
                return;

            for (int index = lo; index <= hi; index++)
                aux[index] = collection[index];

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    collection[k] = aux[j++];
                }
                else if (j > hi)
                {
                    collection[k] = aux[i++];
                }
                else if (aux[i].CompareTo(aux[j]) <= 0)
                {
                    collection[k] = aux[i++];
                }
                else
                {
                    collection[k] = aux[j++];
                }
            }
        }
    }
}
