using System;

namespace AdventSolutions
{
    abstract class AdventDay
    {
        public void Run()
        {
            Console.WriteLine($"Running Day {Day}{Environment.NewLine}");
            RunImpl();
            Console.WriteLine($"{Environment.NewLine}Press Enter to continue...");
            Console.ReadLine();
        }
        protected abstract void RunImpl();
        protected abstract int Day { get; }
    }
}