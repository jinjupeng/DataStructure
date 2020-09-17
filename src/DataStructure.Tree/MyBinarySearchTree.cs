using System;
using System.Collections.Generic;

namespace DataStructure.Tree
{
    /// <summary>
    /// 二叉查找树的模拟实现
    /// </summary>
    public class MyBinarySearchTree
    {
        /*
         * 二叉查找树（Binary Search Tree）又称二叉排序树（Binary Sort Tree），亦称二叉搜索树。它具有以下几个性质：
         * 1. 若左子树不空，则左子树上所有节点的值均小于它的根节点的值
         * 2. 若右子树不空，则右子树上所有节点的值均大于或等于它的根节点的值
         * 3. 左、右子树也分别为二叉排序树
         * 4. 没有键值相等的特点
         * 注意：对于二叉排序树，只需要一次中序遍历即可得到排序后的遍历结果
         */

        // 二叉树的根节点
        private Node<int> _root;
        public Node<int> Root
        {
            get
            {
                return this._root;
            }
        }

        public MyBinarySearchTree() { }

        public MyBinarySearchTree(int data)
        {
            this._root = new Node<int>(data);
        }

        #region 基本的创建与移除方法

        /// <summary>
        /// 判断该二叉树是否是空树
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this._root == null;
        }

        /// <summary>
        /// 插入一个新节点
        /// </summary>
        /// <param name="data"></param>
        public void InsertNode(int data)
        {
            var newNode = new Node<int> {data = data};

            if (this._root == null)
            {
                this._root = newNode;
            }
            else
            {
                var currentNode = this._root;
                Node<int> parentNode = null;

                while (currentNode != null)
                {
                    parentNode = currentNode;
                    if (currentNode.data < data)
                    {
                        currentNode = currentNode.rchild;
                    }
                    else
                    {
                        currentNode = currentNode.lchild;
                    }
                }

                if (parentNode.data < data)
                {
                    // 若插入的元素值小于根节点值，则将元素插入到左子树中
                    parentNode.rchild = newNode;
                }
                else
                {
                    // 若插入的元素值不小于根节点值，则将元素插入到右子树中
                    parentNode.lchild = newNode;
                }
            }
        }

        /// <summary>
        /// 移除一个旧节点
        /// </summary>
        /// <param name="key"></param>
        public void RemoveNode(int key)
        {
            Node<int> current = null, parent = null;

            // 定位节点位置
            current = FindNode(key);

            // 没找到data为key的节点
            if (current == null)
            {
                Console.WriteLine("没有找到data为{0}的节点!", key);
                return;
            }

            #region 1.如果该节点是叶子节点
            if (current.lchild == null && current.rchild == null) // 如果该节点是叶子节点
            {
                if (current == this._root) // 如果该节点为根节点
                {
                    this._root = null;
                }
                else if (parent.lchild == current) // 如果该节点为左孩子节点
                {
                    parent.lchild = null;
                }
                else if (parent.rchild == current) // 如果该节点为右孩子节点
                {
                    parent.rchild = null;
                }
            }
            #endregion
            #region 2.如果该节点是单支节点
            else if (current.lchild == null || current.rchild == null) // 如果该节点是单支节点 (只有一个左孩子节点或者一个右孩子节点)
            {
                if (current == this._root) // 如果该节点为根节点
                {
                    if (current.lchild == null)
                    {
                        this._root = current.rchild;
                    }
                    else
                    {
                        this._root = current.lchild;
                    }
                }
                else
                {
                    if (parent.lchild == current && current.lchild != null)  // p是q的左孩子且p有左孩子
                    {
                        parent.lchild = current.lchild;
                    }
                    else if (parent.lchild == current && current.rchild != null) // p是q的左孩子且p有右孩子
                    {
                        parent.rchild = current.rchild;
                    }
                    else if (parent.rchild == current && current.lchild != null) // p是q的右孩子且p有左孩子
                    {
                        parent.rchild = current.lchild;
                    }
                    else // p是q的右孩子且p有右孩子
                    {
                        parent.rchild = current.rchild;
                    }
                }
            }
            #endregion
            #region 3.如果该节点的左右子树均不为空 
            else // 如果该节点的左右子树均不为空 
            {
                var t = current;
                var s = current.lchild; // 从p的左子节点开始 
                // 找到p的前驱，即p左子树中值最大的节点 
                while (s.rchild != null)
                {
                    t = s;
                    s = s.rchild;
                }

                current.data = s.data; // 把节点s的值赋给p

                if (t == current)
                {
                    current.lchild = s.lchild;
                }
                else
                {
                    current.rchild = s.rchild;
                }
            }
            #endregion
        }

        /// <summary>
        /// 根据Key查找某个节点
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node<int> FindNode(int key)
        {
            var currentNode = this._root;
            while (currentNode != null && currentNode.data != key)
            {
                if (currentNode.data < key)
                {
                    currentNode = currentNode.rchild;
                }
                else if (currentNode.data > key)
                {
                    currentNode = currentNode.lchild;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        }

        /// <summary>
        /// 查找最大值
        /// </summary>
        /// <returns></returns>
        public int FindMaxData()
        {
            var currentNode = this._root;
            while (currentNode != null)
            {
                currentNode = currentNode.rchild;
            }

            return currentNode.data;
        }

        /// <summary>
        /// 判断节点p是否叶子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsLeafNode(Node<int> p)
        {
            if (p == null)
            {
                return false;
            }

            return p.lchild == null && p.rchild == null;
        }

        /// <summary>
        /// 计算二叉树的深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetDepth(Node<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftDepth = GetDepth(root.lchild);
            var rightDepth = GetDepth(root.rchild);

            if (leftDepth > rightDepth)
            {
                return leftDepth + 1;
            }
            else
            {
                return rightDepth + 1;
            }
        }
        #endregion

        #region 基本的遍历方法

        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="node"></param>
        public void PreOrder(Node<int> node)
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
        public void MidOrder(Node<int> node)
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
        public void PostOrder(Node<int> node)
        {
            if (node != null)
            {
                // 左->右->根
                PostOrder(node.lchild);
                PostOrder(node.rchild);
                Console.Write(node.data + " ");
            }
        }

        /// <summary>
        /// 层次遍历（广度优先遍历）
        /// </summary>
        /// <param name="node"></param>
        public void LevelOrder(Node<int> node)
        {
            if (_root == null)
            {
                return;
            }

            var queueNodes = new Queue<Node<int>>();
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
}