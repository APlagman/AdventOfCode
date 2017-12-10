using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    class Day7 : AdventDay
    {
        protected override int Number => 7;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/7
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath());

            LazilyConnectedTree<string> towers = new LazilyConnectedTree<string>();
            Console.WriteLine("Answer to Part 1:");
            foreach (string line in input)
            {
                string[] parts = line.Split(' ');
                if (parts.Length < 2 || parts.Length == 3)
                    throw new ArgumentException("Bad input.");
                string name = parts[0];
                if (int.TryParse(parts[1].Trim(new char[] { '(', ')' }), out int weight))
                {
                    if (parts.Length == 2)
                        towers.UpdateItem(name, weight, new List<string>());
                    else
                    {
                        List<string> children = new List<string>(parts.Length - 3);
                        for (int i = 3; i < parts.Length; ++i)
                            children.Add(parts[i].TrimEnd(','));
                        towers.UpdateItem(name, weight, children);
                    }
                }
                else
                    throw new ArgumentException("Bad input.");
            }
            Console.WriteLine(towers.Root);
            Console.WriteLine("Answer to Part 2:");
            Console.WriteLine(towers.FindImbalance().NewWeight);
        }
    }
}
