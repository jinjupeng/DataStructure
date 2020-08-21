﻿namespace DataStructure.Search
{
    public class BinarySearch
    {
        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int BinarySearchImpl(int[] nums, int target)
        {
            var low = 0;
            var high = nums.Length - 1;
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] < target)
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
    }
}