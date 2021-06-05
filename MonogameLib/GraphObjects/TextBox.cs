using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Behaviours;

namespace MonogameLib.Classes
{
    public class TextBox : GraphObject
    {
        public string text;
        public Color color;
        public Matrix transformMatrix;
        public int positionX;
        public int positionY;
        SpriteFont font;

        public TextBox(string text, int positionX, int positionY, SpriteFont font, Color color )
        {
            this.text = text;
            this.positionX = positionX;
            this.positionY = positionY;
            this.color = color;

            this.font = font;
        }

        private Vector2 transformPosition
        {
            get
            {
                var res = new Vector2(positionX, positionY);
                res.X = positionX - transformMatrix.M41;
                res.Y = positionY - transformMatrix.M42;

                return res;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, transformPosition, color);
        }
    }
}
