using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            var opennigBracketIndeces = new Stack<int>();
            var subExpressions = new List<string>();

            for (int index = 0; index < expression.Length; index++)
            {
                if (expression[index] == '(')
                {
                    opennigBracketIndeces.Push(index);
                }
                else if (expression[index] == ')')
                {
                    if (opennigBracketIndeces.Count == 0)
                    {
                        Console.WriteLine("Brackets missmatch");
                        return;
                    }

                    var top = opennigBracketIndeces.Pop();
                    subExpressions.Add(expression.Substring(top, index - top + 1));
                }
            }

            if (opennigBracketIndeces.Count != 0)
            {
                Console.WriteLine("Brackets missmatch");
                return;
            }

            Console.WriteLine(string.Join("|", subExpressions));
        }
    }
}
