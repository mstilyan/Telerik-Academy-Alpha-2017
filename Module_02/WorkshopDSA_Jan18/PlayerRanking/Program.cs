using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class Program
    {
        private static BigList<Player> ranklist;
        private static Dictionary<string, SortedSet<Player>> orderedPlayersByType;

        static void Main(string[] args)
        {
            ranklist = new BigList<Player>();
            orderedPlayersByType = new Dictionary<string, SortedSet<Player>>();

            StringBuilder resultBuilder = new StringBuilder();
            ReadCommands(resultBuilder);
            Console.WriteLine(resultBuilder);
        }

        private static void ReadCommands(StringBuilder resultBuilder)
        {
            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "end")
            {
                var commandArgs = inputCommand.Split();
                var command = commandArgs[0];

                switch (command)
                {
                    case "add":
                        AddPlayer(commandArgs, resultBuilder);
                        break;
                    case "find":
                        PrintPlayersByType(commandArgs, resultBuilder);
                        break;
                    case "ranklist":
                        PrintRanklistRange(commandArgs, resultBuilder);
                        break;
                }
            }
        }

        private static void PrintRanklistRange(string[] commandArgs, StringBuilder resultBuilder)
        {
            int startInd = int.Parse(commandArgs[1]) - 1;
            int endInd = int.Parse(commandArgs[2]) - 1;

            for (int i = startInd; i < endInd; i++)
            {
                resultBuilder.Append($"{i + 1}. {ranklist[i]}; ");
            }
            resultBuilder.AppendLine($"{endInd + 1}. {ranklist[endInd]}");
        }

        private static void PrintPlayersByType(string[] commandArgs, StringBuilder resultBuilder)
        {
            string findType = commandArgs[1];

            if (orderedPlayersByType.ContainsKey(findType))
            {
                var players = orderedPlayersByType[findType];
                resultBuilder.AppendFormat("Type {0}:", findType);
                foreach (Player player in players)
                {
                    resultBuilder.AppendFormat(" {0};", player);
                }

                resultBuilder.Remove(resultBuilder.Length - 1, 1);
                resultBuilder.AppendLine();
            }
            else
            {
                resultBuilder.AppendFormat("Type {0}: ", findType);
                resultBuilder.AppendLine();
            }
        }

        private static void AddPlayer(string[] commandArgs, StringBuilder resultBuilder)
        {
            var playerName = commandArgs[1];
            var playerType = commandArgs[2];
            var playerAge = int.Parse(commandArgs[3]);
            var playerRank = int.Parse(commandArgs[4]);

            Player playerToAdd = new Player(playerName, playerAge);    
            if (orderedPlayersByType.ContainsKey(playerType))
            {
                if (orderedPlayersByType[playerType].Count == 5)
                {
                    Player lastPlayer = orderedPlayersByType[playerType].Last();
                    if (lastPlayer.CompareTo(playerToAdd) > 0)
                    {
                        orderedPlayersByType[playerType].Remove(lastPlayer);
                        orderedPlayersByType[playerType].Add(playerToAdd);
                    }
                }
                else
                {
                    orderedPlayersByType[playerType].Add(playerToAdd);
                }
            }
            else
            {
                orderedPlayersByType[playerType] = new SortedSet<Player> {playerToAdd};
            }

            ranklist.Insert(playerRank - 1, playerToAdd);
            resultBuilder.AppendLine($"Added player {playerName} to position {playerRank}");
        }
    }


    internal class Player : IComparable<Player>
    {
        public Player(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name}({this.Age})";
        }

        public int CompareTo(Player other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            return other.Age.CompareTo(Age);
        }
    }
}
