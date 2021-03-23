namespace DataStructure.Array.BinarySearchBySortedArray
{
    public class BinarySearchImpl
    {
        /// <summary>
        /// 二分查找普通循环实现
        /// </summary>
        /// <param name="sortedArray">有序的数组</param>
        /// <param name="key">查找的元素</param>
        /// <returns>查找元素的下标</returns>
        public static int BinarySearch(int[] sortedArray, int key)
        {
            var low = 0;
            var high = sortedArray.Length - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                if (sortedArray[mid] == key)
                {
                    return mid;
                }

                if (sortedArray[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 二分查找递归实现
        /// </summary>
        /// <param name="sortedArray">有序数组</param>
        /// <param name="start">元素下标</param>
        /// <param name="end">元素下标</param>
        /// <param name="key">查找的元素值</param>
        /// <returns>返回查找元素值的下标</returns>
        public static int BinarySearch(int[] sortedArray, int start, int end, int key)
        {
            var mid = start + (end - start) / 2;
            if (sortedArray[mid] == key)
            {
                return mid;
            }
            if (start >= end)
            {
                return -1;
            }

            if (key > sortedArray[mid])
            {
                return BinarySearch(sortedArray, mid + 1, end, key);
            }

            if (key < sortedArray[mid])
            {
                return BinarySearch(sortedArray, start, mid - 1, key);
            }
            return -1;

        }
    }
}