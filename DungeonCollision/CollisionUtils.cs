using System;
using DynamicDungeon.DungeonCollision.Shapes;

namespace DynamicDungeon.DungeonCollision
{
    public class CollisionUtils
    {
        public static bool IntersectRectangleCircle(Circle circle, Rectangle rectangle)
        {
            float testX = circle.x;
            float testY = circle.y;

            if (circle.x < rectangle.x)
            {
                testX = rectangle.x;
            }
            else if (circle.x > rectangle.x + rectangle.width)
            {
                testX = rectangle.x + rectangle.width;
            }

            if (circle.y < rectangle.y)
            {
                testY = rectangle.y;
            }
            else if (circle.y > rectangle.y + rectangle.height)
            {
                testY = rectangle.y + rectangle.height;
            }

            float distX = circle.x - testX;
            float distY = circle.y - testY;

            float distance = (float)Math.Sqrt((distX * distX) + (distY * distY));
            if (distance <= circle.radius)
            {
                return true;
            }

            return false;
        }
    }
}