using System.Collections.Generic;

namespace sep17
{
    public class Solution2 : ISolution
    {
        public bool EnableDebug { get; set; }

        /// <summary>
        /// This solution uses a dictionary to store the count of each character.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            // declare a dictionary mapping largest array to a key of num and value of frequency 
            // iterate over smallest array
            // if key exists in dictionary, add to result array and decrement dictionary value
            // if key does not exist in dictionary, do nothing
            // return result array
            int lookupId = nums1.Length > nums2.Length ? 1 : 2;

            var lookup = lookupId == 1 ? BuildLookup(nums1) : BuildLookup(nums2);
            var smaller = lookupId == 1 ? nums2 : nums1;
            var result = new List<int>();

            if (EnableDebug)
            {
                System.Console.WriteLine("Lookup: ");
                foreach (var kvp in lookup)
                {
                    System.Console.WriteLine($"{kvp.Key} : {kvp.Value}");
                }

                System.Console.WriteLine("Smaller: ");
                foreach (var num in smaller)
                {
                    System.Console.WriteLine($"{num}");
                }
            }
            // iterate over smaller 
            foreach (var num in smaller)
            {
                if (lookup.ContainsKey(num))
                {
                    if (EnableDebug) System.Console.WriteLine($"Found {num}, count is {lookup[num]}");
                    result.Add(num);
                    lookup[num]--;
                    if (lookup[num] == 0) lookup.Remove(num);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Build dictionary of nums and their frequency
        /// </summary>
        /// <param name="nums1"></param>
        /// <returns></returns>
        private Dictionary<int, int> BuildLookup(int[] nums1)
        {
            var lookup = new Dictionary<int, int>();
            foreach (var num in nums1)
            {
                if (lookup.ContainsKey(num))
                {
                    lookup[num]++;
                }
                else
                {
                    lookup.Add(num, 1);
                }
            }
            return lookup;
        }
    }
}