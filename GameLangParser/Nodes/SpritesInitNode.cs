using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Nodes
{
    public class SpritesInitNode : Node
    {
        public List<SpriteInitNode> inits;
        public SpritesInitNode(string BlockCode, string KeyWord) : base(BlockCode, KeyWord) 
        {
            inits = new List<SpriteInitNode>();
        }

        public void AddSpiteInit(SpriteInitNode InitNode)
        {
            inits.Add(InitNode);
        }

        public override string ToString(string gameCode)
        {
            string result = "";
            foreach (var init in inits)
            {
                result += init.ToString();
            }

            return gameCode.Replace(KeyWord, result);
        }
    }
}
