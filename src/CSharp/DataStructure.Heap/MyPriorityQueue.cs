using System;
using System.Collections.Generic;

namespace DataStructure.Heap
{
    /// <summary>
    /// 优先队列（PriorityQueue）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyPriorityQueue<T>
    {
        
        private readonly IComparer<T> _comparer;
        private T[] _heap;

        /// <summary>
        /// 堆中元素数量
        /// </summary>
        public int Count { get; private set; }
        public MyPriorityQueue() : this(null){ }
        public MyPriorityQueue(int capacity) : this(capacity, null) { }
        public MyPriorityQueue(IComparer<T> comparer) : this(16, comparer) { }

        public MyPriorityQueue(int capacity, IComparer<T> comparer)
        {
            this._comparer = (comparer == null) ? Comparer<T>.Default : comparer;
            this._heap = new T[capacity];
        }

        /// <summary>
        /// 在数组的末尾插入新的元素，然后执行SiftUp操作
        /// </summary>
        /// <param name="v"></param>
        public void Push(T v)
        {
            if (Count >= _heap.Length)
            {
                Array.Resize(ref _heap, Count * 2);
            }
            _heap[Count] = v;
            SiftUp(Count++);
        }

        /// <summary>
        /// 删除指定位置的元素，用数组末尾的元素代替。然后视情况执行SiftUp或者SiftDown操作（注意这两个操作是互斥的，只能执行其中之一）
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            var v = Top();
            _heap[0] = _heap[--Count];
            if (Count > 0)
            {
                SiftDown(0);
            }
            return v;
        }

        public T Top()
        {
            if (Count > 0)
            {
                return _heap[0];
            }
            throw new InvalidOperationException("优先队列为空");
        }

        private void SiftUp(int n)
        {
            var v = _heap[n];
            // n2是倒数第一个非叶子节点
            for (var n2 = n / 2; n > 0 && _comparer.Compare(v, _heap[n2]) > 0; n = n2, n2 /= 2)
            {
                _heap[n] = _heap[n2];
            }
            _heap[n] = v;
        }

        /// <summary>
        /// 优先队列中，在队列非空情况下移除数组中第一个元素，也就是下标为0的元素，
        /// 然后将数组中最后一个元素移到下标为0的位置，再将下标为0的新元素执行“下沉”操作
        /// </summary>
        /// <param name="n"></param>
        private void SiftDown(int n)
        {
            var v = _heap[n];
            for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && _comparer.Compare(_heap[n2 + 1], _heap[n2]) > 0)
                {
                    n2++;
                }

                if (_comparer.Compare(v, _heap[n2]) >= 0)
                {
                    break;
                }
                _heap[n] = _heap[n2];
            }
            _heap[n] = v;
        }
    }
}