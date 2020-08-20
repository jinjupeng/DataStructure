using System;
using DataStructure.Queue.ImplementByDoubleStack;

namespace DataStructure.Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var doubleStackQueue = new MyDoubleStackQueue<int>();
            doubleStackQueue.Push(1);
            doubleStackQueue.Push(2);
            doubleStackQueue.Push(3);
            doubleStackQueue.Push(4);
            doubleStackQueue.Push(5);
            doubleStackQueue.Push(6);
            var value1 = doubleStackQueue.Pop();
            var value2 = doubleStackQueue.Peek();
            var value3 = doubleStackQueue.Pop();
            var size = doubleStackQueue.Size;
            Console.WriteLine("Hello World!");
        }
    }
}
