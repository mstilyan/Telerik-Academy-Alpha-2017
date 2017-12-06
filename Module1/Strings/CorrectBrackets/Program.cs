using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int opennigBracketsCounter = 0;
            int closingBracketsCounter = 0;
            foreach (var symbol in input)
            {
                if (symbol == '(') opennigBracketsCounter++;
                if (symbol == ')') closingBracketsCounter++;

                if (closingBracketsCounter > opennigBracketsCounter)
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
            }

            if (closingBracketsCounter == opennigBracketsCounter)
                Console.WriteLine("Correct");
            else
                Console.WriteLine("Incorrect");
        }
    }
}
