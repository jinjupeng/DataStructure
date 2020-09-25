using System.Collections.Generic;

namespace DataStructure.Sort.SortImpl
{
    public class ShellSort
    {
        ///<summary>
        /// 希尔排序
        ///</summary>
        ///<param name="list"></param>
        public static List<int> ShellSortImpl(List<int> list)
        {
            var h = 3;
            while (h > 0)
            {
                for (var i = h; i < list.Count; i++)
                {
                    var tmp = list[i];
                    var j = i;
                    while ((j > h - 1) && tmp < list[j - h])
                    {
                        list[j] = list[j - h];
                        j -= h;
                    }
                    list[j] = tmp;
                }
                h = (h - 1) % 3;
            }
            return list;
        }
    }
}