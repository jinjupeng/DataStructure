using DataStructure.Array;

namespace DataStructure.Sort.SortImpl
{
    public class BubbleSort
    {
        /**
         * 冒泡排序是可用的最慢排序算法之一。
         * 这种排序算法的得名是由于数值“像气泡一样”从序列的一端浮动到另一端。
         * 假设现在要把一列数按升序方式进行排序，即较大数值浮动到列的右侧，而较小数值则浮动到列的左侧。
         * 这种操作可以通过下列操作来实现：多次遍历整个列，并且比较相邻的数值，如果左侧的数值大于右侧数值就进行交换。
         * 
         */ 

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