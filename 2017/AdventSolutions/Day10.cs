using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventSolutions
{
    public class Day10 : AdventDay
    {
        private const int DEFAULT_NUMBER_OF_VALUES = 256;
        private const int HASH_GROUP_LENGTH = 16;

        protected override int Number => 10;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/10
            var lines = File.ReadLines(FileUtils.PromptForExistingFilePath());
            Console.WriteLine("Answer to Part 1:");
            foreach (string line in lines)
                Console.WriteLine(TwistAndFindProduct(line, DEFAULT_NUMBER_OF_VALUES));
            Console.WriteLine("Answer to Part 2:");
            foreach (string line in lines)
            {
                Console.WriteLine(KnotHash(line));
            }
        }

        public static int TwistAndFindProduct(string lengthsString, int numberOfValues)
        {
            List<int> numbers = new List<int>(numberOfValues);
            for (int i = 0; i < numberOfValues; ++i)
                numbers.Add(i);
            int currentPosition = 0;
            int skipSize = 0;
            string[] lengthStrings = lengthsString.Split(',');
            int[] lengths = new int[lengthStrings.Length];
            for (int i = 0; i < lengthStrings.Length; ++i)
                lengths[i] = int.Parse(lengthStrings[i]);
            RunRound(numbers, lengths, numberOfValues, ref currentPosition, ref skipSize);
            return numbers[0] * numbers[1];
        }

        public static string KnotHash(string ascii)
        {
            List<int> numbers = new List<int>(DEFAULT_NUMBER_OF_VALUES);
            for (int i = 0; i < DEFAULT_NUMBER_OF_VALUES; ++i)
                numbers.Add(i);
            int currentPosition = 0;
            int skipSize = 0;

            char[] asciiBytes = ascii.ToCharArray();
            List<int> lengths = new List<int>(asciiBytes.Length + 5);
            for (int i = 0; i < asciiBytes.Length; ++i)
                lengths.Add(asciiBytes[i]);
            lengths.AddRange(new int[] { 17, 31, 73, 47, 23 });

            for (int i = 0; i < 64; ++i)
                RunRound(numbers, lengths, DEFAULT_NUMBER_OF_VALUES, ref currentPosition, ref skipSize);

            StringBuilder hex = new StringBuilder("");
            foreach (int val in CalculateDenseHash(numbers))
                hex.Append(val.ToString("x2"));
            return hex.ToString();
        }

        private static void RunRound(List<int> numbers, IEnumerable<int> lengths, int numberOfValues, ref int currentPosition, ref int skipSize)
        {
            foreach (int length in lengths)
            {
                List<int> toReverse;
                if (currentPosition + length >= numberOfValues)
                {
                    toReverse = numbers.GetRange(currentPosition, numberOfValues - currentPosition);
                    toReverse.AddRange(numbers.GetRange(0, length - toReverse.Count()));
                }
                else
                    toReverse = numbers.GetRange(currentPosition, length);
                toReverse.Reverse();
                for (int i = 0, pos = currentPosition; i < length; ++i, pos = (pos + 1) % numberOfValues)
                    numbers[pos] = toReverse[i];
                currentPosition = (currentPosition + length + skipSize) % numberOfValues;
                ++skipSize;
            }
        }

        private static IEnumerable<int> CalculateDenseHash(IList<int> numbers)
        {
            int[] denseHash = new int[numbers.Count() / HASH_GROUP_LENGTH];
            for (int i = 0; i < denseHash.Length; ++i)
            {
                int offset = HASH_GROUP_LENGTH * i;
                for (int j = 0; j < HASH_GROUP_LENGTH; ++j)
                {
                    denseHash[i] ^= numbers[offset + j];
                }
            }
            return denseHash;
        }
    }
}
