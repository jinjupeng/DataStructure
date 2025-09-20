using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructure.WinForm.Sort
{
    public partial class BubbleSortForm : BaseSortForm
    {
        private int currentI = -1;
        private int currentJ = -1;

        public BubbleSortForm()
        {
            Text = "冒泡排序可视化";
        }

        protected override Color GetBarColor(int index)
        {
            if (index == currentI || index == currentJ)
                return Color.Red;
            return Color.LightBlue;
        }

        protected override async Task PerformSort()
        {
            int n = data.Length;
            bool isExchanged = true;

            for (int j = 1; j < n && isSorting; j++)
            {
                isExchanged = false;
                for (int i = 0; i < n - j && isSorting; i++)
                {
                    currentI = i;
                    currentJ = i + 1;
                    await UpdateVisualization(data, currentI, currentJ);

                    if (data[i].CompareTo(data[i + 1]) > 0)
                    {
                        // 使用交换可视化
                        await ShowSwapAnimation(i, i + 1);
                        isExchanged = true;
                    }
                }

                if (!isExchanged)
                    break;
            }

            // 排序完成
            currentI = -1;
            currentJ = -1;
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
