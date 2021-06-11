using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLangParser.Exceptions;

namespace GameLangParser.Nodes
{
    public class LoadContentNode : Node
    {
        public Dictionary<string, string> spitesTexturePath;
        public LoadContentNode(string BlockCode, string KeyWord) : base(BlockCode, KeyWord) { }

        public Dictionary<string, string> spitesTexturePathInit(List<string> spritesTextures)
        {
            this.spitesTexturePath = new Dictionary<string, string>();

            foreach (var sprite in spritesTextures)
            {
                spitesTexturePath.Add(sprite, "-1");
            }

            return spitesTexturePath;
        }

        public override string ToString()
        {
            var result = "";
            var load = "\t\t\t[name] = LoadTextrure([pathTexture]);\n";

            foreach (var texture in spitesTexturePath)
            {
                if (texture.Value != "-1")
                {
                    string curRes;
                    curRes = load.Replace("[name]", texture.Key);
                    curRes = curRes.Replace("[pathTexture]", texture.Value);
                    result += curRes;
                }
                else
                {
                    throw new WrongTextureException(string.Format("UnInitialize texture - {0}", texture.Key));
                }
            }

            return result;
        }

        public override string ToString(string gameCode)
        {
            return gameCode.Replace(KeyWord, this.ToString());
        }
    }
}
