using System;
using System.Collections.Generic;
using System.IO;

namespace AdventSolutions
{
    class Day1 : AdventDay
    {
        protected override int Day => 1;

        protected override void RunImpl()
        {
            string inputFile;
            do
            {
                Console.WriteLine("Provide input file:");
                inputFile = Console.ReadLine();
            } while (!File.Exists(inputFile));
            IEnumerable<string> input = File.ReadLines(inputFile);
            Console.WriteLine("Answer to Part 1:");
            int lineNum = 0;
            foreach (string line in input)
            {
                int sum = 0;
                for (int pos = 0; pos < line.Length; ++pos)
                {
                    if (line[pos] == line[(pos + 1) % line.Length])
                    {
                        sum += Int32.Parse(line[pos].ToString());
                    }
                }
                Console.WriteLine($"Line {lineNum}: {sum}");
                lineNum++;
            }
            Console.WriteLine("Answer to Part 2:");
            lineNum = 0;
            foreach (string line in input)
            {
                int sum = 0;
                for (int pos = 0; pos < line.Length; ++pos)
                {
                    if (line[pos] == line[(pos + (line.Length / 2)) % line.Length])
                    {
                        sum += Int32.Parse(line[pos].ToString());
                    }
                }
                Console.WriteLine($"Line {lineNum}: {sum}");
                lineNum++;
            }
        }
    }
}
