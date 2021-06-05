using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameLib
{
    public class SpriteBatchTiled: SpriteBatch
    {
        public SpriteBatchTiled(GraphicsDevice graphicsDevice) : base(graphicsDevice) { }

        public void DrawTiledBackground(Texture2D texture, int positionX, int positionY, int sizeOriginX, int sizeOriginY, Color color)
        {
            Rectangle nextTexture = new Rectangle(0, 0, sizeOriginX, sizeOriginY);
            int countXTexture = positionX % sizeOriginX == 0 ? positionX / sizeOriginX
                : positionX / sizeOriginX + 1;
            int countYTexture = positionY % sizeOriginY == 0 ? positionY / sizeOriginY
                : positionY / sizeOriginY + 1;

            for (int x = 0; x < countXTexture; x++)
            {
                for (int y = 0; y < countYTexture; y++)
                {
                    nextTexture.X = sizeOriginX * x;
                    nextTexture.Y = sizeOriginY * y;
                    base.Draw(texture, nextTexture, color);
                }

            }
        }
    }
}
