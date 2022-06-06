using System;

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
        public Node<T> GetNodeByIndex(int index)
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
        /// 在尾节点插入新的节点，该方法可以用来构造环状单链表
        /// </summary>
        /// <param name="newNode"></param>
        public void Add(Node<T> newNode)
        {
            if(this._head == null)
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

        /// <summary>
        /// 判断单链表是否有环，若有环则找到入口
        /// 使用快慢指针的方式
        /// </summary>
        /// <param name="head">链表头节点</param>
        /// <returns>若为空，则不存在环；不为空，则输出为入口节点</returns>
        public Node<T> DetectCircleByFastSlow()
        {
            // 快慢指针从头节点开始
            Node<T> fast = _head;
            Node<T> slow = _head;
            // 用于记录相遇点
            Node<T> encounter = null;
            // fast一次走两步，所以要保证next和next.next都不为空，为空则说明无环
            while (fast.Next != null && fast.Next.Next != null)
            {
                // fast走两步，slow走一步
                fast = fast.Next.Next;
                slow = slow.Next;
                // fast和slow一样，说明相遇了，或者fast追上slow了
                if (fast == slow)
                {
                    // 记录相遇点，fast和slow都一样
                    encounter = fast;
                    // 相遇了，就退出环检测过程
                    break;
                }
            }

            // 如果encounter为空，说明没有环，就不用继续找环入口了
            if (encounter == null)
            {
                return encounter;
            }

            // 计算环的入口点

            // fast回到head位置
            fast = _head;
            // 只要两者不相遇，就一直走下去
            while (fast != slow)
            {
                // fast每次走一步，slow每次走一步，速度一样
                fast = fast.Next;
                slow = slow.Next;
            }

            // 相遇点，即为环入口
            return fast;
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