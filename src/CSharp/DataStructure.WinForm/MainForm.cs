using DataStructure.WinForm.Sort;
using DataStructure.WinForm.LinkedList;
using DataStructure.WinForm.Tree;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataStructure.WinForm
{
    public partial class MainForm : Form
    {
        private TabControl mainTabControl;
        private TabPage sortTabPage;
        private TabPage linkedListTabPage;
        private TabPage treeTabPage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 设置窗体属性
            this.Text = "数据结构可视化演示系统";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 创建主TabControl
            mainTabControl = new TabControl();
            mainTabControl.Location = new Point(10, 10);
            mainTabControl.Size = new Size(970, 650);
            mainTabControl.Font = new Font("微软雅黑", 10);
            mainTabControl.Dock = DockStyle.Fill;

            // 创建排序Tab页面
            CreateSortTabPage();
            
            // 创建链表Tab页面
            CreateLinkedListTabPage();
            
            // 创建树Tab页面
            CreateTreeTabPage();

            // 添加Tab页面到TabControl
            mainTabControl.TabPages.Add(sortTabPage);
            mainTabControl.TabPages.Add(linkedListTabPage);
            mainTabControl.TabPages.Add(treeTabPage);

            // 添加TabControl到窗体
            this.Controls.Add(mainTabControl);

            this.ResumeLayout(false);
        }

        private void CreateSortTabPage()
        {
            sortTabPage = new TabPage("排序算法");
            sortTabPage.BackColor = Color.WhiteSmoke;
            sortTabPage.Padding = new Padding(10);

            // 创建排序页面标题
            Label sortTitleLabel = new Label();
            sortTitleLabel.Text = "排序算法可视化演示";
            sortTitleLabel.Font = new Font("微软雅黑", 16, FontStyle.Bold);
            sortTitleLabel.ForeColor = Color.DarkBlue;
            sortTitleLabel.Location = new Point(20, 20);
            sortTitleLabel.Size = new Size(400, 40);
            sortTitleLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 创建描述标签
            Label sortDescLabel = new Label();
            sortDescLabel.Text = "选择一种排序算法进行可视化演示，支持手动输入数据和动态展示排序过程";
            sortDescLabel.Font = new Font("微软雅黑", 10);
            sortDescLabel.ForeColor = Color.Gray;
            sortDescLabel.Location = new Point(20, 60);
            sortDescLabel.Size = new Size(600, 30);
            sortDescLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 创建排序算法按钮容器
            Panel sortButtonPanel = new Panel();
            sortButtonPanel.Location = new Point(20, 100);
            sortButtonPanel.Size = new Size(900, 200);
            sortButtonPanel.BackColor = Color.White;
            sortButtonPanel.BorderStyle = BorderStyle.FixedSingle;

            // 创建排序算法按钮
            CreateSortButtons(sortButtonPanel);

            // 创建手动输入数据区域
            CreateDataInputArea(sortTabPage);

            // 添加控件到排序Tab页面
            sortTabPage.Controls.Add(sortTitleLabel);
            sortTabPage.Controls.Add(sortDescLabel);
            sortTabPage.Controls.Add(sortButtonPanel);
        }

        private void CreateSortButtons(Panel parentPanel)
        {
            // 冒泡排序按钮
            Button bubbleSortButton = new Button();
            bubbleSortButton.Text = "冒泡排序\nBubble Sort";
            bubbleSortButton.Font = new Font("微软雅黑", 10);
            bubbleSortButton.Location = new Point(20, 20);
            bubbleSortButton.Size = new Size(120, 60);
            bubbleSortButton.BackColor = Color.LightBlue;
            bubbleSortButton.Click += BubbleSortButton_Click;

            // 插入排序按钮
            Button insertSortButton = new Button();
            insertSortButton.Text = "插入排序\nInsert Sort";
            insertSortButton.Font = new Font("微软雅黑", 10);
            insertSortButton.Location = new Point(160, 20);
            insertSortButton.Size = new Size(120, 60);
            insertSortButton.BackColor = Color.LightGreen;
            insertSortButton.Click += InsertSortButton_Click;

            // 选择排序按钮
            Button selectSortButton = new Button();
            selectSortButton.Text = "选择排序\nSelect Sort";
            selectSortButton.Font = new Font("微软雅黑", 10);
            selectSortButton.Location = new Point(300, 20);
            selectSortButton.Size = new Size(120, 60);
            selectSortButton.BackColor = Color.LightCoral;
            selectSortButton.Click += SelectSortButton_Click;

            // 快速排序按钮
            Button quickSortButton = new Button();
            quickSortButton.Text = "快速排序\nQuick Sort";
            quickSortButton.Font = new Font("微软雅黑", 10);
            quickSortButton.Location = new Point(440, 20);
            quickSortButton.Size = new Size(120, 60);
            quickSortButton.BackColor = Color.LightYellow;
            quickSortButton.Click += QuickSortButton_Click;

            // 归并排序按钮
            Button mergeSortButton = new Button();
            mergeSortButton.Text = "归并排序\nMerge Sort";
            mergeSortButton.Font = new Font("微软雅黑", 10);
            mergeSortButton.Location = new Point(580, 20);
            mergeSortButton.Size = new Size(120, 60);
            mergeSortButton.BackColor = Color.LightPink;
            mergeSortButton.Click += MergeSortButton_Click;

            // 堆排序按钮
            Button heapSortButton = new Button();
            heapSortButton.Text = "堆排序\nHeap Sort";
            heapSortButton.Font = new Font("微软雅黑", 10);
            heapSortButton.Location = new Point(720, 20);
            heapSortButton.Size = new Size(120, 60);
            heapSortButton.BackColor = Color.LightCyan;
            heapSortButton.Click += HeapSortButton_Click;

            // 希尔排序按钮
            Button shellSortButton = new Button();
            shellSortButton.Text = "希尔排序\nShell Sort";
            shellSortButton.Font = new Font("微软雅黑", 10);
            shellSortButton.Location = new Point(20, 100);
            shellSortButton.Size = new Size(120, 60);
            shellSortButton.BackColor = Color.LightGoldenrodYellow;
            shellSortButton.Click += ShellSortButton_Click;

            // 添加按钮到面板
            parentPanel.Controls.Add(bubbleSortButton);
            parentPanel.Controls.Add(insertSortButton);
            parentPanel.Controls.Add(selectSortButton);
            parentPanel.Controls.Add(quickSortButton);
            parentPanel.Controls.Add(mergeSortButton);
            parentPanel.Controls.Add(heapSortButton);
            parentPanel.Controls.Add(shellSortButton);
        }

        private void CreateDataInputArea(TabPage parentTab)
        {
            // 创建数据输入区域
            GroupBox dataInputGroup = new GroupBox();
            dataInputGroup.Text = "数据输入";
            dataInputGroup.Location = new Point(20, 320);
            dataInputGroup.Size = new Size(900, 100);
            dataInputGroup.Font = new Font("微软雅黑", 10);

            // 数据输入标签
            Label dataLabel = new Label();
            dataLabel.Text = "输入数据（用逗号分隔）:";
            dataLabel.Location = new Point(20, 30);
            dataLabel.Size = new Size(150, 25);
            dataLabel.Font = new Font("微软雅黑", 9);

            // 数据输入文本框
            TextBox dataTextBox = new TextBox();
            dataTextBox.Location = new Point(180, 30);
            dataTextBox.Size = new Size(400, 25);
            dataTextBox.Font = new Font("微软雅黑", 9);
            dataTextBox.Text = "64, 34, 25, 12, 22, 11, 90, 5, 77, 30";

            // 生成随机数据按钮
            Button randomDataButton = new Button();
            randomDataButton.Text = "生成随机数据";
            randomDataButton.Location = new Point(600, 30);
            randomDataButton.Size = new Size(120, 25);
            randomDataButton.Font = new Font("微软雅黑", 9);
            randomDataButton.Click += (s, e) => {
                Random random = new Random();
                int[] randomData = new int[10];
                for (int i = 0; i < randomData.Length; i++)
                {
                    randomData[i] = random.Next(1, 100);
                }
                dataTextBox.Text = string.Join(", ", randomData);
            };

            // 应用数据按钮
            Button applyDataButton = new Button();
            applyDataButton.Text = "应用数据";
            applyDataButton.Location = new Point(740, 30);
            applyDataButton.Size = new Size(100, 25);
            applyDataButton.Font = new Font("微软雅黑", 9);
            applyDataButton.Click += (s, e) => {
                // 这里可以添加应用数据的逻辑
                MessageBox.Show("数据已应用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // 添加控件到组框
            dataInputGroup.Controls.Add(dataLabel);
            dataInputGroup.Controls.Add(dataTextBox);
            dataInputGroup.Controls.Add(randomDataButton);
            dataInputGroup.Controls.Add(applyDataButton);

            // 添加组框到Tab页面
            parentTab.Controls.Add(dataInputGroup);
        }

        private void CreateLinkedListTabPage()
        {
            linkedListTabPage = new TabPage("链表");
            linkedListTabPage.BackColor = Color.WhiteSmoke;
            linkedListTabPage.Padding = new Padding(10);

            // 创建链表页面标题
            Label linkedListTitleLabel = new Label();
            linkedListTitleLabel.Text = "链表数据结构可视化";
            linkedListTitleLabel.Font = new Font("微软雅黑", 16, FontStyle.Bold);
            linkedListTitleLabel.ForeColor = Color.DarkGreen;
            linkedListTitleLabel.Location = new Point(20, 20);
            linkedListTitleLabel.Size = new Size(400, 40);
            linkedListTitleLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 创建描述标签
            Label linkedListDescLabel = new Label();
            linkedListDescLabel.Text = "演示各种链表操作：插入、删除、查找、反转等";
            linkedListDescLabel.Font = new Font("微软雅黑", 10);
            linkedListDescLabel.ForeColor = Color.Gray;
            linkedListDescLabel.Location = new Point(20, 60);
            linkedListDescLabel.Size = new Size(600, 30);
            linkedListDescLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 创建链表操作按钮容器
            Panel linkedListButtonPanel = new Panel();
            linkedListButtonPanel.Location = new Point(20, 100);
            linkedListButtonPanel.Size = new Size(900, 200);
            linkedListButtonPanel.BackColor = Color.White;
            linkedListButtonPanel.BorderStyle = BorderStyle.FixedSingle;

            // 创建链表操作按钮
            CreateLinkedListButtons(linkedListButtonPanel);

            // 添加控件到链表Tab页面
            linkedListTabPage.Controls.Add(linkedListTitleLabel);
            linkedListTabPage.Controls.Add(linkedListDescLabel);
            linkedListTabPage.Controls.Add(linkedListButtonPanel);
        }

        private void CreateLinkedListButtons(Panel parentPanel)
        {
            // 单链表按钮
            Button singleLinkedListButton = new Button();
            singleLinkedListButton.Text = "单链表\nSingle LinkedList";
            singleLinkedListButton.Font = new Font("微软雅黑", 10);
            singleLinkedListButton.Location = new Point(20, 20);
            singleLinkedListButton.Size = new Size(150, 60);
            singleLinkedListButton.BackColor = Color.LightBlue;
            singleLinkedListButton.Click += SingleLinkedListButton_Click;

            // 双向链表按钮
            Button doubleLinkedListButton = new Button();
            doubleLinkedListButton.Text = "双向链表\nDouble LinkedList";
            doubleLinkedListButton.Font = new Font("微软雅黑", 10);
            doubleLinkedListButton.Location = new Point(190, 20);
            doubleLinkedListButton.Size = new Size(150, 60);
            doubleLinkedListButton.BackColor = Color.LightGreen;
            doubleLinkedListButton.Click += DoubleLinkedListButton_Click;

            // 循环链表按钮
            Button circularLinkedListButton = new Button();
            circularLinkedListButton.Text = "循环链表\nCircular LinkedList";
            circularLinkedListButton.Font = new Font("微软雅黑", 10);
            circularLinkedListButton.Location = new Point(360, 20);
            circularLinkedListButton.Size = new Size(150, 60);
            circularLinkedListButton.BackColor = Color.LightCoral;
            circularLinkedListButton.Click += CircularLinkedListButton_Click;

            // LRU缓存按钮
            Button lruCacheButton = new Button();
            lruCacheButton.Text = "LRU缓存\nLRU Cache";
            lruCacheButton.Font = new Font("微软雅黑", 10);
            lruCacheButton.Location = new Point(530, 20);
            lruCacheButton.Size = new Size(150, 60);
            lruCacheButton.BackColor = Color.LightYellow;
            lruCacheButton.Click += LruCacheButton_Click;

            // 添加按钮到面板
            parentPanel.Controls.Add(singleLinkedListButton);
            parentPanel.Controls.Add(doubleLinkedListButton);
            parentPanel.Controls.Add(circularLinkedListButton);
            parentPanel.Controls.Add(lruCacheButton);
        }

        private void CreateTreeTabPage()
        {
            treeTabPage = new TabPage("树结构");
            treeTabPage.BackColor = Color.WhiteSmoke;
            treeTabPage.Padding = new Padding(10);

            // 创建树页面标题
            Label treeTitleLabel = new Label();
            treeTitleLabel.Text = "树结构可视化演示";
            treeTitleLabel.Font = new Font("微软雅黑", 16, FontStyle.Bold);
            treeTitleLabel.ForeColor = Color.DarkOrange;
            treeTitleLabel.Location = new Point(20, 20);
            treeTitleLabel.Size = new Size(400, 40);
            treeTitleLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 创建描述标签
            Label treeDescLabel = new Label();
            treeDescLabel.Text = "演示各种树结构：二叉树、二叉搜索树、平衡树、红黑树等";
            treeDescLabel.Font = new Font("微软雅黑", 10);
            treeDescLabel.ForeColor = Color.Gray;
            treeDescLabel.Location = new Point(20, 60);
            treeDescLabel.Size = new Size(600, 30);
            treeDescLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 创建树操作按钮容器
            Panel treeButtonPanel = new Panel();
            treeButtonPanel.Location = new Point(20, 100);
            treeButtonPanel.Size = new Size(900, 200);
            treeButtonPanel.BackColor = Color.White;
            treeButtonPanel.BorderStyle = BorderStyle.FixedSingle;

            // 创建树操作按钮
            CreateTreeButtons(treeButtonPanel);

            // 添加控件到树Tab页面
            treeTabPage.Controls.Add(treeTitleLabel);
            treeTabPage.Controls.Add(treeDescLabel);
            treeTabPage.Controls.Add(treeButtonPanel);
        }

        private void CreateTreeButtons(Panel parentPanel)
        {
            // 二叉树按钮
            Button binaryTreeButton = new Button();
            binaryTreeButton.Text = "二叉树\nBinary Tree";
            binaryTreeButton.Font = new Font("微软雅黑", 10);
            binaryTreeButton.Location = new Point(20, 20);
            binaryTreeButton.Size = new Size(150, 60);
            binaryTreeButton.BackColor = Color.LightBlue;
            binaryTreeButton.Click += BinaryTreeButton_Click;

            // 二叉搜索树按钮
            Button bstButton = new Button();
            bstButton.Text = "二叉搜索树\nBinary Search Tree";
            bstButton.Font = new Font("微软雅黑", 10);
            bstButton.Location = new Point(190, 20);
            bstButton.Size = new Size(150, 60);
            bstButton.BackColor = Color.LightGreen;
            bstButton.Click += BstButton_Click;

            // 平衡二叉树按钮
            Button avlTreeButton = new Button();
            avlTreeButton.Text = "平衡二叉树\nAVL Tree";
            avlTreeButton.Font = new Font("微软雅黑", 10);
            avlTreeButton.Location = new Point(360, 20);
            avlTreeButton.Size = new Size(150, 60);
            avlTreeButton.BackColor = Color.LightCoral;
            avlTreeButton.Click += AvlTreeButton_Click;

            // 红黑树按钮
            Button redBlackTreeButton = new Button();
            redBlackTreeButton.Text = "红黑树\nRed-Black Tree";
            redBlackTreeButton.Font = new Font("微软雅黑", 10);
            redBlackTreeButton.Location = new Point(530, 20);
            redBlackTreeButton.Size = new Size(150, 60);
            redBlackTreeButton.BackColor = Color.LightYellow;
            redBlackTreeButton.Click += RedBlackTreeButton_Click;

            // 添加按钮到面板
            parentPanel.Controls.Add(binaryTreeButton);
            parentPanel.Controls.Add(bstButton);
            parentPanel.Controls.Add(avlTreeButton);
            parentPanel.Controls.Add(redBlackTreeButton);
        }

        // 排序算法事件处理方法
        private void BubbleSortButton_Click(object sender, EventArgs e)
        {
            BubbleSortForm form = new BubbleSortForm();
            form.Show();
        }

        private void InsertSortButton_Click(object sender, EventArgs e)
        {
            InsertSortForm form = new InsertSortForm();
            form.Show();
        }

        private void SelectSortButton_Click(object sender, EventArgs e)
        {
            SelectSortForm form = new SelectSortForm();
            form.Show();
        }

        private void QuickSortButton_Click(object sender, EventArgs e)
        {
            QuickSortForm form = new QuickSortForm();
            form.Show();
        }

        private void MergeSortButton_Click(object sender, EventArgs e)
        {
            MergeSortForm form = new MergeSortForm();
            form.Show();
        }

        private void HeapSortButton_Click(object sender, EventArgs e)
        {
            HeapSortForm form = new HeapSortForm();
            form.Show();
        }

        private void ShellSortButton_Click(object sender, EventArgs e)
        {
            ShellSortForm form = new ShellSortForm();
            form.Show();
        }

        // 链表事件处理方法
        private void SingleLinkedListButton_Click(object sender, EventArgs e)
        {
            SingleLinkedListForm form = new SingleLinkedListForm();
            form.Show();
        }

        private void DoubleLinkedListButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("双向链表可视化功能开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CircularLinkedListButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("循环链表可视化功能开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LruCacheButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LRU缓存可视化功能开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 树结构事件处理方法
        private void BinaryTreeButton_Click(object sender, EventArgs e)
        {
            BinaryTreeForm form = new BinaryTreeForm();
            form.Show();
        }

        private void BstButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("二叉搜索树可视化功能开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AvlTreeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("平衡二叉树可视化功能开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RedBlackTreeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("红黑树可视化功能开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

