using System;

namespace DataStructure.Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var fibonacci = new Fibonacci();
            Console.WriteLine($"[非递归]斐波那契数列：{fibonacci.Fib(20)}");
            Console.WriteLine($"[递归]斐波那契数列：{fibonacci.FibByRecurse(2)}");
        }
    }
}
