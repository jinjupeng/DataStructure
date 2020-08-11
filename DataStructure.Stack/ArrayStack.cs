using System;
using System.Collections;

namespace DataStructure
{

    /*
    stack是一种先进后出的数据结构
    使用泛型数组实现栈的peek、pop、push和栈的长度
     */
    public class ArrayStack<T>: IEnumerable
    {
        private T[] _memory;

        private int _size;

        public ArrayStack(int capacity)
        {
            Rebuild(capacity);
        }

        public void Clear()
        {
            _size = 0;
        }

        private void Rebuild(int capacity)
        {
            _memory = new T[capacity];
            _size = 0;
        }

        public T Pop()
        {
            var val = Peek();
            _size--;
            return val;
        }

        private T Peek()
        {
            if (Size() == 0)
            {
                throw new System.Exception("empty stack");
            }
            return _memory[Size() - 1];
        }

        public void Push(T val)
        {
            if (Size() == Capacity())
            {
                throw new System.Exception("stack overflow");
            }
            _memory[Size()] = val;
            _size++;
        }

        public int Capacity()
        {
            return _memory.Length;
        }

        private int Size()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        /// <summary>
        /// 用yield关键字构建迭代器方法,支持foreach枚举的自定义集合
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var memory in _memory)
            {
                yield return memory;
            }
        }
    }
}
