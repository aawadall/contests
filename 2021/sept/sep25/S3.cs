using System;

namespace sep25
{
    public class S3 : ISolution
    {
        // iterative solution scanning from right to left, down to up 
        public int ShortestPath(int[][] grid, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            var distances = new int[m, n];
            var budget = new int[m, n];


            // move from bottom right to top left 
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    // if at bottom right, then distance is 0, and full budget
                    if (i == m - 1 && j == n - 1)
                    {
                        distances[i, j] = 0;
                        budget[i, j] = k;
                    }
                    // else find the minimum distance to the right and down
                    else
                    {

                        // if there is an obstacle, reduce budget by 1
                        int budgetPenalty = grid[i][j];
                        // update both distance and budget from right and down if possible 
                        if (i + 1 < m && j + 1 < n)
                        {
                            if (distances[i + 1, j] < 0)
                            {
                                distances[i, j] = distances[i, j + 1] + 1;
                                budget[i, j] = budget[i, j + 1] - budgetPenalty;
                            }
                            else if (distances[i, j + 1] < 0)
                            {
                                distances[i, j] = distances[i + 1, j] + 1;
                                budget[i, j] = budget[i + 1, j] - budgetPenalty;
                            }
                            else
                            {
                                distances[i, j] = Math.Min(distances[i + 1, j], distances[i, j + 1]) + 1;
                                budget[i, j] = Math.Max(budget[i + 1, j], budget[i, j + 1]) - budgetPenalty;
                            }

                        }
                        else if (i + 1 < m)
                        {
                            distances[i, j] = distances[i + 1, j] + 1;
                            budget[i, j] = budget[i + 1, j] - budgetPenalty;
                        }
                        else if (j + 1 < n)
                        {

                            distances[i, j] = distances[i, j + 1] + 1;
                            budget[i, j] = budget[i, j + 1] - budgetPenalty;
                        }



                        if (budget[i, j] < 0) { distances[i, j] = -1; }
                    }
                }
            }

            return distances[0, 0];
        }
        private void PrintDistance(int[,] distance)
        {
            for (int i = 0; i < distance.GetLength(0); i++)
            {
                for (int j = 0; j < distance.GetLength(1); j++)
                {
                    System.Console.Write($"\t{distance[i, j]} ");
                }
                System.Console.WriteLine();
            }
        }

    }
}