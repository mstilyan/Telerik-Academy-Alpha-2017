using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slogan
{
    class Program
    {
        static void Main(string[] args)
        {
            var validSlogans = new List<string>();
            int sloganSuggestions = int.Parse(Console.ReadLine());

            for (int i = 0; i < sloganSuggestions; i++)
            {
                var allowedWords = Console.ReadLine().Trim().Split();
                var suggestedSlogan = Console.ReadLine();

                var wordsUsed = new List<string>();

                if (ValidateSlogan(suggestedSlogan, allowedWords, wordsUsed))
                {
                    wordsUsed.Reverse();
                    validSlogans.Add(suggestedSlogan);
                }
            }

            Console.WriteLine(validSlogans.ToString().Trim());
        }


        private static bool ValidateSlogan(string suggestedSlogan, string[] words, List<string> formatedSlogan)
        {
            if (suggestedSlogan.Equals(string.Empty))
            {
                return true;
            }

            foreach (var word in words)
            {
                if (suggestedSlogan.StartsWith(word))
                {
                    if (ValidateSlogan(suggestedSlogan.Substring(word.Length), words, formatedSlogan))
                    {
                        formatedSlogan.Add(word);
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool StringsAreEqual(string word, string suggestedSlogan, int index)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (suggestedSlogan[i + index] != word[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}