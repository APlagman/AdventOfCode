using QuickGraph;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventSolutions
{
    public class Day12 : AdventDay
    {
        protected override int Number => 12;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/12
            var input = File.ReadLines(FileUtils.PromptForExistingFilePath());
            List<HashSet<int>> groups = Groups(input);
            Console.WriteLine("Answer to Part 1:");
            Console.WriteLine(groups[0].Count);
            Console.WriteLine("Answer to Part 2:");
            Console.WriteLine(groups.Count);
        }

        public static List<HashSet<int>> Groups(IEnumerable<string> connections)
        {
            AdjacencyGraph<int, Edge<int>> graph = new AdjacencyGraph<int, Edge<int>>();
            foreach (string line in connections)
            {
                string[] args = line.Split(' ');
                int lhs = int.Parse(args[0]);
                List<int> rhs = new List<int>();
                for (int i = 2; i < args.Length; ++i)
                {
                    rhs.Add(int.Parse(args[i].TrimEnd(',')));
                }
                foreach (int other in rhs)
                {
                    graph.AddVertex(lhs);
                    graph.AddVertexRange(rhs);
                    graph.AddEdge(new Edge<int>(lhs, other));
                    graph.AddEdge(new Edge<int>(other, lhs));
                }
            }

            HashSet<int> seen = new HashSet<int>();
            List<HashSet<int>> groups = new List<HashSet<int>>();
            Queue<int> remaining = new Queue<int>();
            remaining.Enqueue(0);
            while (seen.Count != graph.VertexCount)
            {
                while (remaining.Count != 0)
                {
                    int current = remaining.Dequeue();
                    if (!seen.Contains(current))
                        seen.Add(current);
                    HashSet<int> groupToUse = groups.Find(group => group.Contains(current));
                    if (groupToUse == null)
                        groupToUse = new HashSet<int>();
                    else
                        groups.Remove(groupToUse);
                    groupToUse.Add(current);
                    foreach (Edge<int> edge in graph.OutEdges(current))
                    {
                        if (!seen.Contains(edge.Target))
                        {
                            remaining.Enqueue(edge.Target);
                            groupToUse.Add(edge.Target);
                            seen.Add(edge.Target);
                        }
                    }
                    groups.Add(groupToUse);
                }
                int? next = new List<int>(graph.Vertices).Find(vertex => !seen.Contains(vertex));
                if (next != null)
                    remaining.Enqueue(next.Value);
            }
            return groups;
        }
    }
}
