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
            bool swap = true;

            while (swap)
            {
                swap = false;
                for (int j = 0; j < collection.Count - 1; j++)
                {
                    if (collection[j].CompareTo(collection[j + 1]) > 0)
                    {
                        SwapElements.Swap(collection, j, j + 1);
                        swap = true;
                    }
                }
            }
        }
    }
}
