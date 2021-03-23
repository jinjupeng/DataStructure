namespace DataStructure.Tree
{
    /// <summary>
    /// 构建二叉树
    /// </summary>
    public class MyBuildTree
    {
        private int[] _preOrder; // 前序
        private int[] _inOrder; // 中序
        private int[] _postOrder; // 后序
        private int _tag; // 下一个要找的根节点的下标

        #region 根据前序和中序遍历构造二叉树

        /// <summary>
        /// 剑指 Offer 07. 重建二叉树
        /// </summary>
        /// <param name="preorder">前序遍历</param>
        /// <param name="inorder">中序遍历</param>
        /// <returns>二叉树</returns>
        public Node<int> BuildTree(int[] preorder, int[] inorder)
        {
            /*
               二叉树的前序遍历：根节点 —> 左子树 —> 右子树
               二叉树的中序遍历：左子树 —> 根节点 —> 右子树
               由此可知：前序遍历中访问到的第一个元素便是根节点，通过该点便可以将中序遍历分成左右两部分，左部分的元素用来生成该二叉树的左子树，右部分用来生成二叉树的右子树。
               同样，左右两部分的元素中，首先在前序遍历中出现的便是该子树的根节点，很明显符合递归的定义。
             */
            this._preOrder = preorder;
            this._inOrder = inorder;
            this._tag = 0;

            return GenerateTree(0, preorder.Length - 1);
        }

        /// <summary>
        /// 用中序 s 到 e 下标所指向的元素生成二叉树，并返回根节点
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private Node<int> GenerateTree(int s, int e)
        {
            if (s > e)
            {
                return null;
            }

            Node<int> node = null;
            for (var i = s; i <= e; i++)
            {
                if (_inOrder[i] == _preOrder[_tag])
                {
                    node = new Node<int>(_preOrder[_tag++]);

                    // 递归遍历生成左子树
                    node.lchild = GenerateTree(s, i - 1);

                    // 递归遍历生成右子树
                    node.rchild = GenerateTree(i + 1, e);
                    break;
                }
            }

            return node;
        }

        #endregion

        #region 根据中序和后序遍历构造二叉树

        /// <summary>
        /// 中序、后序构造二叉树
        /// </summary>
        /// <param name="inOrder"></param>
        /// <param name="postOrder"></param>
        /// <returns></returns>
        public Node<int> BuildTree2(int[] inOrder, int[] postOrder)
        {
            /*
             前序的遍历顺序是：根，左，右；
             中序的遍历顺序是左，根，右；
             后序的遍历顺序是左，右，根；
             如果我们将后序遍历倒过来看便是根，右，左；会发现和前序遍历是非常相似的。
             前序遍历依次是根节点，左子树根节点，右子树根节点；
             后序遍历倒过来依次是根节点，右子树根节点，左子树根节点；
             因此解法和前序+中序生成后序的思路一样，从后序遍历中倒过来查找根节点，且先生成该节点的右子树，在生成该节点的左子树即可。
             */
            this._inOrder = inOrder;
            this._postOrder = postOrder;
            this._tag = postOrder.Length - 1;

            return GenerateTree2(0, _postOrder.Length - 1);


        }

        /// <summary>
        /// 用中序 s 到 e 下标所指向的元素生成二叉树，并返回根节点
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private Node<int> GenerateTree2(int s, int e)
        {
            if (s > e)
            {
                return null;
            }

            Node<int> node = null;
            for (var i = s; i <= e; i++)
            {
                if (_inOrder[i] == _postOrder[_tag])
                {
                    node = new Node<int>(_postOrder[_tag--]);

                    // 递归遍历生成右子树
                    node.rchild = GenerateTree2(i + 1, e);

                    // 递归遍历生成左子树
                    node.lchild = GenerateTree2(s, i - 1);

                    break;
                }
            }

            return node;
        }

        #endregion
    }
}