using System;

namespace _167_two_sum_2_input_array_sorted
{
    public class Solution
    {

        public bool Debug { get; set; }
        /// <summary>
        /// Two Sum II - Input array is sorted
        /// </summary>
        /// <param name="numbers">sorted array of numbers</param>
        /// <param name="target">target number to calculate</param>
        /// <returns>1 indexed array of solution indices</returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            // naive solution
            // 1. scan array of numbers
            // 2. binary search for complement
            // 3. return indices + 1
            // O(n log n)
            for (int i = 0; i < numbers.Length; i++)
            {
                int complement = target - numbers[i];
                int j = BinarySearch(numbers, complement);
                if (j != -1 && j != i)
                {
                    if (i < j)
                        return new int[] { i + 1, j + 1 };
                    return new int[] { j + 1, i + 1 };
                }
            }

            // fallback
            return new int[] { -1, -1 };
        }

        private int BinarySearch(int[] numbers, int target)
        {
            int idx = numbers.Length / 2;
            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)

            {
                if (numbers[idx] == target) return idx;
                if (numbers[idx] > target) right = idx - 1;
                else left = idx + 1;
                idx = (left + right) / 2;
            }

            return -1;
        }
    }
}