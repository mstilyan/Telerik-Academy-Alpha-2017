using System;
using System.Collections.Generic;
using System.Linq;

namespace Trucks
{
    class Program
    {
        private static int nodesCount;
        private static int edgesCount;
        private static IList<Edge> edges;

        static void Main(string[] args)
        {
            ReadGraph();
            var minimalWeight = KruskalAlgorithm.Kruskal(nodesCount, edges);
            Console.WriteLine(minimalWeight);
        }

        private static void ReadGraph()
        {
            var graphDetails = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            nodesCount = graphDetails[0];
            edgesCount = graphDetails[1];

            edges = new List<Edge>(edgesCount);
            
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeDetails = Console.ReadLine()
                    .Split()
                    .ToList();

                int parent = int.Parse(edgeDetails[0]) - 1;
                int child = int.Parse(edgeDetails[1]) - 1;

                long weight = long.Parse(edgeDetails[2]);

                edges.Add(new Edge { StartNode = parent, EndNode = child, Weight = weight });
            }
        }
    }

    public class KruskalAlgorithm
    {
        public static long Kruskal(int numberOfVertices, ICollection<Edge> edges)
        {
            int[] parent = new int[numberOfVertices];

            //Init parent array in a way that each node is its parent
            for (int vertex = 0; vertex < numberOfVertices; vertex++)
            {
                parent[vertex] = vertex;
            }

            //Sorting the Edges by Weight so that we take the min weight
            var orderedEdges = edges.OrderByDescending(x => x.Weight);
            long minimalWeight = 0;

            foreach (var edge in orderedEdges)
            {
                var startNodeRoot = FindRoot(edge.StartNode, parent);
                var endNodeRoot = FindRoot(edge.EndNode, parent);

                if (endNodeRoot != startNodeRoot)
                {
                    parent[endNodeRoot] = startNodeRoot;
                    minimalWeight = edge.Weight;
                }
            }

            return minimalWeight;
        }

        private static int FindRoot(int node, int[] parent)
        {
            if (node == parent[node])
            {
                return node;
            }
            return parent[node] = FindRoot(parent[node], parent);
        }
    }

    public class Edge
    {
        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public long Weight { get; set; }
    }
}
