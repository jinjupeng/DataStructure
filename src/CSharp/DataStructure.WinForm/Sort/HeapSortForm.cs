using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructure.WinForm.Sort
{
    public partial class HeapSortForm : BaseSortForm
    {
        private int currentIndex = -1;
        private int comparingIndex = -1;
        private int heapSize = -1;

        public HeapSortForm()
        {
            Text = "堆排序可视化";
        }

        protected override Color GetBarColor(int index)
        {
            if (index == currentIndex)
                return Color.Red;
            if (index == comparingIndex)
                return Color.Orange;
            if (index < heapSize)
                return Color.LightGreen;
            return Color.LightBlue;
        }

        protected override async Task PerformSort()
        {
            int n = data.Length;
            heapSize = n;

            // 构建初始堆
            for (int i = n / 2 - 1; i >= 0 && isSorting; i--)
            {
                await Heapify(data, i, n);
            }

            // 进行堆排序
            for (int i = n - 1; i >= 1 && isSorting; i--)
            {
                // 交换堆顶和最后一个元素
                int temp = data[0];
                data[0] = data[i];
                data[i] = temp;
                heapSize = i;

                await UpdateVisualization(data);
                await Heapify(data, 0, i);
            }

            // 排序完成
            currentIndex = -1;
            comparingIndex = -1;
            heapSize = -1;
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

        private async Task Heapify(int[] arr, int i, int n)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            currentIndex = i;

            if (left < n && isSorting)
            {
                comparingIndex = left;
                await UpdateVisualization(arr, currentIndex, comparingIndex);
                if (arr[left] > arr[largest])
                {
                    largest = left;
                }
            }

            if (right < n && isSorting)
            {
                comparingIndex = right;
                await UpdateVisualization(arr, currentIndex, comparingIndex);
                if (arr[right] > arr[largest])
                {
                    largest = right;
                }
            }

            if (largest != i && isSorting)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                await UpdateVisualization(arr);
                await Heapify(arr, largest, n);
            }
        }
    }
}
