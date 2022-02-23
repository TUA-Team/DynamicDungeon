using System;

namespace DynamicDungeon.DungeonCollision.Shapes
{
    public class Rectangle : Shapes
    {
        public int width;
        public int height;


        public override bool IntersectWith(Shapes other)
        {
            if (other is Rectangle rectangle2)
            {
                if (this.x >= rectangle2.x + rectangle2.width || rectangle2.x >= this.x + this.width)
                {
                    return true;
                }
                if (this.y + height >= rectangle2.y || rectangle2.y + rectangle2.height >= this.y)
                {
                    return true;
                }
            }

            if (other is Circle circle)
            {
                return CollisionUtils.IntersectRectangleCircle(circle, this);
            }

            return false;
        }

        public override Microsoft.Xna.Framework.Rectangle ToXNARectangle()
        {
            return new Microsoft.Xna.Framework.Rectangle(x, y, width, height);
        }
    }
}