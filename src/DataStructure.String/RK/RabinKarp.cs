namespace DataStructure.String.RK
{
    /// <summary>
    /// Rabin-Karp 算法
    /// </summary>
    public class RabinKarp
    {
        private readonly string _pat;      // 模拟模式串
        private readonly long _patHash;    // 模拟字符串的散列值
        private readonly int _patLength;   // 模拟字符串长度
        private readonly long _q;          // 随机的大素数,在不溢出的情况下选择一个尽可能大的素数
        private readonly int _r;           // 进制数（字母表大小）,如果字符串中所有的字符都是小写英文字母,那么就是26进制,如果都是数字,那么就是10进制,如果没有说明,那么就以ASCII表256进制来计算
        private readonly long _rm;         // _r^(_patLength - 1) % _q


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pattern">模式匹配串</param>
        /// <param name="r">进制数（字母表大小）</param>
        public RabinKarp(char[] pattern, int r)
        {
            this._pat = string.Concat(pattern);
            this._r = r;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pat">模拟字符串</param>
        public RabinKarp(string pat)
        {
            this._pat = pat;
            _r = 256;
            _patLength = pat.Length;
            _q = LongRandomPrime(); // 大素数

            // precompute R^(m-1) % q for use in removing leading digit
            _rm = 1;
            // 注意这里是从1开始,到_patLength-1,[1, _patLength-1],一共_patLength - 1个数;
            for (int i = 1; i <= _patLength - 1; i++)
                _rm = (_r * _rm) % _q;

            _patHash = Hash(pat, _patLength);
        }

        /// <summary>
        /// Compute hash for key[0..m-1]. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private long Hash(string key, int m)
        {
            long h = 0;
            for (int j = 0; j < m; j++)
                h = (_r * h + key.ToCharArray()[j]) % _q;
            return h;
        }

        /// <summary>
        /// 这个方法一般不用,从概率上来说,不用再check,如果你不放心,可以添加上字符逐一对比的代码
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool Check(string txt, int i)
        {
            for (int j = 0; j < _patLength; j++)
                if (_pat.ToCharArray()[j] != txt.ToCharArray()[i + j])
                    return false;
            return true;
        }

        /// <summary>
        /// 返回匹配成功的索引
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public int Search(string txt)
        {
            int n = txt.Length;
            if (n < _patLength) return -1;
            // 计算txt文本的前_patLength长度位的hash值
            long txtHash = Hash(txt, _patLength);

            // 在开始位置匹配成功
            if (_patHash == txtHash && Check(txt, 0))
                return 0;

            // 检查hash值是否匹配，如果hash匹配，则再检测字符串是否匹配
            for (int i = _patLength; i < n; i++)
            {
                // Remove leading digit, add trailing digit, check for match. 
                txtHash = (txtHash + _q - _rm * txt.ToCharArray()[i - _patLength] % _q) % _q;
                txtHash = (txtHash * _r + txt.ToCharArray()[i]) % _q;

                // 匹配
                int offset = i - _patLength + 1;
                if ((_patHash == txtHash) && Check(txt, offset))
                    return offset;
            }

            // 不匹配
            return -1;
        }


        /// <summary>
        /// 生成一个大素数(一定要是一个尽可能大的素数,以减少冲突)
        /// </summary>
        /// <returns></returns>
        private static long LongRandomPrime()
        {
            // TODO：自定义生成一个不溢出情况下的大素数
            return 998;
        }
    }
}