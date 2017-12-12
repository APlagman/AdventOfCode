using System;
using System.IO;

namespace AdventSolutions
{
    public class Day11 : AdventDay
    {
        protected override int Number => 11;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/11
            var lines = File.ReadLines(FileUtils.PromptForExistingFilePath());
            Console.WriteLine("Answer to Part 1:");
            foreach (string line in lines)
            {
                Console.WriteLine(DistanceAfterSteps(line));
            }
            Console.WriteLine("Answer to Part 2:");
            foreach (string line in lines)
            {
                Console.WriteLine(MaxDistanceDuringSteps(line));
            }
        }

        public static int DistanceAfterSteps(string steps)
        {
            int q = 0,
                r = 0,
                s = 0;
            foreach (string step in steps.Split(','))
            {
                switch (step)
                {
                    case "ne":
                        ++q;
                        break;
                    case "sw":
                        --q;
                        break;
                    case "n":
                        ++r;
                        break;
                    case "s":
                        --r;
                        break;
                    case "nw":
                        --q;
                        ++r;
                        break;
                    case "se":
                        ++q;
                        --r;
                        break;
                }
                s = q + r;
            }
            return (Math.Abs(q) + Math.Abs(r) + Math.Abs(s)) / 2;
        }

        public static int MaxDistanceDuringSteps(string steps)
        {
            int max = 0;
            int q = 0,
                r = 0,
                s = 0;
            foreach (string step in steps.Split(','))
            {
                switch (step)
                {
                    case "ne":
                        ++q;
                        break;
                    case "sw":
                        --q;
                        break;
                    case "n":
                        ++r;
                        break;
                    case "s":
                        --r;
                        break;
                    case "nw":
                        --q;
                        ++r;
                        break;
                    case "se":
                        ++q;
                        --r;
                        break;
                }
                s = q + r;
                int dist = (Math.Abs(q) + Math.Abs(r) + Math.Abs(s)) / 2;
                if (dist > max)
                    max = dist;
            }
            return max;
        }
    }
}
