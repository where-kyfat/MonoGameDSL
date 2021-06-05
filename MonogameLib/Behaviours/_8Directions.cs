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
        int _speed;

        public _8Directions(int speed = 4)
        {
            _speed = speed;
        }
        public override void Execute(GameTime gameTime, Sprite target)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                target.PositionY -= _speed;
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                target.PositionY += _speed;

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                target.PositionX -= _speed;
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                target.PositionX += _speed;
        }
    }
}
