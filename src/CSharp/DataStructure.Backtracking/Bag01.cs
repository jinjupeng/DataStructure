namespace DataStructure.Backtracking
{
    /// <summary>
    /// 0-1背包问题
    /// </summary>
    public class Bag01
    {
        public int MaxWeight = int.MinValue; // 存储背包中物品总重量的最大值

        /// <summary>
        /// 设背包可承受重量100，物品个数10，物品重量存储在数组a中，则可以这样调用函数：BagCompute(0, 0, a, 10, 100)
        /// </summary>
        /// <param name="i">i表示考察到哪个物品了</param>
        /// <param name="cw">cw表示当前已经装进去的物品的重量和</param>
        /// <param name="items">items表示每个物品的重量</param>
        /// <param name="n">n表示物品个数</param>
        /// <param name="w">w背包重量</param>
        public void BagCompute(int i, int cw, int[] items, int n, int w)
        {
            if (cw == w || i == n)
            { 
                // cw==w表示装满了;i==n表示已经考察完所有的物品
                if (cw > MaxWeight) MaxWeight = cw;
                return;
            }
            BagCompute(i + 1, cw, items, n, w);
            if (cw + items[i] <= w)
            {
                // 已经超过可以背包承受的重量的时候，就不要再装了
                BagCompute(i + 1, cw + items[i], items, n, w);
            }
        }
    }
}