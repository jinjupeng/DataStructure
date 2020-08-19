using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Queue.ImplementByStack
{
    /// <summary>
    /// 用栈实现队列
    /// </summary>
    public class MyStackQueue
    {
        private readonly Stack<int> _stack;
        /** Initialize your data structure here. */
        public MyStackQueue()
        {
            _stack = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            _stack.Push(x);

        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            var array = _stack.ToArray().Reverse().ToArray();
            var p = (int)array[0];
            _stack.Clear();
            for (int i = 1; i < array.Length; i++)
            {
                _stack.Push(array[i]);
            }
            return p;
        }

        /** Get the front element. */
        public int Peek()
        {
            var array = _stack.ToArray().Reverse().ToArray();
            return (int)array[0];
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return _stack.Count == 0;
        }
    }
}