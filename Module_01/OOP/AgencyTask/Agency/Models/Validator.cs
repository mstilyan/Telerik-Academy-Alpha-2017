using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models
{
    public static class Validator
    {
        public static void ArgumentIsInRangeInclusive(decimal value, decimal min, decimal max, string errorMassage)
        {
            if (!(min <= value && value <= max))
            {
                throw new ArgumentException(errorMassage);
            }
        }

        public static void ArgumentIsGreaterThan(decimal value, decimal min, string errorMassage)
        {
            if (!(min <= value))
            {
                throw new ArgumentException(errorMassage);
            }
        }

        public static void ArgumentIsLessThan(decimal value, decimal max, string errorMassage)
        {
            if (!(value <= max))
            {
                throw new ArgumentException(errorMassage);
            }
        }

        public static void ArgumentStringNotNull(string str)
        {
            if (str == null)
            {
                throw new ArgumentException();
            }
        }
    }
}
