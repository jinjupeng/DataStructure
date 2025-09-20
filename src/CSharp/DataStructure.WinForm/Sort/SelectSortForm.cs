using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructure.WinForm.Sort
{
    public partial class SelectSortForm : BaseSortForm
    {
        private int currentI = -1;
        private int currentJ = -1;
        private int minIndex = -1;

        public SelectSortForm()
        {
            Text = "选择排序可视化";
        }

        protected override Color GetBarColor(int index)
        {
            if (index == currentI)
                return Color.Red;
            if (index == currentJ)
                return Color.Orange;
            if (index == minIndex)
                return Color.Green;
            return Color.LightBlue;
        }

        protected override async Task PerformSort()
        {
            int n = data.Length;

            for (int i = 0; i < n && isSorting; i++)
            {
                currentI = i;
                minIndex = i;

                for (int j = i + 1; j < n && isSorting; j++)
                {
                    currentJ = j;
                    await UpdateVisualization(data, currentI, currentJ);

                    if (data[j] < data[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    // 交换元素
                    int temp = data[i];
                    data[i] = data[minIndex];
                    data[minIndex] = temp;
                }

                await UpdateVisualization(data);
            }

            // 排序完成
            currentI = -1;
            currentJ = -1;
            minIndex = -1;
            if (isSorting)
            {
                Invoke(new Action(() => {
                    isSorting = false;
                    startButton.Text = "开始排序";
                    statusLabel.Text = "排序完成！";
                }));
                await UpdateVisualization(data);
            }
        }
    }
}
