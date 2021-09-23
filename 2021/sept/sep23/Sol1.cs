using System;

namespace sep23
{
    public class Sol1 : ISolution
    {
        public string BreakPalindrome(string palindrome)
        {
            // approach:
            // assuming input strings are already plindrome, there are 5 possible cases:
            // 1. 1 character string -> return empty string
            // 2. string 'aa' -> return 'ab'
            // 3. double character string that is not 'aa' -> replace the first character with 'a'
            // 4. more than 2 characters not starting with 'a' -> replace first character with 'a'
            // 5. more than 2 characters starting with 'a' -> find inner solution or replace last character with 'b'

            if (palindrome.Length == 1) return ""; // 1
            if (palindrome.Length == 2 && palindrome[0] == 'a') return "ab"; // 2
            if (palindrome.Length == 2) return "a" + palindrome[1]; // 3
            if (palindrome.Length > 2 && palindrome[0] != 'a') return "a" + palindrome.Substring(1); // 4
            return FindInnerSolution(palindrome); // 5

        }

        private string FindInnerSolution(string palindrome)
        {
            // approach; peal off characters from outside, until not 'a'
            for (int i = 0; i < palindrome.Length / 2; i++)
            {
                if (palindrome[i] != 'a') return palindrome.Substring(0, i) + "a" + palindrome.Substring(i + 1);
            }
            return palindrome.Substring(0, palindrome.Length - 1) + "b";
        }
    }
}