using System;
using System.Diagnostics;

namespace Sol1
{
    public class Solution
    {
        public bool EnableDebug { get; set; }
        public int MaxTurbulenceSize(int[] arr) {
            // naive solution
            int max = 1;
            int counter = 1;
            var diff = new int[arr.Length -1];
            if (EnableDebug) Debug.WriteLine($"array length={arr.Length}");
            // special case, single element
            if (arr.Length == 1) return 1;

            // iterate through the array and ensure comparison is alternating, otherwise reset max
            for (int i = 0; i < arr.Length - 1; i++)
            {
                diff[i ] = (arr[i] > arr[i + 1]) ? 1 :
                              (arr[i] < arr[i + 1]) ? -1 : 0;
                if (EnableDebug) Debug.WriteLine($"idx:[{i}],\tarr[{i}] = {arr[i]},\tarr[{i+1}]={arr[i+1]},\tdiff={diff[i]}");
            
            }

            // iterate through diff and find max
            for (int i = 1; i < diff.Length; i++)
            {
                if (diff[i] != diff[i - 1] && diff[i] != 0) {
                    counter++;
                    max = Math.Max(max, counter );
                } else
                {
                    counter = diff[i] == 0 ? 1 : 2;
                }
            }
            max = Math.Max(max, counter);
            return max;
        }    
    }
}