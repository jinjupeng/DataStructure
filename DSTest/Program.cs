using DataStructure;
using System;

namespace DSTest
{
    class Program
    {
        static void Main(string[] args)
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
        }
    }
}
