using System;

namespace DataStructure.LinkedList
{
    /// <summary>
    /// 循环链表
    /// </summary>
    /// <summary>
    /// 单向循环链表的模拟实现
    /// </summary>
    public class MyCircularLinkedList<T>
    {
        /*
         * 循环链表和单链表的主要差异就在于循环的判断条件上，原来是判断p.next是否为空，现在则是p.next不等于头结点，则循环未结束。
         */
        private int _count; // 字段：记录数据元素个数
        private CirNode<T> _tail; // 字段：记录尾节点的指针
        private CirNode<T> _currentPrev; // 字段：使用前驱节点标识当前节点

        // 属性：指示链表中元素的个数
        public int Count
        {
            get
            {
                return this._count;
            }
        }

        // 属性：指示当前节点中的元素值
        public T CurrentItem
        {
            get
            {
                return this._currentPrev.Next.Item;
            }
        }

        public MyCircularLinkedList()
        {
            this._count = 0;
            this._tail = null;
        }

        public bool IsEmpty()
        {
            return this._tail == null;
        }

        // Method01:根据索引获取节点
        private CirNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this._count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            CirNode<T> tempNode = this._tail.Next;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        // Method02:在尾节点后插入新节点
        public void Add(T value)
        {
            CirNode<T> newNode = new CirNode<T>(value);
            if (this._tail == null)
            {
                // 如果链表当前为空则新元素既是尾头结点也是头结点
                this._tail = newNode;
                this._tail.Next = newNode;
                this._currentPrev = newNode;
            }
            else
            {
                // 插入到链表末尾处
                newNode.Next = this._tail.Next;
                this._tail.Next = newNode;
                // 改变当前节点
                if (this._currentPrev == this._tail)
                {
                    this._currentPrev = newNode;
                }
                // 重新指向新的尾节点
                this._tail = newNode;
            }

            this._count++;
        }

        // Method03:移除当前所在节点
        public void Remove()
        {
            if (this._tail == null)
            {
                throw new NullReferenceException("链表中没有任何元素");
            }
            else if (this._count == 1)
            {
                // 只有一个元素时将两个指针置为空
                this._tail = null;
                this._currentPrev = null;
            }
            else
            {
                if (this._currentPrev.Next == this._tail)
                {
                    // 当删除的是尾指针所指向的节点时
                    this._tail = this._currentPrev;
                }
                // 移除当前节点
                this._currentPrev.Next = this._currentPrev.Next.Next;
            }

            this._count--;
        }

        // Method04:获取所有节点信息
        public string GetAllNodes()
        {
            if (this._count == 0)
            {
                throw new NullReferenceException("链表中没有任何元素");
            }
            else
            {
                CirNode<T> tempNode = this._tail.Next;
                string result = string.Empty;
                for (int i = 0; i < this._count; i++)
                {
                    result += tempNode.Item + " ";
                    tempNode = tempNode.Next;
                }

                return result;
            }
        }
    }

    /// <summary>
    /// 自定义循环链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CirNode<T>
    {
        public T Item { get; set; }
        public CirNode<T> Next { get; set; }

        public CirNode()
        {
        }

        public CirNode(T item)
        {
            this.Item = item;
        }
    }
}