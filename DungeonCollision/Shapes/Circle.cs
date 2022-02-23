using System;

namespace DynamicDungeon.DungeonCollision.Shapes
{
    public class Circle : Shapes
    {
        public int radius;

        public int Diameter => radius * 2; 
        
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override bool IntersectWith(Shapes other)
        {
            if (other is Circle circle2)
            {
                var dx = this.x - circle2.x;
                var dy = this.y - circle2.y;

                var distance = Math.Sqrt(dx * dx + dy * dy);
                if (distance < this.radius + circle2.radius)
                {
                    return true;
                }
            }
            if (other is Rectangle rectangle)
            {
                return CollisionUtils.IntersectRectangleCircle(this, rectangle);
            }

            return false;
        }

        public override Microsoft.Xna.Framework.Rectangle ToXNARectangle()
        {
            return new Microsoft.Xna.Framework.Rectangle(x - radius, y - radius, Diameter, Diameter);
        }
    }
}