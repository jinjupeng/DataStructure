using System;
using System.Collections.Generic;

namespace DataStructure.Heap
{
    class Program
    {
        static void Main(string[] args)
        {

            // BuildHeapTest();
            // HeapSortTest();
            // PriorityQueueTest();
            MSPriorityQueueTest();
        }

        #region 建堆测试

        public static void BuildHeapTest()
        {
            var heap = new MyHeapByArray(14);
            heap.Insert(33);
            heap.Insert(17);
            heap.Insert(21);
            heap.Insert(16);
            heap.Insert(13);
            heap.Insert(15);
            heap.Insert(9);
            heap.Insert(5);
            heap.Insert(6);
            heap.Insert(7);
            heap.Insert(8);
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(22);
            heap.PrintAll();
            heap.RemoveMax();
            heap.PrintAll();
        }

        #endregion

        #region 堆排序测试

        public static void HeapSortTest()
        {
            // 注意：因为堆顶元素存放在数组下标为1的位置，而元素100000所属下标为0，所以不参与排序运算
            var array = new int[] {100000, 23, 45, 56, 67, 12, 2, 89, 76, 90, 34 };
            var heap = new MyHeapSort();
            heap.HeapSort(array, 10);

            Console.Write("堆排序：");

            for (int i = 0; i < array.Length; i++)
            {
                if (i >= 1)
                {
                    Console.Write(array[i] + " ");
                }
            }
        }

        #endregion

        #region 优先队列测试

        public static void PriorityQueueTest()
        {
            
            var queue = new MyPriorityQueue<int>(5);
            queue.Push(12);
            queue.Push(23);
            queue.Push(11);
            queue.Push(21);
            queue.Pop();
            queue.Pop();
            queue.Pop();
            queue.Pop();
            var count = queue.Count;
        }

        #endregion

        #region 微软源代码优先队列测试

        public static void MSPriorityQueueTest()
        {

            var queue = new MSPriorityQueue<int>(5, new HeapCompare());
            queue.Push(12);
            queue.Push(23);
            queue.Push(11);
            queue.Push(21);
            queue.Pop();
            queue.Pop();
            queue.Pop();
            queue.Pop();
            var count = queue.Count;
        }

        #endregion

    }

    public class HeapCompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
            {
                return -1;
            }

            if (x == y)
            {
                return 0;
            }

            if (x < y)
            {
                return 1;
            }

            return default;
        }
    }

}
