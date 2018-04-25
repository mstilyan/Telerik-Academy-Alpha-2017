using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<Unit>> unitsByType = new Dictionary<string, SortedSet<Unit>>();
            Dictionary<string, Unit> unitsByName = new Dictionary<string, Unit>();
            SortedSet<Unit> unitsOrderedByAttack = new SortedSet<Unit>();
            StringBuilder resultBuilder = new StringBuilder();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandParams = command.Split();
                switch (commandParams[0])
                {
                    case "add":
                        Unit unit = new Unit(commandParams[1], commandParams[2], int.Parse(commandParams[3]));
                        AddUnit(unit, unitsByType, unitsByName, unitsOrderedByAttack, resultBuilder); break;
                    case "remove":
                        RemoveUnit(commandParams[1], unitsByType, unitsByName, unitsOrderedByAttack, resultBuilder); break;
                    case "find":
                        FindUnits(commandParams[1], unitsByType, resultBuilder); break;
                    case "power":
                        PowerUnit(int.Parse(commandParams[1]), unitsOrderedByAttack, resultBuilder); break;
                }
            }

            Console.WriteLine(resultBuilder.ToString());
        }

        public static void AddUnit(Unit unit, Dictionary<string, SortedSet<Unit>> unitsByType,
                                Dictionary<string, Unit> unitsByName, SortedSet<Unit> unitsOrderedByAttack, 
                                StringBuilder resultBuilder)
        {
            if (unitsByName.ContainsKey(unit.Name))
            {
                resultBuilder.AppendLine(string.Format("FAIL: {0} already exists!", unit.Name));
            }
            else
            {
                unitsByName.Add(unit.Name, unit);
                unitsOrderedByAttack.Add(unit);
                if (!unitsByType.ContainsKey(unit.Type))
                {
                    unitsByType.Add(unit.Type, new SortedSet<Unit>());
                }

                unitsByType[unit.Type].Add(unit);

                resultBuilder.AppendLine(string.Format("SUCCESS: {0} added!", unit.Name));
            }
        }

        public static void RemoveUnit(string unitName, Dictionary<string, SortedSet<Unit>> unitsByType,
                                    Dictionary<string, Unit> unitsByName, SortedSet<Unit> unitsOrderedByAttack, StringBuilder resultBuilder)
        {
            if (unitsByName.ContainsKey(unitName))
            {
                Unit unit = unitsByName[unitName];
                unitsByName.Remove(unit.Name);
                unitsOrderedByAttack.Remove(unit);
                unitsByType[unit.Type].Remove(unit);

                resultBuilder.AppendLine(string.Format("SUCCESS: {0} removed!", unitName));
            }
            else
            {
                resultBuilder.AppendLine(string.Format("FAIL: {0} could not be found!", unitName));
            }
        }

        public static void FindUnits(string unitType, Dictionary<string, SortedSet<Unit>> unitsByType, StringBuilder resultBuilder)
        {
            if (unitsByType.ContainsKey(unitType))
            {
                resultBuilder.AppendLine(string.Format("RESULT: {0}", string.Join(", ", unitsByType[unitType].Take(10))));
            }
            else
            {
                resultBuilder.AppendLine("RESULT: ");
            }
        }

        public static void PowerUnit(int count, SortedSet<Unit> unitsOrderedByAttack, StringBuilder resultBuilder)
        {
            resultBuilder.AppendLine(string.Format("RESULT: {0}", string.Join(", ", unitsOrderedByAttack.Take(count))));
        }
    }

    public class Unit : IComparable<Unit>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }

        public int CompareTo(Unit other)
        {
            int result = this.Attack.CompareTo(other.Attack) * -1;
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }
    }
}
