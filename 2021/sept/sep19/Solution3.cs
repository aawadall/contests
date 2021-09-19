using System;
using System.Collections.Generic;
using System.Linq;

namespace sep19
{
    /// <summary>
    /// Solve the problem using a pre-calculated table of indices.
    /// </summary>
    public class Solution3 : ISolution
    {
        public bool EnableDebug { get; set; }
        IDictionary<int, IList<int>> _indices;
        public int NumDistinct(string s, string t)
        {
            // populate the indices
            _indices = FillIndices(s, t);

            // find the number of distinct indices
            return Solve(_indices);
        }

        /// <summary>
        /// Given indices data structure, find permutations of the target string.
        /// </summary>
        /// <param name="indices">dictionary of indices</param>
        /// <param name="indexOffset">where to search from</param>
        /// <param name="index">key to search</param>
        /// <returns></returns>
        private int Solve(IDictionary<int, IList<int>> indices, int indexOffset = 0, int index = 0)
        {
            // base case
            if (index == indices.Count - 1)
            {
                var c = indices[index].Where(i => i >= indexOffset).Count();

                return c;
            }

            // recursive case
            var count = 0;
            foreach (var i in indices[index].Where(i => i >= indexOffset))
            {
                count += Solve(indices, i + 1, index + 1);
            }
            return count;
        }

        /// <summary>
        /// Populate indices dictionary 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private IDictionary<int, IList<int>> FillIndices(string s, string t)
        {
            var indices = new Dictionary<int, IList<int>>();
            // for each character position in t
            for (int i = 0; i < t.Length; i++)
            {
                // build a list of possible incdices for the i-th character of t in string s
                var list = new List<int>();
                for (int index = s.IndexOf(t[i]); index >= 0; index = s.IndexOf(t[i], index + 1))
                {
                    list.Add(index);
                }
                indices.Add(i, list);
            }

            return indices;
        }
    }
}