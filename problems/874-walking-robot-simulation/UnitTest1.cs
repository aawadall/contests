using System.Diagnostics;
using NUnit.Framework;

namespace _874_walking_robot_simulation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // solution.EnableDebug = true;
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void Test1(string testCaseName, int[] commands, int[][] obstacles, int expected)
        {
            int actual;
            long duration;
            System.Console.WriteLine(testCaseName);
            Profile(solution.RobotSim, commands, obstacles, out actual, out duration);
            Assert.AreEqual(expected, actual, testCaseName);
            Assert.True(duration < _maxDuration, $"{testCaseName} took too long; {duration} ms");
        }

        private void Profile(SolDelegate solutionMethod, int[] commands, int[][] obstacles, out int actual, out long duration)
        {
            // stopwatch
            var sw = new System.Diagnostics.Stopwatch();
            // run
            sw.Start();
            // execute
            actual = solutionMethod(commands, obstacles);
            // stop
            sw.Stop();
            // get duration
            duration = sw.ElapsedMilliseconds;
        }
        // Solution Specific 
        private Solution solution = new Solution();

        private delegate int SolDelegate(int[] commands, int[][] obstacles);

        private static int _maxDuration = 5;
        /// <summary>
        /// Test cases with the following catalog
        /// - string: Test Case Name
        /// - int[]: commands
        /// - int[][]: obstacles
        /// - int: expected
        /// </summary>
        /// <value></value>
        static object[] testCases = {
            new object[] {"Example 1", new int[] {4,-1,3}, new int[][]{}, 25},
            new object[] {"Example 2", new int[] {4,-1,4,-2,4}, new int[][]{new int[]{2, 4}}, 65},

            new object[] {
                "Test Case 26",
                new int[] {1,2,-2,5,-1,-2,-1,8,3,-1,9,4,-2,3,2,4,3,9,2,-1,-1,-2,1,3,-2,4,1,4,-1,1,9,-1,-2,5,-1,5,5,-2,6,6,7,7,2,8,9,-1,7,4,6,9,9,9,-1,5,1,3,3,-1,5,9,7,4,8,-1,-2,1,3,2,9,3,-1,-2,8,8,7,5,-2,6,8,4,6,2,7,2,-1,7,-2,3,3,2,-2,6,9,8,1,-2,-1,1,4,7},
                new int[][]{
                    new int[] {-57,-58},
new int[] { -72, 91 },
new int[] { -55, 35 },
new int[] { -20, 29 },
new int[] { 51, 70 },
new int[] { -61, 88 },
new int[] { -62, 99 },
new int[] { 52, 17 },
new int[] { -75, -32 },
new int[] { 91, -22 },
new int[] { 54, 33 },
new int[] { -45, -59 },
new int[] { 47, -48 },
new int[] { 53, -98 },
new int[] { -91, 83 },
new int[] { 81, 12 },
new int[] { -34, -90 },
new int[] { -79, -82 },
new int[] { -15, -86 },
new int[] { -24, 66 },
new int[] { -35, 35 },
new int[] { 3, 31 },
new int[] { 87, 93 },
new int[] { 2, -19 },
new int[] { 87, -93 },
new int[] { 24, -10 },
new int[] { 84, -53 },
new int[] { 86, 87 },
new int[] { -88, -18 },
new int[] { -51, 89 },
new int[] { 96, 66 },
new int[] { -77, -94 },
new int[] { -39, -1 },
new int[] { 89, 51 },
new int[] { -23, -72 },
new int[] { 27, 24 },
new int[] { 53, -80 },
new int[] { 52, -33 },
new int[] { 32, 4 },
new int[] { 78, -55 },
new int[] { -25, 18 },
new int[] { -23, 47 },
new int[] { 79, -5 },
new int[] { -23, -22 },
new int[] { 14, -25 },
new int[] { -11, 69 },
new int[] { 63, 36 },
new int[] { 35, -99 },
new int[] { -24, 82 },
new int[] { -29, -98 },
new int[] { -50, -70 },
new int[] { 72, 95 },
new int[] { 80, 80 },
new int[] { -68, -40 },
new int[] { 65, 70 },
new int[] { -92, 78 },
new int[] { -45, -63 },
new int[] { 1, 34 },
new int[] { 81, 50 },
new int[] { 14, 91 },
new int[] { -77, -54 },
new int[] { 13, -88 },
new int[] { 24, 37 },
new int[] { -12, 59 },
new int[] { -48, -62 },
new int[] { 57, -22 },
new int[] { -8, 85 },
new int[] { 48, 71 },
new int[] { 12, 1 },
new int[] { -20, 36 },
new int[] { -32, -14 },
new int[] { 39, 46 },
new int[] { -41, 75 },
new int[] { 13, -23 },
new int[] { 98, 10 },
new int[] { -88, 64 },
new int[] { 50, 37 },
new int[] { -95, -32 },
new int[] { 46, -91 },
new int[] { 10, 79 },
new int[] { -11, 43 },
new int[] { -94, 98 },
new int[] { 79, 42 },
new int[] { 51, 71 },
new int[] { 4, -30 },
new int[] { 2, 74 },
new int[] { 4, 10 },
new int[] { 61, 98 },
new int[] { 57, 98 },
new int[] { 46, 43 },
new int[] { -16, 72 },
new int[] { 53, -69 },
new int[] { 54, -96 },
new int[] { 22, 0 },
new int[] { -7, 92 },
new int[] { -69, 80 },
new int[] { 68, -73 },
new int[] { -24, -92 },
new int[] { -21, 82 },
new int[] { 32, -1 },
new int[] { -6, 16 },
new int[] { 15, -29 },
new int[] { 70, -66 },
new int[] { -85, 80 },
new int[] { 50, -3 },
new int[] { 6, 13 },
new int[] { -30, -98 },
new int[] { -30, 59 },
new int[] { -67, 40 },
new int[] { 17, 72 },
new int[] { 79, 82 },
new int[] { 89, -100 },
new int[] { 2, 79 },
new int[] { -95, -46 },
new int[] { 17, 68 },
new int[] { -46, 81 },
new int[] { -5, -57 },
new int[] { 7, 58 },
new int[] { -42, 68 },
new int[] { 19, -95 },
new int[] { -17, -76 },
new int[] { 81, -86 },
new int[] { 79, 78 },
new int[] { -82, -67 },
new int[] { 6, 0 },
new int[] { 35, -16 },
new int[] { 98, 83 },
new int[] { -81, 100 },
new int[] { -11, 46 },
new int[] { -21, -38 },
new int[] { -30, -41 },
new int[] { 86, 18 },
new int[] { -68, 6 },
new int[] { 80, 75 },
new int[] { -96, -44 },
new int[] { -19, 66 },
new int[] { 21, 84 },
new int[] { -56, -64 },
new int[] { 39, -15 },
new int[] { 0, 45 },
new int[] { -81, -54 },
new int[] { -66, -93 },
new int[] { -4, 2 },
new int[] { -42, -67 },
new int[] { -15, -33 },
new int[] { 1, -32 },
new int[] { -74, -24 },
new int[] { 7, 18 },
new int[] { -62, 84 },
new int[] { 19, 61 },
new int[] { 39, 79 },
new int[] { 60, -98 },
new int[] { -76, 45 },
new int[] { 58, -98 },
new int[] { 33, 26 },
new int[] { -74, -95 },
new int[] { 22, 30 },
new int[] { -68, -62 },
new int[] { -59, 4 },
new int[] { -62, 35 },
new int[] { -78, 80 },
new int[] { -82, 54 },
new int[] { -42, 81 },
new int[] { 56, -15 },
new int[] { 32, -19 },
new int[] { 34, 93 },
new int[] { 57, -100 },
new int[] { -1, -87 },
new int[] { 68, -26 },
new int[] { 18, 86 },
new int[] { -55, -19 },
new int[] { -68, -99 },
new int[] { -9, 47 },
new int[] { 24, 94 },
new int[] { 92, 97 },
new int[] { 5, 67 },
new int[] { 97, -71 },
new int[] { 63, -57 },
new int[] { -52, -14 },
new int[] { -86, -78 },
new int[] { -17, 92 },
new int[] { -61, -83 },
new int[] { -84, -10 },
new int[] { 20, 13 },
new int[] { -68, -47 },
new int[] { 7, 28 },
new int[] { 66, 89 },
new int[] { -41, -17 },
new int[] { -14, -46 },
new int[] { -72, -91 },
new int[] { 4, 52 },
new int[] { -17, -59 },
new int[] { -85, -46 },
new int[] { -94, -23 },
new int[] { -48, -3 },
new int[] { -64, -37 },
new int[] { 2, 26 },
new int[] { 76, 88 },
new int[] { -8, -46 },
new int[] { -19, -68 },
                }, 5140},


        };
    }
}