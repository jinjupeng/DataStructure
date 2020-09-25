using System;

namespace DataStructure.Sort.SortImpl
{
    public class QuickSort<T> where T : IComparable
    {
        public static void QuickSortImpl(T[] arr, int low, int high)
        {
            if (low >= high) return;
            var index = Partition(arr, low, high);
            // 对左区间递归排序
            QuickSortImpl(arr, low, index - 1);
            // 对右区间递归排序
            QuickSortImpl(arr, index + 1, high);
        }

        private static int Partition(T[] arr, int low, int high)
        {
            int i = low, j = high;
            var temp = arr[i]; // 确定第一个元素作为"基准值"

            while (i < j)
            {
                // Stage1:从右向左扫描直到找到比基准值小的元素
                while (i < j && arr[j].CompareTo(temp) >= 0)
                {
                    j--;
                }
                // 将比基准值小的元素移动到基准值的左端
                arr[i] = arr[j];

                // Stage2:从左向右扫描直到找到比基准值大的元素
                while (i < j && arr[i].CompareTo(temp) <= 0)
                {
                    i++;
                }
                // 将比基准值大的元素移动到基准值的右端
                arr[j] = arr[i];
            }

            // 记录归位
            arr[i] = temp;

            return i;
        }
    }
}