using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    static class GSMCallHistoryTest
    {
        public static GSM GSMSample { get; set; }

        static GSMCallHistoryTest()
        {
            GSMSample = new GSM("Lenovo S1 Light", "Lenovo", 300, 61989, 
                new Battery("61C00", BatteryType.Li_Ion), 
                new Display(3, 1280));


            GSMSample.CallHistory.AddLast(new Call(new DateTime(2016, 01, 17, 16, 30, 17), 512, "+359876584721"));
            GSMSample.CallHistory.AddLast(new Call(new DateTime(2016, 02, 1, 3, 25, 00), 512, "+359876584721"));
            GSMSample.CallHistory.AddLast(new Call(new DateTime(2016, 01, 17, 16, 30, 17), 512, "+359876584721"));

        }

        public static double CalculateCallsTotalPriceTest()
        {
            return GSMSample.CalculateTotalPrice(3.14f);
        }

        public static void DisplayCallHistoryTest()
        {
            Console.WriteLine("Call history:");
            foreach (var call in GSMSample.CallHistory)
            {
                Console.WriteLine(call);
            }
        }

        public static void DisplayCallsTotalPriceTest()
        {
            Console.WriteLine(CalculateCallsTotalPriceTest());
        }

        public static void ClearCallHistoryTest()
        {
            GSMSample.ClearHistory();
        }

        public static bool DeleteLongestCallTest()
        {
            if (GSMSample.CallHistory.Count == 0)
            {
                return false;
            }

            var longestCall = GSMSample.CallHistory.First();
            foreach (var call in GSMSample.CallHistory)
            {
                if (call.Duration > longestCall.Duration)
                {
                    longestCall = call;
                }
            }

            GSMSample.CallHistory.Remove(longestCall);
            return true;
        }

    }
}
