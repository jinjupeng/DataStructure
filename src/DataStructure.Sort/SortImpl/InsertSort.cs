namespace DataStructure.Sort.SortImpl
{
    public class InsertSort
    {
        /// <summary>
        /// 直接插入排序
        /// </summary>
        /// <param name="arr"></param>
        public static void StraightInsertSortImpl(int[] arr)
        {
            int i;
            // 从下标为1的元素开始选择合适的位置插入，因为下标为0的只有一个元素，默认是有序的
            for (i = 1; i < arr.Length; i++)
            {

                // 记录要插入的数据
                var temp = arr[i];
                // 从已经排序的序列最右边的开始比较，找到比其小的数
                var j = i;
                while (j > 0 && temp < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                // 存在比起小的数，插入
                if (j != i)
                {
                    arr[j] = temp;
                }

            }
        }

        /// <summary>
        /// 改进后的直接插入排序
        /// </summary>
        /// <param name="arr"></param>
        public static void StraightInsertSortWithSentryImpl(int[] arr)
        {
            // 遍历待插入的数(从第二位开始)
            for (var i = 1; i < arr.Length; i++)
            {
                // 待插入的数
                var temp = arr[i];
                //（j为已排序的待插入的位置序号）
                var j = i - 1;

                // 若已排序的数大于待插入数，则往后移一位
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                // 将待插入的数放入插入位置
                arr[j + 1] = temp;
            }
        }
    }
}