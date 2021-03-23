using System;

namespace DataStructure.Backtracking
{
    /// <summary>
    /// 八皇后问题
    /// </summary>
    public class EightQueens
    {
        public readonly int[] Result = new int[8]; // 全局或成员变量,下标表示行,值表示queen存储在哪一列

        /// <summary>
        /// 调用cal8queens(0);
        /// </summary>
        /// <param name="row"></param>
        public void Cal8Queens(int row)
        {
            // 8个棋子都放置好了，打印结果
            if (row == 8)
            { 
                PrintQueens(Result);
                return; // 8行棋子都放好了，已经没法再往下递归了，所以就return
            }
            // 每一行都有8中放法
            for (var column = 0; column < 8; ++column)
            {
                // 有些放法不满足要求
                if (IsOk(row, column))
                {
                    // 第row行的棋子放到了column列
                    Result[row] = column;
                    // 考察下一行
                    Cal8Queens(row + 1); 
                }
            }
        }

        /// <summary>
        /// 判断row行column列放置是否合适
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="column">列</param>
        /// <returns></returns>
        private bool IsOk(int row, int column)
        {
            int leftUp = column - 1, rightUp = column + 1;
            // 逐行往上考察每一行
            for (var i = row - 1; i >= 0; --i)
            {
                // 第i行的column列有棋子吗？
                if (Result[i] == column) return false;
                // 考察左上对角线：第i行leftUp列有棋子吗？
                if (leftUp >= 0)
                { 
                    if (Result[i] == leftUp) return false;
                }
                // 考察右上对角线：第i行rightUp列有棋子吗？
                if (rightUp < 8)
                { 
                    if (Result[i] == rightUp) return false;
                }
                --leftUp; ++rightUp;
            }
            return true;
        }

        /// <summary>
        /// 打印出一个二维矩阵
        /// </summary>
        /// <param name="result"></param>
        private void PrintQueens(int[] result)
        { 
            for (var row = 0; row < 8; ++row)
            {
                for (var column = 0; column < 8; ++column)
                {
                    Console.Write(result[row] == column ? "Q " : "* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}