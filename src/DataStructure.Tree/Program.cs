using System;

namespace DataStructure.Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyBinaryTreeBasicTest();
            // MyBinarySearchTreeTest();
            // MyBuildTree();
            MyBuildTree2();
            Console.ReadKey();
        }

        #region Test01:基本测试
        static void MyBinaryTreeBasicTest()
        {
            // 构造一颗二叉树，根节点为"A"
            MyBinaryTree<string> bTree = new MyBinaryTree<string>("A");
            Node<string> rootNode = bTree.Root;
            // 向根节点"A"插入左孩子节点"B"和右孩子节点"C"
            bTree.InsertLeft(rootNode, "B");
            bTree.InsertRight(rootNode, "C");
            // 向节点"B"插入左孩子节点"D"和右孩子节点"E"
            Node<string> nodeB = rootNode.lchild;
            bTree.InsertLeft(nodeB, "D");
            bTree.InsertRight(nodeB, "E");
            // 向节点"C"插入右孩子节点"F"
            Node<string> nodeC = rootNode.rchild;
            bTree.InsertRight(nodeC, "F");

            // 移除节点B的左子树
            // var data1 = bTree.RemoveLeft(bTree.Root.lchild);
            // 移除节点C的右子树
            // var data2 = bTree.RemoveRight(bTree.Root.rchild);

            // 前序遍历
            Console.WriteLine("---------PreOrder---------");
            bTree.PreOrder(bTree.Root);
            // 中序遍历
            Console.WriteLine();
            Console.WriteLine("---------MidOrder---------");
            bTree.MidOrder(bTree.Root);
            // 后序遍历
            Console.WriteLine();
            Console.WriteLine("---------PostOrder---------");
            bTree.PostOrder(bTree.Root);
            Console.WriteLine();

            // 前序遍历（非递归）
            Console.WriteLine("---------PreOrderNoRecursive---------");
            bTree.PreOrderNoRecursive(bTree.Root);
            // 中序遍历（非递归）
            Console.WriteLine();
            Console.WriteLine("---------MidOrderNoRecursive---------");
            bTree.MidOrderNoRecursive(bTree.Root);
            // 后序遍历（非递归）
            Console.WriteLine();
            Console.WriteLine("---------PostOrderNoRecursive---------");
            bTree.PostOrderNoRecursive(bTree.Root);
            Console.WriteLine();
            // 层次遍历
            Console.WriteLine("---------LevelOrderNoRecursive---------");
            bTree.LevelOrder(bTree.Root);
        }
        #endregion

        #region Test02:二叉查找树基本测试
        static void MyBinarySearchTreeTest()
        {
            MyBinarySearchTree bst = new MyBinarySearchTree(8);
            bst.InsertNode(3);
            bst.InsertNode(10);
            bst.InsertNode(1);
            bst.InsertNode(6);
            bst.InsertNode(14);
            bst.InsertNode(4);
            bst.InsertNode(7);
            bst.InsertNode(13);

            Console.WriteLine("----------First LevelOrder----------");
            bst.LevelOrder(bst.Root);
            Console.WriteLine();

            Console.WriteLine("----------二叉搜索树的中序遍历----------");
            bst.MidOrder(bst.Root);
            Console.WriteLine();

            bst.RemoveNode(6);
            Console.WriteLine("----------LevelOrder Again----------");
            bst.LevelOrder(bst.Root);
            Console.WriteLine();
        }
        #endregion

        #region 前序、中序遍历构建二叉树

        public static void MyBuildTree()
        {
            var tree = new MyBuildTree();
            var preOrder = new int[] { 3, 9, 20, 15, 7 };
            var inOrder = new int[] { 9, 3, 15, 20, 7 };
            var data = tree.BuildTree(preOrder, inOrder); // 前序、中序构造二叉树
            Console.WriteLine("Hello World!");
        }

        #endregion

        #region 中序、后序遍历构建二叉树

        public static void MyBuildTree2()
        {
            var tree = new MyBuildTree();
            var inOrder = new int[] { 9, 3, 15, 20, 7 };
            var postOrder = new int[] { 9, 15, 7, 20, 3 };
            var data2 = tree.BuildTree2(inOrder, postOrder); // 中序、后序构造二叉树
            Console.WriteLine("Hello World!");
        }

        #endregion
    }
}
