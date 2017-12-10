using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventSolutions
{
    public class Day6 : AdventDay
    {
        protected override int Number => 6;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/6
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath()); Console.WriteLine("Answer to Part 1:");
            foreach (string line in input)
            {
                string[] vals = line.Split('\t');
                int[] currentBanks = new int[vals.Length];
                for (int i = 0; i < vals.Length; ++i)
                {
                    if (int.TryParse(vals[i], out int bank))
                        currentBanks[i] = bank;
                    else
                        throw new ArgumentException("Bad input: not an integer.");
                }

                Console.WriteLine(RedistributionCycles(currentBanks.ToArray()));
            }

            Console.WriteLine("Answer to Part 2:");
            foreach (string line in input)
            {
                string[] vals = line.Split('\t');
                int[] currentBanks = new int[vals.Length];
                for (int i = 0; i < vals.Length; ++i)
                {
                    if (int.TryParse(vals[i], out int bank))
                        currentBanks[i] = bank;
                    else
                        throw new ArgumentException("Bad input: not an integer.");
                }

                Console.WriteLine(CycleLength(currentBanks.ToArray()));
            }
        }

        public static int RedistributionCycles(int[] banks)
        {
            int numBanks = banks.Length;
            int distributionCount = 0;
            var seen = new List<int[]>();
            while (seen.Find(seenBanks => ArraysEqual(seenBanks, banks)) == null)
            {
                seen.Add(banks.ToArray());

                int maxBankIndex = 0;
                for (int i = 1; i < numBanks; ++i)
                    if (banks[i] > banks[maxBankIndex])
                        maxBankIndex = i;
                int toDistribute = banks[maxBankIndex];
                banks[maxBankIndex] = 0;

                int remaining = toDistribute;
                int valToAddToEachBank = (int)Math.Ceiling(toDistribute / (double)numBanks);
                for (int i = maxBankIndex + 1; remaining > 0; ++i)
                {
                    i %= numBanks;
                    if (remaining < valToAddToEachBank)
                    {
                        banks[i] += remaining;
                        remaining = 0;
                    }
                    else
                    {
                        banks[i] += valToAddToEachBank;
                        remaining -= valToAddToEachBank;
                    }
                }
                ++distributionCount;
            }

            return distributionCount;
        }

        public static int CycleLength(int[] banks)
        {
            int numBanks = banks.Length;
            int distributionCount = 0;
            var seen = new List<int[]>();
            while (seen.Find(seenBanks => ArraysEqual(seenBanks, banks)) == null)
            {
                seen.Add(banks.ToArray());

                int maxBankIndex = 0;
                for (int i = 1; i < numBanks; ++i)
                    if (banks[i] > banks[maxBankIndex])
                        maxBankIndex = i;
                int toDistribute = banks[maxBankIndex];
                banks[maxBankIndex] = 0;

                int remaining = toDistribute;
                int valToAddToEachBank = (int)Math.Ceiling(toDistribute / (double)numBanks);
                for (int i = maxBankIndex + 1; remaining > 0; ++i)
                {
                    i %= numBanks;
                    if (remaining < valToAddToEachBank)
                    {
                        banks[i] += remaining;
                        remaining = 0;
                    }
                    else
                    {
                        banks[i] += valToAddToEachBank;
                        remaining -= valToAddToEachBank;
                    }
                }
                ++distributionCount;
            }

            return distributionCount - seen.IndexOf(seen.Find(seenBanks => ArraysEqual(seenBanks, banks)));
        }

        public static bool ArraysEqual(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs != lhs 
                || rhs == null && rhs != lhs
                || lhs.Length != rhs.Length)
                return false;

            for (int i = 0; i < lhs.Length; ++i)
            {
                if (lhs[i] != rhs[i])
                    return false;
            }
            return true;
        }
    }
}
