

namespace _985_sum_of_even_numbers_after_queries
{
    public class Solution1 : ISolution
    {
        public bool EnableDebug { get; set; }

        /// <summary>
        /// 
        /// <remarks>
        /// You are given an integer array nums and an array queries where queries[i] = [vali, indexi].
        /// For each query i, first, apply nums[indexi] = nums[indexi] + vali, then print the sum of the even values of nums.
        /// Return an integer array answer where answer[i] is the answer to the ith query.
        /// </remarks>
        /// </summary>
        /// <param name="nums">one diemnsional array of numbers to manipulate</param>
        /// <param name="queries">2 dimensional array of operation, index pairs</param>
        /// <returns>results from each query</returns>
        public int[] SumEvenAfterQueries(int[] nums, int[][] queries)
        {
            var evenCache = new int[nums.Length];
            // populate once 
            for (var i = 0; i < nums.Length; i++)
            {
                evenCache[i] = nums[i] % 2 == 0 ? nums[i] : 0;
            }

            var result = new int[queries.Length];

            // iterate over queries 
            for (int idx = 0; idx < queries.Length; idx++)
            {
                SumEvenAfterQuery(ref nums, ref evenCache, queries[idx][0], queries[idx][1], out result[idx]);
            }

            return result;
        }

        /// <summary>
        /// increment the number at the index by the value and return the sum of even numbers
        /// </summary>
        /// <param name="nums">reference to numbers to manipulate</param>
        /// <param name="increment">value to increment by</param>
        /// <param name="index">location where to increment</param>
        /// <returns>result of operation</returns>
        private void SumEvenAfterQuery(ref int[] nums, ref int[] evenCache, int increment, int index, out int sumEven)
        {
            nums[index] += increment;

            evenCache[index] = nums[index] % 2 == 0 ? nums[index] : 0;

            sumEven = 0;
            for (var i = 0; i < evenCache.Length; i++)
                sumEven += evenCache[i];


        }
    }
}