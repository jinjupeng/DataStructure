using System;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            RegexTest();
        }

        #region 正则表达式匹配

        public static void RegexTest()
        {
            var s = "aa";
            var p = "a*";
            var regex = new Regex();
            var data = regex.IsMatch(s, p);
        }

        #endregion
    }
}
