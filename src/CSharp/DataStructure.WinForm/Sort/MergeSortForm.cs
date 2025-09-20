using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructure.WinForm.Sort
{
    public partial class MergeSortForm : BaseSortForm
    {
        private int leftStart = -1;
        private int leftEnd = -1;
        private int rightStart = -1;
        private int rightEnd = -1;
        private int mergeIndex = -1;

        public MergeSortForm()
        {
            Text = "归并排序可视化";
        }

        protected override Color GetBarColor(int index)
        {
            if (index >= leftStart && index <= leftEnd)
                return Color.LightGreen;
            if (index >= rightStart && index <= rightEnd)
                return Color.LightCoral;
            if (index == mergeIndex)
                return Color.Red;
            return Color.LightBlue;
        }

        protected override async Task PerformSort()
        {
            List<int> list = new List<int>(data);
            await MergeSortImpl(list, 0, list.Count - 1);
            data = list.ToArray();

            // 排序完成
            leftStart = -1;
            leftEnd = -1;
            rightStart = -1;
            rightEnd = -1;
            mergeIndex = -1;
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

        private async Task MergeSortImpl(List<int> list, int low, int high)
        {
            if (low >= high || !isSorting) return;

            int mid = (low + high) / 2;
            leftStart = low;
            leftEnd = mid;
            rightStart = mid + 1;
            rightEnd = high;

            await MergeSortImpl(list, low, mid);
            await MergeSortImpl(list, mid + 1, high);
            await Merge(list, low, mid, high);
        }

        private async Task Merge(List<int> list, int low, int mid, int high)
        {
            List<int> temp = new List<int>();
            for (int x = 0; x < list.Count; x++)
            {
                temp.Add(0);
            }

            int i = low;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= high && isSorting)
            {
                leftStart = i;
                rightStart = j;
                mergeIndex = low + k;
                await UpdateVisualization(list.ToArray(), leftStart, rightStart);

                if (list[i] <= list[j])
                {
                    temp[k++] = list[i++];
                }
                else
                {
                    temp[k++] = list[j++];
                }
            }

            while (i <= mid && isSorting)
            {
                leftStart = i;
                mergeIndex = low + k;
                await UpdateVisualization(list.ToArray(), leftStart, -1);
                temp[k++] = list[i++];
            }

            while (j <= high && isSorting)
            {
                rightStart = j;
                mergeIndex = low + k;
                await UpdateVisualization(list.ToArray(), -1, rightStart);
                temp[k++] = list[j++];
            }

            for (i = low, k = 0; i <= high && isSorting; i++, k++)
            {
                list[i] = temp[k];
                mergeIndex = i;
                await UpdateVisualization(list.ToArray());
            }
        }
    }
}
