using System;
using System.Collections.Generic;

namespace Sol2
{
    public class Solution
    {
        public Solution()
        {
            System.Console.WriteLine("***************************************************");
            System.Console.WriteLine("*                   Solution 2                    *");
            System.Console.WriteLine("***************************************************");
            System.Console.WriteLine("");
        }
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
            int count =  Root.CountReachableNodes(maxMoves, new HashSet<Node>(), 0);
            return count; 
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
        public int CountReachableNodes(int maxMoves, HashSet<Node> visited, int depth) {
            if(maxMoves == 0) return 0;

            visited.Add(this);
            int count = 0; // add current node to count
            // Graph path 
            for(int idx=0;idx<depth;idx++) System.Console.Write("            ");
            if(depth > 0) System.Console.Write("+-----------");
            Console.WriteLine($"X-->({Id})");
            
            // iterate over children
            if(Debug)System.Console.WriteLine($"({Id}) -> Iterate over {Neighbors.Count} neighbors");
            foreach (var child in Neighbors) {
                if(Debug)System.Console.WriteLine($"({Id}) -> Child({child.Key.Id})");
                
                if(visited.Contains(child.Key)) {
                    System.Console.WriteLine($"    (Id:{Id}) -> ReachableNodes: Already visited {child.Key.Id}");
                    visited.Remove(child.Key);
                    continue;
                }
                
                visited.Add(child.Key);             
                if(child.Value > maxMoves) {
                    count += maxMoves;
                    
                } else {
                
                    if(Debug) System.Console.WriteLine($"({Id}) -> Inspect Child (Id:{child.Key.Id},Distance:{child.Value})");
                    
                    count +=  1+child.Key.CountReachableNodes(maxMoves - child.Value,  visited, depth + 1) ;
                    if(Debug) System.Console.WriteLine($"({Id}) -> Child (Id:{child.Key.Id},Distance:{child.Value}) count = {count}");
                }
                
            }
            visited.Remove(this);
            // DEBUG
            for(int idx=0;idx<depth+2;idx++) System.Console.Write("            ");
            System.Console.WriteLine($"==> [{count}]");
            
            count++; // add current node to count
            return  count ; 
        }
    }
}