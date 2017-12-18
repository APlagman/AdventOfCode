using System;

namespace AdventSolutions
{
    public class Day17 : AdventDay
    {
        private const int INPUT_STEPS = 343;

        protected override int Number => 17;

        protected override void RunImpl()
        {
            // http://adventofcode.com/2017/day/17
            Console.WriteLine("Answer to Part 1:");
            Console.WriteLine(CircularInsertAndFindNext(INPUT_STEPS, 2017));
            Console.WriteLine("Answer to Part 2:");
            Console.WriteLine(FindAfterZero(INPUT_STEPS, 50000000));
        }

        class Node
        {
            public int Value;
            public Node Next;
        }

        public static int CircularInsertAndFindNext(int steps, int final)
        {
            Node cur = new Node() { Value = 0 };
            cur.Next = cur;
            int length = 1;
            for (int t = 1; t <= final; ++t)
            {
                for (int i = 0; i < steps % length; ++i)
                    cur = cur.Next;
                cur.Next = new Node() { Value = t, Next = cur.Next };
                cur = cur.Next;
                ++length;
            }
            return cur.Next.Value;
        }

        public static int FindAfterZero(int steps, int final)
        {
            int length = 1;
            int result = 0;
            int position = 0;
            for (int t = 1; t <= final; ++t)
            {
                position = (position + steps) % length;
                ++position;
                if (position == 1)
                    result = t;
                ++length;
            }
            return result;
        }
    }
}
