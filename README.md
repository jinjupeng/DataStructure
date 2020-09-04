# 数据结构与算法学习

> 记录学习[《数据结构与算法之美》](https://time.geekbang.org/column/intro/126)专栏的实现代码（C#）& 笔记。

[![](https://img.shields.io/github/issues/jinjupeng/DataStructure.svg)](https://github.com/jinjupeng/DataStructure/issues) [![](http://img.shields.io/github/forks/jinjupeng/DataStructure.svg)](https://github.com/jinjupeng/DataStructure/network)[![star this repo](https://badgen.net/github/stars/jinjupeng/DataStructure)](https://github.com/jinjupeng/DataStructure)[![License MIT](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://github.com/anjoy8/Blog.Core/blob/master/LICENSE) [![Language](https://img.shields.io/badge/language-csharp-d.svg)](#) 
---



## :open_file_folder: src

专栏中讲过的数据结构与算法的 C# 实现。内部包含了详细的代码注释、复杂度分析以及基本实现思路等等。

查看该 Repo 当前包含的数据结构与算法相关的代码，**戳这里**​ :point_right: :point_right: [代码](src/)。

**代码持续更新中 ......**

</br></br>



## :notebook: notes

为方便阅读学习过程中的笔记，笔记已经按照中文排版格式进行排版。排版格式参照 [中文文案排版指北](https://github.com/sparanoid/chinese-copywriting-guidelines)。

阅读笔记，**戳这里**​ :point_right: :point_right: [笔记](notes/)。

**笔记持续更新中 ......** </br></br>





## :pencil2: awesome-resources.md

学习过程中收集的关于数据结构与算法的资源，以及大佬经验。

**戳这里** :point_right: :point_right: [awesome-resources.md](awesome-resources.md)。

**资源持续更新中 ......** </br></br>



## :open_file_folder: practice

本文件夹包含了数据结构与算法对应的练习题及笔记，**戳这里**:point_right: :point_right: [实战](practice/) 。笔记内容清晰标记了复杂度、实现思路及具体实现代码，题目分类来源于 [LeetCode](https://leetcode.com/problemset/all/)。

**持续更新中 ......** </br></br>



## :black_nib: 计划

本 Repo 中， `src`文件夹包含的代码实现，基本上是按照如下列表顺序进行更新。已经完成的会进行特殊标注，除了下面一些数据结构与算法，还会包含一些专栏中涉及到的高级算法实现。如果你觉得某个/些算法也可以加入其中，不妨创建一个 `issue` ，我会把他添加到这里。

##### 数组

- [x] 实现一个支持动态扩容的数组 
- [x] 实现两个有序数组合并为一个有序数组
- [x] 实现一个大小固定的有序数组，支持动态增删改操作 

##### 链表

- [x] 实现单链表，支持增删操作
- [x] 实现循环链表、双向链表，支持增删操作
- [x] 实现单链表反转
- [x] 实现部分单链表翻转
- [x] 实现两个有序的链表合并为一个有序链表
- [x] 实现求链表的中间结点
- [x] 链表检测环
- [x] 单链表实现 LRU 缓存淘汰策略

##### 栈

- [x] 用数组实现一个顺序栈

- [x] 栈在表达式求值中的应用，及其在消消乐中的应用

- [x] 用链表实现一个链式栈
- [x] 编程模拟实现一个浏览器的前进、后退功能

##### 队列

- [x] 用数组实现一个顺序队列
- [x] 用链表实现一个链式队列

- [x] 数组实现一个循环队列

##### 递归

- [x] 编程实现斐波那契数列求值f(n)=f(n-1)+f(n-2)

- [ ] 最终推荐人检测环 A-B-C-A

- [x] 编程实现求阶乘n!
- [ ] 编程实现一组数据集合的全排列

##### 排序

- [x] 实现归并排序、快速排序、插入排序、冒泡排序、选择排序

- [ ] 编程实现O(n)时间复杂度内找到一组数据的第K大元素

##### 二分查找

- [x] 实现一个有序数组的二分查找算法
- [ ] 实现模糊二分查找算法（第一个等于给定值、最后一个等于给定值、第一个大于等于给定值、最后一个小于等于给定值）
- [ ] 循环有序数组查询指定值

##### 跳表

- [ ] 跳表实现

##### 散列表

- [ ] 实现一个基于链表法解决冲突问题的散列表
- [x] 实现一个 LRU 缓存淘汰算法

##### 字符串

- [ ] 实现一个字符集，只包含a～z这26个英文字母的Trie树
- [ ] 实现朴素的字符串匹配算法

##### 二叉树

- [x] 实现一个二叉查找树，并且支持插入、删除、查找操作
- [x] 实现查找二叉查找树中某个节点的后继、前驱节点
- [x] 实现二叉树前、中、后序以及按层遍历

##### 堆

- [ ] 实现一个小顶堆、大顶堆（默认就是一个简单版的优先级队列）
- [ ] 优先级队列
- [ ] 实现堆排序
- [ ] 利用优先级队列合并K个有序数组
- [ ] 求一组动态数据集合的最大Top K

##### 图

- [ ] 实现有向图、有权图、无权图的邻接矩阵和邻接表表示方法
- [ ] 实现无向图邻接表表示方法
- [ ] 实现图的深度优先搜索（递归+非递归）、广度优先搜索
- [ ] 实现Dijkstra算法、A*算法
- [ ] 实现拓扑排序的Kahn算法、DFS算法

##### 回溯

- [ ] 利用回溯算法求解八皇后问题
- [ ] 利用回溯算法求解0-1背包问题
- [ ] [不同路径问题](https://leetcode-cn.com/problems/unique-paths-iii/)

##### 分治

- [ ] 利用分治算法求一组数据的逆序对个数

##### 动态规划

- [ ] 0-1背包问题
- [ ] 最小路径和
- [ ] 编程实现莱文斯坦最短编辑距离
- [ ] 编程实现查找两个字符串的最长公共子序列
- [ ] 编程实现一个数据序列的最长递增子序列</br></br>

 

## :memo: 后记

该项目灵感来源于[https://github.com/saber/algorithm](https://github.com/saber/algorithm)


