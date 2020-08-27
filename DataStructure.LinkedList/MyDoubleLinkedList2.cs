using System;

namespace DataStructure.LinkedList
{
    public class MyDoubleLinkedList2<T>
    {
        private DbNode<T> _head; // 字段：当前链表的头结点

        // 属性：当前链表节点个数
        public int Count { get; set; }

        public T this[int index]
        {
            get => this.GetNodeByIndex(index).Item;
            set => this.GetNodeByIndex(index).Item = value;
        }

        public MyDoubleLinkedList2()
        {
            this.Count = 0;
            this._head = null;
        }


        public bool CheckIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取指定位置节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DbNode<T> GetNodeByIndex(int index)
        {
            if (!this.CheckIndex(index))
            {
                return null;
            }
            DbNode<T> tempNode = this._head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// 头节点之前添加数据
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(T item)
        {
            DbNode<T> tempNode;
            if (this._head == null)
            {
                tempNode = new DbNode<T>(item);
                this._head = tempNode;
            }
            else
            {
                var lastNode = GetNodeByIndex(Count - 1);
                tempNode = new DbNode<T>(item);
                tempNode.Next = this._head;
                tempNode.Prev = lastNode;
                lastNode.Next = tempNode;
                this._head.Prev = tempNode;
                this._head = tempNode;
            }

            Count++;
        }

        /// <summary>
        /// 尾节点之后添加数据
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            DbNode<T> newNode = new DbNode<T>(item);
            if (this._head == null)
            {
                // 如果链表当前为空则置为头结点
                this._head = newNode;
            }
            else
            {
                DbNode<T> lastNode = this.GetNodeByIndex(this.Count - 1);
                // 调整插入节点与前驱节点指针关系
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
                newNode.Next = this._head;
                this._head.Prev = newNode;
            }
            this.Count++;
        }

        /// <summary>
        /// 删除指定位置节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Delete(int index)
        {
            DbNode<T> deleteNode = this.GetNodeByIndex(index);
            if (deleteNode.Next == null)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            DbNode<T> prevNode = deleteNode.Prev;
            DbNode<T> nextNode = deleteNode.Next;
            prevNode.Next = nextNode;
            if (nextNode != null)
            {
                nextNode.Prev = prevNode;
            }

            if (index == 0)
            {
                this._head = nextNode;
            }
            Count--;
            return deleteNode.Item;
        }

        /// <summary>
        /// 移除尾节点
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            return Delete(Count - 1);
        }

        /// <summary>
        /// 移除头节点
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst()
        {
            return Delete(0);
        }
    }

}