using System.Collections.Generic;

namespace DataStructure.Sort.SortImpl
{
    public class BubbleSort
    {
		///<summary>
        /// 冒泡排序--稳定排序
        ///</summary>
        ///<param name="list"></param>
        public static List<int> BubbleSortImpl(List<int> list)
        {
            if (list == null || list.Count < 1)
            {
                return null;
            }

            for (int i = 0; i < list.Count; i++)
            {
                // 设定一个标记，若为true,则表示此次循环没有进行交换，也就是待排序已经有序，排序已经完成
                bool flag = true;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                        flag = false;
                    }
                    if (flag)
                    {
                        return list;
                    }
                }
            }
            return list;
        }
	}
}