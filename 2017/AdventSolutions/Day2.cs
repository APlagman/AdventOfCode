using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventSolutions
{
    public class Day2 : AdventDay
    {
        protected override int Day => 2;

        protected override void RunImpl()
        {
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath());
            Console.WriteLine("Answer to Part 1:");
            int checksum = 0;
            int lineNum = 0;
            foreach (string line in input)
            {
                int range = Range(line);
                Console.WriteLine($"Line {lineNum}: {range}");
                checksum += range;
                lineNum++;
            }
            Console.WriteLine(checksum);

            Console.WriteLine("Answer to Part 2:");
            checksum = 0;
            lineNum = 0;
            foreach (string line in input)
            {
                int quotient = DivideMultiplesIn(line);
                Console.WriteLine($"Line {lineNum}: {quotient}");
                checksum += quotient;
                lineNum++;
            }
            Console.Write(checksum);
        }

        public static int Range(string line)
        {
            var numbersAsText = Regex.Replace(line, @"\s+", " ").Split(' ');
            var numbers = from str in numbersAsText
                         where int.TryParse(str, out _)
                         select int.Parse(str);
            return numbers.Max() - numbers.Min();
        }

        public static int DivideMultiplesIn(string line)
        {
            var numbersAsText = Regex.Replace(line, @"\s+", " ").Split(' ');
            var parsedNumbers = from str in numbersAsText
                          where int.TryParse(str, out _)
                          select int.Parse(str);
            int[] numbers = parsedNumbers.Where(num => num > 0).Distinct().ToArray();
            for (int first = 0; first < numbers.Length; ++first)
            {
                for (int second = first + 1; second < numbers.Length; ++second)
                {
                    if (numbers[first] % numbers[second] == 0)
                        return numbers[first] / numbers[second];
                    if (numbers[second] % numbers[first] == 0)
                        return numbers[second] / numbers[first];
                }
            }
            throw new ArgumentException("Line does not contain a pair of evenly-divisible numbers.");
        }
    }
}
