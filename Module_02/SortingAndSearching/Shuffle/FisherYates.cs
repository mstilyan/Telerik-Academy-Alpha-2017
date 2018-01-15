using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swap;

namespace Shuffle
{
    public class FisherYates
    {
        public static void Shuffle<T>(IList<T> collection) where T : IComparable<T>
        {
            var random = new Random();
            for (int i = 0; i < collection.Count - 1; i++)
            {
                var j = random.Next(i + 1, collection.Count);
                SwapElements.Swap(collection, i, j);
            }
        }
    }
}
