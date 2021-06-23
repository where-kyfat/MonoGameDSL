using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Classes;

namespace MonogameLib.Behaviours
{
    public class BoundToLayout : Behaviour
    {
        int layoutSizeX;
        int layoutSizeY;
        bool IsEdge;

        /// <summary>
        /// Предотвращает выход объекта за пределы макета
        /// </summary>
        /// <param name="layoutSizeX">Ширина макета</param>
        /// <param name="layoutSizeY">Высота макета</param>
        /// <param name="IsEdge"></param>
        public BoundToLayout(int layoutSizeX, int layoutSizeY, bool IsEdge = true)
        {
            this.layoutSizeX = layoutSizeX;
            this.layoutSizeY = layoutSizeY;
            this.IsEdge = IsEdge;
        }

        public override void Execute(GameTime gameTime, Sprite target)
        {
            if (IsEdge) BoundEdge(target);
            else BoundOrigin(target);
        }

        private void BoundEdge(Sprite target)
        {
            var Left = target.Rectangle.Left;
            var Right = target.Rectangle.Right;
            var Bottom = target.Rectangle.Bottom;
            var Top = target.Rectangle.Top;

            var width = target.Rectangle.Width;
            var height = target.Rectangle.Height;

            if (Left < 0) target.PositionX -= Left;
            if (Top < 0) target.PositionY -= Top;
            if (Right < 0) target.PositionX -= Right;
            if (Bottom < 0) target.PositionY -= Bottom;

            if (Bottom > layoutSizeY) target.PositionY = layoutSizeY - height;
            if (Right > layoutSizeX) target.PositionX = layoutSizeX - width;
        }

        private void BoundOrigin(Sprite target)
        {
            if (target.PositionX < 0) target.PositionX = 0;
            if (target.PositionY < 0) target.PositionY = 0;
            if (target.PositionX > layoutSizeX) target.PositionX = layoutSizeX;
            if (target.PositionY > layoutSizeY) target.PositionY = layoutSizeY;
        }
    }
}
