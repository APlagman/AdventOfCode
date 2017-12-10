using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventSolutions
{
    public class Day8 : AdventDay
    {
        protected override int Number => 8;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/8
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath());
            Console.WriteLine("Answer to Part 1:");
            Console.WriteLine(MaximumValueAfterRegisterInstructions(input));
            Console.WriteLine("Answer to Part 2:");
            Console.WriteLine(MaximumValueDuringRegisterInstructions(input));
        }

        public static int MaximumValueAfterRegisterInstructions(IEnumerable<string> instructions)
        {
            IDictionary<string, int> registers = new Dictionary<string, int>();
            foreach (string line in instructions)
            {
                var parts = line.Split(' ');
                registers[parts[0]] = 0;
            }
            foreach (string line in instructions)
            {
                var parts = line.Split(' ');
                string registerToChange = parts[0];
                bool positiveDelta = parts[1].Equals("inc");
                int delta = int.Parse(parts[2]);
                string registerToTest = parts[4];
                int valueToTest = int.Parse(parts[6]);
                bool testPassed;
                switch (parts[5])
                {
                    case ">":
                        testPassed = (registers[registerToTest] > valueToTest);
                        break;
                    case ">=":
                        testPassed = (registers[registerToTest] >= valueToTest);
                        break;
                    case "<":
                        testPassed = (registers[registerToTest] < valueToTest);
                        break;
                    case "<=":
                        testPassed = (registers[registerToTest] <= valueToTest);
                        break;
                    case "==":
                        testPassed = (registers[registerToTest] == valueToTest);
                        break;
                    case "!=":
                        testPassed = (registers[registerToTest] != valueToTest);
                        break;
                    default:
                        throw new ArgumentException("Bad input.");
                }
                if (testPassed)
                    registers[registerToChange] += (positiveDelta) ? delta : -delta;
            }
            return registers.Values.Max();
        }

        public static int MaximumValueDuringRegisterInstructions(IEnumerable<string> instructions)
        {
            IDictionary<string, int> registers = new Dictionary<string, int>();
            foreach (string line in instructions)
            {
                var parts = line.Split(' ');
                registers[parts[0]] = 0;
            }
            int maxValue = 0;
            foreach (string line in instructions)
            {
                var parts = line.Split(' ');
                string registerToChange = parts[0];
                bool positiveDelta = parts[1].Equals("inc");
                int delta = int.Parse(parts[2]);
                string registerToTest = parts[4];
                int valueToTest = int.Parse(parts[6]);
                bool testPassed;
                switch (parts[5])
                {
                    case ">":
                        testPassed = (registers[registerToTest] > valueToTest);
                        break;
                    case ">=":
                        testPassed = (registers[registerToTest] >= valueToTest);
                        break;
                    case "<":
                        testPassed = (registers[registerToTest] < valueToTest);
                        break;
                    case "<=":
                        testPassed = (registers[registerToTest] <= valueToTest);
                        break;
                    case "==":
                        testPassed = (registers[registerToTest] == valueToTest);
                        break;
                    case "!=":
                        testPassed = (registers[registerToTest] != valueToTest);
                        break;
                    default:
                        throw new ArgumentException("Bad input.");
                }
                if (testPassed)
                    registers[registerToChange] += (positiveDelta) ? delta : -delta;
                if (registers.Values.Max() > maxValue)
                    maxValue = registers.Values.Max();
            }
            return maxValue;
        }
    }
}
