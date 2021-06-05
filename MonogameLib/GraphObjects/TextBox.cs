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
        public Vector2 position;
        SpriteFont font;

        public TextBox(string text, Vector2 position, SpriteFont font, Color color )
        {
            this.text = text;
            this.position = position;
            this.color = color;

            this.font = font;
        }

        private Vector2 transformPosition
        {
            get
            {
                var res = position;
                res.X = position.X - transformMatrix.M41;
                res.Y = position.Y - transformMatrix.M42;

                return res;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, transformPosition, color);
        }
    }
}
