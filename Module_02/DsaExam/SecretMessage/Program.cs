using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecretMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var secretMessage = Console.ReadLine();
            var output = string.Empty;
            Stack<int> brackets = new Stack<int>();
            Stack<int> nums = new Stack<int>();

            int index = 0;
            while (index < secretMessage.Length)
            {
                var ch = secretMessage[index];

                if (ch >= 'a' && ch <= 'z')
                {
                    output += ch;
                    index++;
                }
                else if (ch == '{')
                {
                    brackets.Push(output.Length);
                    output += ch;
                    index++;
                }
                else if (ch >= '0' && ch <= '9')
                {
                    string num = string.Empty;
                    while (ch >= '0' && ch <= '9')
                    {
                        num += ch;
                        ch = secretMessage[++index];
                    }

                    nums.Push(int.Parse(num));
                }
                else if (ch == '}')
                {
                    int bracketInd = brackets.Pop();
                    var subStr = output.Substring(bracketInd + 1);
                    output = output.Remove(bracketInd);
                    int count = nums.Pop();

                    for (int i = 0; i < count; i++)
                    {
                        output += subStr;
                    }
                    index++;
                }
            }


            Console.WriteLine(output);
        }

    }
}
