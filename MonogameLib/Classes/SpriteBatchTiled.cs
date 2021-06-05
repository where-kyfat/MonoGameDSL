using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameLib
{
    public class SpriteBatchTiled: SpriteBatch
    {
        public SpriteBatchTiled(GraphicsDevice graphicsDevice) : base(graphicsDevice) { }

        public void DrawTiledBackground(Texture2D texture, Vector2 position, Vector2 sizeOrigin, Color color)
        {
            Rectangle nextTexture = new Rectangle(0, 0, (int)sizeOrigin.X, (int)sizeOrigin.Y);
            int countXTexture = (int)position.X % (int)sizeOrigin.X == 0 ? (int)position.X / (int)sizeOrigin.X
                : (int)position.X / (int)sizeOrigin.X + 1;
            int countYTexture = (int)position.Y % (int)sizeOrigin.Y == 0 ? (int)position.Y / (int)sizeOrigin.Y
                : (int)position.Y / (int)sizeOrigin.Y + 1;

            for (int x = 0; x < countXTexture; x++)
            {
                for (int y = 0; y < countYTexture; y++)
                {
                    nextTexture.X = (int)sizeOrigin.X * x;
                    nextTexture.Y = (int)sizeOrigin.Y * y;
                    base.Draw(texture, nextTexture, color);
                }

            }
        }
    }
}
