using System;

namespace DataStructure.LinkedList
{
    /// <summary>
    /// 双链表的模拟实现
    /// </summary>
    public class MyDoubleLinkedList<T>
    {
        private int count; // 字段：当前链表节点个数
        private DbNode<T> head; // 字段：当前链表的头结点

        // 属性：当前链表节点个数
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        // 索引器
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

        public MyDoubleLinkedList()
        {
            this.count = 0;
            this.head = null;
        }

        /// <summary>
        /// 根据索引获取节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private DbNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            DbNode<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        /// <summary>
        /// 在尾节点后插入新节点
        /// </summary>
        /// <param name="value"></param>
        public void AddAfter(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (this.head == null)
            {
                // 如果链表当前为空则置为头结点
                this.head = newNode;
            }
            else
            {
                DbNode<T> lastNode = this.GetNodeByIndex(this.count - 1);
                // 调整插入节点与前驱节点指针关系
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
            }
            this.count++;
        }

        /// <summary>
        /// 在尾节点前插入新节点
        /// </summary>
        /// <param name="value"></param>
        public void AddBefore(T value)
        {
            DbNode<T> newNode = new DbNode<T>(value);
            if (this.head == null)
            {
                // 如果链表当前为空则置为头结点
                this.head = newNode;
            }
            else
            {
                DbNode<T> lastNode = this.GetNodeByIndex(this.count - 1);
                DbNode<T> prevNode = lastNode.Prev;
                // 调整倒数第2个节点与插入节点的关系
                prevNode.Next = newNode;
                newNode.Prev = prevNode;
                // 调整倒数第1个节点与插入节点的关系
                lastNode.Prev = newNode;
                newNode.Next = lastNode;
            }
            this.count++;
        }

        /// <summary>
        /// 在指定位置后插入新节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertAfter(int index, T value)
        {
            DbNode<T> tempNode;
            if (index == 0)
            {
                if (this.head == null)
                {
                    tempNode = new DbNode<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new DbNode<T>(value);
                    tempNode.Next = this.head;
                    this.head.Prev = tempNode;
                    this.head = tempNode;
                }
            }
            else
            {
                DbNode<T> prevNode = this.GetNodeByIndex(index); // 获得插入位置的节点
                DbNode<T> nextNode = prevNode.Next; // 获取插入位置的后继节点
                tempNode = new DbNode<T>(value);
                // 调整插入节点与前驱节点指针关系
                prevNode.Next = tempNode;
                tempNode.Prev = prevNode;
                // 调整插入节点与后继节点指针关系
                if (nextNode != null)
                {
                    tempNode.Next = nextNode;
                    nextNode.Prev = tempNode;
                }
            }
            this.count++;
        }

        /// <summary>
        /// 在指定位置前插入新节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertBefore(int index, T value)
        {
            DbNode<T> tempNode;
            if (index == 0)
            {
                if (this.head == null)
                {
                    tempNode = new DbNode<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new DbNode<T>(value);
                    tempNode.Next = this.head;
                    this.head.Prev = tempNode;
                    this.head = tempNode;
                }
            }
            else
            {
                DbNode<T> nextNode = this.GetNodeByIndex(index); // 获得插入位置的节点
                DbNode<T> prevNode = nextNode.Prev; // 获取插入位置的前驱节点
                tempNode = new DbNode<T>(value);
                // 调整插入节点与前驱节点指针关系
                prevNode.Next = tempNode;
                tempNode.Prev = prevNode;
                // 调整插入节点与后继节点指针关系
                tempNode.Next = nextNode;
                nextNode.Prev = tempNode;
            }
            this.count++;
        }

        /// <summary>
        /// 移除指定位置的节点
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                DbNode<T> prevNode = this.GetNodeByIndex(index - 1);
                if (prevNode.Next == null)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }

                DbNode<T> deleteNode = prevNode.Next;
                DbNode<T> nextNode = deleteNode.Next;
                prevNode.Next = nextNode;
                if (nextNode != null)
                {
                    nextNode.Prev = prevNode;
                }

                deleteNode = null;
            }
            this.count--;
        }
    }

    /// <summary>
    /// 双链表节点的定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbNode<T>
    {
        public T Item { get; set; }

        /// <summary>
        /// 指向前驱节点的Prev指针域
        /// </summary>
        public DbNode<T> Prev { get; set; }

        /// <summary>
        /// 指向后继节点的Next指针域
        /// </summary>
        public DbNode<T> Next { get; set; }

        public DbNode()
        {

        }

        public DbNode(T item)
        {
            this.Item = item;
        }
    }
}