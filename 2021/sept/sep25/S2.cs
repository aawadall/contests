using System;

namespace sep25
{
    public class S2 : ISolution
    {
        // move backwards from destination to source
        // and populate distance array
        public int ShortestPath(int[][] grid, int k)
        {
            var distance = new int[grid.Length, grid[0].Length];
            System.Console.WriteLine($"Grid size = {grid.Length}x{grid[0].Length}");
            ShortestPath(ref grid, ref distance, k);

            PrintDistance(distance);
            return distance[0, 0];
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

        private void ShortestPath(ref int[][] grid, ref int[,] distance, int budget, int[] pos = null)
        {
            if (pos == null)
                pos = new int[] { grid.Length - 1, grid[0].Length - 1 };

            if (pos[0] == grid.Length - 1 && pos[1] == grid[0].Length - 1)
            {
                System.Console.WriteLine($"Starting from destination ({pos[0]},{pos[1]}), moving backward");
                distance[pos[0], pos[1]] = 0;
            }

            if (pos[0] == 0 && pos[1] == 0)
            {
                System.Console.WriteLine("Starting point");
                return;
            }

            System.Console.WriteLine($"Starting from ({pos[0]},{pos[1]}), moving backward");
            // move from destination to source
            //var moves = new string[] { "up", "down", "left", "right" };
            var moves = new string[] { "left", "up" };

            // for each direction:
            foreach (var move in moves)
            {
                System.Console.WriteLine($"({pos[0]},{pos[1]}) -[{move}]->");
                UpdateDistance(ref grid, ref distance, pos, move, budget);
            }
        }

        private void UpdateDistance(ref int[][] grid, ref int[,] distance, int[] pos, string direction, int budget)
        {
            if (budget < 0) return;
            int[] offset = new int[2];
            switch (direction)
            {
                case "left":
                    offset[0] = 0;
                    offset[1] = -1;
                    break;
                case "right":
                    offset[0] = 0;
                    offset[1] = 1;
                    break;
                case "up":
                    offset[0] = -1;
                    offset[1] = 0;
                    break;
                case "down":
                    offset[0] = 1;
                    offset[1] = 0;
                    break;
            }

            // check if valid move
            if (pos[0] + offset[0] < 0 || pos[0] + offset[0] >= grid.Length ||
                pos[1] + offset[1] < 0 || pos[1] + offset[1] >= grid[0].Length)
            {
                System.Console.WriteLine("invalid move");
                return; // invalid move
            }

            System.Console.Write($"({pos[0]},{pos[1]}) -({direction})->");
            pos[0] += offset[0];
            pos[1] += offset[1];

            // check if k is exhausted
            if (grid[pos[0]][pos[1]] > budget)
            {
                System.Console.WriteLine("budget exhausted");
                distance[pos[0], pos[1]] = -1;
                System.Console.WriteLine($"({pos[0]},{pos[1]}) <- -1");

                return;
            }
            else
            {
                System.Console.Write("carry on, ");
            }

            // calculate step size using inverse of move, by adding 1 to previous distance
            int step = distance[pos[0] - offset[0], pos[1] - offset[1]] >= 0 ? distance[pos[0] - offset[0], pos[1] - offset[1]] + 1 : -1;

            System.Console.WriteLine($"({pos[0]},{pos[1]}) Step ={step}, k={budget}, existing={distance[pos[0], pos[1]]}");

            // if step size is smaller than existing distance, update distance
            if (distance[pos[0], pos[1]] <= 0 || (step < distance[pos[0], pos[1]] && step > 0))
            {
                distance[pos[0], pos[1]] = step;
                System.Console.WriteLine($"({pos[0]},{pos[1]}) <- {step}");
            }
            else
            {
                System.Console.WriteLine($"skipped ({pos[0]},{pos[1]}) <- {distance[pos[0], pos[1]]}");
            }
            ShortestPath(ref grid, ref distance, budget - grid[pos[0]][pos[1]], pos);
        }
    }
}