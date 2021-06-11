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

        public TextBox(SpriteFont font, int positionX, int positionY, string text, Color color)
        {
            this.text = text;
            this.positionX = positionX;
            this.positionY = positionY;
            this.color = color;

            this.font = font;
        }

        public TextBox(SpriteFont font, int positionX, int positionY, string text)
        {
            this.text = text;
            this.positionX = positionX;
            this.positionY = positionY;
            this.color = Color.Yellow;

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
