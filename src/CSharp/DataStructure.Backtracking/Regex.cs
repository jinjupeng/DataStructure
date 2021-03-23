namespace DataStructure.Backtracking
{
    /// <summary>
    /// 正则表达式匹配问题
    /// 通配符匹配：https://leetcode-cn.com/problems/wildcard-matching/
    /// </summary>
    public class Regex
    {
        private bool _matched; // 默认不匹配false
        private readonly char[] _pattern; // 正则表达式
        private readonly int _patternLen; // 正则表达式长度

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pattern">正则表达式</param>
        /// <param name="patternLen">正则表达式长度</param>
        public Regex(char[] pattern, int patternLen)
        {
            this._pattern = pattern;
            this._patternLen = patternLen;
        }

        /// <summary>
        /// 是否匹配
        /// </summary>
        /// <param name="text">文本串</param>
        /// <param name="textLen">文本串长度</param>
        /// <returns></returns>
        public bool Match(char[] text, int textLen)
        { 
            // 文本串及长度
            _matched = false;
            RMatch(0, 0, text, textLen);
            return _matched;
        }

        /// <summary>
        /// 通配符匹配
        /// </summary>
        /// <param name="ti">文本串下标</param>
        /// <param name="pj">正则表达式下标</param>
        /// <param name="text">文本串</param>
        /// <param name="textLen">文本串长度</param>
        private void RMatch(int ti, int pj, char[] text, int textLen)
        {
            // 如果已经匹配了，就不要继续递归了
            if (_matched) return; 

            // 正则表达式到结尾了
            if (pj == _patternLen)
            {
                // 文本串也到结尾了
                if (ti == textLen) _matched = true; 
                return;
            }

            switch (_pattern[pj])
            {
                // *匹配任意个字符
                case '*':
                {
                    for (var k = 0; k <= textLen - ti; ++k)
                    {
                        RMatch(ti + k, pj + 1, text, textLen);
                    }

                    break;
                }
                // ?匹配0个或者1个字符
                case '?':
                    RMatch(ti, pj + 1, text, textLen);
                    RMatch(ti + 1, pj + 1, text, textLen);

                    break;
                // 纯字符匹配才行
                default:
                {
                    if (ti < textLen && _pattern[pj] == text[ti])
                    {
                        RMatch(ti + 1, pj + 1, text, textLen);
                    }

                    break;
                }
            }
        }
    }
}