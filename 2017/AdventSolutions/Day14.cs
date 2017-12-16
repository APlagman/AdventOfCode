using System;

namespace AdventSolutions
{
    public class Day14 : AdventDay
    {
        private const string INPUT = "oundnydw";

        protected override int Number => 14;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/14
            Console.WriteLine("Answer to Part 1:");
            Console.WriteLine(UsedSquares(INPUT));
            Console.WriteLine("Answer to Part 2:");
            Console.WriteLine(NumberOfRegions(INPUT));
        }

        public static int UsedSquares(string key)
        {
            char[,] disk = new char[128, 128];
            for (int row = 0; row < 128; ++row)
            {
                string knotHash = Day10.KnotHash(key + "-" + row.ToString());
                for (int c = 0; c < 32; ++c)
                {
                    int digit = Convert.ToInt32(knotHash[c].ToString(), 16);
                    for (int bit = 0; bit < 4; ++bit)
                    {
                        disk[row, c * 4 + bit] = ((digit & (1 << bit)) > 0) ? '#' : '.';
                    }
                }
            }
            int usedSquares = 0;
            foreach (char square in disk)
            {
                if (square == '#')
                    ++usedSquares;
            }
            return usedSquares;
        }

        public static int NumberOfRegions(string key)
        {
            char[,] disk = new char[128, 128];
            for (int row = 0; row < 128; ++row)
            {
                string knotHash = Day10.KnotHash(key + "-" + row.ToString());
                for (int c = 0; c < 32; ++c)
                {
                    int digit = Convert.ToInt32(knotHash[c].ToString(), 16);
                    for (int bit = 0; bit < 4; ++bit)
                        disk[row, c * 4 + (3 - bit)] = ((digit & (1 << bit)) > 0) ? '#' : '.';
                }
            }
            int regions = 0;
            for (int r = 0; r < 128; ++r)
                for (int c = 0; c < 128; ++c)
                    Check(disk, r, c, ref regions, false);
            return regions;
        }

        private static void Check(char[,] disk, int row, int column, ref int regions, bool inRegion)
        {
            if (row < 0 || column < 0 || row >= 128 || column >= 128 || disk[row, column] != '#')
                return;
            disk[row, column] = 'r';
            if (!inRegion)
                ++regions;
            Check(disk, row - 1, column, ref regions, true);
            Check(disk, row + 1, column, ref regions, true);
            Check(disk, row, column - 1, ref regions, true);
            Check(disk, row, column + 1, ref regions, true);
        }
    }
}
