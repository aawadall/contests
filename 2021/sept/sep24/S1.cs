using System;
using System.Collections.Generic;

namespace sep24
{
    public class S1 : ISolution
    {
        public int Tribonacci(int n)
        {
            var cache = new Dictionary<int, int>{
                {0, 0},
                {1, 1},
                {2, 1},
            };
            return Tribonacci(n, ref cache);
        }

        private int Tribonacci(int n, ref Dictionary<int, int> cache)
        {
            if (cache.ContainsKey(n)) return cache[n];
            var result = 0;
            for (int idx = 1; idx <= 3; idx++)
                result += Tribonacci(n - idx, ref cache);
            cache[n] = result;
            return result;
        }
    }
}