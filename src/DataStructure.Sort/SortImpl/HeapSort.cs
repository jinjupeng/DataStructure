using System;

namespace DataStructure.Sort.SortImpl
{
    public class HeapSort<T> where T : IComparable
    {
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSortImpl(T[] arr)
        {
            var n = arr.Length; // 获取序列的长度
            // 构造初始堆
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Sift(arr, i, n - 1);
            }
            // 进行堆排序
            for (int i = n - 1; i >= 1; i--)
            {
                var temp = arr[0];
                arr[0] = arr[i];     // 将堆中最后一个元素移动到堆顶
                arr[i] = temp;       // 最大元素归位,下一次不会再参与计算

                Sift(arr, 0, i - 1); // 重新递归调整堆
            }
        }

        private static void Sift(T[] arr, int low, int high)
        {
            // i为欲调整子树的根节点索引号，j为这个节点的左孩子
            int i = low, j = 2 * i + 1;
            // temp记录根节点的值
            var temp = arr[i];

            while (j <= high)
            {
                // 如果左孩子小于右孩子，则将要交换的孩子节点指向右孩子
                if (j < high && arr[j].CompareTo(arr[j + 1]) < 0)
                {
                    j++;
                }
                // 如果根节点小于它的孩子节点
                if (temp.CompareTo(arr[j]) < 0)
                {
                    arr[i] = arr[j]; // 交换根节点与其孩子节点
                    i = j;  // 以交换后的孩子节点作为根节点继续调整其子树
                    j = 2 * i + 1;  // j指向交换后的孩子节点的左孩子
                }
                else
                {
                    // 调整完毕，可以直接退出
                    break;
                }
            }
            // 使最初被调整的节点存入正确的位置
            arr[i] = temp;
        }
    }
}