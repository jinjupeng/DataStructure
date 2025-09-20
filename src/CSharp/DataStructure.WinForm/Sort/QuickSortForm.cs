using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructure.WinForm.Sort
{
    public partial class QuickSortForm : BaseSortForm
    {
        private int pivotIndex = -1;
        private int leftIndex = -1;
        private int rightIndex = -1;
        private int lowBound = -1;
        private int highBound = -1;

        public QuickSortForm()
        {
            Text = "快速排序可视化";
        }

        protected override Color GetBarColor(int index)
        {
            if (index == pivotIndex)
                return Color.Red;
            if (index == leftIndex)
                return Color.Orange;
            if (index == rightIndex)
                return Color.Yellow;
            if (index >= lowBound && index <= highBound)
                return Color.LightGreen;
            return Color.LightBlue;
        }

        protected override async Task PerformSort()
        {
            await QuickSortImpl(data, 0, data.Length - 1);

            // 排序完成
            pivotIndex = -1;
            leftIndex = -1;
            rightIndex = -1;
            lowBound = -1;
            highBound = -1;
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

        private async Task QuickSortImpl(int[] arr, int low, int high)
        {
            if (low >= high || !isSorting) return;

            lowBound = low;
            highBound = high;
            int pivotPos = await Partition(arr, low, high);
            
            if (isSorting)
            {
                await QuickSortImpl(arr, low, pivotPos - 1);
                await QuickSortImpl(arr, pivotPos + 1, high);
            }
        }

        private async Task<int> Partition(int[] arr, int low, int high)
        {
            int i = low, j = high;
            int temp = arr[i];
            pivotIndex = i;

            while (i < j && isSorting)
            {
                // 从右向左扫描
                while (i < j && arr[j] >= temp && isSorting)
                {
                    rightIndex = j;
                    leftIndex = i;
                    await UpdateVisualization(arr, leftIndex, rightIndex);
                    j--;
                }
                if (i < j)
                {
                    arr[i] = arr[j];
                }

                // 从左向右扫描
                while (i < j && arr[i] <= temp && isSorting)
                {
                    leftIndex = i;
                    rightIndex = j;
                    await UpdateVisualization(arr, leftIndex, rightIndex);
                    i++;
                }
                if (i < j)
                {
                    arr[j] = arr[i];
                }
            }

            arr[i] = temp;
            pivotIndex = i;
            await UpdateVisualization(arr);
            return i;
        }
    }
}
