using System;
using NUnit.Framework;

namespace sep27
{
    public class Tests
    {
        private ISolution _solution;
        private int _timeout = 10;

        #region Test Cases
        private static object[] _examples = new object[] {
            new object[] {
                new string[] {"test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"},
                2},
            new object[] {
                new string[] {"a@leetcode.com","b@leetcode.com","c@leetcode.com"},
                3},
        };
        #endregion
        [SetUp]
        public void Setup()
        {
            _solution = new S1();
        }

        [Test]
        [TestCaseSource("_examples")]
        public void Test1(string[] emails, int expected)
        {
            var result = profile(() => _solution.NumUniqueEmails(emails));
            Assert.AreEqual(expected, result);
        }

        private T profile<T>(Func<T> func)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var result = func();
            sw.Stop();
            Assert.LessOrEqual(sw.ElapsedMilliseconds, _timeout);
            return result;
        }
    }
}