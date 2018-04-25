using System;
using System.Collections.Generic;
using System.Linq;

namespace BagsOfBalls
{
    class Program
    {
        private static long[] _bagsCapacity;
        private static long _ballsCount;
        private static Dictionary<long, long> maxStepsForSomeBalls;

        static void Main(string[] args)
        {

            // ReSharper disable once PossibleNullReferenceException
            var token = Console.ReadLine().Split();
            _ballsCount = long.Parse(token[0]);

            maxStepsForSomeBalls = new Dictionary<long, long>();

            // ReSharper disable once PossibleNullReferenceException
            _bagsCapacity = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .Where(x => _ballsCount % x == 0 && x < _ballsCount)
                .OrderByDescending(x => x)
                .ToArray();


            var result = GetMaxSteps(_ballsCount, 1);
            Console.WriteLine(result);
        }

        
        private static long GetMaxSteps(long ballsPerBag, long bagsCount, int index = 0)
        {
            if (ballsPerBag == 1)
            {
                return 0;
            }

            if (maxStepsForSomeBalls.ContainsKey(ballsPerBag))
            {
                return maxStepsForSomeBalls[ballsPerBag];
            }

            var steps = 0L;
            for (int i = index; i < _bagsCapacity.Length; ++i)
            {
                if (_bagsCapacity[i] < ballsPerBag && ballsPerBag % _bagsCapacity[i] == 0)
                {
                    var newBagsCount = (ballsPerBag / _bagsCapacity[i]) * bagsCount;
                    steps = Math.Max(steps, bagsCount + GetMaxSteps(_bagsCapacity[i], newBagsCount, i));
                }
            }

            maxStepsForSomeBalls.Add(ballsPerBag, steps);
            return steps;
        }
    }
}