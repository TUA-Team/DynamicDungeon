using DynamicDungeon.DungeonCollision.Shapes;
using DynamicDungeon.DungeonEntity.Interfaces;

namespace DynamicDungeon.DungeonCollision
{
    public class CircularHitbox : Hitbox
    {
        private readonly Circle _circle;
        internal override Shapes.Shapes HitboxShapes => _circle;
        public override bool CollideWithOther(IDungeonEntityUpdatable other)
        {
            return other.EntityHitbox.HitboxShapes.IntersectWith(other.EntityHitbox.HitboxShapes);
        }

        public CircularHitbox(int x, int y, int radius)
        {
            _circle = new Circle(radius);
            _circle.x = x;
            _circle.y = y;
        }
        
    }
}