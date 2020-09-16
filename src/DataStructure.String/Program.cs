using DataStructure.String.BF;
using DataStructure.String.KMP;
using DataStructure.String.RK;

namespace DataStructure.String
{
    class Program
    {
        static void Main(string[] args)
        {
            // BFTest();
            // RKTest();
            // KMPTest();
            TrieTest();
        }


        #region BFTest

        public static void BFTest()
        {
            var mainString = "qweasdfggcxfbghgxxcvbgfjn";
            var pattern = "bgf";
            var bf = new BruteForce();
            var data = bf.BFSearch(mainString, pattern); // 20
        }

        #endregion

        #region RKTest

        public static void RKTest()
        {
            var bf = new RabinKarp("bgf");
            var data = bf.Search("qweasdfggcxfbghgxxcvbgfjn"); // 20
        }

        #endregion

        #region KMPTest

        public static void KMPTest()
        {
            var bf = new KnuthMorrisPratt("bgf");
            var data = bf.Search("qweasdfggcxfbghgxxcvbgfjn"); // 20
        }

        #endregion

        #region TrieTest

        public static void TrieTest()
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            var a = trie.Search("apple");   // 返回 true
            var b = trie.Search("app");     // 返回 false
            var c = trie.StartsWith("app"); // 返回 true
            trie.Insert("app");
            var d = trie.Search("app");     // 返回 true

        }

        #endregion
    }
}
