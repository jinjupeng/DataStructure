using DataStructure.Array;

namespace DataStructure.Sort.SortImpl
{
    public class BubbleSort
    {
        ///<summary>
        /// 冒泡排序--稳定排序
        ///</summary>
        ///<param name="arr"></param>
        public static void BubbleSortImpl(Array<int> arr)
        {
            int i, j;
            int temp;
            // 设定一个标记，若为true,则表示此次循环没有进行交换，也就是待排序已经有序，排序已经完成
            bool isExchanged = true;

            for (j = 1; j < arr.Count && isExchanged; j++)
            {
                isExchanged = false;
                for (i = 0; i < arr.Count - j; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        // 核心操作：交换两个元素
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        // 附加操作：改变标志
                        isExchanged = true;
                    }
                }

                arr.DisplayElements();
            }
        }
	}
}