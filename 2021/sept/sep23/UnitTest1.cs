using System;
using NUnit.Framework;

namespace sep23
{
    public class Tests
    {
        private ISolution _solution;
        private int _timeout = 10;

        #region test cases
        private static readonly object[] _examples = new object[]
        {
            new object[] {"abccba", "aaccba"},
            new object[] {"a", ""},
            new object[] {"aa", "ab"},
            new object[] {"aba", "abb"},
        };
        #endregion
        [SetUp]
        public void Setup()
        {
            _solution = new Sol1();
        }

        [Test]
        [TestCaseSource("_examples")]
        public void TestExamples(string input, string expected)
        {
            var result = profile(() => _solution.BreakPalindrome(input));
            Assert.AreEqual(expected, result);
        }

        private T profile<T>(Func<T> testedMethod)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            var result = testedMethod();
            stopWatch.Stop();
            Assert.Less(stopWatch.ElapsedMilliseconds, _timeout);
            return result;
        }
    }
}