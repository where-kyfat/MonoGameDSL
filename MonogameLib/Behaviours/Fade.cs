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
        private float fadeOutTime;
        private bool destroyAfter;

        int mAlphaValue = 1;
        int mFadeIncrement = 5;
        double mFadeDelay = .035;

        public Fade(bool active, float fadeOutTime, bool destroyAfter)
        {
            this.active = active;
            this.fadeOutTime = fadeOutTime;
            this.destroyAfter = destroyAfter;
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

                    if (target.Color == Color.Transparent)
                    {
                        target.IsRemove = true;
                    }
                }
            }
        }
    }
}