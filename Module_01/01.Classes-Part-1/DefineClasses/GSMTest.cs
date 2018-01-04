using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    static class GSMTest
    {
        public static GSM[] GSMs { get; set; }

        static GSMTest()
        {
            GSMs = new[]
            {
                new GSM("SamsungGalaxy S6Edge", "Samsung", 800, 8787, new Battery("C5B60", BatteryType.NiMH)),
                new GSM("IPhone X", "Apple", 1900, battery: new Battery("9C500", BatteryType.Li_Ion), display: new Display(4, 2560)), 
                new GSM("IPhone 6S", "Apple", 1500, display: new Display(4, 2024))
            };
        }

        public static void DisplayGsmListTest()
        {
            if (GSMs == null)
            {
                throw new InvalidOperationException("GSM list not initialized!");
            }

            foreach (var gsm in GSMs)
            {
                Console.WriteLine(gsm);
                Console.WriteLine();
            }
        }

        public static void DisplayIphone4sGsmDitailsTest()
        {
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
