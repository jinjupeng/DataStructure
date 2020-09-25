using System;
using System.Collections.Generic;

namespace DataStructure.Array.LRU
{
    /// <summary>
    /// 使用数组实现LRU缓存淘汰算法
    /// </summary>
    public class LruBaseArray
    {
        private readonly int _capacity;
        private readonly Dictionary<int, Dictionary<int, int>> _dict = new Dictionary<int, Dictionary<int, int>>();
        public LruBaseArray(int capacity)
        {
            _capacity = capacity;
            CachedList = new Array<int>(capacity);
        }

        public Array<int> CachedList { get; }

        public void Put(int key, int value)
        {
            if (_dict.ContainsKey(key))
            {
                // 找出该值在缓存中的索引位置
                var idx = CachedList.IndexOf(key);
                CachedList.Delete(idx);
                CachedList.Insert(0, key);
                _dict[key][key] = value;
            }
            else
            {
                if (CachedList.Count < _capacity)
                {
                    // 将新缓存插入到表头
                    CachedList.Insert(0, key);
                }
                else
                {
                    var lastIndex = CachedList.Count - 1;
                    _dict.Remove(CachedList.Find(lastIndex));
                    // 缓存已满，删除最后一个元素
                    CachedList.Delete(lastIndex);
                    // 将新缓存插入到表头
                    CachedList.Insert(0, key);
                }
                var dict = new Dictionary<int, int> { { key, value } };
                _dict.Add(key, dict);
            }
        }

        public int Get(int key)
        {
            if (_dict.ContainsKey(key))
            {
                var index = CachedList.IndexOf(key);
                CachedList.Delete(index);
                CachedList.Insert(0, key);
                return _dict[key][key];
            }

            return -1;
        }

        public void PrintAll()
        {
            for (var i = 0; i < CachedList.Count; i++)
            {
                Console.Write(CachedList.Find(i) + " ");
            }

            Console.WriteLine();
        }
    }
}