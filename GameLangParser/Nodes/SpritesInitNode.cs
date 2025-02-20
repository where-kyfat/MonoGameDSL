﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Nodes
{
    public class SpritesInitNode : Node
    {
        public List<SpriteInitNode> inits;
        public SpritesInitNode() : base("[SPRITES LOGIC SECTION]")
        {
            inits = new List<SpriteInitNode>();
        }

        public void AddSpiteInit(SpriteInitNode InitNode)
        {
            inits.Add(InitNode);
        }

        public List<string> GetNameTextures()
        {
            List<string> result = new List<string>();

            foreach (var spriteInit in inits)
            {
                result.Add(spriteInit.className.ToLower());
            }

            var postfix = "Texture";
            for (int i = 0; i < result.Count; i++)
            {
                result[i] += postfix;
            }

            return result;
        }

        protected override void Parse()
        {
            string result = "";
            foreach (var init in inits)
            {
                result += init.ToString();
            }

            BlockCode = result;
        }
    }
}
