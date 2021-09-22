using System.Collections.Generic;
using System.Linq;

namespace sep22
{
    // failed
    public class Solution1 : ISolution
    {
        public int MaxLength(IList<string> arr)
        {
            var characterSets = new List<int>();

            foreach (var str in arr)
            {
                var subSeq = new HashSet<char>(str.ToCharArray()).Count;
                characterSets.Add(subSeq);

            }
            return characterSets.OrderByDescending(x => x).Take(2).Sum();
        }
    }
}