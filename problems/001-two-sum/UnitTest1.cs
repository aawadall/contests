using NUnit.Framework;
using Sol1;
namespace _001_two_sum
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            solution = new Solution();
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void Test1(string testCaseName, int[] nums, int target, int[] expected)
        {
            // measure time 
            var sw = new System.Diagnostics.Stopwatch();
            var actual = solution.TwoSum(nums, target);
            var elapsedMs = sw.ElapsedMilliseconds;
            Assert.AreEqual(expected[0], actual[0], testCaseName);
            Assert.AreEqual(expected[1], actual[1], testCaseName);
            Assert.Less(elapsedMs, timeout, testCaseName);
        }

        /// <summary>
        /// Solution 1
        /// </summary>
        private Solution solution;

        static object[] testCases = {
            new object[] {"Test case 1", new int[] { 2,7,11,15 }, 9, new int[] { 0, 1 } },
            new object[] {"Test case 2", new int[] { 3,2,4 }, 6, new int[] { 1, 2 } },
            new object[] {"Test case 3", new int[] { 3,3 }, 6, new int[] { 0, 1 } },
        };
        private int timeout = 100;
    }
}