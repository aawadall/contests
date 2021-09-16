using System.Linq;
using System.Collections.Generic;
using System;

namespace _874_walking_robot_simulation
{
    public class Solution
    {
        public bool EnableDebug { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commands">series of instructions as; -2: left turn 90 degrees, -1 right turn 90 degrees, k in 1~9 units to move forward</param>
        /// <param name="obstacles">coordinates of obstacles</param>
        /// <returns>squared Euclidean distance from point of origin</returns>
        /// TODO: 
        /// - consider compacting commands -ves together and +ves together
        public int RobotSim(int[] commands, int[][] obstacles)
        {
            // initialize robot
            var currentPosition = new int[] { 0, 0 };
            var direction = new int[] { 0, 1 }; // direction is a unit vector to the north
            var maxDistance = 0;
            // compact commands
            var compactedCommands = CompactCommands(commands);

            // save obstacles
            var obstacleSet = new HashSet<string>(obstacles.Select(o => $"{o[0]},{o[1]}"));
            // iterative approach, might be suboptimal for large data sets
            foreach (var command in compactedCommands)
            {
                Move(command, obstacleSet, ref currentPosition, ref direction);
                maxDistance = Math.Max(maxDistance, GetDistance(currentPosition));
            }

            // return distance 
            return maxDistance;
        }

        private int[] CompactCommands(int[] commands)
        {
            var compactedCommands = new List<int> { commands[0] };
            for (int i = 1; i < commands.Length; i++)
            {
                if (compactedCommands.Last() > 0 && commands[i] > 0)
                {
                    compactedCommands[compactedCommands.Count - 1] += commands[i];
                }
                else
                {
                    compactedCommands.Add(commands[i]);
                }

            }
            return compactedCommands.ToArray();
        }

        private void Move(int command, HashSet<string> obstacles, ref int[] currentPosition, ref int[] direction)
        {
            switch (command)
            {

                case -2: // left turn 90 degrees
                    direction = LeftTurn(direction);
                    break;
                case -1: // right turn 90 degrees
                    direction = RightTurn(direction);
                    break;
                default:
                    // move forward
                    var skip = false;
                    var potentialPosition = new int[2];
                    if (EnableDebug) System.Console.WriteLine($"Walking {command} steps: ");
                    for (int step = 0; step < command && !skip; step++)
                    {
                        potentialPosition = new int[] { currentPosition[0] + direction[0], currentPosition[1] + direction[1] };

                        if (!Blocked(obstacles, potentialPosition))
                        {
                            currentPosition = potentialPosition;
                            if (EnableDebug) System.Console.Write($".");
                        }
                        else
                        {

                            skip = true;
                            //break;
                        };

                    }
                    if (EnableDebug) System.Console.WriteLine($"");
                    break;
            }
            if (EnableDebug) System.Diagnostics.Debug.Write($"Robot at position ({currentPosition[0]},{currentPosition[1]}), direction: [{direction[0]},{direction[1]}]");
            if (EnableDebug) System.Diagnostics.Debug.WriteLine($", that is {GetDistance(currentPosition)} away from origin");
        }

        private bool Blocked(HashSet<String> obstacles, int[] potentialPosition)
        {

            // find if potential position is in list of obstacles
            return obstacles.Contains($"{potentialPosition[0]},{potentialPosition[1]}");
        }

        private int[] RightTurn(int[] direction)
        {
            if (EnableDebug) System.Diagnostics.Debug.WriteLine("Turning right");
            // north -> east
            if (direction[0] == 0 && direction[1] == 1) return new int[] { 1, 0 };

            // east -> south
            if (direction[0] == 1 && direction[1] == 0) return new int[] { 0, -1 };

            // south -> west
            if (direction[0] == 0 && direction[1] == -1) return new int[] { -1, 0 };

            // west -> north
            if (direction[0] == -1 && direction[1] == 0) return new int[] { 0, 1 };

            // fallback
            return direction;
        }

        private int[] LeftTurn(int[] direction)
        {
            if (EnableDebug) System.Diagnostics.Debug.WriteLine("Turning left");
            // north -> west
            if (direction[0] == 0 && direction[1] == 1) return new int[] { -1, 0 };

            // west -> south
            if (direction[0] == -1 && direction[1] == 0) return new int[] { 0, -1 };

            // south -> east
            if (direction[0] == 0 && direction[1] == -1) return new int[] { 1, 0 };

            // east -> north
            if (direction[0] == 1 && direction[1] == 0) return new int[] { 0, 1 };

            // fallback
            return direction;
        }

        private static int GetDistance(int[] currentPosition)
        {
            return currentPosition[0] * currentPosition[0] + currentPosition[1] * currentPosition[1];
        }
    }
}