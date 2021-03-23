using System.Collections.Generic;

namespace DataStructure.Hash
{
    /// <summary>
    /// 设计一个哈希集合
    /// </summary>
    public class MyHashSet
    {
        private readonly Bucket[] _bucketArray;
        private readonly int _keyRange;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MyHashSet()
        {
            this._keyRange = 769;
            this._bucketArray = new Bucket[this._keyRange];
            for (var i = 0; i < this._keyRange; ++i)
                this._bucketArray[i] = new Bucket();
        }

        protected int Hash(int key)
        {
            return (key % this._keyRange);
        }

        /// <summary>
        /// 向哈希集合中插入一个值
        /// </summary>
        /// <param name="key"></param>
        public void Add(int key)
        {
            var bucketIndex = this.Hash(key);
            this._bucketArray[bucketIndex].Insert(key);
        }

        /// <summary>
        /// 将给定值从哈希集合中删除。如果哈希集合中没有这个值，什么也不做
        /// </summary>
        /// <param name="key"></param>
        public void Remove(int key)
        {
            var bucketIndex = this.Hash(key);
            this._bucketArray[bucketIndex].Delete(key);
        }

        /// <summary>
        /// 返回哈希集合中是否存在这个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(int key)
        {
            var bucketIndex = this.Hash(key);
            return this._bucketArray[bucketIndex].Exists(key);
        }
    }

    public class Bucket
    {
        private readonly LinkedList<int> _container;

        public Bucket()
        {
            _container = new LinkedList<int>();
        }

        public void Insert(int key)
        {
            var index = IndexOf(key);
            if (index == -1)
            {
                this._container.AddFirst(key);
            }
        }

        public void Delete(int key)
        {
            this._container.Remove(key);
        }

        public bool Exists(int key)
        {
            var index = IndexOf(key);
            return (index != -1);
        }

        public int IndexOf(int key)
        {
            if (!this._container.Contains(key)) return -1;
            var index = 0;
            foreach (var i1 in _container)
            {
                if (i1 == key)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
    }
}