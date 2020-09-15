namespace DataStructure.String.RK
{
    /// <summary>
    /// Rabin-Karp 算法
    /// </summary>
    public class RabinKarp
    {
        /// <summary>
        /// 计算子串的哈希值，每个字符取ascii码后求和
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public int SimpleHash(string s, int start, int length)
        {
            var ret = 0;
            if (s.Length < start + length + 1)
            {
                return 0;
            }
            foreach (var c in s.Substring(start, length))
            {
                ret += (int) c;
            }

            return ret;
        }

        /// <summary>
        /// 返回匹配的索引位置
        /// </summary>
        /// <param name="main"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public int RKSearch(string main, string pattern)
        {
            var n = main.Length;
            var m = pattern.Length;
            if (n <= m)
            {
                if (pattern == main)
                {
                    return 0;
                }
                return -1;
            }

            // 子串哈希值
            var hashMemo = new int[n - m + 1];
            hashMemo[0] = SimpleHash(main, 0, m);
            for (int i = 1; i <= n-m+1; i++)
            {
                hashMemo[i] = hashMemo[i - 1] - SimpleHash(main, i - 1, m) +
                               SimpleHash(main, i + m - 1, m);
            }

            // 模式串哈希值
            var hashP = SimpleHash(pattern, 0, m);

            foreach (var i in hashMemo)
            {
                // 可能存在哈希冲突
                if (hashMemo[i] == hashP)
                {
                    if (pattern == main.Substring(i, pattern.Length))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}