using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReSharper disable once PossibleNullReferenceException
            var input = Console.ReadLine().Split().ToList();

            var studentsCount = int.Parse(input[0]);
            var seatChangesCount = int.Parse(input[1]);
            var studentsOrder = new LinkedList<string>();
            var studentsPositions = new Dictionary<string, LinkedListNode<string>>(studentsCount);

            // ReSharper disable once PossibleNullReferenceException
            var collection = Console.ReadLine().Split();

            foreach (var student in collection)
            {
                var node = studentsOrder.AddLast(student);
                studentsPositions.Add(student, node);
            }
            

            for (int i = 0; i < seatChangesCount; i++)
            {
                // ReSharper disable once PossibleNullReferenceException
                var studentsToSwap = Console.ReadLine().Split();

                var fstStudent = studentsToSwap[0];
                var secStudent = studentsToSwap[1];

                var fstStudentPos = studentsPositions[fstStudent];
                var secStudentPos = studentsPositions[secStudent];

                if (fstStudentPos.Next != secStudentPos)
                {
                    studentsOrder.Remove(fstStudentPos);
                    studentsPositions[fstStudent] =
                        studentsOrder.AddBefore(secStudentPos, fstStudent);
                }
            }

            Console.WriteLine(string.Join(" ", studentsOrder));
        }
    }
}

