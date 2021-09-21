using System;
using NUnit.Framework;

namespace sep21
{
    public class Tests
    {
        private ISolution _sln;
        private const int _timeout = 10; // ms 

        #region Test Cases
        /*
        Test Cases are in the format:
           - testName: string
           - nums: int[]
           - expected: int

           Example 1:
           
           Input: nums = [1,1,0,1,1,1]
           Output: 3
           Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
           
           Example 2:

           Input: nums = [1,0,1,1,0,1]
           Output: 2
        */
        private static object[] _examples =
        new object[] {
            new object[] {
                "Example 1",
                new int[] { 1, 1, 0, 1, 1, 1 },
                3
            },
            new object[] {
                "Example 2",
                new int[] { 1, 0, 1, 1, 0, 1 },
                2
            }
        };

        private static object[] _testCases =
        new object[] {
        };

        #endregion
        [SetUp]
        public void Setup()
        {
            // Assign solution to an implementation
            _sln = new Solution1();
        }

        [Test]
        [TestCaseSource(nameof(_examples))]
        public void TestExamples(string testName, int[] nums, int expected)
        {
            int result = profile(() => _sln.FindMaxConsecutiveOnes(nums));

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCaseSource(nameof(_testCases))]
        public void TestTestCases(string testName, int[] nums, int expected)
        {
            int result = profile(() => _sln.FindMaxConsecutiveOnes(nums));

            Assert.AreEqual(expected, result);
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