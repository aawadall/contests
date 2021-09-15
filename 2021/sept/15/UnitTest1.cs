using NUnit.Framework;
using System.Diagnostics;
using Sol1;
namespace _15
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            solution.EnableDebug = true;
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void Test1(string testCaseName, int[] arr, int expected)
        {
            int actual;
            long duration;
            System.Console.WriteLine(testCaseName);
            Profile(solution.MaxTurbulenceSize, arr, out actual, out duration);
            Assert.AreEqual(expected, actual, testCaseName);
            Assert.Less(duration, _maxDuration);     
        }

        private void Profile(SolDelegate solutionMethod, int[] arr, out int actual, out long duration) {
            // stopwatch
            var sw = new System.Diagnostics.Stopwatch();
            // run
            sw.Start();
            // execute
            actual = solutionMethod(arr);
            // stop
            sw.Stop();
            // get duration
            duration = sw.ElapsedMilliseconds;
        }
        // Solution Specific 
        private Solution solution = new Solution();

        private delegate int SolDelegate(int[] arr);

        private static int _maxDuration = 100;
        /// <summary>
        /// Test cases with the following catalog
        /// - string: Test Case Name
        /// - int[]: arr
        /// - int: expected
        /// </summary>
        /// <value></value>
        static object[] testCases = {
            new object[] {"Test Example 1", new int[] {9,4,2,10,7,8,8,1,9}, 5},
            new object[] {"Test Example 2", new int[] {4, 8, 12, 16}, 2},
            new object[] {"Test Example 3", new int[] {100}, 1},
            new object[] {"Test case 84", new int[] {9, 9}, 1},
            new object[] {"Test case 83", new int[] {37,199,60,296,257,248,115,31,273,176}, 5},
            new object[] {"Test case 84b", new int[] {0,8,45,88,48,68,28,55,17,24}, 8},
        };
    }
}