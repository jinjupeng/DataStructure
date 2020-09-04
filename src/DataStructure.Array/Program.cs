using System;
using DataStructure.Array.BinarySearchBySortedArray;

namespace DataStructure.Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10] { 1,3,5,6,8,12,14,16,18,20 };
            // var data = BinarySearchImpl.BinarySearch(array, 5);
            var data = BinarySearchImpl.BinarySearch(array, 0, 5, 1);
            Console.WriteLine("Hello World!");
        }
    }
}
