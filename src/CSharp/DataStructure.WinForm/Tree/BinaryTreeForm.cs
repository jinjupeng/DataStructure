using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DataStructure.WinForm.Tree
{
    public partial class BinaryTreeForm : Form
    {
        private Panel drawPanel;
        private Label statusLabel;
        private TextBox valueTextBox;
        private Button insertButton;
        private Button deleteButton;
        private Button searchButton;
        private Button clearButton;
        private Button randomButton;
        private Label operationLabel;
        private ComboBox traversalComboBox;
        private Button traversalButton;

        private TreeNode root;
        private TreeNode highlightNode;
        private string currentOperation = "";

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public TreeNode(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        public BinaryTreeForm()
        {
            InitializeComponent();
            root = null;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 设置窗体属性
            this.Text = "二叉树可视化演示";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 创建绘制面板
            drawPanel = new Panel();
            drawPanel.Location = new Point(20, 60);
            drawPanel.Size = new Size(1140, 500);
            drawPanel.BackColor = Color.White;
            drawPanel.BorderStyle = BorderStyle.FixedSingle;
            drawPanel.Paint += DrawPanel_Paint;

            // 创建状态标签
            statusLabel = new Label();
            statusLabel.Location = new Point(20, 20);
            statusLabel.Size = new Size(400, 30);
            statusLabel.Text = "二叉树可视化演示 - 准备就绪";
            statusLabel.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            statusLabel.ForeColor = Color.DarkGreen;

            // 创建操作标签
            operationLabel = new Label();
            operationLabel.Location = new Point(450, 20);
            operationLabel.Size = new Size(300, 30);
            operationLabel.Text = "当前操作: 无";
            operationLabel.Font = new Font("微软雅黑", 10);
            operationLabel.ForeColor = Color.Gray;

            // 创建值输入文本框
            Label valueLabel = new Label();
            valueLabel.Text = "数值:";
            valueLabel.Location = new Point(20, 580);
            valueLabel.Size = new Size(50, 25);
            valueLabel.Font = new Font("微软雅黑", 10);

            valueTextBox = new TextBox();
            valueTextBox.Location = new Point(80, 580);
            valueTextBox.Size = new Size(100, 25);
            valueTextBox.Font = new Font("微软雅黑", 10);

            // 创建操作按钮
            insertButton = new Button();
            insertButton.Text = "插入";
            insertButton.Location = new Point(200, 580);
            insertButton.Size = new Size(60, 25);
            insertButton.Font = new Font("微软雅黑", 9);
            insertButton.BackColor = Color.LightGreen;
            insertButton.Click += InsertButton_Click;

            deleteButton = new Button();
            deleteButton.Text = "删除";
            deleteButton.Location = new Point(270, 580);
            deleteButton.Size = new Size(60, 25);
            deleteButton.Font = new Font("微软雅黑", 9);
            deleteButton.BackColor = Color.LightCoral;
            deleteButton.Click += DeleteButton_Click;

            searchButton = new Button();
            searchButton.Text = "查找";
            searchButton.Location = new Point(340, 580);
            searchButton.Size = new Size(60, 25);
            searchButton.Font = new Font("微软雅黑", 9);
            searchButton.BackColor = Color.LightYellow;
            searchButton.Click += SearchButton_Click;

            clearButton = new Button();
            clearButton.Text = "清空";
            clearButton.Location = new Point(410, 580);
            clearButton.Size = new Size(60, 25);
            clearButton.Font = new Font("微软雅黑", 9);
            clearButton.BackColor = Color.LightGray;
            clearButton.Click += ClearButton_Click;

            randomButton = new Button();
            randomButton.Text = "随机生成";
            randomButton.Location = new Point(480, 580);
            randomButton.Size = new Size(80, 25);
            randomButton.Font = new Font("微软雅黑", 9);
            randomButton.BackColor = Color.LightPink;
            randomButton.Click += RandomButton_Click;

            // 创建遍历相关控件
            Label traversalLabel = new Label();
            traversalLabel.Text = "遍历:";
            traversalLabel.Location = new Point(580, 580);
            traversalLabel.Size = new Size(50, 25);
            traversalLabel.Font = new Font("微软雅黑", 10);

            traversalComboBox = new ComboBox();
            traversalComboBox.Location = new Point(640, 580);
            traversalComboBox.Size = new Size(100, 25);
            traversalComboBox.Font = new Font("微软雅黑", 9);
            traversalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            traversalComboBox.Items.AddRange(new string[] { "前序遍历", "中序遍历", "后序遍历", "层序遍历" });
            traversalComboBox.SelectedIndex = 0;

            traversalButton = new Button();
            traversalButton.Text = "执行遍历";
            traversalButton.Location = new Point(750, 580);
            traversalButton.Size = new Size(80, 25);
            traversalButton.Font = new Font("微软雅黑", 9);
            traversalButton.BackColor = Color.LightCyan;
            traversalButton.Click += TraversalButton_Click;

            // 添加控件到窗体
            this.Controls.Add(drawPanel);
            this.Controls.Add(statusLabel);
            this.Controls.Add(operationLabel);
            this.Controls.Add(valueLabel);
            this.Controls.Add(valueTextBox);
            this.Controls.Add(insertButton);
            this.Controls.Add(deleteButton);
            this.Controls.Add(searchButton);
            this.Controls.Add(clearButton);
            this.Controls.Add(randomButton);
            this.Controls.Add(traversalLabel);
            this.Controls.Add(traversalComboBox);
            this.Controls.Add(traversalButton);

            this.ResumeLayout(false);
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (root == null)
            {
                using (Font font = new Font("微软雅黑", 14))
                {
                    g.DrawString("树为空", font, Brushes.Gray, 
                        drawPanel.Width / 2 - 50, drawPanel.Height / 2 - 20);
                }
                return;
            }

            // 计算节点位置
            CalculatePositions(root, drawPanel.Width / 2, 50, 200);

            // 绘制树
            DrawTree(g, root);
        }

        private void CalculatePositions(TreeNode node, int x, int y, int levelWidth)
        {
            if (node == null) return;

            node.X = x;
            node.Y = y;

            if (node.Left != null)
            {
                CalculatePositions(node.Left, x - levelWidth / 2, y + 80, levelWidth / 2);
            }

            if (node.Right != null)
            {
                CalculatePositions(node.Right, x + levelWidth / 2, y + 80, levelWidth / 2);
            }
        }

        private void DrawTree(Graphics g, TreeNode node)
        {
            if (node == null) return;

            // 绘制连接线
            if (node.Left != null)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawLine(pen, node.X, node.Y + 25, node.Left.X, node.Left.Y - 25);
                }
                DrawTree(g, node.Left);
            }

            if (node.Right != null)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawLine(pen, node.X, node.Y + 25, node.Right.X, node.Right.Y - 25);
                }
                DrawTree(g, node.Right);
            }

            // 绘制节点
            Color nodeColor = (node == highlightNode) ? Color.Red : Color.LightBlue;
            using (Brush brush = new SolidBrush(nodeColor))
            {
                g.FillEllipse(brush, node.X - 25, node.Y - 25, 50, 50);
            }

            // 绘制节点边框
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, node.X - 25, node.Y - 25, 50, 50);
            }

            // 绘制数值
            using (Font font = new Font("微软雅黑", 10, FontStyle.Bold))
            {
                string text = node.Value.ToString();
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, Brushes.Black, 
                    node.X - textSize.Width / 2, 
                    node.Y - textSize.Height / 2);
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(valueTextBox.Text))
            {
                MessageBox.Show("请输入要插入的数值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int value = int.Parse(valueTextBox.Text);
                root = Insert(root, value);
                highlightNode = FindNode(root, value);
                currentOperation = $"插入: {value}";
                UpdateDisplay();
                
                // 重置高亮
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += (s, args) => {
                    highlightNode = null;
                    currentOperation = "";
                    UpdateDisplay();
                    timer.Stop();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"输入错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeNode Insert(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }

            if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(valueTextBox.Text))
            {
                MessageBox.Show("请输入要删除的数值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int value = int.Parse(valueTextBox.Text);
                if (FindNode(root, value) == null)
                {
                    MessageBox.Show($"未找到数值 {value}！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                root = Delete(root, value);
                currentOperation = $"删除: {value}";
                UpdateDisplay();
                
                // 重置高亮
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += (s, args) => {
                    currentOperation = "";
                    UpdateDisplay();
                    timer.Stop();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"输入错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeNode Delete(TreeNode node, int value)
        {
            if (node == null) return null;

            if (value < node.Value)
            {
                node.Left = Delete(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Delete(node.Right, value);
            }
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                TreeNode minNode = FindMin(node.Right);
                node.Value = minNode.Value;
                node.Right = Delete(node.Right, minNode.Value);
            }

            return node;
        }

        private TreeNode FindMin(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(valueTextBox.Text))
            {
                MessageBox.Show("请输入要查找的数值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int value = int.Parse(valueTextBox.Text);
                TreeNode found = FindNode(root, value);
                
                if (found == null)
                {
                    MessageBox.Show($"未找到数值 {value}！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                highlightNode = found;
                currentOperation = $"查找: {value}";
                UpdateDisplay();
                
                // 重置高亮
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, args) => {
                    highlightNode = null;
                    currentOperation = "";
                    UpdateDisplay();
                    timer.Stop();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"输入错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeNode FindNode(TreeNode node, int value)
        {
            if (node == null) return null;
            if (node.Value == value) return node;
            if (value < node.Value) return FindNode(node.Left, value);
            return FindNode(node.Right, value);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            root = null;
            highlightNode = null;
            currentOperation = "清空树";
            UpdateDisplay();
            
            // 重置高亮
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, args) => {
                currentOperation = "";
                UpdateDisplay();
                timer.Stop();
            };
            timer.Start();
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            root = null;
            
            int count = random.Next(8, 15);
            for (int i = 0; i < count; i++)
            {
                int value = random.Next(1, 100);
                root = Insert(root, value);
            }
            
            currentOperation = $"随机生成 {count} 个节点";
            UpdateDisplay();
            
            // 重置高亮
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, args) => {
                currentOperation = "";
                UpdateDisplay();
                timer.Stop();
            };
            timer.Start();
        }

        private void TraversalButton_Click(object sender, EventArgs e)
        {
            if (root == null)
            {
                MessageBox.Show("树为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> result = new List<int>();
            string traversalType = traversalComboBox.SelectedItem.ToString();

            switch (traversalType)
            {
                case "前序遍历":
                    PreorderTraversal(root, result);
                    break;
                case "中序遍历":
                    InorderTraversal(root, result);
                    break;
                case "后序遍历":
                    PostorderTraversal(root, result);
                    break;
                case "层序遍历":
                    LevelOrderTraversal(root, result);
                    break;
            }

            string resultText = string.Join(" -> ", result);
            MessageBox.Show($"{traversalType}结果：\n{resultText}", "遍历结果", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PreorderTraversal(TreeNode node, List<int> result)
        {
            if (node == null) return;
            result.Add(node.Value);
            PreorderTraversal(node.Left, result);
            PreorderTraversal(node.Right, result);
        }

        private void InorderTraversal(TreeNode node, List<int> result)
        {
            if (node == null) return;
            InorderTraversal(node.Left, result);
            result.Add(node.Value);
            InorderTraversal(node.Right, result);
        }

        private void PostorderTraversal(TreeNode node, List<int> result)
        {
            if (node == null) return;
            PostorderTraversal(node.Left, result);
            PostorderTraversal(node.Right, result);
            result.Add(node.Value);
        }

        private void LevelOrderTraversal(TreeNode node, List<int> result)
        {
            if (node == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                result.Add(current.Value);

                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }
        }

        private void UpdateDisplay()
        {
            int nodeCount = CountNodes(root);
            statusLabel.Text = $"二叉树可视化演示 - 节点数量: {nodeCount}";
            operationLabel.Text = $"当前操作: {currentOperation}";
            drawPanel.Invalidate();
        }

        private int CountNodes(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
    }
}
