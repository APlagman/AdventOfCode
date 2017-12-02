﻿using System;
using System.Collections.Generic;
using System.IO;

namespace AdventSolutions
{
    // http://adventofcode.com/2017/day/1
    public class Day1 : AdventDay
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
                Console.WriteLine($"Line {lineNum}: {SumIdenticalDigits(line, 1)}");
                lineNum++;
            }
            Console.WriteLine("Answer to Part 2:");
            lineNum = 0;
            foreach (string line in input)
            {
                Console.WriteLine($"Line {lineNum}: {SumIdenticalDigits(line, line.Length / 2)}");
                lineNum++;
            }
        }

        public static int SumIdenticalDigits(string line, int offset)
        {
            int sum = 0;
            for (int pos = 0; pos < line.Length; ++pos)
            {
                if (line[pos] == line[(pos + offset) % line.Length])
                {
                    sum += Int32.Parse(line[pos].ToString());
                }
            }
            return sum;
        }
    }
}
