using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class TwoBigNumAdd
    {
        /// <summary>
        /// 大数相加（只考虑到正数）
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string TwoBigNumAdd2(string a, string b)
        {
            var array = new List<int>();
            var one = new List<int>();
            var two = new List<int>();

            // 将两个数处理成相同长度的字符串，短的小的数字前面补0
            for (var i = 0; i < (a.Length > b.Length ? a.Length : b.Length); i++)
            {
                if (i >= a.Length)
                    one.Insert(i - a.Length, 0);
                else
                    one.Add(int.Parse(a[i].ToString()));
                if (i >= b.Length)
                    two.Insert(i - b.Length, 0);
                else
                    two.Add(int.Parse(b[i].ToString()));
            }

            // array集合用于存储相加的和，所以长度最大也只会比最大的数长度长1，刚开始全部存0
            for (var i = 0; i <= (a.Length > b.Length ? a.Length : b.Length); i++)
            {
                array.Add(0);
            }

            // 从低位往高位每位开始相加，如果相加 >=10 则进1取余
            for (var i = (a.Length > b.Length ? a.Length : b.Length) - 1; i >= 0; i--)
            {
                array[i + 1] += (one[i] + two[i]) % 10;
                var k = (one[i] + two[i]) / 10;

                array[i] += k;
            }

            // 如果首位为0，则移除
            if (array[0] == 0)
            {
                array.RemoveAt(0);
            }

            // 将集合转换成字符串返回
            var result = new StringBuilder();
            foreach (var t in array)
            {
                result.Append(t);
            }
            return result.ToString();
        }
    }
}