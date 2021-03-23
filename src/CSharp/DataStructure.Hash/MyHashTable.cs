using System;

namespace DataStructure.Hash
{
    /// <summary>
    /// 实现基于链表法解决冲突问题的散列表
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class MyHashTable<K, V> where K : IComparable<K>
    {

        /// <summary>
        /// 散列表默认长度
        /// </summary>
        private static readonly int DEFAULT_INITIAL_CAPACITY = 8;

        /// <summary>
        /// 装载因子
        /// </summary>
        private static readonly float LOAD_FACTOR = 0.75f;

        /// <summary>
        /// 初始化散列表数组
        /// </summary>
        private Entry<K, V>[] _table;

        /// <summary>
        /// 实际元素数量
        /// </summary>
        private int _size = 0;

        /// <summary>
        /// 散列表索引数量
        /// </summary>
        private int _use = 0;

        public MyHashTable()
        {
            _table = new Entry<K, V>[DEFAULT_INITIAL_CAPACITY];
        }

        public class Entry<K, V>
        {
            public K Key;

            public V Value;

            public Entry<K, V> Next;

            public Entry(K key, V value, Entry<K, V> next)
            {
                this.Key = key;
                this.Value = value;
                this.Next = next;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(K key, V value)
        {
            var index = Hash(key);
            // 位置未被引用，创建哨兵节点
            if (_table[index] == null)
            {
                _table[index] = new Entry<K, V>(default, default, null);
            }

            var tmp = _table[index];
            // 新增节点
            if (tmp.Next == null)
            {
                tmp.Next = new Entry<K, V>(key, value, null);
                _size++;
                _use++;
                // 动态扩容
                if (_use >= _table.Length * LOAD_FACTOR)
                {
                    Resize();
                }
            }
            // 解决散列冲突，使用链表法
            else
            {
                do
                {
                    tmp = tmp.Next;
                    // key相同，覆盖旧的数据
                    if (tmp.Key.CompareTo(key) == 0)
                    {
                        tmp.Value = value;
                        return;
                    }
                } while (tmp.Next != null);

                var temp = _table[index].Next;
                _table[index].Next = new Entry<K, V>(key, value, temp);
                _size++;
            }
        }

        /// <summary>
        /// 散列函数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int Hash(object key)
        {
            int h;
            return key == null ? 0 : ((h = key.GetHashCode()) ^ (h >> 16)) % _table.Length;
        }

        /// <summary>
        /// 扩容
        /// </summary>
        private void Resize()
        {
            var oldTable = _table;
            _table = new Entry<K, V>[_table.Length * 2];
            _use = 0;
            foreach (var t in oldTable)
            {
                if (t == null || t.Next == null)
                {
                    continue;
                }
                var e = t;
                while (e.Next != null)
                {
                    e = e.Next;
                    var index = Hash(e.Key);
                    if (_table[index] == null)
                    {
                        _use++;
                        // 创建哨兵节点
                        _table[index] = new Entry<K, V>(default, default, null);
                    }
                    _table[index].Next = new Entry<K, V>(e.Key, e.Value, _table[index].Next);
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            var index = Hash(key);
            var e = _table[index];
            if (e == null || e.Next == null)
            {
                return;
            }

            var headNode = _table[index];
            do
            {
                var pre = e;
                e = e.Next;
                if (key.CompareTo(e.Key) == 0)
                {
                    pre.Next = e.Next;
                    _size--;
                    if (headNode.Next == null) _use--;
                    return;
                }
            } while (e.Next != null);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            var index = Hash(key);
            var e = _table[index];
            if (e == null || e.Next == null)
            {
                return default;
            }
            while (e.Next != null)
            {
                e = e.Next;
                if (key.CompareTo(e.Key) == 0)
                {
                    return e.Value;
                }
            }
            return default;
        }
    }
}