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
        Vector2 layoutSize;
        bool IsEdge;

        public BoundToLayout(int layoutSizeX, int layoutSizeY, bool IsEdge = true)
        {
            this.layoutSize = new Vector2(layoutSizeX, layoutSizeY);
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

            if (Bottom > layoutSize.Y) target.PositionY = (int)layoutSize.Y - height;
            if (Right > layoutSize.X) target.PositionX = (int)layoutSize.X - width;
        }

        private void BoundOrigin(Sprite target)
        {
            if (target.PositionX < 0) target.PositionX = 0;
            if (target.PositionY < 0) target.PositionY = 0;
            if (target.PositionX > layoutSize.X) target.PositionX = (int)layoutSize.X;
            if (target.PositionY > layoutSize.Y) target.PositionY = (int)layoutSize.Y;
        }
    }
}
