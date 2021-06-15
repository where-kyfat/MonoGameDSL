using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameLib.Classes;

namespace MonogameLib.Behaviours
{
    public class Fade : Behaviour
    {
        public bool active;
        private bool destroyAfter;

        int mAlphaValue;
        int mFadeIncrement;
        double mFadeDelay = .035;

        public Fade(bool active, bool destroyAfter, Sprite target)
        {
            this.active = active;
            this.destroyAfter = destroyAfter;
            if (target.mFadeIncrement == default)
            {
                this.mFadeIncrement = 5;
            }
            else
            {
                this.mFadeIncrement = target.mFadeIncrement;
            }

            if (target.mAlphaValue == default)
            {
                this.mAlphaValue = 1;
            }
            else
            {
                this.mAlphaValue = target.mAlphaValue;
            }

            if (target.mFadeDelay == default)
            {
                this.mFadeDelay = .035;
            }
            else
            {
                this.mFadeDelay = target.mFadeDelay;
            }
        }

        public override void Execute(GameTime gameTime, Sprite target)
        {
            if (active)
            {

                //Decrement the delay by the number of seconds that have elapsed since
                //the last time that the Update method was called
                mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;

                //If the Fade delays has dropped below zero, then it is time to 
                //fade in/fade out the image a little bit more.
                if (mFadeDelay <= 0)
                {
                    //Reset the Fade delay
                    mFadeDelay = .035;

                    //Increment/Decrement the fade value for the image
                    if (mAlphaValue <= 255)
                    {
                        mAlphaValue += mFadeIncrement;
                    }

                    byte curValue = (byte)(255 - MathHelper.Clamp(mAlphaValue, 0, 255));

                    target.Color = new Color(curValue, curValue, curValue, (byte)0);

                    if (target.Color == Color.Transparent && destroyAfter)
                    {
                        target.IsRemove = true;
                    }
                }
            }

            targetUpdate(target);
        }

        void targetUpdate(Sprite target)
        {
            target.mAlphaValue = mAlphaValue;
            target.mFadeIncrement = mFadeIncrement;
            target.mFadeDelay = mFadeDelay;
        }
    }
}