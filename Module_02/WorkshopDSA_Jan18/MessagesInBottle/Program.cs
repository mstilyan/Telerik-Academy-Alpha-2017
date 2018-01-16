using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MessagesInBottle
{
    class Program
    {
        public static Dictionary<char, string> cipher;
        public static SortedSet<string> messages;

        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string cipherInput = Console.ReadLine();

            cipher = new Dictionary<char, string>();
            messages = new SortedSet<string>();

            ExtractCipher(cipherInput);
            Decipher(code);

            Console.WriteLine(messages.Count);
            Console.WriteLine(string.Join("\n", messages));
        }

        private static void Decipher(string code, string message = "", int index = 0)
        {
            if (index == code.Length)
            {
                messages.Add(string.Join("", message));
                return;
            }

            foreach (var pattern in cipher)
            {
                if (pattern.Value.Length + index <= code.Length &&
                    string.Equals(pattern.Value, code.Substring(index, pattern.Value.Length)))
                {
                    Decipher(code, message + pattern.Key, index + pattern.Value.Length);
                }
            }
        }

        private static void ExtractCipher(string cipherInput)
        {
            string pattern = "([A-Z])(\\d+)";
            var matches = Regex.Matches(cipherInput, pattern);

            foreach (Match match in matches)
            {
                var key = match.Groups[1].Value[0];
                var value = match.Groups[2].Value;

                if (!cipher.ContainsKey(key))
                {
                    cipher.Add(key, value);
                }
            }
        }
    }
}
