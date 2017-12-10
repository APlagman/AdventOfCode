using System;

namespace AdventSolutions
{
    public abstract class AdventDay
    {
        public void Run()
        {
            Console.WriteLine($"Running Day {Number}{Environment.NewLine}");
            RunImpl();
            Console.WriteLine($"{Environment.NewLine}Press Enter to continue...");
            Console.ReadLine();
        }
        protected abstract void RunImpl();
        protected abstract int Number { get; }
    }
}