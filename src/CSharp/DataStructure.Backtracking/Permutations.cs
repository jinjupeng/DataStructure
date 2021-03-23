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
        /// <param name="cur"></param>
        public void Permute(string[] array, int cur)
        {
            /* 全排列 递归实现 
                递归树：
                array:        a             b               c
                           ab   ac       ba   bc         ca   cb
                打印:    abc      acb  bac      bca    cab      cba
            */

            // 遍历完了一个全排列结果
            if (cur == array.Length)
            {
                Console.WriteLine(string.Join(",", array));
            }
            else
            {
                Permute(array, cur + 1);
                int i;
                for (i = cur + 1; i < array.Length; i++)
                {
                    Swap(array, cur, i);
                    Permute(array, cur + 1);
                    Swap(array, cur, i);
                }
            }
        }

        /// <summary>
        /// 交换数组下标位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Swap(string[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}