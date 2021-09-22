using System.Collections.Generic;

namespace sep22
{
    public interface ISolution
    {
        /// <summary>
        /// Maximum Length of a Concatenated String with Unique Characters
        /// </summary>
        /// <remarks>
        /// Given an array of strings arr. String s is a concatenation of a sub-sequence of arr which have unique characters.
        /// Return the maximum possible length of s.
        /// </remarks>
        /// <param name="arr"></param>
        /// <returns></returns>
        int MaxLength(IList<string> arr);
    }
}