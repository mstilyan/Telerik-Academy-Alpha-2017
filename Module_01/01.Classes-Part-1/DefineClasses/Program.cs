using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Call c = new Call(new DateTime(1999, 11, 7), 11, "+359890002759" );
            GSM.IPhone4S.CallHistory.AddLast(new Call(new DateTime(2007, 11, 22), 3691, "+359899764080"));
            GSM.IPhone4S.CallHistory.AddLast(c);

            //GSMTest.DisplayGsmList();
            GSMTest.DisplayIphone4sGsmDitailsTest();
        }
    }
}
