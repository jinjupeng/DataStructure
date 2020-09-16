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
            KMPTest();
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
    }
}
