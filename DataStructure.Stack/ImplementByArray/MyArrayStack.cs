namespace DataStructure.Stack.ImplementByArray
{
    /// <summary>
    /// 基于数组实现的顺序栈
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class MyArrayStack<T>
    {
        private T[] _nodes;

        public MyArrayStack(int capacity)
        {
            this._nodes = new T[capacity];
            this.Size = 0;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="node">节点元素</param>
        public void Push(T node)
        {
            if (Size == _nodes.Length)
            {
                // 增大数组容量
                ResizeCapacity(_nodes.Length * 2);
            }

            _nodes[Size] = node;
            Size++;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns>出栈节点元素</returns>
        public T Pop()
        {
            if (Size == 0)
            {
                return default(T);
            }

            T node = _nodes[Size - 1];
            Size--;
            _nodes[Size] = default(T);

            if (Size > 0 && Size == _nodes.Length / 4)
            {
                // 缩小数组容量
                ResizeCapacity(_nodes.Length / 2);
            }
            return node;
        }

        /// <summary>
        /// 重置数组大小
        /// </summary>
        /// <param name="newCapacity">新的容量</param>
        private void ResizeCapacity(int newCapacity)
        {
            T[] newNodes = new T[newCapacity];
            if (newCapacity > _nodes.Length)
            {
                for (int i = 0; i < _nodes.Length; i++)
                {
                    newNodes[i] = _nodes[i];
                }
            }
            else
            {
                for (int i = 0; i < newCapacity; i++)
                {
                    newNodes[i] = _nodes[i];
                }
            }

            _nodes = newNodes;
        }

        /// <summary>
        /// 栈是否为空
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