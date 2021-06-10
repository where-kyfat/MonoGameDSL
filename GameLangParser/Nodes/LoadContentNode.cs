using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Nodes
{
    public class LoadContentNode : Node
    {
        List<string> spritesNames;
        public LoadContentNode(string BlockCode, string KeyWord) : base(BlockCode, KeyWord) { }

        public void SpritesNameInit(List<string> spritesNames)
        {
            this.spritesNames = spritesNames;
        }
    }
}
