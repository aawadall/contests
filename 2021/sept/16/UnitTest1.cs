using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace _16
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
        public void Test1(string testCaseName, int[][] matrix, IList<int> expected)
        {
            IList<int> actual;
            long duration;
            System.Console.WriteLine(testCaseName);
            Profile(solution.SpiralOrder, matrix, out actual, out duration);
            Assert.AreEqual(expected, actual, testCaseName);
            Assert.True(duration < _maxDuration, $"{testCaseName} took too long; {duration} ms");
        }

        private void Profile(SolDelegate solutionMethod, int[][] matrix, out IList<int> actual, out long duration)
        {
            // stopwatch
            var sw = new System.Diagnostics.Stopwatch();
            // run
            sw.Start();
            // execute
            actual = solutionMethod(matrix);
            // stop
            sw.Stop();
            // get duration
            duration = sw.ElapsedMilliseconds;
        }
        // Solution Specific 
        private Solution solution = new Solution();

        private delegate IList<int> SolDelegate(int[][] matrix);

        private static int _maxDuration = 1;
        /// <summary>
        /// Test cases with the following catalog
        /// - string: Test Case Name
        /// - int[][]: matrix
        /// - IList<int>: expected
        /// </summary>
        /// <value></value>
        static object[] testCases = {
            new object[] {
                "Test Example 1",
                new int[][] {
                    new int[] {1,2,3,4},
                    new int[] {5,6,7,8},
                    new int[] {9,10,11,12},
                },
                new List<int>{1,2,3,4,8,12,11,10,9,5,6,7}
            },
            new object[] {
                "Test Example 2",
                new int[][] {
                    new int[] {1,2,3,4},
                    new int[] {5,6,7,8},
                    new int[] {9,10,11,12}
                },
                new List<int>{1,2,3,4,8,12,11,10,9,5,6,7}
            },
            new object[] {
                "Test Case 20",
                new int[][] {
                    new int[] {2, 3}
                },
                new List<int>{2, 3}
            },
        };
    }
}


