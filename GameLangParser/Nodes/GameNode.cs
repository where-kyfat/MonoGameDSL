using System.Collections.Generic;

namespace GameLangParser.Nodes
{
    public class GameNode
    {
        List<Node> nodes;
        string patternGame;
        public GameNode(string patternGame)
        {
            nodes = new List<Node>();
            this.patternGame = patternGame;
        }

        public void AddNode(Node node)
        {
            nodes.Add(node);
        }

        public override string ToString()
        {
            foreach (var node in nodes)
            {
                patternGame = node.ToString(patternGame);
            }
            return patternGame;
        }
    }
}
