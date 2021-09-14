using System.Collections.Generic;
using System.Linq;
namespace Sol2
{
    // second attempt 
    public class Solution
    {
        // balloon character frequency 
        private static IDictionary<char, int> _characterFrequency = new Dictionary<char, int> {
            {'b', 1},
            {'a', 1},
            {'l', 2},
            {'o', 2},
            {'n', 1},
        };

        public bool Debug { get; set; }

        public int MaxNumberOfBalloons(string text) {
            var charCount = new List<int>();
            foreach( char ch in _characterFrequency.Keys ) {
                charCount.Add( text.Count( c => c == ch ) / _characterFrequency[ch] );
            }
            return charCount.Min();
        }
    }
}