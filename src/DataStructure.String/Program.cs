using DataStructure.String.BF;

namespace DataStructure.String
{
    class Program
    {
        static void Main(string[] args)
        {
            BFTest();
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
    }
}
