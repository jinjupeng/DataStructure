using DataStructure.Hash.LRU;

namespace DataStructure.Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            LruCacheTest();
        }

        #region LRU（最近最少未使用算法）测试

        public static void LruCacheTest()
        {
            var cache = new LRUBaseHashTable<int, int>(2);
            cache.Add(1, 1);
            cache.Add(2, 2);
            var a = cache.Get(1);       // 返回  1
            cache.Add(3, 3);    // 该操作会使得关键字 2 作废
            var b = cache.Get(2);       // 返回  0 (未找到)
            cache.Add(4, 4);    // 该操作会使得关键字 1 作废
            var c = cache.Get(1);       // 返回  0 (未找到)
            var d = cache.Get(3);       // 返回  3
            var e = cache.Get(4);       // 返回  4

        }

        #endregion
    }
}
