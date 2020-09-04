using System;

namespace DataStructure.Heap
{
    /// <summary>
    /// 一维数组实现堆
    /// </summary>
    public class MyHeapByArray
    {
        private readonly int[] _array; // 从下标1开始存储数据
        private readonly int _capacity; // 堆可以存储的最大数据个数
        private int _count; // 堆中已经存储的数据个数

        /// <summary>
        /// 初始化堆
        /// </summary>
        /// <param name="capacity"></param>
        public MyHeapByArray(int capacity)
        {
            _array = new int[capacity + 1];
            _capacity = capacity;
            _count = 0;
        }

        /// <summary>
        /// 堆中插入一个元素
        /// 第一种堆化方式：自下往上堆化
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            if (_count >= _capacity) // 堆满了
            {
                return;
            }

            ++_count;
            _array[_count] = data;

            var i = _count;
            while (i / 2 > 0 && _array[i] > _array[i / 2])
            {
                Swap(_array, i, i / 2); // swap()函数作用：交换下标为i和i/2的两个元素
                i = i / 2;
            }
        }

        /// <summary>
        /// 移除堆顶元素
        /// </summary>
        /// <returns>返回移除的堆顶元素</returns>
        public void RemoveMax()
        {
            if (_count == 0)
            {
                return; // 堆中没有数据
            }

            _array[1] = _array[_count];
            --_count;
            // 从数组下标1开始堆化
            Heapify(_array, _count, 1);
        }

        /// <summary>
        /// 第二种堆化方式：自上往下堆化
        /// </summary>
        /// <param name="array"></param>
        /// <param name="count">数组中保存的堆元素个数</param>
        /// <param name="index">数组下标索引</param>
        private void Heapify(int[] array, int count, int index)
        {
            /*
             * 注意：堆的顶点保存在下标为1的位置
             * 以数组下标为i的节点为基准：
             * 它的左子节点下标位置：i * 2;
             * 它的右子节点下标位置：i * 2 + 1；
             * 它的父节点下标位置：i / 2;
             */
            while (true)
            {
                var maxPos = index;

                if (index * 2 <= count && array[index] < array[index * 2])
                {
                    maxPos = index * 2;
                }

                if (index * 2 + 1 <= count && array[maxPos] < array[index * 2 + 1])
                {
                    maxPos = index * 2 + 1;
                }

                if (maxPos == index)
                {
                    break;
                } 
                Swap(array, index, maxPos);
                index = maxPos;
            }
        }

        /// <summary>
        /// 交换两个元素
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Swap(int[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        public void PrintAll()
        {
            Console.Write("打印堆中保存的数据：");
            if (0 == _count) return;
            foreach (var i in _array)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }

}