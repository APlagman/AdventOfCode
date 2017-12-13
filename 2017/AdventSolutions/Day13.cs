using System;
using System.IO;

namespace AdventSolutions
{
    public class Day13 : AdventDay
    {
        protected override int Number => 13;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/13
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath());
            Firewall firewall = new Firewall();
            foreach (string line in input)
            {
                string[] args = line.Split(':');
                firewall.AddLayer(int.Parse(args[0]), int.Parse(args[1].TrimStart(' ')));
            }
            Console.WriteLine("Answer to Part 1:");
            Console.WriteLine(firewall.Pass().Severity);
            Console.WriteLine("Answer to Part 2:");
            Console.WriteLine(firewall.MinimumDelay());
        }
    }
}
