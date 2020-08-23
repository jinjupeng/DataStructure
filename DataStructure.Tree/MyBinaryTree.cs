using System;
using System.Collections;
using System.Collections.Generic;

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

        #region 二叉树非递归实现

        /// <summary>
        /// 前序遍历
        /// 在该方法中，利用了栈的先进后出的特性，首先遍历显示根节点，
        /// 然后将右子树（注意是右子树不是左子树）压栈，最后将左子树压栈。
        /// 由于最后时将左子树节点压栈，所以下一次首先出栈的应该是左子树的根节点，
        /// 也就保证了先序遍历的规则。
        /// </summary>
        /// <param name="node"></param>
        public void PreOrderNoRecursive(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            // 根->左->右
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                // 1.遍历根节点
                var tempNode = stack.Pop();
                Console.Write(tempNode.data + " ");
                // 2.右子树进栈
                if (tempNode.rchild != null)
                {
                    stack.Push(tempNode.rchild);
                }
                // 3.左子树进栈（目的：保证下一个出栈的是左子树的节点）
                if (tempNode.lchild != null)
                {
                    stack.Push(tempNode.lchild);
                }
            }

        }

        /// <summary>
        /// 中序遍历
        /// 在该方法中，首先将根节点所有的左子树节点压栈，
        /// 然后一一出栈，每当出栈一个元素后，便将其右子树节点压栈。
        /// 这样就可以实现首先出栈的永远是栈中的左子树节点，
        /// 然后是根节点，最后时右子树节点，也就可以保证中序遍历的规则。
        /// </summary>
        /// <param name="node"></param>
        public void MidOrderNoRecursive(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            // 左->根->右
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> tempNode = node;

            while (tempNode != null || stack.Count > 0)
            {
                // 1.依次将所有左子树节点压栈
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.lchild;
                }
                // 2.出栈遍历节点
                tempNode = stack.Pop();
                Console.Write(tempNode.data + " ");
                // 3.左子树遍历结束则跳转到右子树
                tempNode = tempNode.rchild;
            }
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="node"></param>
        public void PostOrderNoRecursive(Node<T> node)
        {
            /*
             * 在该方法中，使用了两个栈来辅助，其中一个stackIn作为中间存储起到过渡作用，
             * 而另一个stackOut则作为最后的输出结果进行遍历显示。
             * 众所周知，栈的特性使LIFO（后进先出），
             * 那么stackIn在进行存储过渡时，先按照根节点->左孩子->右孩子的顺序依次压栈，
             * 那么其出栈顺序就是右孩子->左孩子->根节点。而每当循环一次就会从stackIn中出栈一个元素，并压入stackOut中，
             * 那么这时stackOut中的出栈顺序则变成了左孩子->右孩子->根节点的顺序，
             * 也就符合了后序遍历的规则。
             */
            if (root == null)
            {
                return;
            }

            // 两个栈：一个存储，一个输出
            Stack<Node<T>> stackIn = new Stack<Node<T>>();
            Stack<Node<T>> stackOut = new Stack<Node<T>>();
            // 根节点首先压栈
            stackIn.Push(node);
            // 左->右->根
            while (stackIn.Count > 0)
            {
                var currentNode = stackIn.Pop();
                stackOut.Push(currentNode);
                // 左子树压栈
                if (currentNode.lchild != null)
                {
                    stackIn.Push(currentNode.lchild);
                }
                // 右子树压栈
                if (currentNode.rchild != null)
                {
                    stackIn.Push(currentNode.rchild);
                }
            }

            while (stackOut.Count > 0)
            {
                // 依次遍历各节点
                Node<T> outNode = stackOut.Pop();
                Console.Write(outNode.data + " ");
            }
        }

        #endregion

        /// <summary>
        /// 层序遍历（广度优先遍历）
        /// </summary>
        /// <param name="node"></param>
        public void LevelOrder(Node<T> node)
        {
            /*
             * 在该方法中，使用了一个队列来辅助实现，队列是遵循FIFO（先进先出）的，与栈刚好相反，
             * 所以，我们这里只需要按照根节点->左孩子->右孩子的入队顺序依次入队，
             * 输出时就可以符合根节点->左孩子->右孩子的规则了。
             */
            if (root == null)
            {
                return;
            }

            Queue<Node<T>> queueNodes = new Queue<Node<T>>();
            queueNodes.Enqueue(node);
            // 利用队列先进先出的特性存储节点并输出
            while (queueNodes.Count > 0)
            {
                var tempNode = queueNodes.Dequeue();
                Console.Write(tempNode.data + " ");

                if (tempNode.lchild != null)
                {
                    queueNodes.Enqueue(tempNode.lchild);
                }

                if (tempNode.rchild != null)
                {
                    queueNodes.Enqueue(tempNode.rchild);
                }
            }
        }
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