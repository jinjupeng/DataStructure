namespace DataStructure.Heap
{
    public class MyHeapSort
    {
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="array">数组中的数据从下标1到count的位置的数据</param>
        /// <param name="count">堆保存的数据的个数</param>
        public void HeapSort(int[] array, int count)
        {
            BuildHeap(array, count);
            int k = count;
            while (k > 1)
            {
                Swap(array, 1, k);
                --k;
                Heapify(array, k, 1);
            }
        }

        /// <summary>
        /// 建堆
        /// </summary>
        /// <param name="array"></param>
        /// <param name="count"></param>
        private void BuildHeap(int[] array, int count)
        {
            for (int i = count / 2; i >= 1; --i)
            {
                Heapify(array, count, i);
            }
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
    }
}