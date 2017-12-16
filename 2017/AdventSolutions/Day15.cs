using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    public class Day15 : AdventDay
    {
        private const long GENERATOR_A_FACTOR = 16807L;
        private const long GENERATOR_B_FACTOR = 48271L;
        private const int GENERATOR_A_INITIAL = 591;
        private const int GENERATOR_B_INITIAL = 393;
        private const long DIVISOR = 2147483647L;
        private const int GENERATOR_A_MULTIPLES = 4;
        private const int GENERATOR_B_MULTIPLES = 8;
        private const long PART1_PAIRS = 40000000L;
        private const long PART2_PAIRS = 5000000L;

        public static int MatchingPairs(int initialA, int initialB, long numberOfPairs)
        {
            int matches = 0;
            long genA = initialA;
            long genB = initialB;
            for (long i = 0; i < numberOfPairs; ++i)
            {
                genA *= GENERATOR_A_FACTOR;
                genA %= DIVISOR;
                genB *= GENERATOR_B_FACTOR;
                genB %= DIVISOR;
                if (genA << 48 >> 48 == genB << 48 >> 48)
                    ++matches;
            }
            return matches;
        }

        public static int MatchingPairsWithMultiples(int initialA, int initialB, long numberOfPairs, int multipleA, int multipleB)
        {
            int matches = 0;
            long genA = initialA;
            long genB = initialB;
            for (long i = 0; i < numberOfPairs; ++i)
            {
                do
                {
                    genA *= GENERATOR_A_FACTOR;
                    genA %= DIVISOR;
                } while (genA % multipleA != 0);
                do
                {
                    genB *= GENERATOR_B_FACTOR;
                    genB %= DIVISOR;
                } while (genB % multipleB != 0);
                if (genA << 48 >> 48 == genB << 48 >> 48)
                    ++matches;
            }
            return matches;
        }

        protected override int Number => 15;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/15
            Console.WriteLine("Answer to Part 1:");
            Console.WriteLine(MatchingPairs(GENERATOR_A_INITIAL, GENERATOR_B_INITIAL, PART1_PAIRS));
            Console.WriteLine("Answer to Part 2:");
            Console.WriteLine(MatchingPairsWithMultiples(GENERATOR_A_INITIAL, GENERATOR_B_INITIAL, PART2_PAIRS, GENERATOR_A_MULTIPLES, GENERATOR_B_MULTIPLES));
        }
    }
}
