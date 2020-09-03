using System;

namespace DataStructure.Queue.ImplementByArray
{
    /// <summary>
    /// 动态数组实现队列
    /// </summary>
    public class MyDynamicArrayQueue
    {
        // 数组：items，数组大小：n
        private string[] items;
        private int n = 0;

        // head表示队头下标，tail表示队尾下标
        private int _head = 0;
        private int _tail = 0;

        // 申请一个大小为capacity的数组
        public MyDynamicArrayQueue(int capacity)
        {
            items = new string[capacity];
            n = capacity;
        }

        // 入队操作，将item放入队尾
        public bool Enqueue(string item)
        {
            // tail == n表示队列末尾没有空间了
            if (_tail == n)
            {
                // tail ==n && head==0，表示整个队列都占满了
                if (_head == 0) return false;
                // 数据搬移
                for (int i = _head; i < _tail; ++i)
                {
                    items[i - _head] = items[i];
                }
                // 搬移完之后重新更新head和tail
                _tail -= _head;
                _head = 0;
            }

            items[_tail] = item;
            _tail++;
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
            ++_head;
            return ret;
        }

        public void PrintAll()
        {
            for (int i = _head; i < _tail; ++i)
            {
                Console.WriteLine(items[i] + " ");
            }
            Console.ReadLine();
        }
    }
}