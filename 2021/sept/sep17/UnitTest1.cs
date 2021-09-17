using System.Diagnostics;
using NUnit.Framework;

namespace sep17
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // init solution 
            solution = new Solution2();
            // log level 
            solution.EnableDebug = true;
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void Test1(string testCaseName, int[] nums1, int[] nums2, int[] expected)
        {
            int[] actual;
            long duration;
            Profile(solution.Intersect, nums1, nums2, out actual, out duration);
            Assert.AreEqual(expected, actual);
            Assert.Less(duration, _maxDuration, $"{testCaseName} took long; {duration} ms");
        }

        // Solution 
        private ISolution solution;
        private delegate int[] SolDelegate(int[] nums1, int[] nums2);
        private static int _maxDuration = 10;
        private void Profile(SolDelegate solutionMethod, int[] nums1, int[] nums2, out int[] actual, out long duration)
        {
            // stopwatch
            var sw = new System.Diagnostics.Stopwatch();
            // run
            sw.Start();
            // execute
            actual = solutionMethod(nums1, nums2);
            // stop
            sw.Stop();
            // get duration
            duration = sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// Test cases
        /// <remarks>
        /// made of the following components:
        /// - testCaseName: string
        /// - nums1: int[]
        /// - nums2: int[]
        /// - expected: int[]
        /// </remarks>
        /// </summary>
        /// <value></value>
        static object[] testCases = {
            new object[] {
                "Example 1",
                new int[] { 1,2,2,1 }, // nums1
                new int[] { 2,2 },   // nums2
                new int[] { 2,2 }   // expected
            },
            new object[] {
                "Example 2",
                new int[] { 4,9,5 }, // nums1
                new int[] { 9,4,9,8,4 },   // nums2
                new int[] { 4,9 }   // expected
            },
            new object[] {
                "Test case 31",
                new int[]{3,1,2},
                new int[]{1,1},
                new int[]{1}
            },
            new object[] {
                "Test case 53",
                new int[]{1,2},
                new int[]{1,1},
                new int[]{1}
            },
        };
    }
}