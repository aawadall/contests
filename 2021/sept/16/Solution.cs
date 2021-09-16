using System.Collections.Generic;
using System.Diagnostics;

namespace _16
{
    public class Solution
    {
        public bool EnableDebug { get; set; }
        /// <summary>
        /// flatten a matrix into a single list spirally exracted from the matrix
        /// </summary>
        /// <param name="matrix">m x n matrix of integers</param>
        /// <returns>a single list of integers representing the spiral order of the matrix</returns>
        /// <remarks>Given an m x n matrix, return all elements of the matrix in spiral order.</remarks>
        public IList<int> SpiralOrder(int[][] matrix)
        {
            // Approach
            // 1. handle special cases
            //   1.1. if matrix is empty, return empty list
            //   1.2. if matrix is 1x1, return the element
            // 2. create a list to store the spiral order
            // 3. maintain direction of spiral (right, down, left, up)
            // 4. maintain boundaries of spiral (top, bottom, left, right) initialized to 0, 0, m-1, n-1
            // 5. loop until size of spiral is m x n
            //    alternate between right, down, left, up

            // 1. handle special cases
            if (matrix.Length == 0)
            {
                if (EnableDebug) Debug.WriteLine("matrix is empty");
                return new List<int>();
            }

            if (matrix.Length * matrix[0].Length == 1)
            {
                if (EnableDebug) Debug.WriteLine("matrix is 1x1");
                return new List<int> { matrix[0][0] };
            }

            // 2. create a list to store the spiral order
            IList<int> result = new List<int>();

            // 3. maintain direction of spiral (right, down, left, up)
            int direction = 0; // 0: right, 1: down, 2: left, 3: up

            // 4. maintain boundaries of spiral (top, bottom, left, right) initialized to 0, 0, m-1, n-1
            int top = 0, bottom = matrix.Length - 1;
            int left = 0, right = matrix[0].Length - 1;
            if (EnableDebug) Debug.WriteLine($"Input matrix is {matrix.Length} x {matrix[0].Length}");
            // 5. loop until size of spiral is m x n
            int targetSize = matrix.Length * matrix[0].Length;
            while (result.Count < targetSize)
            {
                if (EnableDebug) Debug.WriteLine("SpiralOrder: top={0}, bottom={1}, left={2}, right={3}, direction={4}", top, bottom, left, right, direction);
                switch (direction)
                {
                    case 0: // right
                        for (int idx = left; idx <= right; idx++)
                        {
                            result.Add(matrix[top][idx]);
                        }
                        top++;
                        direction = 1;
                        break;
                    case 1: // down
                        for (int idx = top; idx <= bottom; idx++)
                        {
                            result.Add(matrix[idx][right]);
                        }
                        right--;
                        direction = 2;
                        break;
                    case 2: // left
                        for (int idx = right; idx >= left; idx--)
                        {
                            result.Add(matrix[bottom][idx]);
                        }
                        bottom--;
                        direction = 3;
                        break;
                    case 3: // up
                        for (int idx = bottom; idx >= top; idx--)
                        {
                            result.Add(matrix[idx][left]);
                        }
                        left++;
                        direction = 0;
                        break;
                }
            }

            // return result
            return result;
        }
    }
}