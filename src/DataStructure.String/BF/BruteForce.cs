namespace DataStructure.String.BF
{
    public class BruteForce
    {
        /// <summary>
        /// BF（Brute Force）：暴力匹配算法，也叫朴素匹配算法
        /// </summary>
        /// <param name="main"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public int BFSearch(string main, string pattern)
        {
            if (main.Length == 0 || pattern.Length == 0 || main.Length < pattern.Length)
            {
                return -1;
            }

            for (int i = 0; i <= main.Length - pattern.Length; i++)
            {
                var subStr = main.Substring(i, pattern.Length);
                if (subStr == pattern)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}