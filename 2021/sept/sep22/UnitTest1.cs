using System;
using NUnit.Framework;

namespace sep22
{
    public class Tests
    {
        private ISolution _sln;
        private const int _timeout = 10; // ms 

        #region Test Cases
        /* 
        Example 1:

        Input: arr = ["un","iq","ue"]
        Output: 4
        Explanation: All possible concatenations are "","un","iq","ue","uniq" and "ique".
        Maximum length is 4.
        Example 2:

        Input: arr = ["cha","r","act","ers"]
        Output: 6
        Explanation: Possible solutions are "chaers" and "acters".
        Example 3:

        Input: arr = ["abcdefghijklmnopqrstuvwxyz"]
        Output: 26
        */

        private static object[] _examples = new object[]
        {
            new object[] { new string[] { "un", "iq", "ue" }, 4 },
            new object[] { new string[] { "cha", "r", "act", "ers" }, 6 },
            new object[] { new string[] { "abcdefghijklmnopqrstuvwxyz" }, 26 },
        };

        /* Test Cases
        Test Case 10
        Input: ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p"]
        Expected: 16
        */
        private static object[] _testCases = new object[]
        {
            new object[] { new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" }, 16 },
        };

        #endregion
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource(nameof(_examples))]
        public void Examples(string[] arr, int expected)
        {
            var sol = new Solution2();

            var actual = profile<int>(() => sol.MaxLength(arr));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(nameof(_testCases))]
        public void TestCases(string[] arr, int expected)
        {
            var sol = new Solution2();

            var actual = profile<int>(() => sol.MaxLength(arr));

            Assert.AreEqual(expected, actual);
        }

        private T profile<T>(Func<T> p)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var result = p();
            sw.Stop();
            Assert.LessOrEqual(sw.ElapsedMilliseconds, _timeout);
            return result;
        }
    }
}