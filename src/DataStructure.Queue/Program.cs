using System;
using DataStructure.Queue.ImplementByArray;
using DataStructure.Queue.ImplementByDoubleStack;
using DataStructure.Queue.ImplementByLinkedList;

namespace DataStructure.Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyDoubleStackQueueTest();
            // MyArrayQueueTest();
            // MyLinkedListQueueTest();
            MyCircularQueueTest();
        }

        #region 双栈实现队列

        static void MyDoubleStackQueueTest()
        {
            var doubleStackQueue = new MyDoubleStackQueue<int>();
            doubleStackQueue.Push(1);
            var size = doubleStackQueue.Empty();
            Console.WriteLine("size: " + size);
        }

        #endregion

        #region 数组实现队列测试

        static void MyArrayQueueTest()
        {
            var arrayQueue = new MyArrayQueue<int>(10);
            arrayQueue.Enqueue(1);
            arrayQueue.Enqueue(2);
            var result = arrayQueue.Dequeue();
            var isEmpty = arrayQueue.IsEmpty();
            Console.WriteLine("result：" + result);
            Console.WriteLine("isEmpty：" + isEmpty);
        }

        #endregion

        #region 链表实现队列测试

        static void MyLinkedListQueueTest()
        {
            var linkedListQueue = new MyLinkedListQueue<int>();
            linkedListQueue.Enqueue(1);
            // linkedListQueue.Enqueue(2);
            // linkedListQueue.Enqueue(3);
            var result = linkedListQueue.Dequeue();
            var isEmpty = linkedListQueue.IsEmpty();
            Console.WriteLine("result：" + result);
            Console.WriteLine("isEmpty：" + isEmpty);
        }

        #endregion

        #region 数组实现循环队列测试

        public static void MyCircularQueueTest()
        {
            var circularQueue = new MyCircularQueue(3); // 设置长度为 3
            var a1 = circularQueue.EnQueue(1);  // 返回 true
            var a2 = circularQueue.EnQueue(2);  // 返回 true
            var a3 = circularQueue.EnQueue(3);  // 返回 true
            var a4 = circularQueue.EnQueue(4);  // 返回 false，队列已满
            var a5 = circularQueue.Rear();  // 返回 3
            var a6 = circularQueue.IsFull();  // 返回 true
            var a7 = circularQueue.DeQueue();  // 返回 true
            var a8 = circularQueue.EnQueue(4);  // 返回 true
            var a9 = circularQueue.Rear();  // 返回 4
            circularQueue.PrintAll();
        }

        #endregion
    }
}
