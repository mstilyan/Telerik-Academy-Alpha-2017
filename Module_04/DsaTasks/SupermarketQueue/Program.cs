using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace SupermarketQueue
{
    class Program
    {
        private static BigList<string> supermarketQueue;
        private static Dictionary<string, int> personCount;

        private const string AppendCommand = "Append";
        private const string InsertCommand = "Insert";
        private const string FindCommand = "Find";
        private const string ServeCommand = "Serve";
        private const string EndCommand = "End";

        static void Main(string[] args)
        {
            supermarketQueue = new BigList<string>();
            personCount = new Dictionary<string, int>();

            var output = ProcessInput();

            Console.WriteLine(output);
        }

        private static string ProcessInput()
        {
            var resultBuilder = new StringBuilder();

            string input;
            while (string.CompareOrdinal(input = Console.ReadLine(), EndCommand) != 0)
            {
                var inputArray = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var commandName = inputArray[0];
                var commandArgs = inputArray.Skip(1).ToList();
                var commandResult = string.Empty;

                switch (commandName)
                {
                    case AppendCommand:
                        commandResult = Append(commandArgs);
                        break;
                    case InsertCommand:
                        commandResult = Insert(commandArgs);
                        break;
                    case FindCommand:
                        commandResult = Find(commandArgs);
                        break;
                    case ServeCommand:
                        commandResult = Serve(commandArgs);
                        break;
                }

                resultBuilder.AppendLine(commandResult);
            }

            return resultBuilder.ToString().TrimEnd();
        }

        private static string Serve(List<string> commandArgs)
        {
            var count = int.Parse(commandArgs[0]);
            if (count > supermarketQueue.Count) return "Error";

            var servedPeople = supermarketQueue.GetRange(0, count);
            servedPeople.ForEach(x => personCount[x]--);
            supermarketQueue.RemoveRange(0, count);

            return string.Join(" ", servedPeople);
        }

        private static string Find(IList<string> commandArgs)
        {
            var personName = commandArgs[0];
            return personCount.ContainsKey(personName) 
                ? personCount[personName].ToString() 
                : 0.ToString();
        }

        private static string Insert(IList<string> commandArgs)
        {
            var position = int.Parse(commandArgs[0]);
            var personName = commandArgs[1];

            if (position < 0 || position > supermarketQueue.Count) return "Error";
            supermarketQueue.Insert(position, personName);

            UpdatePersonCount(personName);

            return "OK";
        }

        private static string Append(IList<string> commandArgs)
        {
            var personName = commandArgs[0];
            supermarketQueue.Add(personName);

            UpdatePersonCount(personName);

            return "OK";
        }

        private static void UpdatePersonCount(string personName)
        {
            if (!personCount.ContainsKey(personName))
            {
                personCount.Add(personName, 0);
            }
            personCount[personName]++;
        }
    }
}
