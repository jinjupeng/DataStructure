using System;

namespace DataStructure.Queue.ImplementByArray
{
    /// <summary>
    /// 用数组实现顺序队列
    /// </summary>
    public class MyArrayQueue<T>
    {
        private readonly T[] _memory;
        private readonly int _size; // 数组的大小

        // head表示队头下标
        private int _head = 0;

        // head表示队尾下标
        private int _tail = 0;

        /// <summary>
        /// 申请一个大小为capacity的数组
        /// </summary>
        /// <param name="capacity"></param>
        public MyArrayQueue(int capacity)
        {
            _memory = new T[capacity];
            _size = capacity;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Enqueue(T item)
        {
            // 如果tail == _size 表示队列已经满了
            if (_tail == _size)
            {
                return false;
            }

            _memory[_tail] = item;
            ++_tail;
            return true;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            // 如果head == tail 表示队列为空
            if (_head == _tail) return default(T);

            T ret = _memory[_head];
            ++_head;
            return ret;
        }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _head == _tail;
        }
    }
}