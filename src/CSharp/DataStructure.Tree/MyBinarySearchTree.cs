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
        public Node<int> Tree { get; private set; }

        public MyBinarySearchTree() { }

        public MyBinarySearchTree(int data)
        {
            this.Tree = new Node<int>(data);
        }

        #region 基本的创建与移除方法

        /// <summary>
        /// 判断该二叉树是否是空树
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.Tree == null;
        }

        /// <summary>
        /// 插入一个新节点
        /// </summary>
        /// <param name="data"></param>
        public void InsertNode(int data)
        {
            if (this.Tree == null)
            {
                this.Tree = new Node<int>(data);
            }

            var currentNode = Tree;
            while (currentNode != null)
            {
                // 若插入的元素值不小于当前节点值，则将元素插入到当前节点右子树中
                if (data > currentNode.data)
                {
                    if (currentNode.rchild == null)
                    {
                        currentNode.rchild = new Node<int>(data);
                        return;
                    }
                    currentNode = currentNode.rchild;
                }
                else
                {
                    // 若插入的元素值小于当前节点值，则将元素插入到当前节点左子树中
                    // data < p.data
                    if (currentNode.lchild == null)
                    {
                        currentNode.lchild = new Node<int>(data);
                        return;
                    }
                    currentNode = currentNode.lchild;
                }
            }
        }

        /// <summary>
        /// 移除一个旧节点
        /// </summary>
        /// <param name="data"></param>
        public void RemoveNode(int data)
        {
            var p = Tree; // p指向要删除的节点，初始化指向根节点
            Node<int> pp = null; // pp记录的是p的父节点
            while (p != null && p.data != data)
            {
                pp = p;
                p = data > p.data ? p.rchild : p.lchild;
            }
            if (p == null) return; // 没有找到

            // 要删除的节点有两个子节点
            if (p.lchild != null && p.rchild != null)
            { // 查找右子树中最小节点
                var minP = p.rchild;
                var minPp = p; // minPP表示minP的父节点
                while (minP.lchild != null)
                {
                    minPp = minP;
                    minP = minP.lchild;
                }
                p.data = minP.data; // 将minP的数据替换到p中
                p = minP; // 下面就变成了删除minP了
                pp = minPp;
            }

            // 删除节点是叶子节点或者仅有一个子节点
            Node<int> child; // p的子节点
            if (p.lchild != null) child = p.lchild;
            else if (p.rchild != null) child = p.rchild;
            else child = null;

            if (pp == null) Tree = child; // 删除的是根节点
            else if (pp.lchild == p) pp.lchild = child;
            else pp.rchild = child;
        }

        /// <summary>
        /// 根据data查找某个节点
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<int> FindNode(int data)
        {
            var currentNode = this.Tree;
            while (currentNode != null)
            {
                if (currentNode.data < data)
                {
                    currentNode = currentNode.rchild;
                }
                else if (currentNode.data > data)
                {
                    currentNode = currentNode.lchild;
                }
                else
                {
                    return currentNode;
                }
            }

            return null;
        }

        /// <summary>
        /// 查找最小值
        /// </summary>
        /// <returns></returns>
        public Node<int> FindMin()
        {
            if (Tree == null)
            {
                return null;
            }

            var currentNode = Tree;
            while (currentNode.lchild != null)
            {
                currentNode = currentNode.lchild;
            }

            return currentNode;
        }

        /// <summary>
        /// 查找最大值
        /// </summary>
        /// <returns></returns>
        public Node<int> FindMax()
        {
            if (Tree == null)
            {
                return null;
            }
            var currentNode = this.Tree;
            while (currentNode.rchild != null)
            {
                currentNode = currentNode.rchild;
            }

            return currentNode;
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
        /// <param name="tree"></param>
        /// <returns></returns>
        public int GetDepth(Node<int> tree)
        {
            if (tree == null)
            {
                return 0;
            }

            var leftDepth = GetDepth(tree.lchild);
            var rightDepth = GetDepth(tree.rchild);

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
            if (Tree == null)
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