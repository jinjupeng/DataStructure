using System;

namespace DataStructure.Array.LRU
{
    /// <summary>
    /// 使用数组实现LRU缓存淘汰算法
    /// </summary>
    public class LRUWithArray
    {
        private readonly int _capacity;

        public LRUWithArray(int capacity)
        {
            _capacity = capacity;
            CachedList = new Array<int>(capacity);
        }

        public Array<int> CachedList { get; }

        public void Put(int val)
        {
            // 找出该值在缓存中的索引位置
            int idx = CachedList.IndexOf(val);

            // 存在该缓存值
            if (idx != -1)
            {
                CachedList.Delete(idx);
                CachedList.Insert(0, val);
                return;
            }

            // 不存在该缓存值
            if (CachedList.Count == _capacity)
            {
                // 缓存已满，删除最后一个元素
                CachedList.Delete(CachedList.Count - 1);
            }

            // 将新缓存插入到表头
            CachedList.Insert(0, val);
        }

        public int Get(int value)
        {
            // 如果不存在，数组有位置则插入到表头
            var index = CachedList.IndexOf(value);
            if ( index == -1)
            {
                if (CachedList.Count == _capacity)
                {
                    // 缓存已满，删除最后一个元素
                    CachedList.Delete(CachedList.Count - 1);
                }

            }

            // 如果存在，将该元素移动到表头
            if (index >= 0)
            {
                CachedList.Delete(index);
            }
            // 将新缓存插入到表头
            CachedList.Insert(0, value);

            return CachedList.Find(0);
        }

        public void PrintAll()
        {
            for (int i = 0; i < CachedList.Count; i++)
            {
                Console.Write(CachedList.Find(i) + " ");
            }

            Console.WriteLine();
        }
    }
}