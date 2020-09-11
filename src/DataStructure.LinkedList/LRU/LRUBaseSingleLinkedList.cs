using System.Collections.Generic;
using System.Linq;

namespace DataStructure.LinkedList.LRU
{
    public class LRUBaseSingleLinkedList
    {
        /*
         * 实现LRU缓存淘汰算法思路：
         * 维护一个有序单链表，越靠近链尾的数据是最早访问的。
         * 当有一个新的数据被访问时，
         * 1. 如果数据在缓存中，则将其从原位置删除，然后插入到表头；
         * 2. 如果数据不在缓存中，有两种情况：
         *     1) 链表未满，则将数据插入到表头；
         *     2) 链表已满，则删除尾结点，将新数据插入到表头。
         */

        /// <summary>
        /// 双向链表节点的定义
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class DbNode<T>
        {
            public T Key { get; set; }

            public T Value { get; set; }

            /// <summary>
            /// 指向前驱节点的Prev指针域
            /// </summary>
            public DbNode<T> Prev { get; set; }

            /// <summary>
            /// 指向后继节点的Next指针域
            /// </summary>
            public DbNode<T> Next { get; set; }

            public DbNode(T key, T value)
            {
                Key = key;
                Value = value;
            }
        }

        private int _size;
        private readonly int _capacity; // 缓存容量
        private readonly DbNode<int> _head; // 链表的首指针
        private readonly DbNode<int> _tail; // 链表的尾指针
        private readonly Dictionary<int, DbNode<int>> _dict = new Dictionary<int, DbNode<int>>();

        /// <summary>
        /// 思路：双向链表 + 字典
        /// </summary>
        /// <param name="capacity"></param>
        public LRUBaseSingleLinkedList(int capacity)
        {
            _size = 0;
            _capacity = capacity;
            _head = new DbNode<int>(default, default);
            _tail = new DbNode<int>(default, default);
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        /// <summary>
        /// 在头指针后新增节点
        /// </summary>
        /// <param name="node"></param>
        private void AddNode(DbNode<int> node)
        {
            node.Prev = _head;
            node.Next = _head.Next;
            _head.Next.Prev = node;
            _head.Next = node;
        }

        /// <summary>
        /// 移除一个给定的节点
        /// </summary>
        /// <param name="node"></param>
        private void RemoveNode(DbNode<int> node)
        {
            var prev = node.Prev;
            var next = node.Next;
            prev.Next = next;
            next.Prev = prev;
        }

        /// <summary>
        /// 节点移动到头指针后
        /// </summary>
        /// <param name="node"></param>
        private void MoveToHead(DbNode<int> node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        /// <summary>
        /// 尾指针前节点移出
        /// </summary>
        /// <returns></returns>
        private DbNode<int> PopTail()
        {
            // 尾节点
            var tail = _tail.Prev;
            RemoveNode(tail);
            return tail;
        }

        public int Get(int key)
        {
            if (_dict.Keys.Contains(key))
            {
                var node = _dict[key];
                MoveToHead(node);
                return node.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (_dict.Keys.Contains(key))
            {
                var node = _dict[key];
                node.Value = value;
                MoveToHead(node);
            }
            else
            {
                var node = new DbNode<int>(key, value);
                if (_size < _capacity)
                {
                    AddNode(node);
                    _size++;
                }
                else
                {
                    var deleteNode = PopTail();
                    _dict.Remove(deleteNode.Key);
                    AddNode(node);
                }
                _dict.Add(key, node);
            }
        }
    }
}