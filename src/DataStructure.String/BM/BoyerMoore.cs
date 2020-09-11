namespace DataStructure.String.BM
{
    public class BoyerMoore
    {
        /// <summary>
        /// BM（Boyer-Moore）算法：
        /// </summary>
        /// <param name="main"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public int BMSearch(string main, string pattern)
        {
            if (main.Length == 0 || pattern.Length == 0 || main.Length < pattern.Length)
            {
                return -1;
            }

            return -1;
        }
    }
}