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
                Console.WriteLine($"Graph (Root Node {Root.Id})->CountReachableNodes({maxMoves})");

                // Print all nodes
                System.Console.Write("    Children are: ");
                foreach (var child in Root.Neighbors) {
                    System.Console.Write($"{child.Key.Id}, ");
                }    
                System.Console.WriteLine();
            }
            
            // Initialize
            int count = 1;

            // find nodes from each child in root
            var visited = new HashSet<Node>();
            visited.Add(Root);
            
            foreach (var child in Root.Neighbors) {
                if(Debug) System.Console.WriteLine($"    Child (Id:{child.Key.Id},Distance:{child.Value})\n\n");
                var childCount = child.Key.CountReachableNodes(maxMoves, child.Value,  visited);
                if(Debug) System.Console.WriteLine($"    ChildCount: {childCount}\n");
                count += childCount;
            }
            if(Debug) System.Console.WriteLine($"Graph (Root Node {Root.Id})->CountReachableNodes({maxMoves}) --->    Count: {count}");
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
        public int CountReachableNodes(int maxMoves, int weight, HashSet<Node> visited) {
            if(Debug) {
                Console.WriteLine($"    (Id:{Id}) -> ReachableNodes(moves:{maxMoves}, weight:{weight})");
                 // Print all nodes
                System.Console.Write("    Children are: ");
                foreach (var child in Neighbors) {
                    System.Console.Write($"{child.Key.Id}, ");
                }    
                System.Console.WriteLine();
            }

            int count =  (weight < maxMoves ? weight  : 1 + maxMoves);
            maxMoves -= count;
            maxMoves = maxMoves < 0 ? 0 : maxMoves;

            // if we have no more moves, return count
            if(maxMoves <= 0) {
                if(Debug) System.Console.WriteLine($"    (Id:{Id}) -> ReachableNodes: No more moves Count: {count}, maxMoves:{maxMoves}");
                return count;
                }

            // iterate over children
            foreach (var child in Neighbors) {
                if(visited.Contains(child.Key)) {
                    if(Debug) System.Console.WriteLine($"    (Id:{Id}) -> ReachableNodes: Already visited {child.Key.Id}");
                    continue;
                }
                visited.Add(child.Key);

                
                
                if(Debug) System.Console.WriteLine($"({Id}) -> Inspect Child (Id:{child.Key.Id},Distance:{child.Value})");
                
                count += child.Key.CountReachableNodes(maxMoves, child.Value, visited);
                if(Debug) System.Console.WriteLine($"({Id}) -> Child (Id:{child.Key.Id},Distance:{child.Value}) count = {count}");
            }
            
            return count; 
        }
    }
}