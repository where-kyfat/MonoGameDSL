using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Nodes
{
    public class VariablesInitNode : Node
    {
        List<string> spritesNames;
        public VariablesInitNode(string BlockCode, string KeyWord) : base(BlockCode, KeyWord) { }

        public void SpritesNameInit(List<string> spritesNames)
        {
            this.spritesNames = spritesNames;
        }

        public override string ToString(string gameCode)
        {
            string SpritesTextures = "";
            string prefix = "Texture2D [name]Texture;  ";

            foreach (var sprite in spritesNames)
            {
                SpritesTextures += prefix.Replace("[name]", sprite.ToLower());
            }

            BlockCode = SpritesTextures + BlockCode;

            return base.ToString(gameCode);
        }
    }
}