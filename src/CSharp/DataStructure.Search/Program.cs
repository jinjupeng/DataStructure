﻿using System;

namespace DataStructure.Search
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 二分查找

            var binarySearch = new BinarySearch();
            var array = new int[] { 1, 3, 5, 6 };
            var data = binarySearch.IndexOf(array, 5);

            #endregion
            Console.WriteLine("Hello World!");
        }
    }
}
