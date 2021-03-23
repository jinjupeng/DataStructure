using System;

namespace DataStructure.Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyAdjacencyListBFSTraverseTest();
            MyAdjacencyListDFSTraverseTest();
        }

        public static void MyAdjacencyListBFSTraverseTest()
        {
            Console.WriteLine("------------无向图------------");
            MyAdjacencyList<string> adjList = new MyAdjacencyList<string>();
            // 添加顶点
            adjList.AddVertex("A");
            adjList.AddVertex("B");
            adjList.AddVertex("C");
            adjList.AddVertex("D");
            //adjList.AddVertex("D"); // 会报异常：添加了重复的节点
            // 添加无向边
            adjList.AddEdge("A", "B");
            adjList.AddEdge("A", "C");
            adjList.AddEdge("A", "D");
            adjList.AddEdge("B", "D");
            //adjList.AddEdge("B", "D"); // 会报异常：添加了重复的边

            Console.Write(adjList.GetGraphInfo());


            Console.WriteLine("------------有向图------------");
            MyAdjacencyList<string> dirAdjList = new MyAdjacencyList<string>();
            // 添加顶点
            dirAdjList.AddVertex("A");
            dirAdjList.AddVertex("B");
            dirAdjList.AddVertex("C");
            dirAdjList.AddVertex("D");
            // 添加有向边
            dirAdjList.AddDirectedEdge("A", "B");
            dirAdjList.AddDirectedEdge("A", "C");
            dirAdjList.AddDirectedEdge("A", "D");
            dirAdjList.AddDirectedEdge("B", "D");

            Console.Write(dirAdjList.GetGraphInfo(true));

            Console.Write("广度优先遍历：");
            // BFS遍历
            adjList.BFSTraverse();
            Console.WriteLine();
        }

        public static void MyAdjacencyListDFSTraverseTest()
        {
            Console.Write("深度优先遍历：");
            MyAdjacencyList<string> adjList = new MyAdjacencyList<string>();
            // 添加顶点
            adjList.AddVertex("V1");
            adjList.AddVertex("V2");
            adjList.AddVertex("V3");
            adjList.AddVertex("V4");
            adjList.AddVertex("V5");
            adjList.AddVertex("V6");
            adjList.AddVertex("V7");
            adjList.AddVertex("V8");
            // 添加边
            adjList.AddEdge("V1", "V2");
            adjList.AddEdge("V1", "V3");
            adjList.AddEdge("V2", "V4");
            adjList.AddEdge("V2", "V5");
            adjList.AddEdge("V3", "V6");
            adjList.AddEdge("V3", "V7");
            adjList.AddEdge("V4", "V8");
            adjList.AddEdge("V5", "V8");
            adjList.AddEdge("V6", "V8");
            adjList.AddEdge("V7", "V8");
            // DFS遍历
            adjList.DFSTraverse();
            Console.WriteLine();
        }
    }
}
