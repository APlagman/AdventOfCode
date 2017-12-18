using System;
using System.IO;

namespace AdventSolutions
{
    public class Day16 : AdventDay
    {
        protected override int Number => 16;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/16
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath());
            Console.WriteLine("Answer to Part 1:");
            foreach (string line in input)
            {
                string[] moves = line.Split(',');
                Console.WriteLine(Dance('p', moves));
            }
            Console.WriteLine("Answer to Part 2:");
            foreach (string line in input)
            {
                string[] moves = line.Split(',');
                Console.WriteLine(Dance('p', moves, (int)1e9));
            }
        }

        public static string Dance(char lastLetter, string[] moves, int times = 1)
        {
            string str = "a";
            for (char c = 'b'; c <= lastLetter; ++c)
                str += c;

            string result = str;
            for (int t = 0; t < times; ++t)
            {
                foreach (string move in moves)
                {
                    switch (move[0])
                    {
                        case 's':
                            {
                                int numberToSpin = int.Parse(move.Substring(1));
                                result = result.Substring(result.Length - numberToSpin) + result.Substring(0, result.Length - numberToSpin);
                                break;
                            }
                        case 'x':
                            {
                                string[] parts = move.Substring(1).Split('/');
                                int a = int.Parse(parts[0]);
                                int b = int.Parse(parts[1]);
                                char charA = result[a];
                                char charB = result[b];
                                result = result.Replace(result[a], '$');
                                result = result.Replace(result[b], charA);
                                result = result.Replace('$', charB);
                                break;
                            }
                        case 'p':
                            {
                                string[] parts = move.Substring(1).Split('/');
                                string a = parts[0];
                                string b = parts[1];
                                result = result.Replace(a[0], '$');
                                result = result.Replace(b[0], a[0]);
                                result = result.Replace('$', b[0]);
                                break;
                            }
                    }
                }
                if (result.Equals(str))
                {
                    times %= (t + 1);
                    t = -1;
                }
            }

            return result;
        }
    }
}
