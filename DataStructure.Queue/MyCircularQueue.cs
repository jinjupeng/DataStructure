using System;

namespace DataStructure.Queue
{
    /// <summary>
    /// 数组实现循环队列
    /// </summary>
    public class MyCircularQueue
    {
        // 数组：items，数组大小：n
        private string[] items;
        private int n = 0;

        // head表示队头下标，tail表示队尾下标
        private int _head = 0;
        private int _tail = 0;

        // 申请一个大小为capacity的数组
        public MyCircularQueue(int capacity)
        {
            items = new string[capacity];
            n = capacity;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Enqueue(string item)
        {
            // 队列满了
            if ((_tail + 1) % n == _head) return false;
            items[_tail] = item;
            _tail = (_tail + 1) % n;
            return true;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            // 如果head == tail 表示队列为空
            if (_head == _tail) return null;
            string ret = items[_head];
            _head = (_head + 1) % n;
            return ret;
        }

        public void PrintAll()
        {
            if (0 == n) return;
            for (int i = _head; i % n != _tail; i = (i + 1) % n)
            {
                Console.WriteLine(items[i] + " ");
            }

            Console.ReadLine();
        }
    }
}