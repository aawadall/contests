using System;
using System.Collections.Generic;

namespace sep19
{
    public class Solution2 : ISolution
    {
        public bool EnableDebug { get; set; }

        public int NumDistinct(string s, string t)
        {
            // Solution 2
            // do while length of t is > 0
            //   if s is empty, return 0
            //   if length t == 1 and t == s, return 1
            //   if length t == 1 and t != s, return 0
            //   for all indexes <- find(t[0], in s)
            //     if index == -1, return 0
            //     advance count by recursive call
            if (EnableDebug) Console.WriteLine("s: {0}, t: {1}", s, t);
            return innerNumDistinct(s, t);

        }

        private int innerNumDistinct(string s, string t)
        {
            if (EnableDebug) Console.WriteLine($"inner NumDistinct({s}, {t})");
            // base cases
            var m = s.Length;
            var n = t.Length;

            if (n > m) return 0;

            if (n == 0)
            {
                if (EnableDebug) Console.WriteLine("+1 !");
                return 1;
            }

            if (m == 0) return 0;

            if (n == 1 && m == 1)
            {
                if (t[0] == s[0])
                {
                    if (EnableDebug) Console.WriteLine("+1 !!");
                    return 1;
                }
                return 0;
            }


            // recursive case
            var count = 0;

            for (int index = s.IndexOf(t[0]); index > -1; index = s.IndexOf(t[0], index + 1))
            {
                if (EnableDebug) Console.WriteLine($"\tindex: {index}, s: {s.Substring(index)} <- t: {t}");
                count += innerNumDistinct(s.Substring(index + 1), t.Substring(1));
                if (EnableDebug) Console.WriteLine($"\tcount: {count}");
            }
            return count;
        }


    }
}