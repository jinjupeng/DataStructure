using DataStructure.Hash.LRU;

namespace DataStructure.Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            // LruCacheTest();
            // MyHashSetTest();
            MyHashMapTest();
        }

        #region LRU（最近最少未使用算法）测试

        public static void LruCacheTest()
        {
            var cache = new LruBaseHashTable<int, int>(2);
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

        #region 设计哈希集合测试

        public static void MyHashSetTest()
        {
            var hashSet = new MyHashSet();
            hashSet.Add(1);
            hashSet.Add(2);
            var a1 = hashSet.Contains(1);    // 返回 true
            var a2 = hashSet.Contains(3);    // 返回 false (未找到)
            hashSet.Add(2);
            var a3 = hashSet.Contains(2);    // 返回 true
            hashSet.Remove(2);
            var a4 = hashSet.Contains(2);    // 返回  false (已经被删除)

        }

        #endregion

        #region 设计哈希映射测试

        public static void MyHashMapTest()
        {
            var hashMap = new MyHashMap();
            hashMap.Put(1, 1);
            hashMap.Put(2, 2);
            var a1 = hashMap.Get(1);            // 返回 1
            var a2 = hashMap.Get(3);            // 返回 -1 (未找到)
            hashMap.Put(2, 1);         // 更新已有的值
            var a4 = hashMap.Get(2);            // 返回 1 
            hashMap.Remove(2);         // 删除键为2的数据
            var a6 = hashMap.Get(2);            // 返回 -1 (未找到) 

        }

        #endregion
    }
}
