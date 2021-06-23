using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameLib.Classes
{
    public static class Conditions
    {
        static float timerSec = 0;
        static float timerMil = 0;

        /// <summary>
        /// Возвращает true каждый тик игры
        /// </summary>
        public static bool EveryTick()
        {
            return true;
        }

        /// <summary>
        /// Возвращает true, когда проходит определенное время в игре
        /// </summary>
        /// <param name="x">Время в секундах через которое срабатывает</param>
        public static bool EveryXSeconds(GameTime gameTime, float x)
        {
            timerSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timerSec > x)
            {
                timerSec = 0f;
                return true;
            }
            return false;
        }

        //public static bool ForEach(List<Sprite> sprites, )

        /// <summary>
        /// Возвращает true, когда объект выходит за пределы макета
        /// </summary>
        /// <param name="target">экземпляр объекта</param>
        /// <param name="layoutSizeX">ширина макета</param>
        /// <param name="layoutSizeY">высота макета</param>
        public static bool IsOutsideLayout(Sprite target, int layoutSizeX, int layoutSizeY)
        {
            var Left = target.Rectangle.Left;
            var Right = target.Rectangle.Right;
            var Bottom = target.Rectangle.Bottom;
            var Top = target.Rectangle.Top;
            if (layoutSizeX <= Right || layoutSizeY <=  Bottom ||
                Left <= 0 || Top < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Возвращает true, если объекты сталкиваются
        /// </summary>
        /// <param name="target1">первый объект</param>
        /// <param name="target2">второй объект</param>
        public static bool InCollisionWith(Sprite target1, Sprite target2)
        {
            return IsTouchingLeft(target1, target2) || IsTouchingRight(target1, target2) 
                || IsTouchingTop(target1, target2) || IsTouchingBottom(target1, target2);

        }

        public static bool IsTouchingLeft(Sprite target1, Sprite target2)
        {
            return target1.Rectangle.Right > target2.Rectangle.Left &&
              target1.Rectangle.Left < target2.Rectangle.Left &&
              target1.Rectangle.Bottom > target2.Rectangle.Top &&
              target1.Rectangle.Top < target2.Rectangle.Bottom;
        }

        public static bool IsTouchingRight(Sprite target1, Sprite target2)
        {
            return target1.Rectangle.Left < target2.Rectangle.Right &&
              target1.Rectangle.Right > target2.Rectangle.Right &&
              target1.Rectangle.Bottom > target2.Rectangle.Top &&
              target1.Rectangle.Top < target2.Rectangle.Bottom;
        }

        public static bool IsTouchingTop(Sprite target1, Sprite target2)
        {
            return target1.Rectangle.Bottom > target2.Rectangle.Top &&
              target1.Rectangle.Top < target2.Rectangle.Top &&
              target1.Rectangle.Right > target2.Rectangle.Left &&
              target1.Rectangle.Left < target2.Rectangle.Right;
        }

        public static bool IsTouchingBottom(Sprite target1, Sprite target2)
        {
            return target1.Rectangle.Top < target2.Rectangle.Bottom &&
              target1.Rectangle.Bottom > target2.Rectangle.Bottom &&
              target1.Rectangle.Right > target2.Rectangle.Left &&
              target1.Rectangle.Left < target2.Rectangle.Right;
        }


        enum MouseButton
        {
            Left,
            Right,
            Middle
        }

        static bool OnMouseXButtonClicked(MouseButton NameButton, GameTime gameTime)
        {
            timerMil += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timerMil > 250f)
            {
                var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
                if (NameButton == MouseButton.Left)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        timerMil = 0f;
                        return true;
                    }
                }
                else if (NameButton == MouseButton.Right)
                {
                    if (mouseState.RightButton == ButtonState.Pressed)
                    {
                        timerMil = 0f;
                        return true;
                    }
                }
                else if (NameButton == MouseButton.Middle)
                {
                    if (mouseState.MiddleButton == ButtonState.Pressed)
                    {
                        timerMil = 0f;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает true, когда нажата левая клавиша мыши
        /// </summary>
        public static bool OnMouseLeftClicked(GameTime gameTime)
        {
            return OnMouseXButtonClicked(MouseButton.Left, gameTime);
        }

        /// <summary>
        /// Возвращает true, когда нажата прававя клавиша мыши
        /// </summary>
        public static bool OnMouseRightClicked(GameTime gameTime)
        {
            return OnMouseXButtonClicked(MouseButton.Right, gameTime);
        }

        /// <summary>
        /// Возвращает true, когда нажато колесо клавиша мыши
        /// </summary>
        public static bool OnMouseMiddleClicked(GameTime gameTime)
        {
            return OnMouseXButtonClicked(MouseButton.Middle, gameTime);
        }

        public static bool OnXButtonClicked(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}
