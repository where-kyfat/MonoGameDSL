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
        /// <summary>
        /// Перемещает камеру к объекту
        /// </summary>
        /// <param name="target">целевой объект</param>
        /// <param name="camera">текущая камера</param>
        /// <param name="windowSizeX">ширина окна</param>
        /// <param name="windowSizeY">высота окна</param>
        /// <param name="layoutSizeX">ширина макета</param>
        /// <param name="layoutSizeY">высота макета</param>
        public static void ScrollToObject(Sprite target, Camera camera, int windowSizeX, int windowSizeY, int layoutSizeX, int layoutSizeY)
        {
            var middlePointX = windowSizeX / 2;
            var middlePointY = windowSizeY / 2;
            camera.Follow((int)target.transformPosition.X, (int)target.transformPosition.Y, middlePointX, middlePointY, layoutSizeX, layoutSizeY);
        }

        /// <summary>
        /// Поворачивает спрайт по направлению к точке
        /// </summary>
        /// <param name="target">целевой объект</param>
        /// <param name="pointX">x координата точки</param>
        /// <param name="pointY">y координата точки</param>
        /// <param name="IsGlobal">флаг, определяющий: вычислять в глобальных координатах или относительно окна</param>
        public static void SetAngleForward(Sprite target, float pointX, float pointY, bool IsGlobal)
        {
            Vector2 position;
            if (IsGlobal)
            {
                position = new Vector2(target.PositionX, target.PositionY);
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

        /// <summary>
        /// Уничтожает объект
        /// </summary>
        /// <param name="target">Целевой объект</param>
        public static void Destroy(Sprite target)
        {
            target.IsRemove = true;
        }

        public static void SpawnAnotherObject(Sprite parent, Sprite child)
        {
            child.PositionX = parent.PositionX;
            child.PositionY = parent.PositionY;
            child.Rotation = parent.Rotation;
        }

        public static void RemoveObject(Sprite target, List<Sprite> allSprites, List<Sprite> similarSprites)
        {
            allSprites.Remove(target);
            similarSprites.Remove(target);
        }
    }
}
