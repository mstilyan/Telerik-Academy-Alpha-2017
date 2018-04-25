using System;
using System.Collections.Generic;
using System.Linq;

namespace Expressions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string input = Console.ReadLine();
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            long targetValue = long.Parse(Console.ReadLine());

            // ReSharper disable once PossibleNullReferenceException
            var digits = input.ToCharArray().Select(i => i - '0').ToArray();
            var operations = new[] {"*", "+", "-", ""};

            GenerateExpressionPermutations(operations, digits, new string[digits.Length - 1], targetValue);
        }

        private static void GenerateExpressionPermutations(string[] operations, int[] digits, string[] permutation, long targetValue, int index = 0)
        {
            if (index >= permutation.Length)
            {
                var digitsCopy = new int[digits.Length];

                return;
            }

            foreach (var operation in operations)
            {
                permutation[index] = operation;
                GenerateExpressionPermutations(operations, digits, permutation, index + 1);
            }
        }
    }
}