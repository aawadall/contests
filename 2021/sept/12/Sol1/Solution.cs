using System;
using System.Collections.Generic;

namespace Sol1
{
    public class Solution
    {
        public int ReachableNodes(int[][] edges, int maxMoves, int n)
        {
            var debug = false;
            // Create graph nodes
            var graphNodes = new List<Node>();
            for (int idx = 0; idx < n; idx++)
            {
                graphNodes.Add(new Node($"{idx}", debug));
            }

            // Create Graph with root node
            var graph = new Graph(graphNodes, debug);

            // iterate over edges and add them to graph
            foreach (var edge in edges)
            {
                graph.AddEdge(edge);
            }

            // DEBUG
            // graph.PrintGraph();

            // return number of reachable nodes
            return graph.GetReachableNodes(maxMoves);
        }
    }

    /// <summary>
    /// Graph of nodes
    /// </summary>
    internal class Graph
    {
        private int _globalCounter;
        private Node root;  // Root node
        private List<Node> graphNodes;
        public bool Debug { get; set; }
        public Graph(List<Node> graphNodes, bool debug = false)
        {
            this.graphNodes = graphNodes;
            this.root = graphNodes[0];
            _globalCounter = graphNodes.Count;
            this.Debug = debug;
        }

        /// <summary>
        /// Add edge 
        /// </summary>
        /// <param name="edge">edge data linking two nodes</param>
        internal void AddEdge(int[] edge)
        {
            var node1 = graphNodes[edge[0]];
            var node2 = graphNodes[edge[1]];
            var steps = edge[2];

            if (Debug) Console.WriteLine($"Adding edge {node1.Id} -> {node2.Id} with {steps} steps");

            for (int idx = 0; idx < steps; idx++)
            {
                string id = $"{_globalCounter++}";
                var middleNode = new Node(id);
                node1.AddNeighbor(middleNode);
                middleNode.AddNeighbor(node1);
                if (Debug) Console.WriteLine($"....link {node1.Id} <-> {middleNode.Id}");
                node1 = middleNode;
            }

            // DEBUG
            if (Debug) Console.WriteLine($"....final link {node1.Id} <-> {node2.Id}");
            node1.AddNeighbor(node2);
            node2.AddNeighbor(node1);
        }

        internal int GetReachableNodes(int maxMoves)
        {
            // DEBUG
            if (Debug) System.Console.WriteLine($"Graph->GetReachableNodes({maxMoves})");
            return root.GetReachableNodes(maxMoves);
        }

        internal void PrintGraph()
        {
            System.Console.WriteLine($"Graph->PrintGraph()");
            root.PrintGraph();
        }
    }

    /// <summary>
    /// Graph Nodes
    /// </summary>
    internal class Node
    {
        public string Id { get; set; }
        private HashSet<Node> neighbors; // node neighbors
        public bool Debug { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="idx"></param>
        public Node(string id, bool debug = false)
        {
            this.Id = id;
            this.neighbors = new HashSet<Node>();
            Debug = debug;
        }

        /// <summary>
        /// Add neighbor
        /// </summary>
        /// <param name="node"></param>
        public void AddNeighbor(Node node)
        {
            // DEBUG
            // System.Console.WriteLine($"Node({Id})->AddNeighbor({node.Id})");
            if (this.neighbors == null)
            {
                this.neighbors = new HashSet<Node>();
            }
            this.neighbors.Add(node);
        }

        /// <summary>
        /// Returns total number of reachable nodes from this node using max moves
        /// </summary>
        /// <param name="maxMoves"></param>
        /// <returns></returns>
        internal int GetReachableNodes(int maxMoves)
        {
            if (Debug) Console.WriteLine($"Node({Id})->GetReachableNodes({maxMoves})");
            return CountDepthFirst(maxMoves);
        }


        internal int CountDepthFirst(int maxMoves, HashSet<Node> visited = null)
        {
            if (visited == null)
            {
                visited = new HashSet<Node>();
            }
            visited.Add(this);
            // DEBUG
            if (Debug)
            {
                Console.WriteLine($"({this.Id}) -> CountDepthFirst({maxMoves})");
                Console.Write($"    {neighbors.Count} Children -> ");
                foreach (var node in neighbors)
                {
                    System.Console.Write($"{node.Id}, ");
                }
                System.Console.WriteLine();
            }

            if (maxMoves > 0)
            {
                int count = 1;
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        count += neighbor.CountDepthFirst(maxMoves - 1, visited);
                    }

                }
                return count;
            }
            return 1;
        }

        /// <summary>
        /// Used to print graph
        /// </summary>
        internal void PrintGraph()
        {
            Console.WriteLine($"({this.Id})");
            foreach (var neighbor in neighbors)
            {
                Console.WriteLine($"({this.Id}) -> ({neighbor.Id})");
            }
        }
    }
}