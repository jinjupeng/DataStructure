namespace DataStructure.Tree
{
    /// <summary>
    /// 二叉树的节点定义
    /// </summary>
    /// <typeparam name="T">数据具体类型</typeparam>
    public class Node<T>
    {
        public T data { get; set; }
        public Node<T> lchild { get; set; }
        public Node<T> rchild { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Node()
        {

        }

        /// <summary>
        /// 有一个参数的构造函数
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            this.data = data;
        }

        /// <summary>
        /// 有三个参数的构造函数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="lchild"></param>
        /// <param name="rchild"></param>
        public Node(T data, Node<T> lchild, Node<T> rchild)
        {
            this.data = data;
            this.lchild = lchild;
            this.rchild = rchild;
        }
    }
}