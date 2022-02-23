using DynamicDungeon.DungeonCollision;

namespace DynamicDungeon.DungeonEntity.Interfaces
{
    public interface ICollidableEntity
    {
        void ResolveCollisionWithOtherEntity(ICollidableEntity hitbox);
    }
}