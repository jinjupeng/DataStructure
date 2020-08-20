using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Queue.ImplementByDoubleStack
{
    /// <summary>
    /// 双栈实现队列
    /// </summary>
    public class MyDoubleStackQueue<T>
    {
        private readonly Stack<T> _stack1;
        private readonly Stack<T> _stack2;

        /** Initialize your data structure here. */
        public MyDoubleStackQueue()
        {
            _stack1 = new Stack<T>();
            _stack2 = new Stack<T>();
        }

        /** Push element x to the back of queue. */
        public void Push(T t)
        {
            _stack1.Push(t);
            this.Size = 0;
        }

        /** Removes the element from in front of queue and returns that element. */
        public T Pop()
        {
            foreach (var item in _stack1)
            {
                _stack2.Push(item);
            }

            var value = _stack2.Pop();
            _stack1.Clear();
            foreach (var item in _stack2)
            {
                _stack1.Push(item);
            }
            _stack2.Clear();
            Size = _stack1.Count;
            return value;
        }

        /** Get the front element. */
        public T Peek()
        {
            foreach (var item in _stack1)
            {
                _stack2.Push(item);
            }
            var value = _stack2.Peek();
            _stack2.Clear();
            Size = _stack1.Count;
            return value;
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return Size == 0;
        }

        /// <summary>
        /// 队列大小
        /// </summary>
        public int Size
        {
            get;
            private set;
        }
    }
}