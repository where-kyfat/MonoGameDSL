using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Behaviours;

namespace MonogameLib.Classes
{
    public class Sprite : GraphObject
    {
        public Texture2D Texture;
        private Rectangle DestinationRectangle;
        public Color Color = new Color(255, 255, 255, 255);
        public float Rotation;
        public Vector2 Origin;
        public float Scale = 1;
        public SpriteEffects SpriteEffects;
        public float LayerDepth;
        public Matrix transformMatrix;
        public Vector2 Position;
        public float _forwardAngle = 0f;
        public bool IsRemove = false;

        public List<Behaviour> Behaviours;


        public Sprite(Texture2D Texture, Vector2 Position)
        {
            this.Texture = Texture;
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            this.Position = Position;
            DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

            Behaviours = new List<Behaviour>();
        }

        public Sprite(Sprite copy)
        {
            this.Texture = copy.Texture;
            this.DestinationRectangle = copy.DestinationRectangle;
            this.Color = copy.Color;
            this.Rotation = copy.Rotation;
            this.Origin = copy.Origin;
            this.Scale = copy.Scale;
            this.SpriteEffects = copy.SpriteEffects;
            this.LayerDepth = copy.LayerDepth;
            this.transformMatrix = copy.transformMatrix;
            this.Position = copy.Position;
            this._forwardAngle = copy._forwardAngle;
            this.Behaviours = copy.Behaviours;
        }

        public Vector2 transformPosition
        {
            get
            {
                var res = Position;
                res.X = transformMatrix.M41 + Position.X;
                res.Y = transformMatrix.M42 + Position.Y;

                return res;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                int width = (int)((Texture.Width * Math.Cos(Rotation) + Texture.Height * Math.Sin(Rotation)) * Scale);
                int height = (int)((Texture.Width * -Math.Sin(Rotation) + Texture.Height * Math.Cos(Rotation)) * Scale);
                width = Math.Abs(width) - 2;
                height = Math.Abs(height) - 2;
                return new Rectangle((int)(Position.X - width / 2f), (int)(Position.Y - height / 2f), width, height);
            }
        }

        public override void Update(GameTime gameTime)  
        {
            foreach (var behaviour in Behaviours)
            {
                behaviour.Execute(gameTime, this);
            }
        }

        private void UpdateDestinationRectangle()
        {
            DestinationRectangle.X = (int)Position.X;
            DestinationRectangle.Y = (int)Position.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Scale != 1)
            {
                spriteBatch.Draw(Texture, Position, null, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
            }
            else
            {
                UpdateDestinationRectangle();
                spriteBatch.Draw(Texture, DestinationRectangle, null, Color, Rotation, Origin, SpriteEffects, LayerDepth);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(Texture, position, null, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
