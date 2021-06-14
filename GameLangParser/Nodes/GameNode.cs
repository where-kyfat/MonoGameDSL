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

        public void ChangeFromPathToTextures()
        {
            var spritesTextures = ((SpritesInitNode)nodes[0]).GetNameTextures();
            spritesTextures.Add("layoutTexture");

            var LoadNode = new LoadContentNode(null, "[LOAD CONTENT SECTION]");
            var TexturePath = LoadNode.spitesTexturePathInit(spritesTextures);

            foreach (var node in nodes)
            {
                if (node is VariablesInitNode)
                {
                    ((VariablesInitNode)node).SpritesTextureInit(spritesTextures);
                }

                if (node is InitializeNode)
                {
                    TexturePath = ((InitializeNode)node).GetPathTextures(TexturePath);
                }

                if (node is UpdateNode)
                {
                    TexturePath = ((UpdateNode)node).GetPathTextures(TexturePath);
                }
            }

            LoadNode.spitesTexturePath = TexturePath;
            nodes.Add(LoadNode);
        }

        public override string ToString()
        {
            ChangeFromPathToTextures();

            foreach (var node in nodes)
            {
                patternGame = node.ToString(patternGame);
            }
            return patternGame;
        }
    }
}
