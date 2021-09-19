namespace sep19
{
    public interface ISolution
    {
        bool EnableDebug { get; set; }
        /// <summary>
        /// Given two strings s and t, return the number of distinct subsequences of s which equals t.
        /// A string's subsequence is a new string formed from the original string 
        /// by deleting some (can be none) of the characters without disturbing the remaining characters' 
        /// relative positions. (i.e., "ACE" is a subsequence of "ABCDE" while "AEC" is not).
        /// It is guaranteed the answer fits on a 32-bit signed integer.
        /// </summary>
        /// <example>
        /// Input: s = "rabbbit", t = "rabbit"
        /// Output: 3
        /// Explanation:
        /// As shown below, there are 3 ways you can generate "rabbit" from S.
        /// [rabb]b[it]
        /// [ra]b[bbit]
        /// [rab]b[bit]
        /// </example>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        int NumDistinct(string s, string t);
    }
}