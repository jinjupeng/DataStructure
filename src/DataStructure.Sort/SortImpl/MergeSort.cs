using System.Collections.Generic;

namespace DataStructure.Sort.SortImpl
{
    public class MergeSort
    {
		///<summary>
        /// 归并排序--稳定排序
        ///</summary>
        ///<param name="list">要排序的集合</param>
        ///<param name="low">下标开始位置，向右查找</param>
        ///<param name="high">下标开始位置，向左查找</param>
        public static void MergeSortImpl(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSortImpl(list, low, mid); // 左边归并排序，使得左子序列有序
                MergeSortImpl(list, mid + 1, high); // 右边归并排序，使得右子序列有序
                Merge(list, low, mid, high); // 将两个有序子列表合并操作
            }
        }

        private static void Merge(List<int> list, int low, int mid, int high)
        {
            // listTmp为临时存放空间，存放合并后的数据
            List<int> listTmp = new List<int>(list.Count);

            #region 为空list赋值，因为空list不能直接用下标赋值，会报错

            for (int x = 0; x < list.Count; x++)
            {
                listTmp.Add(0);
            }

            #endregion


            int i = low;
            int j = mid + 1; // 右序列下标
            int k = 0;// k为临时列表listTmp的下标
            while (i <= mid && j <= high)
            {
                // listTmp[k++] = (list[i] <= list[j]) ? list[i++] : list[j++];
                if (list[i] <= list[j])
                {
                    // 空的list不能直接用角标赋值,否则会报数组下标溢出
                    listTmp[k++] = list[i++];
                }
                else
                {
                    listTmp[k++] = list[j++];
                }
            }
            while (i <= mid) // 将左边剩余元素填充进temp中
            {
                listTmp[k++] = list[i++];
            }
            while (j <= high) // 将右序列剩余元素填充进temp中
            {
                listTmp[k++] = list[j++];
            }
            // 将listTemp中的元素全部拷贝到原列表中
            for (i = low, k = 0; i <= high; i++, k++)
            {
                list[i] = listTmp[k];
            }
        }
	}
}