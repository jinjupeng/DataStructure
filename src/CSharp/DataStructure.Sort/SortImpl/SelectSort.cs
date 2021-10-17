namespace DataStructure.Sort.SortImpl
{
    public class SelectSort
    {
        /**
         * 从数组的起始处开始，把第一个元素与数组中其他元素进行比较。
         * 然后，将最小的元素放置在第0个位置上，接着再从第1个位置开始再次进行排序操作。
         * 这种操作会一直除最后一个元素外的每一个元素都作为新循环的起始点操作过后才终止。
         * 
         */

		///<summary>
        /// 选择排序--直接选择排序
        ///</summary>
        ///<param name="arr"></param>
        public static void SelectSortImpl(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var min = i;
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if (i != min)
                {
                    var tmp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = tmp;
                }
            }
        }
	}
}