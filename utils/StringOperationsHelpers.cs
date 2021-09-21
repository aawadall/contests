using System.Collections.Generic;

namespace utils
{
    /// <summary>
    /// Common string operations
    /// </summary>
    public static class StringOperationsHelpers
    {
        /// <summary>
        /// Find permutations of a string
        /// using backtracking
        /// </summary>
        /// <remarks>This is O(n!)</remarks>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] Permute(this string str)
        {
            // base case
            if (str.Length == 1)
            {
                return new[] { str };
            }

            var result = new List<string>();
            for (var i = 0; i < str.Length; i++)
            {
                var first = str[i];
                var rest = str.Substring(0, i) + str.Substring(i + 1);
                var subPermutations = rest.Permute();
                foreach (var subPermutation in subPermutations)
                {
                    result.Add(first + subPermutation);
                }
            }

            return result.ToArray();
        }



    }
}