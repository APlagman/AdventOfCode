using System;
using System.Collections.Generic;
using System.IO;

namespace AdventSolutions
{
    public class Day3 : AdventDay
    {
        protected override int Number => 3;

        protected override void RunImpl()
        {
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath()); Console.WriteLine("Answer to Part 1:");
            int lineNum = 0;
            foreach (string line in input)
            {
                if (int.TryParse(line, out int parsedValue))
                {
                    int steps = StepsToCenter(parsedValue);
                    Console.WriteLine($"Line {lineNum}: {steps}");
                }
                else
                {
                    Console.WriteLine($"Line {lineNum}: Bad input.");
                }
                lineNum++;
            }
            Console.WriteLine("Answer to Part 2:");
            lineNum = 0;
            foreach (string line in input)
            {
                if (int.TryParse(line, out int parsedValue))
                {
                    int answer = NextInSpiral(parsedValue);
                    Console.WriteLine($"Line {lineNum}: {answer}");
                }
                else
                {
                    Console.WriteLine($"Line {lineNum}: Bad input.");
                }
                lineNum++;
            }
        }

        public static int StepsToCenter(int source)
        {
            /*
            17  16  15  14  13
            18   5   4   3  12
            19   6   1   2  11
            20   7   8   9  10
            21  22  23---> ...
            */
            if (source == 1)
                return 0;
            if (source < 9)
                return (source % 2 == 0) ? 1 : 2;
            int radius = SquareRootOfNextOddPerfectSquare(source) / 2;

            int spiralSideLength = (int)((radius + 0.5) * 2);
            int square = (int)Math.Pow(spiralSideLength, 2);
            int distanceAlongSide = (source - (int)Math.Pow(spiralSideLength - 2, 2)) % (spiralSideLength - 1);
            return radius + Math.Abs(distanceAlongSide - (spiralSideLength / 2));
        }

        public static int SquareRootOfNextOddPerfectSquare(int number)
        {
            int root = (int)Math.Ceiling(Math.Sqrt(number));
            if (root % 2 == 0)
                ++root;
            return root;
        }

        const int WIDTH = 100;
        const int HEIGHT = 100;

        public static int NextInSpiral(int num)
        {
            int last = 0;
            int[,] values = new int[HEIGHT, WIDTH];
            for (int i = 0; i < HEIGHT; ++i)
            {
                for (int j = 0; j < WIDTH; ++j)
                {
                    values[i, j] = -1;
                }
            }
            int[][] directions = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { -1, 0 },
                new int[] { 0, -1 },
                new int[] { 1, 0 }
            };
            int[][] neighbors = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { -1, 0 },
                new int[] { 0, -1 },
                new int[] { 1, 0 },
                new int[] { 1, 1 },
                new int[] { -1, 1 },
                new int[] { 1, -1 },
                new int[] { -1, -1 }
            };

            int[] origin = { HEIGHT / 2 - 1, WIDTH / 2 - 1 };
            values[origin[0], origin[1]] = 1;
            int[] offset = new int[] { 0, 1 };
            int count = 1;
            int radius = 1;
            int currentDirection = 1;
            while (last <= num)
            {
                int[] pos = new int[] { origin[0] + offset[0], origin[1] + offset[1] };
                int value = 0;
                foreach (int[] neighborDirection in neighbors)
                {
                    int[] newPos = new int[] { pos[0] + neighborDirection[0], pos[1] + neighborDirection[1] };
                    if (newPos[0] >= WIDTH || newPos[0] < 0 || newPos[1] >= HEIGHT || newPos[1] < 0)
                        continue;
                    int neighbor = values[newPos[0], newPos[1]];
                    if (neighbor != -1)
                        value += neighbor;
                }
                values[pos[0], pos[1]] = value;
                last = value;
                ++count;
                int spiralSideLength = (int)((radius + 0.5) * 2);
                if (count == Math.Pow(spiralSideLength, 2))
                {
                    ++radius;
                    spiralSideLength += 2;
                }
                int square = (int)Math.Pow(spiralSideLength, 2);
                if (count - (int)Math.Pow(spiralSideLength - 2, 2) != 0)
                {
                    int distanceAlongSide = (count - (int)Math.Pow(spiralSideLength - 2, 2)) % (spiralSideLength - 1);
                    if (distanceAlongSide == 0)
                        currentDirection = (currentDirection + 1) % directions.Length;
                    offset[0] += directions[currentDirection][0];
                    offset[1] += directions[currentDirection][1];
                }
                else
                {
                    offset[0] += directions[currentDirection][0];
                    offset[1] += directions[currentDirection][1];
                    currentDirection = (currentDirection + 1) % directions.Length;
                }
            }
            return last;
        }
    }
}
