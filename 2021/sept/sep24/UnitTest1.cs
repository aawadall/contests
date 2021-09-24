using System;
using NUnit.Framework;

namespace sep24
{
    public class Tests
    {
        private ISolution _solution;
        private int _timeout = 10;

        #region test cases
        private static object[] _examples = new object[]
        {
            new object[] {4, 4},
            new object[] {25, 1389537},
        };

        #endregion
        [SetUp]
        public void Setup()
        {
            _solution = new S1();
        }

        [Test]
        [TestCaseSource("_examples")]
        public void Test1(int n, int expected)
        {
            var actual = profile(() => _solution.Tribonacci(n));
            Assert.AreEqual(expected, actual);
        }

        private T profile<T>(Func<T> func)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            var result = func();
            stopwatch.Stop();
            Assert.Less(stopwatch.ElapsedMilliseconds, _timeout);
            return result;
        }
    }
}