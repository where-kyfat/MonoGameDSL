using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Classes;

namespace MonogameLib.Behaviours
{
    public class BulletMovement : Behaviour
    {
        float speed;
        //int angleDegrees;

        public BulletMovement(float speed = 5f/*, int angleDegrees = 0*/)
        {
            this.speed = speed;
            //this.angleDegrees = angleDegrees;
        }

        public override void Execute(GameTime gameTime, Sprite target)
        {
            var Direction = new Vector2((float)Math.Cos(target.Rotation), (float)Math.Sin(target.Rotation));
            var Position = new Vector2(target.PositionX, target.PositionY);
            Position += Direction * speed;
            target.PositionX = (int)Position.X;
            target.PositionY = (int)Position.Y;
        }
    }
}
