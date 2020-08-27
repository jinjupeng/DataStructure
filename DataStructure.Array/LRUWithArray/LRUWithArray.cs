namespace DataStructure.Array.LRUWithArray
{
    /// <summary>
    /// 使用数组实现LRU缓存淘汰算法
    /// </summary>
    public class LRUWithArray
    {
        /*
         * 实现LRU缓存淘汰算法思路：
         * 维护一个有序单链表，越靠近链尾的数据是最早访问的。
         * 当有一个新的数据被访问时，
         * 1. 如果数据在缓存中，则将其从原位置删除，然后插入到表头；
         * 2. 如果数据不在缓存中，有两种情况：
         *     1) 链表未满，则将数据插入到表头；
         *     2) 链表已满，则删除尾结点，将新数据插入到表头。
         */

        private readonly int _capacity;

        public LRUWithArray(int capacity)
        {
            _capacity = capacity;
            CachedList = new Array<int>(capacity);
        }

        public Array<int> CachedList { get; }

        public void Set(int val)
        {
            // 找出该值在缓存中的索引位置
            int idx = CachedList.IndexOf(val);

            // 存在该缓存值
            if (idx != -1)
            {
                CachedList.Delete(idx);
                CachedList.Insert(0, val);
                return;
            }

            // 不存在该缓存值
            if (CachedList.Length == _capacity)
            {
                // 缓存已满，删除最后一个元素
                CachedList.Delete(CachedList.Length - 1);
            }

            // 将新缓存插入到表头
            CachedList.Insert(0, val);
        }
    }
}