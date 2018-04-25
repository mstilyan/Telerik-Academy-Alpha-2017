using System;
using System.Collections.Generic;

namespace ModernTime
{
    class Program
    {
        private static List<Person> males;
        private static List<Person> females;
        private static Match bestMatch;

        static void Main(string[] args)
        {
            males = new List<Person>();
            females = new List<Person>();

            ProcessInput();
            Console.WriteLine(bestMatch);
        }

        private static void ProcessInput()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var name = Console.ReadLine();
                var gender = Console.ReadLine();

                Console.ReadLine();

                var interests = new Dictionary<string, int>();

                // ReSharper disable once PossibleNullReferenceException
                var interestsArray = Console.ReadLine().Split(',');

                foreach (var interest in interestsArray)
                {
                    if (!interests.ContainsKey(interest))
                    {
                        interests.Add(interest, 0);
                    }
                    interests[interest]++;
                }

                var person = new Person {Name = name, Interests = interests};

                if (gender == "f")
                {
                    females.Add(person);
                    EvaluateMatchesWithMales(person);
                }
                else
                {
                    males.Add(person);
                    EvaluateMatchesWithFemales(person);
                }              
            }
        }

        private static void EvaluateMatchesWithFemales(Person male)
        {
            foreach (var female in females)
            {
                Match match = GetMatch(male, female);
                if (match.CompareTo(bestMatch) > 0)
                {
                    bestMatch = match;
                }
            }
        }

        private static void EvaluateMatchesWithMales(Person female)
        {
            foreach (var male in males)
            {
                Match match = GetMatch(male, female);
                if (match.CompareTo(bestMatch) > 0)
                {
                    bestMatch = match;
                }
            }
        }

        private static Match GetMatch(Person male, Person female)
        {
            int count = 0;
            foreach (var kvp in male.Interests)
            {
                var interest = kvp.Key;
                if (female.Interests.ContainsKey(interest))
                {
                    count += male.Interests[interest] * female.Interests[interest];
                }
            }

            return new Match {Male = male, Female = female, InterestsCount = count};
        }
    }

    class Person
    {
        public string Name { get; set; }
        public IDictionary<string, int> Interests { get; set; }
    }

    class Match : IComparable<Match>
    {
        public Person Male { get; set; }
        public Person Female { get; set; }
        public int InterestsCount { get; set; }


        public override string ToString()
        {
            return $"{Male.Name} and {Female.Name} have {InterestsCount} common interests!";
        }

        public int CompareTo(Match other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var cmp = InterestsCount.CompareTo(other.InterestsCount);
            if (cmp != 0) return cmp;

            return String.Compare(other.Male.Name, this.Male.Name, StringComparison.Ordinal);
        }
    }
}
