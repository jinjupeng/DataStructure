using DataStructure;
using System;

namespace DSTest
{
    class Program
    {
        /*        static void Main(string[] args)
                {
                    var array = new ArrayStack<int>(5);
                    array.Push(12);
                    array.Push(1);
                    array.Push(99);
                    array.Push(48);
                    array.Push(76);

                    foreach (var item in array)
                    {
                        Console.WriteLine(item);
                    }
                }*/

        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个加数");
            string oneNum = Console.ReadLine();
            Console.WriteLine("请输入第二个加数");
            string twoNum = Console.ReadLine();

            string result = TwoBigNumAdd.TwoBigNumAdd2(oneNum, twoNum);
            Console.WriteLine("计算结果：");
            Console.WriteLine(result);
        }
    }
}
