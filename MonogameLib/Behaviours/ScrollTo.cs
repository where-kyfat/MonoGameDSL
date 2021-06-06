using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Classes;


namespace MonogameLib.Behaviours
{
    public class ScrollTo : Behaviour
    {
        Camera camera;
        int middlePointX;
        int middlePointY;
        int layoutSizeX;
        int layoutSizeY;

        public ScrollTo(Camera camera, int windowSizeX, int windowSizeY, int layoutSizeX, int layoutSizeY)
        {
            this.camera = camera;
            this.middlePointX = windowSizeX / 2;
            this.middlePointY = windowSizeY / 2;
            this.layoutSizeX = layoutSizeX;
            this.layoutSizeY = layoutSizeY;
        }

        public override void Execute(GameTime gameTime, Sprite target)
        {
            //var middlePoint = new Vector2(windowSize.X / 2, windowSize.Y / 2);
            camera.Follow(target.PositionX, target.PositionY, middlePointX, middlePointY, layoutSizeX, layoutSizeY);
            target.transformMatrix = camera.Transform;
        }
    }
}
