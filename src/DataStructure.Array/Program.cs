using System;
using DataStructure.Array.BinarySearchBySortedArray;
using DataStructure.Array.LRU;

namespace DataStructure.Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // BinarySearchTest();
            LruCacheTest();
            Console.ReadKey();
        }

        #region 二分查找测试

        public static void BinarySearchTest()
        {
            var array = new int[10] { 1, 3, 5, 6, 8, 12, 14, 16, 18, 20 };
            // var data = BinarySearchImpl.BinarySearch(array, 5);
            var data = BinarySearchImpl.BinarySearch(array, 0, 5, 1);
        }

        #endregion
        #region LRU（最近最少未使用算法）自定义实现测试

        public static void LruCacheTest()
        {
            var cache = new LRUWithArray(2);
            cache.Put(1);
            cache.Put(2);
            cache.PrintAll();
            var a = cache.Get(1);       // 返回  1
            cache.PrintAll();
            cache.Put(3);    // 该操作会使得关键字 2 作废
            cache.PrintAll();
            var b = cache.Get(2);       // 返回  2
            cache.PrintAll();
            cache.Put(4);    // 该操作会使得关键字 1 作废
            cache.PrintAll();
            var c = cache.Get(1);       // 返回  1
            cache.PrintAll();
            var d = cache.Get(3);       // 返回  3
            cache.PrintAll();
            var e = cache.Get(4);       // 返回  4
            cache.PrintAll();
        }

        #endregion
    }
}
