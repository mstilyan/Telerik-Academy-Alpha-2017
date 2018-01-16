using System;
using System.Collections.Generic;
using System.Linq;

namespace Actions
{
    class Program
    {
        private static int nodes;
        private static int edges;
        private static SortedDictionary<int, HashSet<int>> graph;
        private static SortedDictionary<int, HashSet<int>> reversedGraph;

        static void Main(string[] args)
        {
            var nodesAndEdges = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            nodes = nodesAndEdges[0];
            edges = nodesAndEdges[1];
            InitializeGraphs();

            ReadEdges();
            TopologicalSort();
        }

        private static void InitializeGraphs()
        {
            graph = new SortedDictionary<int, HashSet<int>>();
            reversedGraph = new SortedDictionary<int, HashSet<int>>();

            for (int node = 0; node < nodes; node++)
            {
                graph.Add(node, new HashSet<int>());
                reversedGraph.Add(node, new HashSet<int>());
            }
        }

        private static void TopologicalSort()
        {
            for (int task = 0; task < nodes; task++)
            {
                var node = graph.Keys.First(key => graph[key].Count == 0);
                graph.Remove(node);

                foreach (var parent in reversedGraph[node])
                {
                    graph[parent].Remove(node);
                }

                Console.WriteLine(node);
            }
        }

        private static void ReadEdges()
        {
            for (int i = 0; i < edges; i++)
            {
                var tasks = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int firstTask = tasks[0];
                int secondTask = tasks[1];

                graph[secondTask].Add(firstTask);
                reversedGraph[firstTask].Add(secondTask);
            }
        }
    }
}