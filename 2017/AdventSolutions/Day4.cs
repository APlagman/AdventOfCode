using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace AdventSolutions
{
    public class Day4 : AdventDay
    {
        protected override int Number => 4;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/4
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath()); Console.WriteLine("Answer to Part 1:");
            int lineNum = 0;
            int validCount = 0;
            foreach (string line in input)
            {
                if (line.Equals(""))
                {

                    lineNum++;
                    continue;
                }
                bool isValidPhrase = AreAllWordsDistinct(line);
                Console.WriteLine($"Line {lineNum}: {isValidPhrase}");
                    lineNum++;
                if (isValidPhrase)
                    ++validCount;
            }
            Console.WriteLine(validCount);
            Console.ReadLine();

            Console.WriteLine("Answer to Part 2:");
            lineNum = 0;
            validCount = 0;
            foreach (string line in input)
            {
                if (line.Equals(""))
                {

                    lineNum++;
                    continue;
                }
                bool isValidPhrase = AreNoWordsAnagrams(line);
                Console.WriteLine($"Line {lineNum}: {isValidPhrase}");
                lineNum++;
                if (isValidPhrase)
                    ++validCount;
            }
            Console.WriteLine(validCount);
        }

        public static bool AreAllWordsDistinct(string line)
        {
            string[] words = line.Split(' ');
            if (words.Length <= 1)
                return true;
            var distinctWords = words.Distinct();
            return (distinctWords.Count() == words.Count());
        }

        public static bool AreNoWordsAnagrams(string line)
        {
            string[] words = line.Split(' ');
            if (words.Length <= 1)
                return true;
            List<string> anagrams = new List<string>(words.Length);
            foreach (string word in words.Distinct())
                anagrams.Add(String.Concat(word.OrderBy(c => c)));
            return (anagrams.Distinct().Count() == words.Count());
        }
    }
}
