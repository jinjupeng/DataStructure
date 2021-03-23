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
        /// 第一种堆化方式：自底向上堆化
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            if (_count >= _capacity) // 堆满了
            {
                return;
            }

            ++_count;
            _array[_count] = data; // 将值data置于数组末尾

            var i = _count;
            // 如果i节点有父节点，且比父节点的值大
            while (i / 2 > 0 && _array[i] > _array[i / 2])
            {
                // 交换i与父节点的值
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
                // 假设index位置是最大值位置
                var maxPos = index;

                // 如果index位置节点有左节点，且比左节点值小
                if (index * 2 <= count && array[index] < array[index * 2])
                {
                    // 左节点成最大值
                    maxPos = index * 2;
                }

                // 如果index位置节点有右节点，且最大值节点小于右节点
                if (index * 2 + 1 <= count && array[maxPos] < array[index * 2 + 1])
                {
                    // 右节点成最大值
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