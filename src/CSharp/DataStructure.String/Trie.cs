namespace DataStructure.String
{
    /// <summary>
    /// Trie树
    /// </summary>
    public class Trie
    {
        private readonly TrieNode _root = new TrieNode('/'); // 存储无意义字符

        public Trie()
        {
        }

        /// <summary>
        /// 往Trie树中插入一个字符串
        /// </summary>
        /// <param name="text"></param>
        public void Insert(string text)
        {
            var p = _root;
            var textChar = text.ToCharArray();
            foreach (var t in textChar)
            {
                var index = t - 'a';
                if (p.Children[index] == null)
                {
                    var newNode = new TrieNode(t);
                    p.Children[index] = newNode;
                }
                p = p.Children[index];
            }
            p.IsEndingChar = true;
        }


        /// <summary>
        /// 在Trie树中查找一个字符串
        /// </summary>
        /// <param name="word"></param>
        /// <returns>如果不存在或只有前缀则返回false，否则为true</returns>
        public bool Search(string word)
        {
            var p = _root;
            var pattern = word.ToCharArray();
            foreach (var t in pattern)
            {
                var index = t - 'a';
                if (p.Children[index] == null)
                {
                    return false; // 不存在pattern
                }
                p = p.Children[index];
            }
            if (p.IsEndingChar == false)
            {
                return false;
            } // 不能完全匹配，只是前缀

            return true; // 找到pattern
        }

        /// <summary>
        /// 一个字符串前缀是否存在Trie树中
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public bool StartsWith(string prefix)
        {
            var p = _root;
            var pattern = prefix.ToCharArray();
            foreach (var t in pattern)
            {
                var index = t - 'a';
                if (p.Children[index] == null)
                {
                    return false; // 不存在pattern
                }
                p = p.Children[index];
            }

            return true;
        }

        public class TrieNode
        {
            public char Data;
            public TrieNode[] Children = new TrieNode[26];
            public bool IsEndingChar; // 默认为false
            public TrieNode(char data)
            {
                this.Data = data;
            }
        }
    }
}