using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DataStructure.WinForm.LinkedList
{
    public partial class SingleLinkedListForm : Form
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

        private List<int> linkedList;
        private int highlightIndex = -1;
        private string currentOperation = "";

        public SingleLinkedListForm()
        {
            InitializeComponent();
            linkedList = new List<int>();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 设置窗体属性
            this.Text = "单链表可视化演示";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 创建绘制面板
            drawPanel = new Panel();
            drawPanel.Location = new Point(20, 60);
            drawPanel.Size = new Size(940, 400);
            drawPanel.BackColor = Color.White;
            drawPanel.BorderStyle = BorderStyle.FixedSingle;
            drawPanel.Paint += DrawPanel_Paint;

            // 创建状态标签
            statusLabel = new Label();
            statusLabel.Location = new Point(20, 20);
            statusLabel.Size = new Size(400, 30);
            statusLabel.Text = "单链表可视化演示 - 准备就绪";
            statusLabel.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            statusLabel.ForeColor = Color.DarkBlue;

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
            valueLabel.Location = new Point(20, 480);
            valueLabel.Size = new Size(50, 25);
            valueLabel.Font = new Font("微软雅黑", 10);

            valueTextBox = new TextBox();
            valueTextBox.Location = new Point(80, 480);
            valueTextBox.Size = new Size(100, 25);
            valueTextBox.Font = new Font("微软雅黑", 10);

            // 创建操作按钮
            insertButton = new Button();
            insertButton.Text = "插入头部";
            insertButton.Location = new Point(200, 480);
            insertButton.Size = new Size(80, 25);
            insertButton.Font = new Font("微软雅黑", 9);
            insertButton.BackColor = Color.LightGreen;
            insertButton.Click += InsertButton_Click;

            Button insertTailButton = new Button();
            insertTailButton.Text = "插入尾部";
            insertTailButton.Location = new Point(290, 480);
            insertTailButton.Size = new Size(80, 25);
            insertTailButton.Font = new Font("微软雅黑", 9);
            insertTailButton.BackColor = Color.LightBlue;
            insertTailButton.Click += InsertTailButton_Click;

            deleteButton = new Button();
            deleteButton.Text = "删除";
            deleteButton.Location = new Point(380, 480);
            deleteButton.Size = new Size(60, 25);
            deleteButton.Font = new Font("微软雅黑", 9);
            deleteButton.BackColor = Color.LightCoral;
            deleteButton.Click += DeleteButton_Click;

            searchButton = new Button();
            searchButton.Text = "查找";
            searchButton.Location = new Point(450, 480);
            searchButton.Size = new Size(60, 25);
            searchButton.Font = new Font("微软雅黑", 9);
            searchButton.BackColor = Color.LightYellow;
            searchButton.Click += SearchButton_Click;

            clearButton = new Button();
            clearButton.Text = "清空链表";
            clearButton.Location = new Point(520, 480);
            clearButton.Size = new Size(80, 25);
            clearButton.Font = new Font("微软雅黑", 9);
            clearButton.BackColor = Color.LightGray;
            clearButton.Click += ClearButton_Click;

            randomButton = new Button();
            randomButton.Text = "随机生成";
            randomButton.Location = new Point(610, 480);
            randomButton.Size = new Size(80, 25);
            randomButton.Font = new Font("微软雅黑", 9);
            randomButton.BackColor = Color.LightPink;
            randomButton.Click += RandomButton_Click;

            // 添加控件到窗体
            this.Controls.Add(drawPanel);
            this.Controls.Add(statusLabel);
            this.Controls.Add(operationLabel);
            this.Controls.Add(valueLabel);
            this.Controls.Add(valueTextBox);
            this.Controls.Add(insertButton);
            this.Controls.Add(insertTailButton);
            this.Controls.Add(deleteButton);
            this.Controls.Add(searchButton);
            this.Controls.Add(clearButton);
            this.Controls.Add(randomButton);

            this.ResumeLayout(false);
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (linkedList.Count == 0)
            {
                using (Font font = new Font("微软雅黑", 14))
                {
                    g.DrawString("链表为空", font, Brushes.Gray, 
                        drawPanel.Width / 2 - 50, drawPanel.Height / 2 - 20);
                }
                return;
            }

            int startX = 50;
            int startY = drawPanel.Height / 2;
            int nodeWidth = 80;
            int nodeHeight = 50;
            int spacing = 100;

            for (int i = 0; i < linkedList.Count; i++)
            {
                int x = startX + i * spacing;
                int y = startY - nodeHeight / 2;

                // 绘制节点
                Color nodeColor = (i == highlightIndex) ? Color.Red : Color.LightBlue;
                using (Brush brush = new SolidBrush(nodeColor))
                {
                    g.FillRectangle(brush, x, y, nodeWidth, nodeHeight);
                }

                // 绘制节点边框
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawRectangle(pen, x, y, nodeWidth, nodeHeight);
                }

                // 绘制数值
                using (Font font = new Font("微软雅黑", 12, FontStyle.Bold))
                {
                    string text = linkedList[i].ToString();
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, Brushes.Black, 
                        x + (nodeWidth - textSize.Width) / 2, 
                        y + (nodeHeight - textSize.Height) / 2);
                }

                // 绘制箭头（除了最后一个节点）
                if (i < linkedList.Count - 1)
                {
                    int arrowStartX = x + nodeWidth;
                    int arrowEndX = x + spacing - 20;
                    int arrowY = y + nodeHeight / 2;

                    using (Pen pen = new Pen(Color.Black, 2))
                    {
                        g.DrawLine(pen, arrowStartX, arrowY, arrowEndX, arrowY);
                        
                        // 绘制箭头头部
                        Point[] arrowHead = {
                            new Point(arrowEndX - 10, arrowY - 5),
                            new Point(arrowEndX, arrowY),
                            new Point(arrowEndX - 10, arrowY + 5)
                        };
                        g.FillPolygon(Brushes.Black, arrowHead);
                    }
                }
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
                linkedList.Insert(0, value);
                highlightIndex = 0;
                currentOperation = $"插入头部: {value}";
                UpdateDisplay();
                
                // 重置高亮
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += (s, args) => {
                    highlightIndex = -1;
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

        private void InsertTailButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(valueTextBox.Text))
            {
                MessageBox.Show("请输入要插入的数值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int value = int.Parse(valueTextBox.Text);
                linkedList.Add(value);
                highlightIndex = linkedList.Count - 1;
                currentOperation = $"插入尾部: {value}";
                UpdateDisplay();
                
                // 重置高亮
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += (s, args) => {
                    highlightIndex = -1;
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
                int index = linkedList.IndexOf(value);
                
                if (index == -1)
                {
                    MessageBox.Show($"未找到数值 {value}！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                linkedList.RemoveAt(index);
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
                int index = linkedList.IndexOf(value);
                
                if (index == -1)
                {
                    MessageBox.Show($"未找到数值 {value}！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                highlightIndex = index;
                currentOperation = $"查找: {value} (位置: {index})";
                UpdateDisplay();
                
                // 重置高亮
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, args) => {
                    highlightIndex = -1;
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            linkedList.Clear();
            highlightIndex = -1;
            currentOperation = "清空链表";
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
            linkedList.Clear();
            
            int count = random.Next(5, 10);
            for (int i = 0; i < count; i++)
            {
                linkedList.Add(random.Next(1, 100));
            }
            
            currentOperation = $"随机生成 {count} 个元素";
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

        private void UpdateDisplay()
        {
            statusLabel.Text = $"单链表可视化演示 - 元素数量: {linkedList.Count}";
            operationLabel.Text = $"当前操作: {currentOperation}";
            drawPanel.Invalidate();
        }
    }
}
