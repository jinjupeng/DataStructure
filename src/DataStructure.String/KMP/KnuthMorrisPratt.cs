namespace DataStructure.String.KMP
{
    public class KnuthMorrisPratt
    {
        private readonly int _r;       // 进制数（字母表大小）,如果字符串中所有的字符都是小写英文字母,那么就是26进制,如果都是数字,那么就是10进制,如果没有说明,那么就以ASCII表256进制来计算
        private readonly int _m;       // 模式串长度
        private readonly int[,] _dfa;  // the KMP automoton （有限状态自动机，Deterministic Finite Automaton）


        /// <summary>
        /// 预处理模式串
        /// </summary>
        /// <param name="pat">模式串</param>
        public KnuthMorrisPratt(string pat)
        {
            _r = 256;
            _m = pat.Length;

            // build DFA from pattern
            _dfa = new int[_r,_m];
            _dfa[pat.ToCharArray()[0],0] = 1;
            for (int x = 0, j = 1; j < _m; j++)
            {
                for (int c = 0; c < _r; c++)
                    _dfa[c,j] = _dfa[c,x];              // Copy mismatch cases. 
                _dfa[pat.ToCharArray()[j],j] = j + 1;   // Set match case. 
                x = _dfa[pat.ToCharArray()[j],x];       // Update restart state. 
            }
        }


        /// <summary>
        /// 预处理模式串
        /// </summary>
        /// <param name="pattern">模式串</param>
        /// <param name="r">进制数（字符集大小）</param>
        public KnuthMorrisPratt(char[] pattern, int r)
        {
            _r = r;
            _m = pattern.Length;

            // build DFA from pattern
            var m = pattern.Length;
            _dfa = new int[r,m];
            _dfa[pattern[0],0] = 1;
            for (int x = 0, j = 1; j < m; j++)
            {
                for (int c = 0; c < r; c++)
                    _dfa[c,j] = _dfa[c,x];     // Copy mismatch cases. 
                _dfa[pattern[j],j] = j + 1;    // Set match case. 
                x = _dfa[pattern[j],x];        // Update restart state. 
            }
        }


        /// <summary>
        /// 返回匹配成功的索引值
        /// </summary>
        /// <param name="txt">主串</param>
        /// <returns></returns>
        public int Search(string txt)
        {
            // simulate operation of DFA on text
            var n = txt.Length;
            int i, j;
            for (i = 0, j = 0; i < n && j < _m; i++)
            {
                j = _dfa[txt.ToCharArray()[i],j];
            }
            if (j == _m) return i - _m;   // 匹配
            return -1;                    // 不匹配
        }


        /// <summary>
        /// 返回匹配成功的索引值
        /// </summary>
        /// <param name="text">主串</param>
        /// <returns></returns>
        public int Search(char[] text)
        {
            // simulate operation of DFA on text
            var n = text.Length;
            int i, j;
            for (i = 0, j = 0; i < n && j < _m; i++)
            {
                j = _dfa[text[i],j];
            }
            if (j == _m) return i - _m;   // 匹配
            return -1;                    // 不匹配
        }
    }
}