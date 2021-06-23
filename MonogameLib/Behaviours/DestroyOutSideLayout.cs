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

        /// <summary>
        ///  Автоматически уничтожает объект, если он покидает область макета
        /// </summary>
        /// <param name="layoutSizeX">Ширина макета</param>
        /// <param name="layoutSizeY">Высота макета</param>
        public DestroyOutSideLayout(int layoutSizeX, int layoutSizeY) 
        {
            this.layoutSize = new Vector2(layoutSizeX, layoutSizeY);
        }

        public override void Execute(GameTime gameTime, Sprite target)
        {
            if (Conditions.IsOutsideLayout(target, (int)layoutSize.X, (int)layoutSize.Y))
            {
                target.IsRemove = true;
            }
        }
    }
}
