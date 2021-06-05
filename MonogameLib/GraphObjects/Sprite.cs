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
        public int OriginX;
        public int OriginY;
        public float Scale = 1;
        public SpriteEffects SpriteEffects;
        public float LayerDepth;
        public Matrix transformMatrix;
        public int PositionX;
        public int PositionY;
        public float _forwardAngle = 0f;
        public bool IsRemove = false;

        public List<Behaviour> Behaviours;


        public Sprite(Texture2D Texture, int PositionX, int PositionY)
        {
            this.Texture = Texture;
            this.OriginX = Texture.Width / 2;
            this.OriginY = Texture.Height / 2;
            this.PositionX = PositionX;
            this.PositionY = PositionY;
            DestinationRectangle = new Rectangle(PositionX, PositionY, Texture.Width, Texture.Height);

            Behaviours = new List<Behaviour>();
        }

        public Sprite(Sprite copy)
        {
            this.Texture = copy.Texture;
            this.DestinationRectangle = copy.DestinationRectangle;
            this.Color = copy.Color;
            this.Rotation = copy.Rotation;
            this.OriginX = copy.OriginX;
            this.OriginY = copy.OriginY;
            this.Scale = copy.Scale;
            this.SpriteEffects = copy.SpriteEffects;
            this.LayerDepth = copy.LayerDepth;
            this.transformMatrix = copy.transformMatrix;
            this.PositionX = copy.PositionX;
            this.PositionY = copy.PositionY;
            this._forwardAngle = copy._forwardAngle;
            this.Behaviours = copy.Behaviours;
        }

        public Vector2 transformPosition
        {
            get
            {
                var res = new Vector2();
                res.X = transformMatrix.M41 + PositionX;
                res.Y = transformMatrix.M42 + PositionY;

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
                return new Rectangle((int)(PositionX - width / 2f), (int)(PositionY - height / 2f), width, height);
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
            DestinationRectangle.X = PositionX;
            DestinationRectangle.Y = PositionY;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Scale != 1)
            {
                var Position = new Vector2(PositionX, PositionY);
                var Origin = new Vector2(OriginX, OriginY);
                spriteBatch.Draw(Texture, Position, null, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
            }
            else
            {
                var Origin = new Vector2(OriginX, OriginY);
                UpdateDestinationRectangle();
                spriteBatch.Draw(Texture, DestinationRectangle, null, Color, Rotation, Origin, SpriteEffects, LayerDepth);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, int positionX, int positionY)
        {
            var Origin = new Vector2(OriginX, OriginY);
            var Position = new Vector2(PositionX, PositionY);
            spriteBatch.Draw(Texture, Position, null, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
