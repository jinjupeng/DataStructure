using System;

namespace DataStructure.Queue
{
    /// <summary>
    /// 数组实现循环队列
    /// </summary>
    public class MyCircularQueue
    {
        private readonly int[] _items; 
        private readonly int _length; // 循环队列的最大长度
        private int _count; // 循环队列中元素个数

        // head表示队头下标，tail表示队尾下标
        private int _head;
        private int _tail;

        /// <summary>
        /// 构造函数，初始化队列长度为k
        /// </summary>
        /// <param name="k"></param>
        public MyCircularQueue(int k)
        {
            _items = new int[k];
            _length = k;
            _count = 0;
        }

        /// <summary>
        /// 向循环队列插入一个元素。如果成功插入则返回真
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool EnQueue(int value)
        {
            if (IsFull()) return false;
            // 插入元素到队尾
            _items[_tail] = value;
            // 队尾索引值+1
            _tail = (_tail + 1) % _length;
            // 元素个数+1
            _count++;
            return true;
        }

        /// <summary>
        /// 从循环队列中删除一个元素。如果成功删除则返回真
        /// </summary>
        /// <returns></returns>
        public bool DeQueue()
        {
            if (IsEmpty()) return false;
            // 队头索引值+1
            _head = (_head + 1) % _length;
            // 元素个数-1
            _count--;
            return true;
        }

        /// <summary>
        /// 从队首获取元素。如果队列为空，返回 -1 
        /// </summary>
        /// <returns></returns>
        public int Front()
        {
            if (!IsEmpty())
            {
                return _items[_head];
            }
            return -1;
        }

        /// <summary>
        /// 获取队尾元素。如果队列为空，返回 -1 
        /// </summary>
        /// <returns></returns>
        public int Rear()
        {
            if (IsEmpty()) return -1;
            // 队尾元素位于队尾索引值减一的位置，但若队尾循环到索引 0 的位置，队尾元素位于数组最后
            var temp = _tail == 0 ? _length - 1 : _tail - 1;
            return _items[temp];
        }

        /// <summary>
        /// 检查循环队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            // 队列中元素个数为0，队列空
            return _count == 0;
        }

        /// <summary>
        /// 检查循环队列是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            // 队列元素个数为数组最大长度，队列满
            return _count == _length;
        }

        /// <summary>
        /// 打印循环队列中的所有元素
        /// </summary>
        public void PrintAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列为空");
                return;
            }

            Console.Write("循环队列元素: ");
            int current = _head;
            for (int i = 0; i < _count; i++)
            {
                Console.Write(_items[current]);
                if (i < _count - 1)
                {
                    Console.Write(" -> ");
                }
                current = (current + 1) % _length;
            }
            Console.WriteLine();
        }
    }
}