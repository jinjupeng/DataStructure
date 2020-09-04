using System;
using System.Xml;

namespace DataStructure.LinkedList
{
    /// <summary>
    /// 单链表模拟实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MySingleLinkedList<T>
    {
        private int _count; // 字段：当前链表节点个数
        private Node<T> _head; // 字段：当前链表的头节点

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        public MySingleLinkedList()
        {
            this._count = 0;
            this._head = null;
        }

        /// <summary>
        /// 属性：当前链表节点的个数
        /// </summary>
        public int Count
        {
            get
            {
                return this._count;
            }
        }

        /// <summary>
        /// this关键字-索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return this.GetNodeByIndex(index).Item;
            }
            set
            {
                this.GetNodeByIndex(index).Item = value;
            }
        }

        /// <summary>
        /// Method01:根据索引获取节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this._count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            Node<T> tempNode = this._head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        /// <summary>
        /// Method02:在尾节点后插入新节点
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this._head == null)
            {
                // 如果链表当前为空则置为头结点
                this._head = newNode;
            }
            else
            {
                Node<T> prevNode = this.GetNodeByIndex(this._count - 1);
                prevNode.Next = newNode;
            }

            this._count++;
        }

        /// <summary>
        /// Method03:在指定位置插入新节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, T value)
        {
            Node<T> tempNode = null;
            if (index < 0 || index > this._count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            if (index == 0)
            {
                if (this._head == null)
                {
                    tempNode = new Node<T>(value);
                    this._head = tempNode;
                }
                else
                {
                    tempNode = new Node<T>(value);
                    tempNode.Next = this._head;
                    this._head = tempNode;
                }
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                tempNode = new Node<T>(value);
                tempNode.Next = prevNode.Next;
                prevNode.Next = tempNode;
            }

            this._count++;
        }

        /// <summary>
        /// Method04：移除指定位置的节点
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                this._head = this._head.Next;
            }
            else
            {
                Node<T> prevNode = GetNodeByIndex(index - 1);
                if (prevNode.Next == null)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }

                Node<T> deleteNode = prevNode.Next;
                prevNode.Next = deleteNode.Next;

                deleteNode = null;
            }

            this._count--;
        }
    }

    /// <summary>
    /// 单链表节点的定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        // 数据域
        public T Item; 
        // 指针域
        public Node<T> Next;

        /// <summary>
        /// 自定义无参构造函数
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// 自定义有一个参数的构造函数（构造函数重载）
        /// </summary>
        /// <param name="item"></param>
        /// <param name="next"></param>
        public Node(T item, Node<T> next = null)
        {
            this.Item = item;
            this.Next = next;
        }
    }
}