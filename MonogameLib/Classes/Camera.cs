using Microsoft.Xna.Framework;

namespace MonogameLib.Classes
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Vector2 target, Vector2 middlePoint, Vector2 backgroundSize)
        {
            float cameraX = target.X;
            float cameraY = target.Y;
            if (/*target.X >= 0 && */target.X <= middlePoint.X)
            {
                cameraX = middlePoint.X;
            }
            if (/*target.Y >= 0 && */target.Y <= middlePoint.Y)
            {
                cameraY = middlePoint.Y;
            }
            if (backgroundSize.X - middlePoint.X <= target.X /*&& backgroundSize.X >= target.X*/)
            {
                cameraX = backgroundSize.X - middlePoint.X;
            }
            if (backgroundSize.Y - middlePoint.Y <= target.Y /*&& backgroundSize.Y >= target.Y*/)
            {
                cameraY = backgroundSize.Y - middlePoint.Y;
            }

            var position = Matrix.CreateTranslation(
              -cameraX,
              -cameraY,
              0);

            var offset = Matrix.CreateTranslation(middlePoint.X, middlePoint.Y, 0);

            Transform = position * offset;
        }
    }
}
