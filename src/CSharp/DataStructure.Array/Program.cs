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
            var cache = new LruBaseArray(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            var a = cache.Get(1);       // 返回  1
            cache.Put(3, 3);    // 该操作会使得关键字 2 作废
            var b = cache.Get(2);       // 返回  -1 (未找到)
            cache.Put(4, 4);    // 该操作会使得关键字 1 作废
            var c = cache.Get(1);       // 返回  -1 (未找到)
            var d = cache.Get(3);       // 返回  3
            var e = cache.Get(4);       // 返回  4
        }

        #endregion
    }
}
