using System.Collections.Generic;
using System.Linq;

namespace sep17
{
    public class Solution1 : ISolution
    {
        public bool EnableDebug { get; set; }

        /// <summary>
        /// Given two integer arrays nums1 and nums2, 
        /// return an array of their intersection. 
        /// Each element in the result must appear 
        /// as many times as it shows in both arrays 
        /// and you may return the result in any order.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            // naive solution
            // using LINQ
            // iterate through smallest array
            // find elements of smallest array in larger array
            // if found:
            // - add to result array
            // - remove from larger array

            var result = new List<int>();
            var arr1Length = nums1.Length;
            var arr2Length = nums2.Length;

            var inp1 = nums1.ToList();
            var inp2 = nums2.ToList();

            if (arr1Length > arr2Length)
            {
                foreach (var num in nums2)
                {
                    if (inp1.Contains(num))
                    {
                        result.Add(num);
                        inp1.Remove(num);
                    }
                }
            }
            else
            {
                foreach (var num in nums1)
                {
                    if (inp2.Contains(num))
                    {
                        result.Add(num);
                        inp2.Remove(num);
                    }
                }
            }
            return result.ToArray();
        }
    }
}