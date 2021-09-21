namespace sep21
{
    internal class Solution1 : ISolution
    {
        /// <summary>
        /// Given a binary array nums, return the maximum number of consecutive 1's in the array.
        /// <remarks>
        /// Bruteforce solution O(n)
        /// </remarks>
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                    max = max < count ? count : max;
                }
                else
                {
                    count = 0;
                }
            }
            return max;
        }
    }
}