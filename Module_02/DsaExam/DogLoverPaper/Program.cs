﻿using System;

public class Program
{
    private static readonly bool[] ToBeUsed = new bool[21];
    private static readonly bool[,] Graph = new bool[21, 21];

    public static void Main()
    {
        Input();
        var answer = RecoverNumber();
        Console.WriteLine(answer);
    }

    private static void Input()
    {
        int edges = int.Parse(Console.ReadLine());

        for (int i = 0; i < edges; i++)
        {
            var line = Console.ReadLine();
            var firstNumber = line[0] - '0';
            var secondNumber = line[line.Length - 1] - '0';
            if (line.Contains("before"))
            {
                AddRelation(firstNumber, secondNumber);
            }
            else
            {
                AddRelation(secondNumber, firstNumber);
            }
        }
    }

    private static void AddRelation(int firstNumber, int secondNumber)
    {
        ToBeUsed[firstNumber] = true;
        ToBeUsed[secondNumber] = true;
        Graph[firstNumber, secondNumber] = true;
    }

    private static long RecoverNumber()
    {
        int toBeUsedCount = 0;
        for (int i = 0; i <= 9; i++)
        {
            if (ToBeUsed[i])
            {
                toBeUsedCount++;
            }
        }

        long number = 0;
        for (int i = 0; i < toBeUsedCount; i++)
        {
            for (int candidate = 0; candidate <= 9; candidate++)
            {
                if (candidate == 0 && number == 0)
                {
                    // No leading zeros allowed.
                    continue;
                }

                if (ToBeUsed[candidate] && !HasParent(candidate))
                {
                    // candidate is the smallest digit that has no precedent and is part of the original number
                    number *= 10;
                    number += candidate;

                    ToBeUsed[candidate] = false;
                    RemoveAllDescendents(candidate);
                    break;
                }
            }
        }

        return number;
    }

    private static void RemoveAllDescendents(int node)
    {
        for (int i = 0; i <= 9; i++)
        {
            Graph[node, i] = false;
        }
    }

    private static bool HasParent(int node)
    {
        for (int i = 0; i <= 9; i++)
        {
            if (Graph[i, node])
            {
                return true;
            }
        }

        return false;
    }
}