using NUnit.Framework;

namespace _167_two_sum_2_input_array_sorted
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            solution = new Solution();
            solution.Debug = true;
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void Test1(string testCaseName, int[] numbers, int target, int[] expected)
        {
            // measure time 
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var actual = solution.TwoSum(numbers, target);
            sw.Stop();
            var elapsedTime = sw.ElapsedMilliseconds;

            Assert.AreEqual(expected[0], actual[0], testCaseName);
            Assert.AreEqual(expected[1], actual[1], testCaseName);
            Assert.Less(elapsedTime, timeout, testCaseName);
        }

        private int timeout = 100;
        static object[] testCases = new object[] {
            new object[] {"Example 1", new int[] {2,7,11,15}, 9, new int[] {1, 2}},
            new object[] {"Example 2", new int[] {2,3,4},  6, new int[] {1, 3}},
            new object[] {"Example 3", new int[] {-1,0},  -1, new int[] {1, 2}},
            new object[] {"Test Case 5", new int[] {5,25,75}, 100, new int[] {2, 3}},
            new object[] {"Test Case 17", new int[] {0, 0, 3, 4}, 0, new int[] {1, 2}},
        };
        private Solution solution;
    }
}