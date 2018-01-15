using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    public class InsertionSort
    {
        public static void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = 1; i < collection.Count; i++)
            {
                var element = collection[i];

                int index;
                for (index = i - 1; index >= 0; index--)
                {
                    if (element.CompareTo(collection[index]) >= 0)
                        break;

                    collection[index + 1] = collection[index];
                }
                collection[index + 1] = element;
            }
        }
    }
}
