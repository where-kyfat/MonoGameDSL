using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Nodes
{
    public class VariablesInitNode : Node
    {
        List<string> spritesTexturs;
        public VariablesInitNode(string BlockCode, string KeyWord) : base(BlockCode, KeyWord) { }

        public void SpritesTextureInit(List<string> spritesTexturs)
        {
            this.spritesTexturs = spritesTexturs;
        }

        public override string ToString(string gameCode)
        {
            string SpritesTextures = "";
            string prefix = "\t\tTexture2D [name];\n";

            foreach (var sprite in spritesTexturs)
            {
                if (sprite != "layoutTexture")
                {
                    SpritesTextures += prefix.Replace("[name]", sprite);
                }
                
            }

            BlockCode = SpritesTextures + BlockCode;

            return base.ToString(gameCode);
        }
    }
}