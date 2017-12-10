using System;
using System.IO;

namespace AdventSolutions
{
    public class Day9 : AdventDay
    {
        protected override int Number => 9;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/9
            var lines = File.ReadLines(FileUtils.PromptForExistingFilePath());
            Console.WriteLine("Answer to Part 1:");
            foreach (string line in lines)
            {
                Console.WriteLine(ScoreOfStream(line).Score);
            }
            Console.WriteLine("Answer to Part 2:");
            foreach (string line in lines)
            {
                Console.WriteLine(ScoreOfStream(line).GarbageCount);
            }
        }

        public static (int Score, int GarbageCount) ScoreOfStream(string stream)
        {
            int score = 0;
            int currentGroupLevel = 0;
            bool inGarbage = false;
            int garbageRemoved = 0;
            for (int i = 0; i < stream.Length; ++i)
            {
                if (!inGarbage && stream[i] == '{')
                    score += ++currentGroupLevel;
                else if (!inGarbage && stream[i] == '}')
                    --currentGroupLevel;
                else if (!inGarbage && stream[i] == '<')
                    inGarbage = true;
                else if (inGarbage && stream[i] == '>')
                    inGarbage = false;
                else if (inGarbage && stream[i] == '!')
                    ++i;
                else if (inGarbage)
                    ++garbageRemoved;
            }
            return (score, garbageRemoved);
        }
    }
}
