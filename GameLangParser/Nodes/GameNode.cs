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
            var spritesNames = ((SpritesInitNode)nodes[0]).GetNameSprites();

            foreach (var node in nodes)
            {
                if (node is VariablesInitNode)
                {
                    ((VariablesInitNode)node).SpritesNameInit(spritesNames);
                }

                if (node is LoadContentNode)
                {
                    ((LoadContentNode)node).SpritesNameInit(spritesNames);
                }

                patternGame = node.ToString(patternGame);
            }
            return patternGame;
        }
    }
}
