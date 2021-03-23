namespace DataStructure.Stack.ImplementByLinkList
{
    /// <summary>
    /// 基于链表的栈节点
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        public Node(T item)
        {
            this.Item = item;
        }

        public Node()
        { }
    }

    /// <summary>
    /// 基于链表的栈实现
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class MyLinkStack<T>
    {
        private Node<T> _first;

        public MyLinkStack()
        {
            this._first = null;
            this.Size = 0;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item">新节点</param>
        public void Push(T item)
        {
            Node<T> oldNode = _first;
            _first = new Node<T> {Item = item, Next = oldNode};

            Size++;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns>出栈元素</returns>
        public T Pop()
        {
            T item = _first.Item;
            _first = _first.Next;
            Size--;

            return item;
        }

        /// <summary>
        /// 是否为空栈
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        /// <summary>
        /// 栈中节点个数
        /// </summary>
        public int Size { get; private set; }
    }
}