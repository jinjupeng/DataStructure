namespace DataStructure.Tree
{
    /// <summary>
    /// 平衡二叉树
    /// </summary>
    public class MyBalancedBinaryTree
    {
        /*
         * 平衡二叉树：一棵空树或树中任意节点的左右子树的深度相差都不超过1。
         */

        /// <summary>
        /// 判断是否是一颗平衡二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(Node<int> root)
        {
            /*
             * 输入一棵二叉树的根节点，判断该树是不是平衡二叉树。如果某二叉树中任意节点的左右子树的深度相差不超过1，那么它就是一棵平衡二叉树。
             */
            if (root == null)
            {
                return true; // 空树是平衡二叉树
            }

            var left = MaxDepth(root.lchild);
            var right = MaxDepth(root.rchild);
            var diff = left - right;
            if (diff > 1 || diff < -1)
            {
                return false;
            }

            return IsBalanced(root.lchild) && IsBalanced(root.rchild);
        }

        /// <summary>
        /// 二叉树深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int MaxDepth(Node<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            // 思路：深度优先遍历搜索(就是递归)
            var leftDepth = MaxDepth(root.lchild);
            var rightDepth = MaxDepth(root.rchild);

            if (leftDepth > rightDepth)
            {
                return leftDepth + 1;
            }

            return rightDepth + 1;
        }

        // 平衡二叉树的插入


        // 平衡二叉树的删除


    }
}