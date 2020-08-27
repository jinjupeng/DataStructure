namespace DataStructure.Queue.ImplementByLinkedList
{
    /// <summary>
    /// 用链表实现链式队列
    /// </summary>
    public class MyLinkedListQueue<T>
    {
        // 队列的队首和队尾
        private Node<T> _head;
        private Node<T> _tail;

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            if (_tail == null)
            {
                Node<T> newNode = new Node<T>(value, null);
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = new Node<T>(value, null);
                _tail = _tail.Next;
            }
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (_head == null)
            {
                return default(T);
            }

            T value = _head.Data;
            _head = _head.Next;
            if (_head == null)
            {
                _tail = null;
            }

            return value;
        }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _head == _tail;
        }
    }

    /// <summary>
    /// 自定义节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;

        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}