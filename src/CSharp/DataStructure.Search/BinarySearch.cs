namespace DataStructure.Search
{
    public class BinarySearch
    {
        /**
         * 当要查找的记录从头到尾都是有序排列的时候，为找到数值可以执行一种比
         * 顺序查找更加有效的查找。这种查找被称为是二叉查找。
         * 
         */

        /// <summary>
        /// 二分查找实例方法
        /// </summary>
        /// <param name="array">有序数组</param>
        /// <param name="target">要查找的目标值</param>
        /// <returns>返回目标值在数组中的索引，如果未找到返回-1</returns>
        public int IndexOf(int[] array, int target)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }
            
            return BinSearch(array, 0, array.Length - 1, target);
        }

        /// <summary>
        /// 二分查找While循环实现
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="low">开始索引</param>
        /// <param name="high">结束索引</param>
        /// <param name="target">要查找的对象</param>
        /// <returns>返回索引</returns>
        public static int BinSearch(int[] nums, int low, int high, int target)
        {
            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (target == nums[middle])
                {
                    return middle;
                }
                else if (target > nums[middle])
                {
                    low = middle + 1;
                }
                else if (target < nums[middle])
                {
                    high = middle - 1;
                }
            }
            return -1;
        }


        /// <summary>
        /// 二分查找递归实现
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="low">开始索引 0</param>
        /// <param name="high">结束索引 </param>
        /// <param name="key">要查找的对象</param>
        /// <returns>返回索引</returns>
        public static int RbinSearch(int[] arr, int low, int high, int key)
        {
            int mid = (low + high) / 2;//中间索引
            if (low > high)
                return -1;
            else
            {
                if (arr[mid] == key)
                    return mid;
                else if (arr[mid] > key)
                    return RbinSearch(arr, low, mid - 1, key);
                else
                    return RbinSearch(arr, mid + 1, high, key);
            }
        }
    }
}