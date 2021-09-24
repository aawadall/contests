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
            var result = Tribonacci(n - 1, ref cache) + Tribonacci(n - 2, ref cache) + Tribonacci(n - 3, ref cache);
            cache[n] = result;
            return result;
        }
    }
}