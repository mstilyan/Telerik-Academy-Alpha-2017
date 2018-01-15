using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap
{
    public class SwapElements
    {
        public static void Swap<T>(IList<T> l, int fstInd, int secInd)
        {
            var temp = l[fstInd];
            l[fstInd] = l[secInd];
            l[secInd] = temp;
        }
    }
}
