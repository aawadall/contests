using System.Collections.Generic;

namespace Sol1
{
    public class Solution
    {
        public bool Debug { get; set; }
        /// <summary>
        /// Reverse letters in a string and retains order for non-letter characters
        /// </summary>
        /// <param name="s">input string, up to 100 characters, from ASCII 33 to 122</param>
        /// <returns>reversed string</returns>
        public string ReverseOnlyLetters(string s)
        {
            // Naiive solution
            // use a stack to store the letters
            // rescan the string and pop from the stack into letter positions in the string
            // return the string
            var stack = new Stack<char>();

            // Pass 1: push letters into stack
            foreach (var c in s)
            {
                if (char.IsLetter(c)) stack.Push(c);
            }

            // Pass 2: pop letters from stack into string
            var result = "";
            foreach (var c in s)
            {
                if (char.IsLetter(c))
                    result += stack.Pop();
                else result += c;
            }

            return result; // TODO: implement
        }
    }
}