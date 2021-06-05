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

        public BoundToLayout(Vector2 layoutSize, bool IsEdge = true)
        {
            this.layoutSize = layoutSize;
            this.IsEdge = IsEdge;
        }

        public override void Execute(GameTime gameTime, Sprite target)
        {
            if (IsEdge) BoundEdge(target, layoutSize);
            else BoundOrigin(target, layoutSize);
        }

        private void BoundEdge(Sprite target, Vector2 layoutSize)
        {
            var Left = target.Rectangle.Left;
            var Right = target.Rectangle.Right;
            var Bottom = target.Rectangle.Bottom;
            var Top = target.Rectangle.Top;

            var width = target.Rectangle.Width;
            var height = target.Rectangle.Height;

            if (Left < 0) target.Position.X -= Left;
            if (Top < 0) target.Position.Y -= Top;
            if (Right < 0) target.Position.X -= Right;
            if (Bottom < 0) target.Position.Y -= Bottom;

            if (Bottom > layoutSize.Y) target.Position.Y = layoutSize.Y - height;
            if (Right > layoutSize.X) target.Position.X = layoutSize.X - width;
        }

        private void BoundOrigin(Sprite target, Vector2 layoutSize)
        {
            if (target.Position.X < 0) target.Position.X = 0;
            if (target.Position.Y < 0) target.Position.Y = 0;
            if (target.Position.X > layoutSize.X) target.Position.X = layoutSize.X;
            if (target.Position.Y > layoutSize.Y) target.Position.Y = layoutSize.Y;
        }
    }
}
