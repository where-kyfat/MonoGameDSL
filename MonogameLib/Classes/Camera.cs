using Microsoft.Xna.Framework;

namespace MonogameLib.Classes
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(int targetPosX, int targetPosY, int middlePointX, int middlePointY, int backgroundSizeX, int backgroundSizeY)
        {
            float cameraX = targetPosX;
            float cameraY = targetPosY;
            if (/*target.X >= 0 && */targetPosX <= middlePointX)
            {
                cameraX = middlePointX;
            }
            if (/*target.Y >= 0 && */targetPosY <= middlePointY)
            {
                cameraY = middlePointY;
            }
            if (backgroundSizeX - middlePointX <= targetPosX /*&& backgroundSize.X >= target.X*/)
            {
                cameraX = backgroundSizeX - middlePointX;
            }
            if (backgroundSizeY - middlePointY <= targetPosY /*&& backgroundSize.Y >= target.Y*/)
            {
                cameraY = backgroundSizeY - middlePointY;
            }

            var position = Matrix.CreateTranslation(
              -cameraX,
              -cameraY,
              0);

            var offset = Matrix.CreateTranslation(middlePointX, middlePointY, 0);

            Transform = position * offset;
        }
    }
}
