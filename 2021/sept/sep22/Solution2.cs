using System.Collections.Generic;
using System.Linq;

namespace sep22
{
    public class Solution2 : ISolution
    {
        public int MaxLength(IList<string> arr)
        {
            // approach:
            // using back tracking
            // take 1 string, and check if it can be concatenated with other strings with no duplicates
            // take length of this string 
            // each concatination should exhaust the pool of strings 

            // sort all strings alphabetically
            //IList<string> sorted = arr.OrderBy(x => x).ToList();

            var possibleStrings = GetPossibleStrings(arr);
            foreach (var str in possibleStrings)
            {
                System.Console.WriteLine(str);
            }
            return possibleStrings.OrderByDescending(x => x.Length).First().Length;
        }


        private IList<string> GetPossibleStrings(IList<string> arr)
        {
            var result = new List<string>();
            var pool = new List<string>(arr);

            foreach (var str in pool)
            {
                pool.Remove(str);
                while (pool.Count > 0)
                {
                    var candidate = pool[0];
                    pool.Remove(candidate);
                    if (CanBeConcatenated(str, candidate))
                    {
                        result.Add(str + candidate);
                    }
                }

            }

            return result;
        }

        private bool CanBeConcatenated(string currentString, string v)
        {
            var smallString = currentString.Length < v.Length ? currentString : v;
            var bigString = currentString.Length < v.Length ? v : currentString;
            System.Console.WriteLine($"{smallString},  {bigString}");
            foreach (var c in smallString)
            {
                if (bigString.Contains(c)) return false;
            }

            return true;
        }
    }
}