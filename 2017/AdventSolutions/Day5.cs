using System;
using System.Collections.Generic;
using System.IO;

namespace AdventSolutions
{
    public class Day5 : AdventDay
    {
        protected override int Number => 5;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/5
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath()); Console.WriteLine("Answer to Part 1:");
            var offsets = new List<int>();
            foreach (string line in input)
            {
                if (int.TryParse(line, out int val))
                    offsets.Add(val);
                else
                    throw new ArgumentException("Bad input: not an integer.");
            }
            Console.WriteLine(NumberOfSteps(new List<int>(offsets)));

            Console.WriteLine("Answer to Part 2:");
            Console.WriteLine(NumberOfStepsVersion2(new List<int>(offsets)));
        }

        public static int NumberOfSteps(IList<int> offsets)
        {
            int index = 0;
            int steps = 0;
            while (index >= 0 && index < offsets.Count)
            {
                ++steps;
                index += offsets[index]++;
            }
            return steps;
        }

        private static int NumberOfSteps(IList<int> offsets, Func<int, int> newOffset)
        {
            int index = 0;
            int steps = 0;
            while (index >= 0 && index < offsets.Count)
            {
                ++steps;
                int newIndex = index + offsets[index];
                offsets[index] = newOffset(offsets[index]);
                index = newIndex;
            }
            return steps;
        }

        public static int NumberOfStepsVersion2(IList<int> offsets)
        {
            return NumberOfSteps(offsets, offset => (offset >= 3) ? offset - 1 : offset + 1);
        }
    }
}
