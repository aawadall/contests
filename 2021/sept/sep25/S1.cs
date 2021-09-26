using System;
using System.Collections.Generic;
using System.Linq;

namespace sep25
{
    public class S1 : ISolution
    {
        /// <summary>
        /// Shortest Path in a Grid with Obstacles Elimination
        /// </summary>
        /// <remarks>
        /// You are given an m x n integer matrix grid 
        /// where each cell is either 0 (empty) or 1 (obstacle). 
        /// You can move up, down, left, or right from and to an empty cell in one step.
        /// 
        /// Return the minimum number of steps 
        /// to walk from the upper left corner (0, 0) 
        /// to the lower right corner (m - 1, n - 1) 
        /// given that you can eliminate at most k obstacles. 
        /// If it is not possible to find such walk return -1.
        /// <h3>Constraints</h3>
        /// <ul>
        /// <li>m == grid.length</li>
        /// <li>n == grid[i].length</li>
        /// <li>1 <= m, n <= 40</li>
        /// <li>1 <= k <= m * n</li>
        /// <li>grid[i][j] == 0 or 1</li>
        /// <li>grid[0][0] == grid[m - 1][n - 1] == 0</li>
        /// </ul>
        /// </remarks>
        /// <param name="grid">grid layout</param>
        /// <param name="k">number of obstacles that can be eliminated</param>
        /// <returns>Minimum number of steps to traverse from corner to corner, -1 if no solution</returns>
        public int ShortestPath(int[][] grid, int k)
        {

            // Strategy: Will use branch and bound to find the shortest path.
            // Collect some information about the grid
            int m = grid.Length;
            int n = grid[0].Length;

            int[] currentPosition = new int[] { 0, 0 };
            int[] destination = new int[] { m - 1, n - 1 };
            System.Console.WriteLine($"Grid: {m}x{n}");
            return ShortestPath(ref grid, k, currentPosition, destination);
        }

        /// <summary>
        /// Find shortest path recursively
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <param name="currentPosition"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private int ShortestPath(ref int[][] grid, int k, int[] currentPosition, int[] destination, Dictionary<string, int> cache = null)
        {
            System.Console.Write($"evl: ({currentPosition[0]},{currentPosition[1]}) -> ");

            if (cache == null)
            {
                cache = new Dictionary<string, int>();
            }

            // check if we already visited this node
            string key = string.Join(",", currentPosition);
            if (cache.ContainsKey(key))
            {
                System.Console.WriteLine($"already visited at ({currentPosition[0]},{currentPosition[1]})");
                return cache[key];
            }

            // check if obstacle clearing budget is exhausted
            if (k < 0)
            {
                System.Console.WriteLine($"exhausted budget at ({currentPosition[0]},{currentPosition[1]})");
                // cache.Add($"{currentPosition[0]},{currentPosition[1]}", -1);
                return -1;
            }

            // Check if we are at the destination
            if (currentPosition[0] == destination[0] && currentPosition[1] == destination[1])
            {
                System.Console.WriteLine($"found destination at ({currentPosition[0]},{currentPosition[1]})");
                cache.Add($"{currentPosition[0]},{currentPosition[1]}", 0);
                return 0;
            }



            var candidateSolutions = new List<int>();

            // cheack clearest path 
            int penality;
            int trip = 0;
            // right 
            // check bounds
            if (currentPosition[1] + 1 < grid[0].Length)
            {
                penality = grid[currentPosition[0]][currentPosition[1] + 1];
                trip = ShortestPath(ref grid, k - penality, new int[] { currentPosition[0], currentPosition[1] + 1 }, destination, cache);
                trip = trip >= 0 ? trip + 1 : trip;
                candidateSolutions.Add(trip);
            }
            else Console.WriteLine($"out of bounds ({currentPosition[0]},{currentPosition[1]}) -> ({currentPosition[0]},{currentPosition[1] + 1})");
            // down 
            // check bounds
            if (currentPosition[0] + 1 < grid.Length)
            {
                penality = grid[currentPosition[0] + 1][currentPosition[1]];
                trip = ShortestPath(ref grid, k - penality, new int[] { currentPosition[0] + 1, currentPosition[1] }, destination, cache);
                trip = trip >= 0 ? trip + 1 : trip;
                candidateSolutions.Add(trip);
            }
            else Console.WriteLine($"out of bounds ({currentPosition[0]},{currentPosition[1]}) -> ({currentPosition[0] + 1},{currentPosition[1]})");

            // left
            // check bounds
            if (currentPosition[1] - 1 >= 0)
            {
                penality = grid[currentPosition[0]][currentPosition[1] - 1];
                trip = ShortestPath(ref grid, k - penality, new int[] { currentPosition[0], currentPosition[1] - 1 }, destination, cache);
                trip = trip >= 0 ? trip + 1 : trip;
                candidateSolutions.Add(trip);
            }
            else Console.WriteLine($"out of bounds ({currentPosition[0]},{currentPosition[1]}) -> ({currentPosition[0]},{currentPosition[1] - 1})");

            // up
            // check bounds
            if (currentPosition[0] - 1 >= 0)
            {
                penality = grid[currentPosition[0] - 1][currentPosition[1]];
                trip = ShortestPath(ref grid, k - penality, new int[] { currentPosition[0] - 1, currentPosition[1] }, destination, cache);
                trip = trip >= 0 ? trip + 1 : trip;
                candidateSolutions.Add(trip);
            }
            else Console.WriteLine($"out of bounds ({currentPosition[0]},{currentPosition[1]}) -> ({currentPosition[0] - 1},{currentPosition[1]})");

            if (candidateSolutions.Where(c => c > 0).Count() == 0)
            {
                cache.Add(key, -1);
                return -1;
            }

            cache.Add(key, candidateSolutions.Where(c => c > 0).Min());
            return candidateSolutions.Where(c => c > 0).Min();
        }
    }
}