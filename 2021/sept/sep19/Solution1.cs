using System;
namespace sep19
{
    public class Solution1 : ISolution
    {
        public bool EnableDebug { get; set; }
        public int NumDistinct(string s, string t)
        {
            // discussion:
            // total number of characters to be deleted from s is length of s minus length of t
            // that means:
            // if len(s) == len(t) and s != t, then there is no solution 
            // if len(s) < len(t), then there is no solution
            // if len(s) > len(t), then there can be multiple solutions equal to diff between len(s) and len(t)
            // Constraints:
            // 1 <= s.length, t.length <= 1000
            // s and t consist of English letters.


            #region Solution 
            var deltaLen = s.Length - t.Length;
            int count = 0;
            // special cases
            if (deltaLen < 0) return 0;
            if (deltaLen == 0 && s != t) return 0;
            if (deltaLen == 0 && s == t) return 1;

            // remaining cases will require searching for best fit 
            // we need to delete characters in a systematic way
            // how to calcualate possible configurations of deletion?
            // # config = Sum_{i=0}^{len(s)-len(t)} (len(s)-i) -> O(n)
            // deleting is invarient to the order of deletion
            // i.e last configuration to delete a character will be len(s) - deltaLen - 1

            count = CountConfigurations(s, t, 0, deltaLen);

            #endregion
            return count; // TODO: Implement
        }

        private int CountConfigurations(string stringToCompare, string referenceString, int notBefore, int deltaLen)
        {
            if (EnableDebug) System.Console.WriteLine($"cfg: s:{stringToCompare},\tt:{referenceString},\tdelta:{deltaLen}");

            // base case
            if (deltaLen == 0 && stringToCompare == referenceString)
            {
                if (EnableDebug) System.Console.WriteLine($"\t\t* delta:{deltaLen}");
                return 1;
            }
            if (deltaLen == 0 && stringToCompare != referenceString)
            {
                // if (EnableDebug) Console.WriteLine("No match at {0}", firstChar);
                return 0;
            }

            // recursive case
            int count = 0;
            for (int index = notBefore; index < stringToCompare.Length - deltaLen + 1; index++)
            {
                if (EnableDebug) System.Console.WriteLine($"\tindex: {index}");
                count += CountConfigurations(stringToCompare: RemoveChar(stringToCompare, index),
                                             referenceString,
                                             notBefore: index,
                                             deltaLen: deltaLen - 1);
            }
            return count;
        }

        /// <summary>
        /// Removes character at index i from string s
        /// </summary>
        /// <param name="s"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string RemoveChar(string s, int index) => s.Substring(0, index) + s.Substring(index + 1);
    }
}