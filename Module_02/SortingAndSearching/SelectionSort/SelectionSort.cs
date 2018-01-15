using System;
using System.Collections.Generic;
using Swap;

namespace SelectionSort
{
    public class SelectionSort
    {
        public static void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                var min = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    SwapElements.Swap(collection, min, i);
                }
            }
        }
    }
}
