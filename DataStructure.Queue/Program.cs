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
            var size = doubleStackQueue.Empty();
            Console.WriteLine("Hello World!");
        }
    }
}
