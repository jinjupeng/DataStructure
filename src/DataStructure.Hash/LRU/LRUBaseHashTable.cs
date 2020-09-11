using System;

namespace DataStructure.Hash.LRU
{
    /// <summary>
    /// 基于散列表的LRU算法
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class LRUBaseHashTable<K, V> where K: IComparable<K>
    {

        /// <summary>
        /// 默认链表容量
        /// </summary>
        private static readonly int DEFAULT_CAPACITY = 10;

        /// <summary>
        /// 头结点
        /// </summary>
        private readonly DNode<K, V> _headNode;

        /// <summary>
        /// 尾节点
        /// </summary>
        private readonly DNode<K, V> _tailNode;

        /// <summary>
        /// 链表长度
        /// </summary>
        private int _length;

        /// <summary>
        /// 链表容量
        /// </summary>
        private readonly int _capacity;

        /// <summary>
        /// 散列表存储key
        /// </summary>
        private readonly HashTable<K, DNode<K, V>> _table;

        /// <summary>
        /// 双向链表
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        public class DNode<K, V>
        {

            public K Key;

            /// <summary>
            /// 数据
            /// </summary>
            public V Value;

            /// <summary>
            /// 前驱指针
            /// </summary>
            public DNode<K, V> Prev;

            /// <summary>
            /// 后继指针
            /// </summary>
            public DNode<K, V> Next;

            public DNode()
            {
            }

            public DNode(K key, V value)
            {
                this.Key = key;
                this.Value = value;
            }

        }

        public LRUBaseHashTable(int capacity)
        {
            this._length = 0;
            this._capacity = capacity;

            _headNode = new DNode<K, V>();

            _tailNode = new DNode<K, V>();

            _headNode.Next = _tailNode;
            _tailNode.Prev = _headNode;

            _table = new HashTable<K, DNode<K, V>>();
        }

        public LRUBaseHashTable() : this(DEFAULT_CAPACITY)
        {
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            DNode<K, V> node = _table.Get(key);
            if (node == null)
            {
                DNode<K, V> newNode = new DNode<K, V>(key, value);
                _table.Put(key, newNode);
                AddNode(newNode);

                if (++_length > _capacity)
                {
                    DNode<K, V> tail = PopTail();
                    _table.Remove(tail.Key);
                    _length--;
                }
            }
            else
            {
                node.Value = value;
                MoveToHead(node);
            }
        }

        /// <summary>
        /// 将新节点加到头部
        /// </summary>
        /// <param name="newNode"></param>
        private void AddNode(DNode<K, V> newNode)
        {
            newNode.Next = _headNode.Next;
            newNode.Prev = _headNode;

            _headNode.Next.Prev = newNode;
            _headNode.Next = newNode;
        }

        /// <summary>
        /// 弹出尾部数据节点
        /// </summary>
        /// <returns></returns>
        private DNode<K, V> PopTail()
        {
            DNode<K, V> node = _tailNode.Prev;
            RemoveNode(node);
            return node;
        }

        /// <summary>
        /// 移除节点
        /// </summary>
        /// <param name="node"></param>
        private void RemoveNode(DNode<K, V> node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        /// <summary>
        /// 将节点移动到头部
        /// </summary>
        /// <param name="node"></param>
        private void MoveToHead(DNode<K, V> node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        /// <summary>
        /// 获取节点数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            DNode<K, V> node = _table.Get(key);
            if (node == null)
            {
                return default;
            }

            MoveToHead(node);
            return node.Value;
        }

        /// <summary>
        /// 移除节点数据
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            DNode<K, V> node = _table.Get(key);
            if (node == null)
            {
                return;
            }

            RemoveNode(node);
            _length--;
            _table.Remove(node.Key);
        }

        private void PrintAll()
        {
            DNode<K, V> node = _headNode.Next;
            while (node.Next != null)
            {
                Console.Write(node.Value + ",");
                node = node.Next;
            }

            Console.WriteLine();
        }
    }
}