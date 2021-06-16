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

        public List<VarNode> varNodes;
        public VariablesInitNode() : base("[VARIBLES SECTION]") { }

        public void SpritesTextureInit(List<string> spritesTexturs)
        {
            this.spritesTexturs = spritesTexturs;
        }

        protected override void Parse()
        {
            string SpritesTextures = "";

            //Autocreating all Texture variables
            string prefix = "\t\tTexture2D [name];\n";

            foreach (var sprite in spritesTexturs)
            {
                if (sprite != "layoutTexture")
                {
                    SpritesTextures += prefix.Replace("[name]", sprite);
                }

            }
            BlockCode = SpritesTextures + BlockCode;
            //---------------------------------------

            prefix = "\t\t";
            foreach (var init in varNodes)
            {
                BlockCode += prefix + init.ToString() + ";\n";
            }

        }
    }
}