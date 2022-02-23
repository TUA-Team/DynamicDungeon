using DynamicDungeon.DungeonEntity.Interfaces;

namespace DynamicDungeon.DungeonCollision
{
    public abstract class Hitbox
    {
        internal abstract Shapes.Shapes HitboxShapes { get; }

        public bool PhysicalCollision = false;

        public abstract bool CollideWithOther(IDungeonEntityUpdatable other);
    }
}