using NUnit.Framework;
using System.Collections.Generic;
using Sol1;
namespace sept_13
{
    public class Tests
    {
        // test data 
        static object[] _testData =  {
            new object[] {"nlaebolko", 1},
            new object[] {"loonbalxballpoon", 2},
            new object[] {"leetcode", 0},
        };

        private Solution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Solution();
            _solution.Debug = true;
        }

        [TestCaseSource(nameof(_testData))]
        [Test]
        public void TestCases(string text, int expected)
        {
            var actual = _solution.MaxNumberOfBalloons(text);
            Assert.AreEqual(expected, actual, $"Expected: {expected}, Actual: {actual}"); 
        }
    }
}