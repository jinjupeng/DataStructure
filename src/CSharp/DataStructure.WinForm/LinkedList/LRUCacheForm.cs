using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DataStructure.WinForm.LinkedList
{
    public partial class LRUCacheForm : Form
    {
        private Panel drawPanel;
        private Label statusLabel;
        private TextBox keyTextBox;
        private TextBox valueTextBox;
        private Button putButton;
        private Button getButton;
        private Button clearButton;
        private Button randomButton;
        private Label operationLabel;
        private Label capacityLabel;
        private TrackBar capacityTrackBar;

        private Dictionary<int, int> cache;
        private List<int> accessOrder;
        private int capacity;
        private int highlightKey = -1;
        private string currentOperation = "";

        public LRUCacheForm()
        {
            InitializeComponent();
            capacity = 5;
            cache = new Dictionary<int, int>();
            accessOrder = new List<int>();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 设置窗体属性
            this.Text = "LRU缓存可视化演示";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new Size(800, 500);

            // 创建绘制面板
            drawPanel = new Panel();
            drawPanel.Location = new Point(20, 60);
            drawPanel.Size = new Size(940, 400);
            drawPanel.BackColor = Color.White;
            drawPanel.BorderStyle = BorderStyle.FixedSingle;
            drawPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            drawPanel.Paint += DrawPanel_Paint;

            // 创建状态标签
            statusLabel = new Label();
            statusLabel.Location = new Point(20, 20);
            statusLabel.Size = new Size(400, 30);
            statusLabel.Text = "LRU缓存可视化演示 - 准备就绪";
            statusLabel.Font = new Font("微软雅黑", 12, FontStyle.Bold);
            statusLabel.ForeColor = Color.DarkMagenta;

            // 创建操作标签
            operationLabel = new Label();
            operationLabel.Location = new Point(450, 20);
            operationLabel.Size = new Size(300, 30);
            operationLabel.Text = "当前操作: 无";
            operationLabel.Font = new Font("微软雅黑", 10);
            operationLabel.ForeColor = Color.Gray;

            // 创建容量控制
            capacityLabel = new Label();
            capacityLabel.Text = "缓存容量:";
            capacityLabel.Location = new Point(20, 480);
            capacityLabel.Size = new Size(80, 25);
            capacityLabel.Font = new Font("微软雅黑", 10);

            capacityTrackBar = new TrackBar();
            capacityTrackBar.Location = new Point(110, 480);
            capacityTrackBar.Size = new Size(100, 25);
            capacityTrackBar.Minimum = 3;
            capacityTrackBar.Maximum = 10;
            capacityTrackBar.Value = 5;
            capacityTrackBar.TickFrequency = 1;
            capacityTrackBar.ValueChanged += CapacityTrackBar_ValueChanged;

            // 创建键输入文本框
            Label keyLabel = new Label();
            keyLabel.Text = "键:";
            keyLabel.Location = new Point(230, 480);
            keyLabel.Size = new Size(30, 25);
            keyLabel.Font = new Font("微软雅黑", 10);

            keyTextBox = new TextBox();
            keyTextBox.Location = new Point(270, 480);
            keyTextBox.Size = new Size(60, 25);
            keyTextBox.Font = new Font("微软雅黑", 10);

            // 创建值输入文本框
            Label valueLabel = new Label();
            valueLabel.Text = "值:";
            valueLabel.Location = new Point(340, 480);
            valueLabel.Size = new Size(30, 25);
            valueLabel.Font = new Font("微软雅黑", 10);

            valueTextBox = new TextBox();
            valueTextBox.Location = new Point(380, 480);
            valueTextBox.Size = new Size(60, 25);
            valueTextBox.Font = new Font("微软雅黑", 10);

            // 创建操作按钮
            putButton = new Button();
            putButton.Text = "PUT";
            putButton.Location = new Point(450, 480);
            putButton.Size = new Size(50, 25);
            putButton.Font = new Font("微软雅黑", 9);
            putButton.BackColor = Color.LightGreen;
            putButton.Click += PutButton_Click;

            getButton = new Button();
            getButton.Text = "GET";
            getButton.Location = new Point(510, 480);
            getButton.Size = new Size(50, 25);
            getButton.Font = new Font("微软雅黑", 9);
            getButton.BackColor = Color.LightBlue;
            getButton.Click += GetButton_Click;

            clearButton = new Button();
            clearButton.Text = "清空";
            clearButton.Location = new Point(570, 480);
            clearButton.Size = new Size(60, 25);
            clearButton.Font = new Font("微软雅黑", 9);
            clearButton.BackColor = Color.LightGray;
            clearButton.Click += ClearButton_Click;

            randomButton = new Button();
            randomButton.Text = "随机操作";
            randomButton.Location = new Point(640, 480);
            randomButton.Size = new Size(80, 25);
            randomButton.Font = new Font("微软雅黑", 9);
            randomButton.BackColor = Color.LightPink;
            randomButton.Click += RandomButton_Click;

            // 添加控件到窗体
            this.Controls.Add(drawPanel);
            this.Controls.Add(statusLabel);
            this.Controls.Add(operationLabel);
            this.Controls.Add(capacityLabel);
            this.Controls.Add(capacityTrackBar);
            this.Controls.Add(keyLabel);
            this.Controls.Add(keyTextBox);
            this.Controls.Add(valueLabel);
            this.Controls.Add(valueTextBox);
            this.Controls.Add(putButton);
            this.Controls.Add(getButton);
            this.Controls.Add(clearButton);
            this.Controls.Add(randomButton);

            this.ResumeLayout(false);
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (cache.Count == 0)
            {
                using (Font font = new Font("微软雅黑", 14))
                {
                    g.DrawString("LRU缓存为空", font, Brushes.Gray, 
                        drawPanel.Width / 2 - 60, drawPanel.Height / 2 - 20);
                }
                return;
            }

            int startX = 50;
            int startY = drawPanel.Height / 2;
            int nodeWidth = 120;
            int nodeHeight = 80;
            int spacing = 140;

            // 绘制缓存项
            for (int i = 0; i < accessOrder.Count; i++)
            {
                int key = accessOrder[i];
                int x = startX + i * spacing;
                int y = startY - nodeHeight / 2;

                // 绘制节点
                Color nodeColor = (key == highlightKey) ? Color.Red : Color.LightYellow;
                using (Brush brush = new SolidBrush(nodeColor))
                {
                    g.FillRectangle(brush, x, y, nodeWidth, nodeHeight);
                }

                // 绘制节点边框
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawRectangle(pen, x, y, nodeWidth, nodeHeight);
                }

                // 绘制键值对
                using (Font font = new Font("微软雅黑", 10, FontStyle.Bold))
                {
                    string keyText = $"Key: {key}";
                    string valueText = $"Value: {cache[key]}";
                    SizeF keySize = g.MeasureString(keyText, font);
                    SizeF valueSize = g.MeasureString(valueText, font);
                    
                    g.DrawString(keyText, font, Brushes.Black, 
                        x + (nodeWidth - keySize.Width) / 2, 
                        y + 15);
                    g.DrawString(valueText, font, Brushes.Black, 
                        x + (nodeWidth - valueSize.Width) / 2, 
                        y + 35);
                }

                // 绘制访问顺序
                using (Font font = new Font("微软雅黑", 8))
                {
                    string orderText = $"访问顺序: {i + 1}";
                    g.DrawString(orderText, font, Brushes.Gray, 
                        x + 5, y + 5);
                }

                // 绘制箭头（除了最后一个节点）
                if (i < accessOrder.Count - 1)
                {
                    int arrowStartX = x + nodeWidth;
                    int arrowEndX = x + spacing - 20;
                    int arrowY = y + nodeHeight / 2;

                    using (Pen pen = new Pen(Color.Blue, 2))
                    {
                        g.DrawLine(pen, arrowStartX, arrowY, arrowEndX, arrowY);
                        
                        // 绘制箭头头部
                        Point[] arrowHead = {
                            new Point(arrowEndX - 10, arrowY - 5),
                            new Point(arrowEndX, arrowY),
                            new Point(arrowEndX - 10, arrowY + 5)
                        };
                        g.FillPolygon(Brushes.Blue, arrowHead);
                    }
                }
            }

            // 绘制容量信息
            using (Font font = new Font("微软雅黑", 12, FontStyle.Bold))
            {
                string capacityText = $"容量: {cache.Count}/{capacity}";
                g.DrawString(capacityText, font, Brushes.DarkBlue, 
                    drawPanel.Width - 120, 20);
            }
        }

        private void PutButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(keyTextBox.Text) || string.IsNullOrEmpty(valueTextBox.Text))
            {
                MessageBox.Show("请输入键和值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int key = int.Parse(keyTextBox.Text);
                int value = int.Parse(valueTextBox.Text);
                
                Put(key, value);
                highlightKey = key;
                currentOperation = $"PUT({key}, {value})";
                UpdateDisplay();
                
                // 重置高亮
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1500;
                timer.Tick += (s, args) => {
                    highlightKey = -1;
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

        private void GetButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(keyTextBox.Text))
            {
                MessageBox.Show("请输入键！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int key = int.Parse(keyTextBox.Text);
                int value = Get(key);
                
                if (value == -1)
                {
                    MessageBox.Show($"键 {key} 不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                highlightKey = key;
                currentOperation = $"GET({key}) = {value}";
                UpdateDisplay();
                
                // 重置高亮
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1500;
                timer.Tick += (s, args) => {
                    highlightKey = -1;
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
            cache.Clear();
            accessOrder.Clear();
            highlightKey = -1;
            currentOperation = "清空缓存";
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
            int operationCount = random.Next(5, 10);
            
            for (int i = 0; i < operationCount; i++)
            {
                if (random.Next(2) == 0)
                {
                    // PUT操作
                    int key = random.Next(1, 20);
                    int value = random.Next(1, 100);
                    Put(key, value);
                }
                else
                {
                    // GET操作
                    if (accessOrder.Count > 0)
                    {
                        int randomKey = accessOrder[random.Next(accessOrder.Count)];
                        Get(randomKey);
                    }
                }
            }
            
            currentOperation = $"随机执行 {operationCount} 个操作";
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

        private void CapacityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            capacity = capacityTrackBar.Value;
            UpdateDisplay();
        }

        private void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                // 更新现有键的值
                cache[key] = value;
                // 移动到最前面
                accessOrder.Remove(key);
                accessOrder.Insert(0, key);
            }
            else
            {
                if (cache.Count >= capacity)
                {
                    // 移除最久未使用的项
                    int lruKey = accessOrder[accessOrder.Count - 1];
                    cache.Remove(lruKey);
                    accessOrder.RemoveAt(accessOrder.Count - 1);
                }
                
                // 添加新项到最前面
                cache[key] = value;
                accessOrder.Insert(0, key);
            }
        }

        private int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                // 移动到最前面
                accessOrder.Remove(key);
                accessOrder.Insert(0, key);
                return cache[key];
            }
            return -1;
        }

        private void UpdateDisplay()
        {
            statusLabel.Text = $"LRU缓存可视化演示 - 当前大小: {cache.Count}";
            operationLabel.Text = $"当前操作: {currentOperation}";
            drawPanel.Invalidate();
        }
    }
}
