using System;

namespace DataStructure.Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTreeBasicTest();

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
            var data1 = bTree.RemoveLeft(bTree.Root.lchild);
            // 移除节点C的右子树
            var data2 = bTree.RemoveRight(bTree.Root.rchild);

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
        }
        #endregion
    }
}
