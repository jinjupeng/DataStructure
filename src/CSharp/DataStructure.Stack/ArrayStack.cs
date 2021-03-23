using System.Collections;

namespace DataStructure.Stack
{

    /// <summary>
    /// stack是一种先进后出的数据结构，使用泛型数组实现栈的peek、pop、push和栈的长度
    /// 基于数组实现的顺序栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayStack<T>: IEnumerable
    {
        private T[] _memory; // 数组

        private int _size; // 栈的大小


        /// <summary>
        /// 初始化数组，申请一个大小为capacity的数组空间
        /// </summary>
        /// <param name="capacity"></param>
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

        /// <summary>
        /// 移除并返回最近添加的元素
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 向栈中添加一个新的元素
        /// </summary>
        /// <param name="val"></param>
        public void Push(T val)
        {
            if (Size() == Capacity())
            {
                throw new System.Exception("stack overflow");
            }
            _memory[Size()] = val;
            _size++;
        }

        /// <summary>
        /// 栈的容量大小
        /// </summary>
        /// <returns></returns>
        public int Capacity()
        {
            return _memory.Length;
        }

        /// <summary>
        /// 栈中元素个数
        /// </summary>
        /// <returns></returns>
        private int Size()
        {
            return _size;
        }

        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns></returns>
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
