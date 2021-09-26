using System;
using System.Collections.Generic;

namespace sep25
{
    public class S4 : ISolution
    {
        public int ShortestPath(int[][] grid, int k)
        {
            return ShortestPath(ref grid, k, new int[] { 0, 0 });
        }


        private int ShortestPath(ref int[][] grid, int budget, int[] start, HashSet<string> visited = null, int tripCount = 0)
        {
            // TODO: Consider cache 

            var moveQueue = new Queue<Move>();
            if (visited == null)
                visited = new HashSet<string>();

            if (visited.Contains(start.ToString())) return int.MaxValue;

            visited.Add(start[0] + "," + start[1]); // mark start point visited

            // Find valid moves
            foreach (var move in GetMoves(ref grid, start, budget))
            {
                moveQueue.Enqueue(move);
            }

            while (moveQueue.Count > 0)
            {
                var move = moveQueue.Dequeue();

            }
        }

        private IEnumerable<Move> GetMoves(ref int[][] grid, int[] start, int budget, int cost = 0)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            var moves = new List<Move>();

            // check all 4 directions
            // down if start[0] < m - 1
            if (start[0] < m - 1)
            {
                moves.Add(new Move { Direction = "down", Cost = cost + 1, X = start[1], Y = start[0] + 1, Budget = budget });
            }

            // up if start[0] > 0
            if (start[0] > 0)
            {
                moves.Add(new Move { Direction = "up", Cost = cost + 1, X = start[1], Y = start[0] - 1, Budget = budget });
            }

            // left if start[1] > 0
            if (start[1] > 0)
            {
                moves.Add(new Move { Direction = "left", Cost = cost + 1, X = start[1] - 1, Y = start[0], Budget = budget });
            }

            // right if start[1] < n - 1
            if (start[1] < n - 1)
            {
                moves.Add(new Move { Direction = "right", Cost = cost + 1, X = start[1] + 1, Y = start[0], Budget = budget });
            }
            return moves;
        }
    }

    public class Move
    {
        public string Direction { get; set; }
        public int Cost { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Budget { get; set; }
    }
}