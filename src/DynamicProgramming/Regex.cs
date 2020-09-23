
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class Regex
    {
        /// <summary>
        /// 10. 正则表达式匹配
        /// </summary>
        /// <param name="s">s 可能为空，且只包含从 a-z 的小写字母</param>
        /// <param name="p">p 可能为空，且只包含从 a-z 的小写字母，以及字符 . 和 *</param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            /*
             * 给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。
             * '.' 匹配任意单个字符
             * '*' 匹配零个或多个前面的那一个元素
             * 来源：力扣（LeetCode）
             * 链接：https://leetcode-cn.com/problems/regular-expression-matching
             * 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
             */
            return dp(s, 0, p, 0);

            // 思路：https://mp.weixin.qq.com/s/rnaFK05IcFWvNN1ppNf2ug

        }

        private bool dp(string s, int i, string p, int j)
        {
            int m = s.Length, n = p.Length;
            // 基本情况
            if (j == n)
            {
                return i == m;
            }

            if (i == m)
            {
                if ((n - j) % 2 == 1)
                {
                    return false;
                }
                for (; j + 1 < n; j += 2)
                {
                    if (p[j + 1] != '*')
                    {
                        return false;
                    }
                }
                return true;
            }

            // 记录状态 (i, j)，消除重叠子问题
            var key = i + "," + j;
            var dict = new Dictionary<string, bool>();
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }

            bool res; // 默认为false

            if (s[i] == p[j] || p[j] == '.')
            {
                // 匹配
                if (j < p.Length - 1 && p[j + 1] == '*')
                {
                    // 有 * 通配符，可以匹配0次或多次
                    res = dp(s, i, p, j + 2) || dp(s, i + 1, p, j);
                }
                else
                {
                    // 无 * 通配符，老老实实匹配1次
                    res = dp(s, i + 1, p, j + 1);
                }
            }
            else
            {
                // 不匹配
                if (j < p.Length - 1 && p[j + 1] == '*')
                {
                    // 有 * 通配符，只能匹配0次
                    res = dp(s, i, p, j + 2);
                }
                else
                {
                    // 无 * 通配符，匹配无法进行下去了
                    res = false;
                }
            }
            // 将当前记录写入备忘录中
            dict[key] = res;

            return res;
        }
    }
}