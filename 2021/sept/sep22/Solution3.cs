using System.Collections.Generic;

namespace sep22
{
    public class Solution3 : ISolution
    {
        /// <summary>
        /// Find maximum length of subarray concatination leading to no repeating characters
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxLength(IList<string> arr)
        {
            // constraints:
            // 1 <= arr.length <= 16
            // 1 <= arr[i].length <= 26
            // arr[i] contains only lower case English letters.
            // i.e. max target length is 26 
            // we need to find a way to find strings that are disjoint

            // define upper bound for the length of the longest substring
            // and piggy back to attempt a single string of all characters

            var set = new HashSet<char>();

            var pool = new List<string>();
            foreach (var str in arr)
            {
                if (IsAllUnique(str)) pool.Add(str);
            }
            // attempt to stitch sequence of all strings 
            string allChars = "";
            foreach (var str in pool)
            {
                if (IsDisjoint(str, allChars)) allChars += str;
                foreach (var ch in str) set.Add(ch);
            }
            var upperBound = set.Count;
            if (allChars.Length == upperBound) return upperBound;

            return MaxLength("", pool, upperBound);

        }

        private int MaxLength(string str, IList<string> arr, int upperBound, Dictionary<Dictionary<string, HashSet<string>>, int> cache = null)
        {
            if (str.Length == upperBound) return upperBound;
            if (arr.Count == 0) return str.Length;


            if (cache == null) cache = new Dictionary<Dictionary<string, HashSet<string>>, int>();
            if (cache.ContainsKey(new Dictionary<string, HashSet<string>>() { { str, new HashSet<string>() } })) return cache[new Dictionary<string, HashSet<string>>() { { str, new HashSet<string>() } }];

            int max = str.Length;


            Dictionary<HashSet<string>, bool> disjointCache = new Dictionary<HashSet<string>, bool>();
            foreach (var s in arr)
            {
                if (IsDisjoint(str, s, disjointCache))
                {
                    var newArr = new List<string>(arr);
                    newArr.Remove(s);
                    var newStr = str + s;
                    System.Console.WriteLine(newStr);

                    // one level deeper
                    var newMax = MaxLength(newStr, newArr, upperBound, cache);

                    // update max
                    if (newMax > max) max = newMax;
                }
            }

            cache.Add(new Dictionary<string, HashSet<string>>() { { str, new HashSet<string>() } }, max);
            return max;
        }

        private bool IsDisjoint(string s1, string s2, Dictionary<HashSet<string>, bool> cache = null)
        {
            if (cache == null) cache = new Dictionary<HashSet<string>, bool>();

            if (cache.ContainsKey(new HashSet<string>() { s1, s2 })) return cache[new HashSet<string>() { s1, s2 }];

            var smallString = s1.Length < s2.Length ? s1 : s2;
            var largeString = s1.Length < s2.Length ? s2 : s1;

            foreach (var c in smallString)
            {
                if (largeString.Contains(c))
                {
                    cache.Add(new HashSet<string>() { s1, s2 }, false);
                    return false;
                }
            }
            cache.Add(new HashSet<string>() { s1, s2 }, true);
            return true;

        }

        private bool IsAllUnique(string str)
        {
            var set = new HashSet<char>(str.ToCharArray());
            return set.Count == str.Length;
        }
    }
}