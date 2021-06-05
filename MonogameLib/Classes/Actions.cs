using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameLib.Classes
{
    public static class Actions
    {
        public static void ScrollToObject(Sprite target, Camera camera, Vector2 windowSize, Vector2 layoutSize)
        {
            var middlePoint = new Vector2(windowSize.X / 2, windowSize.Y / 2);
            camera.Follow(target.transformPosition, middlePoint, layoutSize);
        }

        public static void SetAngleForward(Sprite target, float pointX, float pointY, bool IsGlobal)
        {
            Vector2 position;
            if (IsGlobal)
            {
                position = target.Position;
            }
            else
            {
                position = target.transformPosition;
            }
            double dX = -position.X + pointX;
            double dY = -position.Y + pointY;
            target.Rotation = (float)(Math.Atan2(dY, dX));
        }

        public static void SetText(TextBox target, string text)
        {
            target.text = text;
        }

        public static void Destroy(Sprite target)
        {
            target.IsRemove = true;
        }

        public static void SpawnAnotherObject(Sprite parent, Sprite child)
        {
            child.Position = parent.Position;
            child.Rotation = parent.Rotation;
        }

        public static void RemoveObject(Sprite target, List<Sprite> allSprites, List<Sprite> similarSprites)
        {
            allSprites.Remove(target);
            similarSprites.Remove(target);
        }
    }
}
