using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swap;

namespace BubbleSort
{
    public class BubbleSort
    {
        public static void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = 0; i < collection.Count; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[i]) < 0)
                    {
                        SwapElements.Swap(collection, i, j);
                    }
                }
            }
        }
    }
}
