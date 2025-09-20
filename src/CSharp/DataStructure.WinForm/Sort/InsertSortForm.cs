using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructure.WinForm.Sort
{
    public partial class InsertSortForm : BaseSortForm
    {
        private int currentI = -1;
        private int currentJ = -1;
        private int insertingIndex = -1;

        public InsertSortForm()
        {
            Text = "插入排序可视化";
        }

        protected override Color GetBarColor(int index)
        {
            if (index == currentI)
                return Color.Red;
            if (index == currentJ)
                return Color.Orange;
            if (index == insertingIndex)
                return Color.Green;
            return Color.LightBlue;
        }

        protected override async Task PerformSort()
        {
            int n = data.Length;

            for (int i = 1; i < n && isSorting; i++)
            {
                insertingIndex = i;
                int temp = data[i];
                int j = i;

                while (j > 0 && isSorting)
                {
                    currentI = j - 1;
                    currentJ = j;
                    await UpdateVisualization(data, currentI, currentJ);

                    if (temp < data[j - 1])
                    {
                        data[j] = data[j - 1];
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (j != i)
                {
                    data[j] = temp;
                }

                await UpdateVisualization(data);
            }

            // 排序完成
            currentI = -1;
            currentJ = -1;
            insertingIndex = -1;
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
