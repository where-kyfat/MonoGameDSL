namespace GameLangParser.Nodes
{
    public abstract class Node
    {
        protected string BlockCode;
        protected string KeyWord;

        public Node(string KeyWord)
        {
            this.BlockCode = "";
            this.KeyWord = KeyWord;
        }

        protected virtual void Parse()  {  }

        public virtual string ToString(string gameCode)
        {
            Parse();
            return gameCode.Replace(KeyWord, BlockCode);
        }
    }
}
