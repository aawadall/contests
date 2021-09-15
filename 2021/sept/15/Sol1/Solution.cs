using System;
using System.Diagnostics;

namespace Sol1
{
    public class Solution
    {
        public bool EnableDebug { get; set; }
        public int MaxTurbulenceSize(int[] arr) {
            // naive solution
            int max = 0, 
                counter = 0;
            int previousComparison;
            // for each element in the array, compare to next element
            // compare current comparison to previous comparison
            // if current > next, and previous comparison is less than, advance counter by 1 
            // if current < next, and previous comparison is greater than, advance counter by 1
            // else reset counter as follows
            // if current = next, reset counter to 1, else reset to 2
            // before reset, compare max to counter and update if required 

            // special case 
            if (arr.Length == 1) return 1;

            // first comparison 
            counter = 2; // assuming different elements

            if (arr[0] > arr[1]) { 
                previousComparison = 1;
            } else if (arr[0] < arr[1]) {
                previousComparison = -1;
            } else {
                if (EnableDebug) Debug.WriteLine("Special case, equal elements");
                previousComparison = 0;
                counter = 1; // fallback to 1
            }
            
            max = counter;
            // iterate through the array
            for (int i = 1; i < arr.Length - 1; i++) {
                // get current comparison 
                int currentComparison = arr[i] > arr[i + 1] ? 1 : arr[i] < arr[i + 1] ? -1 : 0;
                
                // if current comparison is not 0 and different from previous comparison, increment counter
                if (currentComparison != 0 && currentComparison != previousComparison) {
                    if (EnableDebug) Debug.WriteLine($"Incrementing counter {counter} -> {counter+1}");
                    counter++;
                    previousComparison = currentComparison;
                    max = Math.Max(max, counter);
                } else {
                    // if current comparison is 0, reset counter to 1
                    if (currentComparison == 0) {
                        if(EnableDebug) Console.WriteLine("Resetting counter to 1");
                        max = Math.Max(max, counter);
                        counter = 1;
                    } else {
                        // if current comparison is same as previous comparison, reset counter to 2
                        if (EnableDebug) Console.WriteLine("Resetting counter to 2");
                        previousComparison = currentComparison;
                        max = Math.Max(max, counter);
                        counter = 2;
                    }
                }
            }
            // return max counter 
            return max;
        }  

    }


}