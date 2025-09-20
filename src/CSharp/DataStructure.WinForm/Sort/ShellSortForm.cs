using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructure.WinForm.Sort
{
    public partial class ShellSortForm : BaseSortForm
    {
        private int currentIndex = -1;
        private int comparingIndex = -1;
        private int gap = -1;

        public ShellSortForm()
        {
            Text = "希尔排序可视化";
        }

        protected override Color GetBarColor(int index)
        {
            if (index == currentIndex)
                return Color.Red;
            if (index == comparingIndex)
                return Color.Orange;
            if (gap > 0 && (index - currentIndex) % gap == 0)
                return Color.LightGreen;
            return Color.LightBlue;
        }

        protected override async Task PerformSort()
        {
            List<int> list = new List<int>(data);
            int h = 3;

            while (h > 0 && isSorting)
            {
                gap = h;
                for (int i = h; i < list.Count && isSorting; i++)
                {
                    currentIndex = i;
                    int temp = list[i];
                    int j = i;

                    while (j >= h && isSorting)
                    {
                        comparingIndex = j - h;
                        await UpdateVisualization(list.ToArray(), currentIndex, comparingIndex);

                        if (temp < list[j - h])
                        {
                            list[j] = list[j - h];
                            j -= h;
                        }
                        else
                        {
                            break;
                        }
                    }

                    list[j] = temp;
                    await UpdateVisualization(list.ToArray());
                }
                h = (h - 1) % 3;
            }

            data = list.ToArray();

            // 排序完成
            currentIndex = -1;
            comparingIndex = -1;
            gap = -1;
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
