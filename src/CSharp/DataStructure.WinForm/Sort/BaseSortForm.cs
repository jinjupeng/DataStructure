using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace DataStructure.WinForm.Sort
{
    public partial class BaseSortForm : Form
    {
        protected int[] data;
        protected int[] originalData;
        protected bool isSorting = false;
        protected int delay = 500; // 动画延迟时间（毫秒）
        protected Graphics graphics;
        protected Panel drawPanel;
        protected Label statusLabel;
        protected Button startButton;
        protected Button resetButton;
        protected Button randomButton;
        protected TrackBar speedTrackBar;
        protected Label speedLabel;
        protected TextBox dataInputTextBox;
        protected Button applyDataButton;
        protected Button clearDataButton;
        
        // 交换可视化相关
        protected int swapIndex1 = -1;
        protected int swapIndex2 = -1;
        protected bool isSwapping = false;
        protected int swapStep = 0; // 交换步骤：0-准备，1-交换中，2-完成

        public BaseSortForm()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            
            // 设置窗体属性
            Text = "排序可视化";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(600, 500);

            // 创建绘制面板
            drawPanel = new DoubleBufferedPanel();
            drawPanel.Location = new Point(20, 60);
            drawPanel.Size = new Size(740, 400);
            drawPanel.BackColor = Color.White;
            drawPanel.BorderStyle = BorderStyle.FixedSingle;
            drawPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            drawPanel.Paint += DrawPanel_Paint;

            // 创建状态标签
            statusLabel = new Label();
            statusLabel.Location = new Point(20, 20);
            statusLabel.Size = new Size(300, 30);
            statusLabel.Text = "准备就绪";
            statusLabel.Font = new Font("微软雅黑", 10);
            statusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // 创建开始按钮
            startButton = new Button();
            startButton.Location = new Point(350, 20);
            startButton.Size = new Size(80, 30);
            startButton.Text = "开始排序";
            startButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            startButton.Click += StartButton_Click;

            // 创建重置按钮
            resetButton = new Button();
            resetButton.Location = new Point(450, 20);
            resetButton.Size = new Size(80, 30);
            resetButton.Text = "重置";
            resetButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            resetButton.Click += ResetButton_Click;

            // 创建随机生成按钮
            randomButton = new Button();
            randomButton.Location = new Point(550, 20);
            randomButton.Size = new Size(80, 30);
            randomButton.Text = "随机生成";
            randomButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            randomButton.Click += RandomButton_Click;

            // 创建速度滑块
            speedTrackBar = new TrackBar();
            speedTrackBar.Location = new Point(650, 20);
            speedTrackBar.Size = new Size(100, 30);
            speedTrackBar.Minimum = 1;
            speedTrackBar.Maximum = 20;
            speedTrackBar.Value = 5; // 默认设置为较慢的速度
            speedTrackBar.TickFrequency = 5;
            speedTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            speedTrackBar.ValueChanged += SpeedTrackBar_ValueChanged;

            // 创建速度标签
            speedLabel = new Label();
            speedLabel.Location = new Point(650, 50);
            speedLabel.Size = new Size(100, 20);
            speedLabel.Text = "速度: 慢";
            speedLabel.Font = new Font("微软雅黑", 8);
            speedLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // 创建数据输入区域
            CreateDataInputControls();

            // 添加控件到窗体
            Controls.Add(drawPanel);
            Controls.Add(statusLabel);
            Controls.Add(startButton);
            Controls.Add(resetButton);
            Controls.Add(randomButton);
            Controls.Add(speedTrackBar);
            Controls.Add(speedLabel);

            ResumeLayout(false);
        }

        protected virtual void CreateDataInputControls()
        {
            // 数据输入标签
            Label dataInputLabel = new Label();
            dataInputLabel.Text = "手动输入数据（用逗号分隔）:";
            dataInputLabel.Location = new Point(20, 480);
            dataInputLabel.Size = new Size(200, 25);
            dataInputLabel.Font = new Font("微软雅黑", 9);
            dataInputLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // 数据输入文本框
            dataInputTextBox = new TextBox();
            dataInputTextBox.Location = new Point(230, 480);
            dataInputTextBox.Size = new Size(300, 25);
            dataInputTextBox.Font = new Font("微软雅黑", 9);
            dataInputTextBox.Text = "64, 34, 25, 12, 22, 11, 90, 5, 77, 30";
            dataInputTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // 应用数据按钮
            applyDataButton = new Button();
            applyDataButton.Text = "应用数据";
            applyDataButton.Location = new Point(550, 480);
            applyDataButton.Size = new Size(80, 25);
            applyDataButton.Font = new Font("微软雅黑", 9);
            applyDataButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            applyDataButton.Click += ApplyDataButton_Click;

            // 清空数据按钮
            clearDataButton = new Button();
            clearDataButton.Text = "清空";
            clearDataButton.Location = new Point(650, 480);
            clearDataButton.Size = new Size(60, 25);
            clearDataButton.Font = new Font("微软雅黑", 9);
            clearDataButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clearDataButton.Click += ClearDataButton_Click;

            // 添加控件到窗体
            Controls.Add(dataInputLabel);
            Controls.Add(dataInputTextBox);
            Controls.Add(applyDataButton);
            Controls.Add(clearDataButton);
        }

        protected virtual void InitializeData()
        {
            data = new int[50];
            originalData = new int[50];
            Random random = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.Next(10, 400);
                originalData[i] = data[i];
            }
        }

        protected virtual void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            DrawBars();
        }

        protected virtual void DrawBars()
        {
            if (data == null) return;

            // 清除背景
            graphics.Clear(Color.White);
            
            int barWidth = drawPanel.Width / data.Length;
            int maxHeight = drawPanel.Height - 20;
            
            // 预创建字体和画笔，避免重复创建
            using (Font font = new Font("Arial", 8))
            using (Pen borderPen = new Pen(Color.Black, 1))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    int barHeight = (int)((double)data[i] / 400 * maxHeight);
                    int x = i * barWidth;
                    int y = drawPanel.Height - barHeight - 10;

                    // 根据排序状态选择颜色
                    Color barColor = GetBarColor(i);
                    
                    // 绘制柱子
                    using (Brush brush = new SolidBrush(barColor))
                    {
                        graphics.FillRectangle(brush, x, y, barWidth - 2, barHeight);
                    }
                    
                    // 绘制边框
                    graphics.DrawRectangle(borderPen, x, y, barWidth - 2, barHeight);

                    // 绘制数值（只在柱子足够高时绘制）
                    if (barHeight > 20)
                    {
                        string text = data[i].ToString();
                        SizeF textSize = graphics.MeasureString(text, font);
                        graphics.DrawString(text, font, Brushes.Black, 
                            x + (barWidth - textSize.Width) / 2, y - 15);
                    }
                }
            }
        }

        protected virtual Color GetBarColor(int index)
        {
            // 交换可视化效果
            if (isSwapping && (index == swapIndex1 || index == swapIndex2))
            {
                switch (swapStep)
                {
                    case 0: // 准备交换
                        return Color.Orange;
                    case 1: // 交换中
                        return Color.Red;
                    case 2: // 交换完成
                        return Color.Green;
                    default:
                        return Color.Red;
                }
            }
            return Color.LightBlue;
        }

        protected virtual void StartButton_Click(object sender, EventArgs e)
        {
            if (isSorting)
            {
                isSorting = false;
                startButton.Text = "开始排序";
                statusLabel.Text = "排序已停止";
            }
            else
            {
                isSorting = true;
                startButton.Text = "停止排序";
                statusLabel.Text = "正在排序...";
                Task.Run(() => PerformSort());
            }
        }

        protected virtual void ResetButton_Click(object sender, EventArgs e)
        {
            if (isSorting) return;
            
            Array.Copy(originalData, data, data.Length);
            drawPanel.Invalidate();
            statusLabel.Text = "已重置";
        }

        protected virtual void RandomButton_Click(object sender, EventArgs e)
        {
            if (isSorting) return;
            
            InitializeData();
            drawPanel.Invalidate();
            statusLabel.Text = "已生成新数据";
        }

        protected virtual void ApplyDataButton_Click(object sender, EventArgs e)
        {
            if (isSorting) return;

            try
            {
                string inputText = dataInputTextBox.Text.Trim();
                if (string.IsNullOrEmpty(inputText))
                {
                    MessageBox.Show("请输入数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] parts = inputText.Split(',');
                int[] newData = new int[parts.Length];
                
                for (int i = 0; i < parts.Length; i++)
                {
                    newData[i] = int.Parse(parts[i].Trim());
                }

                // 限制数据长度，避免界面过于拥挤
                if (newData.Length > 100)
                {
                    MessageBox.Show("数据量过大，最多支持100个元素！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                data = newData;
                originalData = (int[])data.Clone();
                drawPanel.Invalidate();
                statusLabel.Text = $"已应用 {data.Length} 个数据元素";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据格式错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void ClearDataButton_Click(object sender, EventArgs e)
        {
            if (isSorting) return;

            dataInputTextBox.Clear();
            statusLabel.Text = "数据输入框已清空";
        }

        protected virtual void SpeedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // 调整速度计算公式，使速度更慢
            delay = 1000 - speedTrackBar.Value * 50; // 范围从950ms到50ms
            if (delay < 50) delay = 50; // 最小延迟50ms
            if (delay > 1000) delay = 1000; // 最大延迟1000ms
            
            string speedText = speedTrackBar.Value <= 5 ? "很慢" : 
                              speedTrackBar.Value <= 10 ? "慢" : 
                              speedTrackBar.Value <= 15 ? "中等" : "快";
            speedLabel.Text = $"速度: {speedText}";
        }

        protected virtual async Task PerformSort()
        {
            // 子类需要重写此方法实现具体的排序算法
            await Task.Delay(100);
        }

        protected async Task UpdateVisualization(int[] array, int highlightIndex1 = -1, int highlightIndex2 = -1)
        {
            if (!isSorting) return;
            
            data = (int[])array.Clone();
            
            // 使用BeginInvoke进行异步更新，减少阻塞
            drawPanel.BeginInvoke(new Action(() => {
                if (isSorting) // 再次检查是否仍在排序
                {
                    drawPanel.Invalidate();
                }
            }));
            
            // 调整延迟时间，使动画更流畅
            await Task.Delay(delay);
        }

        protected void SetHighlightIndices(int index1, int index2)
        {
            // 子类可以重写此方法来设置高亮索引
        }

        protected async Task ShowSwapAnimation(int index1, int index2)
        {
            if (!isSorting) return;

            // 设置交换状态
            isSwapping = true;
            swapIndex1 = index1;
            swapIndex2 = index2;

            // 步骤1：准备交换（橙色高亮）
            swapStep = 0;
            drawPanel.BeginInvoke(new Action(() => {
                if (isSorting) drawPanel.Invalidate();
            }));
            await Task.Delay(delay / 4);

            // 步骤2：交换中（红色高亮）
            swapStep = 1;
            drawPanel.BeginInvoke(new Action(() => {
                if (isSorting) drawPanel.Invalidate();
            }));
            await Task.Delay(delay / 8);

            // 执行交换
            int temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;

            // 步骤3：交换完成（绿色高亮）
            swapStep = 2;
            drawPanel.BeginInvoke(new Action(() => {
                if (isSorting) drawPanel.Invalidate();
            }));
            await Task.Delay(delay / 4);

            // 重置交换状态
            isSwapping = false;
            swapIndex1 = -1;
            swapIndex2 = -1;
            swapStep = 0;
        }
    }
}
