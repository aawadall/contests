using System;
using System.Collections.Generic;

namespace Sol2
{
    public class Solution
    {
        public int ReachableNodes(int[][] edges, int maxMoves, int n)
        {
            var debug = true;
            
            // No need to create graphs, just use a list of edges
            var graph = new Graph(n, edges, debug);
            
            // return number of reachable nodes
            return graph.CountReachableNodes(maxMoves); // TODO
        }
    }

    /// <summary>
    /// Graph class 
    /// </summary>
    public class Graph {
        public Node Root { get; set; }
        private Node[] _nodes;
        public bool Debug { get; set; }
        
        // Constructor
        public Graph(int n, int[][] edges, bool debug = false) {
            Debug = debug;

            if(Debug) {
                Console.WriteLine($"Graph({n} nodes, {edges.Length} edges, {(debug ? "DEBUG" : "NO DEBUG")})");
            }
            // Create nodes
            _nodes = new Node[n];
            for(int idx = 0; idx < n; idx++) {
                _nodes[idx]= new Node(idx, debug);
            }

            // Set root node
            if(_nodes.Length > 0) {
                Root = _nodes[0];
            }

            // iterate over edges
            foreach (var edge in edges) {
                _nodes[edge[0]].AddNeighbor(node: _nodes[edge[1]], distance: edge[2]);
            }
        }

        // Count number of reachable nodes from root
        public int CountReachableNodes(int maxMoves) {
            if (Debug) {
                Console.WriteLine($"Graph->CountReachableNodes({maxMoves})");
            }
            
            // Initialize
            int count = 1;

            // find nodes from each child in root
            foreach (var child in Root.Neighbors) {
                if(Debug) System.Console.WriteLine($"Child ({child.Key.Id},{child.Value})");
                count +=child.Key.CountReachableNodes(maxMoves, child.Value, Root);
            }

            return count; // TODO
        }
    }

    /// <summary>
    /// Graph Node class
    /// </summary>
    public class Node {
        public int Id { get; set; }
        public IDictionary<Node, int> Neighbors { get; set; }
        public bool Debug { get; set; }
        // Constructor
        public Node(int id, bool debug = false) {    
            if(debug) {
                Console.WriteLine($"Node({id})");
            }
            Id = id;
            Neighbors = new Dictionary<Node, int>();
            Debug = debug;
        }

        // Add a neighbor to the node
        public void AddNeighbor(Node node, int distance) {
            if(Debug) {
                Console.WriteLine($"({Id}) -> AddNeighbor({node.Id}, {distance})");
            }
            Neighbors.Add(node, distance);
            node.Neighbors.Add(this, distance);
        }

        // count nodes reachable from this node
        public int CountReachableNodes(int maxMoves, int weight, Node parent = null) {
            if(Debug) {
                Console.WriteLine($"(Id:{Id}) -> ReachableNodes(moves:{maxMoves}, weight:{weight})");
            }

            int count = weight < maxMoves ? weight  : maxMoves;
            maxMoves -= count;

            if(maxMoves <= 0) return count;
            // iterate over children
            foreach (var child in Neighbors) {
                if(parent != null && child.Key == parent) {
                    if(Debug) System.Console.WriteLine($"({Id}) -> Skip parent ({child.Key.Id},{child.Value})");
                    continue;
                }
                
                if(Debug) System.Console.WriteLine($"({Id}) -> Inspect Child (Id:{child.Key.Id},Distance:{child.Value})");
                count += child.Key.CountReachableNodes(maxMoves, child.Value, this);
                if(Debug) System.Console.WriteLine($"({Id}) -> Child (Id:{child.Key.Id},Distance:{child.Value}) count = {count}");
            }
            return count; 
        }
    }
}