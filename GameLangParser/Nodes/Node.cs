namespace GameLangParser.Nodes
{
    public abstract class Node
    {
        protected string BlockCode;
        protected string KeyWord;

        public Node(string BlockCode, string KeyWord)
        {
            this.BlockCode = BlockCode;
            this.KeyWord = KeyWord;
        }

        public virtual string ToString(string gameCode)
        {
            return gameCode.Replace(KeyWord, BlockCode);
        }
    }
}
