using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Classes;

namespace MonogameLib.Behaviours
{
    public class DestroyOutSideLayout : Behaviour
    {
        Vector2 layoutSize;

        public DestroyOutSideLayout(Vector2 layoutSize) 
        {
            this.layoutSize = layoutSize;
        }

        public override void Execute(GameTime gameTime, Sprite target)
        {
            if (Conditions.IsOutsideLayout(target, layoutSize))
            {
                target.IsRemove = true;
            }
        }
    }
}
