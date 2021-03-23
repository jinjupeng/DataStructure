using System;

namespace DataStructure.Backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bag01Test();
            // RegexTest();
            // EightQueensTest();
            PermutationsTest();
        }

        #region 回溯算法之8皇后问题

        public static void EightQueensTest()
        {
            var queen = new EightQueens();
            queen.Cal8Queens(0);
        }

        #endregion

        #region 回溯算法之0-1背包问题

        public static void Bag01Test()
        {
            var bag = new Bag01();
            var n = 10;
            var w = 100;
            var item = new int[] { 1,15,13,2,6,7,9,21,3,4 };
            bag.BagCompute(0, 0, item, n , w);
            var data = bag.MaxWeight; // 背包中能装的最大容量
        }

        #endregion

        #region 回溯算法之全排列问题

        public static void PermutationsTest()
        {
            var permutations = new Permutations();
            var strArray = new string[] { "a", "b", "c" };
            permutations.Permute(strArray, 0);
        }

        #endregion

        #region 回溯算法之正则表达式匹配问题

        public static void RegexTest()
        {
            var pattern = "?a";
            var text = "cb";
            var regex = new Regex(pattern.ToCharArray(), pattern.Length);
            var data = regex.Match(text.ToCharArray(), text.Length);
        }

        #endregion
    }
}
