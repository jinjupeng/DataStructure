using System;

namespace DataStructure.Array
{
    public class Array<T> where T : IComparable<T>
    {
        private T[] _data;

        /// <summary>
        /// 定义数组容量
        /// </summary>
        private readonly int _capacity;

        /// <summary>
        /// 定义数组中保存的实际个数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="capacity"></param>
        public Array(int capacity)
        {
            _data = new T[capacity];
            _capacity = capacity;
            Count = 0;
        }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Array() : this(10)
        {
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _data.Length)
                {
                    //... Out of range index Exception
                    throw new IndexOutOfRangeException("Index was outside the bounds of the list");
                }
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }

        /// <summary>
        /// 根据索引位置插入元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newElem"></param>
        public void Insert(int index, T newElem)
        {
            // 数组空间已满
            if (Count == _capacity)
            {
                throw new OutOfMemoryException("List has no more space");
            }

            // 插入位置不合法
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the list");
            }

            // to loop array from end until finding the target index
            for (var k = Count; k > index; k--)
            {
                _data[k] = _data[k - 1];
            }

            _data[index] = newElem;

            Count++;
        }

        /// <summary>
        /// 根据索引，找到数据中的元素并返回
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Find(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the list");
            }

            return _data[index];
        }

        /// <summary>
        /// search the node which matches specified value and return its index (index start from 0)
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public int IndexOf(T val)
        {
            if (Count == 0) return -1;
            if (_data[0].Equals(val)) return 0;
            if (_data[Count - 1].CompareTo(val) == 0) return Count - 1;

            var start = 1;
            while (start < Count - 1)
            {
                if (_data[start].CompareTo(val) == 0) return start;
                start++;
            }

            return -1;
        }

        /// <summary>
        /// 根据索引，删除数组中元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Delete(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException("Index must be in the bound of list");
            }

            if (index < Count - 1)
            {
                for (int k = index; k < Count; k++)
                {
                    _data[k] = _data[k + 1];
                }
            }

            Count--;

            return true;
        }

        /// <summary>
        /// 从数组中删除指定元素
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Delete(T val)
        {
            int index;
            for (index = 0; index < Count; index++)
            {
                if (_data[index].CompareTo(val) == 0) break;
            }

            if (index >= Count) return false;

            return Delete(index);
        }

        /// <summary>
        /// 清空数组
        /// </summary>
        public void Clear()
        {
            _data = new T[_capacity];
            Count = 0;
        }

        /// <summary>
        /// 判断数组是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// 显示数组中所有元素数据，仅供测试
        /// </summary>
        public void DisplayElements()
        {
            for(int i = 0; i < Count; i++)
            {
                Console.Write(_data[i] + " ");
            }
            Console.WriteLine();
        }
    }
}