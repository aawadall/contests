namespace Sol1
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];

            // naive solution O(n^2)
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (i != j && nums[i] + nums[j] == target)
                        return new int[] { i, j };
                }
            }

            // fallback return empty array
            return result;

        }
    }
}