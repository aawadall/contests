namespace sep25
{
    public interface ISolution
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
        int ShortestPath(int[][] grid, int k);
    }
}