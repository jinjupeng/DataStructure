using System;

namespace DataStructure.Backtracking
{
    /// <summary>
    /// 全排列问题
    /// </summary>
    public class Permutations
    {
        /// <summary>
        /// 数组全排列递归
        /// </summary>
        /// <param name="array"></param>
        /// <param name="begin"></param>
        public void Permute(string[] array, int begin)
        {
            /* 全排列 递归实现 
                递归树：
                array:        a             b               c
                           ab   ac       ba   bc         ca   cb
                打印:    abc      acb  bac      bca    cab      cba
            */

            // 遍历完了一个全排列结果
            if (begin == array.Length)
            {
                Console.WriteLine(string.Join(",", array));
            }
            else
            {
                Permute(array, begin + 1);
                int i;
                for (i = begin + 1; i < array.Length; i++)
                {
                    // 交换数组下标位置
                    var t = array[begin];
                    array[begin] = array[i];
                    array[i] = t;
                    Permute(array, begin + 1);
                    // 交换数组下标位置
                    t = array[begin];
                    array[begin] = array[i];
                    array[i] = t;
                }
            }
        }
    }
}