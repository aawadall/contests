using System;
using System.Diagnostics;
using NUnit.Framework;

namespace sep20
{
    public class Tests
    {

        private ISolution _solution;
        private int _maxTime = 10;
        private delegate string TestMethod(int[][] moves);
        #region Test Data
        /// <summary>
        /// Test Data; made of the following parts:
        /// - string:testCaseName (name of the test case)
        /// - int[][]:moves (the moves)
        /// - string:expected (the expected result)
        /// </summary>
        /// <value></value>
        private static object[] TestCases = {
            /* Example 1:

            Input: moves = [[0,0],[2,0],[1,1],[2,1],[2,2]]
            Output: "A"
            Explanation: "A" wins, he always plays first.
            "X  "    "X  "    "X  "    "X  "    "X  "
            "   " -> "   " -> " X " -> " X " -> " X "
            "   "    "O  "    "O  "    "OO "    "OOX"
            */
            new object[] {
                "Example 1",
                new int[][] {
                    new int[] {0,0},
                    new int[] {2,0},
                    new int[] {1,1},
                    new int[] {2,1},
                    new int[] {2,2}
                },
                "A"
            },
            /*
            Example 2:

            Input: moves = [[0,0],[1,1],[0,1],[0,2],[1,0],[2,0]]
            Output: "B"
            Explanation: "B" wins.
            "X  "    "X  "    "XX "    "XXO"    "XXO"    "XXO"
            "   " -> " O " -> " O " -> " O " -> "XO " -> "XO " 
            "   "    "   "    "   "    "   "    "   "    "O  "
            */
            new object[] {
                "Example 2",
                new int[][] {
                    new int[] {0,0},
                    new int[] {1,1},
                    new int[] {0,1},
                    new int[] {0,2},
                    new int[] {1,0},
                    new int[] {2,0}
                },
                "B"
            },
            /*
            Example 3:

            Input: moves = [[0,0],[1,1],[2,0],[1,0],[1,2],[2,1],[0,1],[0,2],[2,2]]
            Output: "Draw"
            Explanation: The game ends in a draw since there are no moves to make.
            "XXO"
            "OOX"
            "XOX"
            */
            new object[] {
                "Example 3",
                new int[][] {
                    new int[] {0,0},
                    new int[] {1,1},
                    new int[] {2,0},
                    new int[] {1,0},
                    new int[] {1,2},
                    new int[] {2,1},
                    new int[] {0,1},
                    new int[] {0,2},
                    new int[] {2,2}
                },
                "Draw"
            },
            /*
            Example 4:

            Input: moves = [[0,0],[1,1]]
            Output: "Pending"
            Explanation: The game has not finished yet.
            "X  "
            " O "
            "   " */
            new object[] {
                "Example 4",
                new int[][] {
                    new int[] {0,0},
                    new int[] {1,1}
                },
                "Pending"
            },

            new object[] {
                "Test Case 55",
                new int[][] {
                    new int [] {1,0},
                    new int [] {2,2},
                    new int [] {2,0},
                    new int [] {0,1},
                    new int [] {1,1}
                },
                "Pending" },
        };
        #endregion

        [SetUp]
        public void Setup()
        {
            // concrete implementation of the ISolution interface
            _solution = new Solution1();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Test1(string testCaseName, int[][] moves, string expected)
        {
            int executionTime;
            var result = profile(_solution.Tictactoe, moves, out executionTime);

            Assert.AreEqual(expected, result); // is correct answer?
            Assert.IsTrue(executionTime <= _maxTime); // did I answer in time?
        }

        private string profile(TestMethod testMethod, int[][] moves, out int executionTime)
        {
            var sw = Stopwatch.StartNew();
            var result = testMethod(moves);
            sw.Stop();
            executionTime = (int)sw.ElapsedMilliseconds;
            return result;
        }
    }
}