namespace DataStructure.Sort.SortImpl
{
    public class SelectSort
    {
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