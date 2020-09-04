using System.Collections.Generic;

namespace DataStructure.Stack.ImplementByQueue
{
    /// <summary>
    /// 用队列实现栈
    /// </summary>
    public class MyQueueStack
    {
        private readonly Queue<int> _inputQueue;
        /** Initialize your data structure here. */
        public MyQueueStack()
        {
            _inputQueue = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            _inputQueue.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            var size = _inputQueue.Count - 1;
            for (int i = 0; i < size; i++)
            {
                var data = _inputQueue.Peek();
                _inputQueue.Dequeue();
                _inputQueue.Enqueue(data);
            }

            return _inputQueue.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            var size = _inputQueue.Count - 1;
            for (int i = 0; i < size; i++)
            {
                var data = _inputQueue.Peek();
                _inputQueue.Dequeue();
                _inputQueue.Enqueue(data);
            }

            var value = _inputQueue.Peek();
            _inputQueue.Dequeue();
            _inputQueue.Enqueue(value);
            return value;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return _inputQueue.Count == 0;
        }
    }
}