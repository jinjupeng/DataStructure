using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Graph
{
    /// <summary>
    /// 模拟图的邻接表存储方式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyAdjacencyList<T> where T : class
    {
        private readonly List<Vertex<T>> _items;  // 图的顶点集合

        public MyAdjacencyList()
            : this(10)
        {
        }

        public MyAdjacencyList(int capacity)
        {
            this._items = new List<Vertex<T>>(capacity);
        }

        #region 基本方法：为图中添加顶点、添加有向与无向边
        /// <summary>
        /// 添加一个顶点
        /// </summary>
        /// <param name="item">顶点元素data</param>
        public void AddVertex(T item)
        {
            if (Contains(item))
            {
                throw new ArgumentException("添加了重复的顶点！");
            }

            Vertex<T> newVertex = new Vertex<T>(item);
            _items.Add(newVertex);
        }

        /// <summary>
        /// 添加一条无向边
        /// </summary>
        /// <param name="from">头顶点data</param>
        /// <param name="to">尾顶点data</param>
        public void AddEdge(T from, T to)
        {
            var fromVertex = Find(from);
            if (fromVertex == null)
            {
                throw new ArgumentException("头顶点不存在！");
            }

            var toVertex = Find(to);
            if (toVertex == null)
            {
                throw new ArgumentException("尾顶点不存在！");
            }

            // 无向图的两个顶点都需要记录边的信息
            AddDirectedEdge(fromVertex, toVertex);
            AddDirectedEdge(toVertex, fromVertex);
        }

        /// <summary>
        /// 添加一条有向边
        /// </summary>
        /// <param name="fromVertex">头顶点</param>
        /// <param name="toVertex">尾顶点</param>
        private void AddDirectedEdge(Vertex<T> fromVertex, Vertex<T> toVertex)
        {
            if (fromVertex.FirstEdge == null)
            {
                fromVertex.FirstEdge = new Node(toVertex);
            }
            else
            {
                Node temp = null;
                var node = fromVertex.FirstEdge;

                do
                {
                    // 检查是否添加了重复边
                    if (node.Adjvex.Data.Equals(toVertex.Data))
                    {
                        throw new ArgumentException("添加了重复的边！");
                    }
                    temp = node;
                    node = node.Next;
                } while (node != null);

                var newNode = new Node(toVertex);
                temp.Next = newNode;
            }
        }

        /// <summary>
        /// 添加一条有向边
        /// </summary>
        /// <param name="from">头结点data</param>
        /// <param name="to">尾节点data</param>
        public void AddDirectedEdge(T from, T to)
        {
            var fromVertex = Find(from);
            if (fromVertex == null)
            {
                throw new ArgumentException("头顶点不存在！");
            }

            var toVertex = Find(to);
            if (toVertex == null)
            {
                throw new ArgumentException("尾顶点不存在！");
            }

            AddDirectedEdge(fromVertex, toVertex);
        }

        /// <summary>
        /// 打印打印每个顶点和它的邻接点
        /// </summary>
        /// <param name="isDirectedGraph">是否是有向图</param>
        public string GetGraphInfo(bool isDirectedGraph = false)
        {
            var sb = new StringBuilder();
            foreach (var v in _items)
            {
                sb.Append(v.Data.ToString() + ":");
                if (v.FirstEdge != null)
                {
                    var temp = v.FirstEdge;
                    while (temp != null)
                    {
                        if (isDirectedGraph)
                        {
                            sb.Append(v.Data.ToString() + "→" + temp.Adjvex.Data.ToString() + " ");
                        }
                        else
                        {
                            sb.Append(temp.Adjvex.Data.ToString());
                        }
                        temp = temp.Next;
                    }
                }
                sb.Append("\r\n");
            }

            return sb.ToString();
        }
        #endregion

        #region 辅助方法：图中是否包含某个元素、查找指定顶点、初始化visited标志
        /// <summary>
        /// 辅助方法：查找图中是否包含某个元素
        /// </summary>
        private bool Contains(T item)
        {
            foreach (var v in _items)
            {
                if (v.Data.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 辅助方法：查找指定项并返回
        /// </summary>
        private Vertex<T> Find(T item)
        {
            foreach (var v in _items)
            {
                if (v.Data.Equals(item))
                {
                    return v;
                }
            }

            return null;
        }

        /// <summary>
        /// 辅助方法：初始化顶点的visited标志为false
        /// </summary>
        public void InitVisited()
        {
            foreach (var v in _items)
            {
                v.IsVisited = false;
            }
        }
        #endregion

        #region 广度优先和深度优先遍历算法

        /// <summary>
        /// 广度优先遍历接口For连通图
        /// </summary>
        public void BFSTraverse()
        {
            InitVisited(); // 首先初始化visited标志
            BFS(_items[0]); // 从第一个顶点开始遍历
        }

        /// <summary>
        /// 广度优先遍历算法
        /// </summary>
        /// <param name="v">顶点</param>
        private void BFS(Vertex<T> v)
        {
            v.IsVisited = true; // 首先将访问标志设为true标识为已访问
            Console.Write(v.Data.ToString() + " "); // 进行访问操作：这里是输出顶点data
            var verQueue = new Queue<Vertex<T>>(); // 使用队列存储
            verQueue.Enqueue(v);

            while (verQueue.Count > 0)
            {
                var w = verQueue.Dequeue();
                var node = w.FirstEdge;
                // 访问此顶点的所有邻接节点
                while (node != null)
                {
                    // 如果邻接节点没有被访问过则访问它的边
                    if (node.Adjvex.IsVisited == false)
                    {
                        node.Adjvex.IsVisited = true; // 设置为已访问
                        Console.Write(node.Adjvex.Data + " "); // 访问
                        verQueue.Enqueue(node.Adjvex); // 入队
                    }
                    node = node.Next; // 访问下一个邻接点
                }
            }
        }

        /// <summary>
        /// 深度优先遍历接口For连通图
        /// </summary>
        public void DFSTraverse()
        {
            InitVisited(); // 首先初始化visited标志
            DFS(_items[0]); // 从第一个顶点开始遍历
        }

        /// <summary>
        /// 深度优先遍历算法
        /// </summary>
        /// <param name="v">顶点</param>
        private void DFS(Vertex<T> v)
        {
            v.IsVisited = true; // 首先将访问标志设为true标识为已访问
            Console.Write(v.Data + " "); // 进行访问操作：这里是输出顶点data
            var node = v.FirstEdge;

            while (node != null)
            {
                if (node.Adjvex.IsVisited == false) // 如果邻接顶点未被访问
                {
                    DFS(node.Adjvex); // 递归访问node的邻接顶点
                }
                node = node.Next; // 访问下一个邻接点
            }
        }
        #endregion

        /// <summary>
        /// 嵌套类：存放于数组中的表头节点
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        public class Vertex<TValue>
        {
            public TValue Data;     // 数据
            public Node FirstEdge;  // 邻接点链表头指针
            public bool IsVisited;  // 访问标志：遍历时使用

            public Vertex()
            {
                this.Data = default(TValue);
            }

            public Vertex(TValue value)
            {
                this.Data = value;
            }
        }

        /// <summary>
        /// 嵌套类：链表中的表节点
        /// </summary>
        public class Node
        {
            public Vertex<T> Adjvex;    // 邻接点域
            public Node Next;           // 下一个邻接点指针域

            public Node()
            {
                this.Adjvex = null;
            }

            public Node(Vertex<T> value)
            {
                this.Adjvex = value;
            }
        }
    }
}