using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Classes;

namespace MonogameLib.Behaviours
{
    public class _8Directions : Behaviour
    {
        float _speed;

        public _8Directions(float speed = 4)
        {
            _speed = speed;
        }
        public override void Execute(GameTime gameTime, Sprite target)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                target.Position.Y -= _speed;
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                target.Position.Y += _speed;

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                target.Position.X -= _speed;
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                target.Position.X += _speed;
        }
    }
}
