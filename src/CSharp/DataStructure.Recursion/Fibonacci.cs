using System;

namespace DataStructure.Recursion
{
    public class Fibonacci
    {
        /// <summary>
        /// 斐波那契数列
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib(int n)
        {
            int f0 = 0, f1 = 1, ans = 0;
            if (n == 0)
            {
                return f0;
            }
            else if (n == 1)
            {
                return f1;
            }
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    ans = (f1 + f0) % 1000000007;
                    f0 = f1;
                    f1 = ans;
                }
            }
            return ans;
        }

        /// <summary>
        /// 递归实现
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FibByRecurse(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            return FibByRecurse(n - 2) + FibByRecurse(n - 1);
        }

        
        public int FibByRecurse2(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int a = 1;
            int b = 1;

            for (int i = 3; i <= n; i++)
            {
                b = checked(a + b); // when n>46 memory will  overflow
                a = b - a;
            }
            return b;
        }
    }
}