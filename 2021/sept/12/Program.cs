using System;
using System.Collections.Generic;
using Sol2;
namespace _12
{
    class Program
    {

        static void Main(string[] args)
        {
            var testCases = new List<TestData> {
                new TestData {
                    Name = "Test Case 1",
                    edges = new int[][] {
                        new int[]{0,1,10},
                        new int[]{0,2,1},
                        new int[]{1,2,2},
                    },
                    maxMoves = 6,
                    n = 3,
                    Expected = 13
                    },
                new TestData {
                    Name = "Test Case 2",
                    edges = new int[][] {
                        new int[] {0,1,4},
                        new int[] {1,2,6},
                        new int[] {0,2,8},
                        new int[] {1,3,1},
                    },
                    maxMoves = 10,
                    n = 4,
                    Expected = 23
                },
                new TestData {
                    Name = "Test Case 3",
                    edges = new int[][] {
                    new int[] {1,2,4},
                    new int[] {1,4,5},
                    new int[] {1,3,1},
                    new int[] {2,3,4},
                    new int[] {3,4,5}
                    },
                    maxMoves = 17,
                    n = 5,
                    Expected = 1
                },
                new TestData {
                    Name = "Test Case 14",
                    edges = new int[][] {
                        new int[] {0,2,3},
                        new int[] {0,4,4},
                        new int[] {2,3,8},
                        new int[] {1,3,5},
                        new int[] {0,3,9},
                        new int[] {3,4,6},
                        new int[] {0,1,5},
                        new int[] {2,4,6},
                        new int[] {1,2,3},
                        new int[] {1,4,1}
                    },
                    maxMoves = 8,
                    n = 5,
                    Expected = 43,
                },
                // new TestData {
                //     Name = "Test Case 14 - Ordered",
                //     edges = new int[][] {
                //         new int[] {0,1,5},
                //         new int[] {0,2,3},
                //         new int[] {0,3,9},
                //         new int[] {0,4,4},
                //         new int[] {1,2,3},
                //         new int[] {1,3,5},
                //         new int[] {1,4,1},
                //         new int[] {2,3,8},
                //         new int[] {2,4,6},
                //         new int[] {3,4,6},
                //     },
                //     maxMoves = 8,
                //     n = 5,
                //     Expected = 43,
                // },
            };

            var sol = new Solution();
            foreach (var test in testCases)
            {
                var res = sol.ReachableNodes(test.edges, test.maxMoves, test.n);
                ReportResult(test, res);
            }
        }

        static void ReportResult(TestData testData, int actual)
        {
            // set color to yellow 
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Dump Test Case name 
            Console.Write("{0}: ", testData.Name);

            // if pass set color to green else red
            var color = actual == testData.Expected ? ConsoleColor.Green : ConsoleColor.Red;
            Console.ForegroundColor = color;

            // Dump expected value
            string result = testData.Expected == actual ? "Pass" : "Fail";
            Console.Write($"[{result}]");

            // Set color back to white
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine($" .. Expected {testData.Expected}\t, Actual {actual}");

            // Reset color
            Console.ResetColor();
        }
    }

    public class TestData
    {
        public string Name { get; set; }
        public int[][] edges { get; set; }
        public int maxMoves { get; set; }
        public int n { get; set; }
        public int Expected { get; set; }
    }
}
