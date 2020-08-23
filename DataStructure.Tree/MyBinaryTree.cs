using System;

namespace DataStructure.Tree
{
    /// <summary>
    /// 二叉树的模拟实现
    /// </summary>
    public class MyBinaryTree<T>
    {
        /// <summary>
        /// 二叉树的根节点
        /// </summary>
        private Node<T> root;

        public Node<T> Root
        {
            get
            {
                return this.root;
            }
        }

        public MyBinaryTree()
        {

        }

        public MyBinaryTree(T data)
        {
            this.root = new Node<T>(data);
        }
        #region 二叉树的顺序存储结构（使用数组）

        /*
         * 注意：考虑一种极端的情况，一棵深度为k的右斜树，它只有k个结点，却需要分配2的k次方-1个存储单元空间，
         * 这显然是对存储空间的浪费，所以，顺序存储结构一般只适用于完全二叉树。
         */

        #endregion

        #region 二叉树的链式存储结构

        /// <summary>
        /// 判断二叉树是否为空树
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.root == null;
        }

        /// <summary>
        /// 在节点p下插入左孩子节点的data
        /// </summary>
        /// <param name="p"></param>
        /// <param name="data"></param>
        public void InsertLeft(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            tempNode.lchild = p.lchild;

            p.lchild = tempNode;
        }

        /// <summary>
        /// 在节点p下插入右孩子节点的data
        /// </summary>
        /// <param name="p"></param>
        /// <param name="data"></param>
        public void InsertRight(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            tempNode.rchild = p.rchild;

            p.rchild = tempNode;
        }

        /// <summary>
        /// 删除节点p下的左子树
        /// </summary>
        /// <param name="p"></param>
        /// <returns>返回删除的左子树</returns>
        public Node<T> RemoveLeft(Node<T> p)
        {
            if (p == null || p.lchild == null)
            {
                return null;
            }

            Node<T> tempNode = p.lchild;
            p.lchild = null;
            return tempNode;
        }

        /// <summary>
        /// 移除节点p下的右子树
        /// </summary>
        /// <param name="p"></param>
        /// <returns>返回删除的右子树</returns>
        public Node<T> RemoveRight(Node<T> p)
        {
            if (p == null || p.rchild == null)
            {
                return null;
            }

            Node<T> tempNode = p.rchild;
            p.rchild = null;
            return tempNode;
        }

        #region 基本的递归遍历方法

        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="node"></param>
        public void PreOrder(Node<T> node)
        {
            if (node != null)
            {
                // 根->左->右
                Console.Write(node.data + " ");
                PreOrder(node.lchild);
                PreOrder(node.rchild);
            }
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="node"></param>
        public void MidOrder(Node<T> node)
        {
            if (node != null)
            {
                // 左->根->右
                MidOrder(node.lchild);
                Console.Write(node.data + " ");
                MidOrder(node.rchild);
            }
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="node"></param>
        public void PostOrder(Node<T> node)
        {
            if (node != null)
            {
                // 左->右->根
                PostOrder(node.lchild);
                PostOrder(node.rchild);
                Console.Write(node.data + " ");
            }
        }
        #endregion
        #endregion
    }

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