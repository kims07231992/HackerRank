using System;
using System.Collections.Generic;

namespace A_Tale_of_Two_Stacks
{
    internal class Program
    {
        private static Stack<string> _pushStack = new Stack<string>();
        private static Stack<string> _dequeueStack = new Stack<string>();

        private static void Main(string[] args)
        {
            string countString = Console.ReadLine();
            int count = int.Parse(countString);

            for (int i = 0; i < count; i++)
            {
                string s = Console.ReadLine();
                string[] numbers = s.Split(' ');

                if (numbers[0] == "1")
                {
                    _pushStack.Push(numbers[1]);
                }
                else if (numbers[0] == "2")
                {
                    if (IsDequeueStackEmpty())
                    {
                        MoveFromPushStackToDequeueStack();
                    }
                    Dequeue();
                }
                else
                {
                    if (IsDequeueStackEmpty())
                    {
                        MoveFromPushStackToDequeueStack();
                    }
                    string itemToPrint = Front();
                    Console.WriteLine(itemToPrint);
                }
            }
        }

        private static void MoveFromPushStackToDequeueStack()
        {
            int length = _pushStack.Count;
            for (int j = 0; j < length; j++)
            {
                string item = _pushStack.Pop();
                _dequeueStack.Push(item);
            }
        }

        private static void Push(string item)
        {
            _pushStack.Push(item);
        }

        private static void Dequeue()
        {
            _dequeueStack.Pop();
        }

        private static string Front()
        {
           return  _dequeueStack.Peek();
        }

        private static bool IsDequeueStackEmpty()
        {
            return _dequeueStack.Count == 0;
        }
    }
}
